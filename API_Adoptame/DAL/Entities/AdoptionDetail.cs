using System.ComponentModel.DataAnnotations;

namespace API_Adoptame.DAL.Entities
{
    public class AdoptionDetail : AuditBase
    {

        [Display(Name = "ID")] 
        public Guid Id { get; set; }



        [Display(Name = "Fecha De Adopción")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        public DateTime? AdoptionDate { get; set; }



        [Display(Name = "Fecha De Ingreso")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime AdmissionDate { get; set; }



        [Display(Name = "Estado De Adopción")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string AdoptionStatus { get; set; }
        
    }
}
