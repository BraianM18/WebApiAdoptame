using System.ComponentModel.DataAnnotations;

namespace API_Adoptame.DAL.Entities
{
    public class Pet : AuditBase
    {

        [Key] //DataAnnotation me sriven para definir que esta propiedad ID es un PK
        [Required] //Para campos obligatorios, o sea que deben tener valor (no permite nulls)
        public virtual Guid IDpet { get; set; } //Sera la PK de todas las tablas de mi BD


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

        public Fundation? Fundation { get; set; }

        [Display(Name = "ID de la Fundación")]
        public Guid FundationID { get; set; } //FK



        public User? User { get; set; }

        [Display(Name = "ID de el usuario")]
        public Guid UserID { get; set; } //FK


        [Display(Name = "Detalle de adopcion")]
        public ICollection<AdoptionDetail>? AdoptionDetails { get; set; }
    }
}
