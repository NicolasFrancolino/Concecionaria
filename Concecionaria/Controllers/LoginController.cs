using Concecionaria.Models.Users;
using Concecionaria.Services;
using Concecionaria.UnitOfWork;
using Concecionaria.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Concecionaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUnitOfWork _uow;

        public LoginController(IUsuarioService usuarioService, IUnitOfWork uow)
        {
            _usuarioService = usuarioService;
            _uow = uow;
        }
        [HttpPost]
        public ActionResult Login([FromBody] AuthenticateRequest req)
        {
            var response = _usuarioService.Login(req.Email, req.Password);
            if (response == null)
            {
                return Unauthorized();
            }
            var token = _usuarioService.GetToken(response);
            return Ok(new
            {
                token = token,
                usuario = response
            });
        }
        [HttpPost("Registro")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public ActionResult RegistrarUsuario([FromBody] AuthenticateRequest user)
        {
            if (_uow.UsuarioRepo.ExisteUsuario(user.Email.ToLower()))
            {
                return BadRequest("Ya existe un cuenta asociada a ese Email");
            }
            AuthenticateResponse res = _usuarioService.Registrar(user, user.Password);
            return Ok(res);
        }
    }
}
