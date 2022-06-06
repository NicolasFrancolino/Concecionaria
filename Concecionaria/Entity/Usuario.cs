using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Concecionaria.Entity
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(16)]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Role Role { get; set; }
    }
}
