using API_Adoptame.DAL;
using API_Adoptame.DAL.Entities;
using API_Adoptame.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Adoptame.Domain.Services
{
    public class FundationService : IFundationService
    {
        public readonly DataBaseContext _context;
        public FundationService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Fundation>> GetFundationAsync()
        {
           
            var fundations = await _context.Fundations.ToListAsync();

            return fundations;
         
        }

        public async Task<Fundation> CreateFundationAsync(Fundation fundation)
        {
            try
            {
                fundation.Id = Guid.NewGuid(); 
                fundation.CreateDate = DateTime.Now;

               
                _context.Fundations.Add(fundation);
                await _context.SaveChangesAsync();

                return fundation;
            }
            catch (DbUpdateException dbUpdateException)
            {
               
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

    }
}
