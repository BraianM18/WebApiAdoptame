using API_Adoptame.DAL.Entities;
using API_Adoptame.DAL;
using Microsoft.EntityFrameworkCore;
using API_Adoptame.Domain.Interfaces;

namespace API_Adoptame.Domain.Services
{
    public class AdoptionDetailService : IAdoptionDetailService
    {
        public readonly DataBaseContext _context;
        public AdoptionDetailService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AdoptionDetail>> GetAdoptionDetailsAsync()
        {

            var adoptionDetail = await _context.AdoptionDetails.ToListAsync();

            return adoptionDetail;

        }

        public async Task<AdoptionDetail> CreateAdoptionDetailsAsync(AdoptionDetail adoptionDetail)
        {
            try
            {
                adoptionDetail.IDadoptiondetail = Guid.NewGuid(); //asi se asigna automaticamente un ID a un nuevo registro
                adoptionDetail.CreateDate = DateTime.Now;//lo mismo aqui con fecha de creacion


                _context.AdoptionDetails.Add(adoptionDetail);//Aqui estoy creando el objeto AdoptionDetail en el contexto de mi BD
                await _context.SaveChangesAsync();//Aqui ya estoy yendo a la BD para hacer el INSERT en la tabla

                return adoptionDetail;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }


    }
}
