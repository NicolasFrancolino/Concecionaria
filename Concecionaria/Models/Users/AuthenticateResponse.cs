using Concecionaria.Entity;

namespace Concecionaria.Models.Users
{

    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }


        //public AuthenticateResponse(Usuario user, string token)
        //{
        //    Id = user.Id;
        //    FirstName = user.FirstName;
        //    LastName = user.LastName;
        //    Username = user.Username;
        //    Email = user.Email;
        //    Role = user.Role;
        //    Token = token;
        //}
    }
}
