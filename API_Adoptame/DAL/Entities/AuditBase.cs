using System.ComponentModel.DataAnnotations;

namespace API_Adoptame.DAL.Entities
{
    public class AuditBase
    {
        public virtual DateTime? CreateDate { get; set; } //Campos nulleables, notacion elvis (?) me permite guardar nullos
        public virtual DateTime? ModifiedDate { get; set; }// Campos nulleable 

    }
}
