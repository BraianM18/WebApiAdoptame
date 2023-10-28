using System.ComponentModel.DataAnnotations;

namespace API_Adoptame.DAL.Entities
{
    public class AuditBase
    {
        [Key] //DataAnnotation me sriven para definir que esta propiedad ID es un PK
        [Required] //Para campos obligatorios, o sea que deben tener valor (no permite nulls)
        public virtual Guid Id { get; set; } //Sera la PK de todas las tablas de mi BD
        public virtual DateTime? CreateDate { get; set; } //Campos nulleables, notacion elvis (?) me permite guardar nullos
        public virtual DateTime? ModifiedDate { get; set; }// Campos nulleable 
    }
}
