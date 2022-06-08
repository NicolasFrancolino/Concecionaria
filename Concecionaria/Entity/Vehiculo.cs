using System.ComponentModel.DataAnnotations;
using Concecionaria.Validations;

namespace Concecionaria.Entity
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        public string? Marca { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        public string? Modelo { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        [TeslaCar(2009)]
        public int Año { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        public double Importe { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Este valor es requerido")]
        public DateTime FechaBaja { get; set; }
    }
}
