using System.ComponentModel.DataAnnotations;

namespace API_Adoptame.DAL.Entities
{
    public class DogBreed : AuditBase
    {
        [Display(Name = "Raza de Perro")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")] //el 0 hace referencia a País
        public string Name { get; set; }//varchar(50)--> MaxLength
    }
}
