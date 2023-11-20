using System.ComponentModel.DataAnnotations;

namespace API_Adoptame.DAL.Entities
{
    public class User : AuditBase
    {
        [Display(Name = "ID de usuario")]
        public Guid UserId { get; set; }

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
