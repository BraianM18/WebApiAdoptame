using System.ComponentModel.DataAnnotations;

namespace API_Adoptame.DAL.Entities
{
    
    public class Country : AuditBase
    {
        [Display(Name = "Raza de Perro")]// Para yo pintar el nombre bien bonito ene l FrontEnd. significa mostrar.
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]//Longitud de caracteres máxima que esta propiedad me permiete tener, ejem varchar(50)
        [Required (ErrorMessage = "El campo {0} es obligatorio")] //el 0 hace referencia a País
        public string Name { get; set; }//varchar(50)--> MaxLength
    }
}
