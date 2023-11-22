using System.ComponentModel.DataAnnotations;

namespace API_Adoptame.DAL.Entities
{
    public class Fundation : AuditBase
    {
        [Display(Name = "ID de la fundación")]
        public Guid IdFundation { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }



        [Display(Name = "Correo Electrónico")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Email { get; set; }



        [Display(Name = "Dirección")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Address { get; set; }



        [Display(Name = "Teléfono")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int PhoneNumber { get; set; }


        //relacion con pets
        public List<Pet>? Pets { get; set; }
    }
}
