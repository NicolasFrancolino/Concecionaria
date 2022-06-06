using System.ComponentModel.DataAnnotations;
using Concecionaria.Validations;

namespace Concecionaria.Entity
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Marca { get; set; }
        [Required]
        public string? Modelo { get; set; }
        [Required]
        [TeslaCar(2009)]
        public int Año { get; set; }
        public double Importe { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaBaja { get; set; }
    }
}
