using System.ComponentModel.DataAnnotations;

namespace API_Adoptame.DAL.Entities
{
    public class Pet : AuditBase
    {


        [Display(Name = "Nombre")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }


        [Display(Name = "Especie")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Kind { get; set; }


        [Display(Name = "Raza")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        public string Race { get; set; }


        [Display(Name = "Edad")]
        public int Age { get; set; }


        [Display(Name = "Tamaño")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Size { get; set; }


    }
}
