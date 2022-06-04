using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Concecionaria.Entity;
using Concecionaria.Models.Users;
using Concecionaria.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Concecionaria.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _uOW;
        private readonly IConfiguration _configuration;
        public UsuarioService(IUnitOfWork uow, IConfiguration configuration)
        {
            _uOW = uow;
            _configuration = configuration;
        }
        public string GetToken(AuthenticateResponse usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.NameId, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, usuario.Nombre),
                new Claim(ClaimTypes.Role, usuario.Role.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddMinutes(120),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials

            };
            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public AuthenticateResponse Login(string email, string password)
        {
            if (_uOW.UsuarioRepo.ExisteUsuario(email))
            {
                AuthenticateResponse response = new AuthenticateResponse();
                //traigo el usuario, por el email
                Usuario user = _uOW.UsuarioRepo.GetByEmail(email);
                //verifico si el password ingresado es el mismo del usuario en la DB
                if (!VerificarPassword(password, user.PasswordHash, user.PasswordSalt))
                {
                    return null;
                }
                //aca deberia mappear a un UserResponse
                response.Email = email;
                response.Nombre = user.Nombre;
                response.Id = user.Id;
                response.Role = user.Role;
                //Devuelvo la respuesta si esta todo bien
                return response;
            }
            return null;
        }

        private bool VerificarPassword(string pass, byte[] pHash, byte[] pSalt)
        {
            //hago una encriptacion con la key (psalt)
            var hMac = new HMACSHA512(pSalt);
            var hash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
            //comparo el pass de la DB con el que acabo de encriptar
            for (var i = 0; i < hash.Length; i++)
            {
                if (hash[i] != pHash[i]) return false;
            }

            return true;
        }

        private void CrearPassHash(string pass, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //creo una encriptacion
            var hMac = new HMACSHA512();
            //le asigno la llave de la encriptacion al passwordSalt
            passwordSalt = hMac.Key;
            //Encripto el pass y lo guardo en passwordHash
            passwordHash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));


        }

        public AuthenticateResponse Registrar(AuthenticateRequest user, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            CrearPassHash(password, out passwordHash, out passwordSalt);
            Usuario usuario = new Usuario();
            usuario.Nombre = user.Username;
            usuario.Email = user.Email;
            usuario.PasswordHash = passwordHash;
            usuario.PasswordSalt = passwordSalt;
            usuario.Role = Role.Admin;
            _uOW.UsuarioRepo.Insert(usuario);
            _uOW.Save();
            AuthenticateResponse response = new AuthenticateResponse();
            response.Email = usuario.Email;
            response.Nombre = usuario.Nombre;
            response.Id = usuario.Id;
            response.Role = usuario.Role;
            return response;
        }
    }
}
