﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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


        
        public Guid? PetID { get; set; } // FK

        [JsonIgnore]
        public Pet Pet { get; set; }
    }
}
