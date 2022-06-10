using System.ComponentModel.DataAnnotations;

namespace Concecionaria.Entity
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        public double Importe { get; set; }
        public double Descuento { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public int VehiculoId { get; set; }
        public Vehiculo? Vehiculo { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
