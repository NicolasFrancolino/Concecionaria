using Concecionaria.Entity;

namespace Concecionaria.Models.Users
{

    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }


    
    }
}
