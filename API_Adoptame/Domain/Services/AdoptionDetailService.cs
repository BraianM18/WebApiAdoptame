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
        public async Task<IEnumerable<AdoptionDetail>> GetAdoptionDetailAsync()
        {

            var adoptionDetail = await _context.AdoptionDetails.ToListAsync();

            return adoptionDetail;

        }

        public async Task<AdoptionDetail> CreateAdoptionDetailAsync(AdoptionDetail adoptionDetail)
        {
            try
            {
                adoptionDetail.Id = Guid.NewGuid();
                adoptionDetail.CreateDate = DateTime.Now;


                _context.AdoptionDetails.Add(adoptionDetail);
                await _context.SaveChangesAsync();

                return adoptionDetail;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }


    }
}
