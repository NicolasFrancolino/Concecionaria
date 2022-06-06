using System.ComponentModel.DataAnnotations;
using Concecionaria.Entity;

namespace Concecionaria.Validations
{
    public class TeslaCarAttribute : ValidationAttribute
    {
        public int Año { get; }
        //por parametro entra el dato de referencia a validar que esta en el dataannotation
        public TeslaCarAttribute(int year)
        {
            Año = year;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //capturo el objeto a validar
            var auto = (Vehiculo)validationContext.ObjectInstance;
            //capturo el valor a validar
            var añoFabricacion = ((int)value!);

            if (auto.Marca == "Tesla" && añoFabricacion < Año)
            {
                return new ValidationResult($"Los autos Tesla no puede ser mas viejo que {Año}.");
            }

            return ValidationResult.Success;
        }
    }
}
