using System.ComponentModel.DataAnnotations;

namespace Concecionaria.Models.Users
{
    public class AuthenticateRequest
    {
        [Required(ErrorMessage = "Este valor es requerido")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        public string Password { get; set; }
    }
}
