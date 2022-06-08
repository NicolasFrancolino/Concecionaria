using System.ComponentModel.DataAnnotations;

namespace Concecionaria.Entity
{
    public class Cliente
    {
        /// <summary>
        /// Id Identity, primary KEY
        /// </summary>
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        public string Direccion { get; set; }
    }
}
