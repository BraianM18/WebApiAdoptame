using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? Race { get; set; }


        [Display(Name = "Edad")]
        public int? Age { get; set; }


        [Display(Name = "Tamaño")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Size { get; set; }


        //Relacion con Fundación y user

        [Display(Name = "ID de la fundación")]
        public Guid IdFundation { get; set; }

        //[ForeignKey(nameof(IdFundation))]
        public Fundation Fundation { get; set; }

        [Display(Name = "ID de usuario")]
        public Guid UserId { get; set; }

        //[ForeignKey(nameof(UserId))]
        public User User { get; set; }



    }
}
