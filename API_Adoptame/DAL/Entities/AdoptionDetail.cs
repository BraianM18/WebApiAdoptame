using System.ComponentModel.DataAnnotations;

namespace API_Adoptame.DAL.Entities
{
    public class AdoptionDetail : AuditBase
    {
        [Key] //DataAnnotation me sriven para definir que esta propiedad ID es un PK
        [Required] //Para campos obligatorios, o sea que deben tener valor (no permite nulls)
        public virtual Guid IDadoptiondetail { get; set; } //Sera la PK de todas las tablas de mi BD

        [Display(Name = "Fecha De Adopción")]
        
        public DateTime? AdoptionDate { get; set; }



        [Display(Name = "Fecha De Ingreso")]
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime AdmissionDate { get; set; }



        [Display(Name = "Estado De Adopción")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string AdoptionStatus { get; set; }


        public Pet? Pet { get; set; }
        [Display(Name = "ID de la Mascota")]
        public Guid PetID { get; set; } //FK  
    }
}
