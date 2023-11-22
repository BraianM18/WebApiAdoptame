using System.ComponentModel.DataAnnotations;

namespace API_Adoptame.DAL.Entities
{
    public class User : AuditBase
    {

        [Key] //DataAnnotation me sriven para definir que esta propiedad ID es un PK
        [Required] //Para campos obligatorios, o sea que deben tener valor (no permite nulls)
        public virtual Guid IDuser { get; set; } //Sera la PK de todas las tablas de mi BD


        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }



        [Display(Name = "Correo Electrónico")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Email { get; set; }



        [Display(Name = "Número De Teléfono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int PhoneNumber { get; set; }



        [Display(Name = "Contraseña")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Password { get; set; }
    }
}
