using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Concecionaria.Entity
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        [MaxLength(16)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        public byte[] PasswordHash { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        public byte[] PasswordSalt { get; set; }
        public Role Role { get; set; }
    }
}
