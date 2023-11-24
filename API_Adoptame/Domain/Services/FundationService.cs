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





        /*CREATE*/

        public async Task<Fundation> CreateFundationsAsync(Fundation fundation)
        {
            try
            {
                fundation.IDfundation = Guid.NewGuid();
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





        /*GET ALL*/

        public async Task<IEnumerable<Fundation>> GetFundationsAsync()
        {

            var fundations = await _context.Fundations.ToListAsync();

            return fundations;

        }




        
        /*GET BY ID*/

        public async Task<Fundation> GetFundationsByIdAsync(Guid id)
        {
            return await _context.Fundations.FirstOrDefaultAsync(f => f.IDfundation == id);
        }




        /*GET BY NAME*/

        public async Task<Fundation> GetFundationsByNameAsync(String name)
        {
            return await _context.Fundations.FirstOrDefaultAsync(f => f.Name == name);
        }




        /*UPDATE*/

        public async Task<Fundation> EditFundationsAsync(Fundation fundation)
        {
            try
            {
                
                fundation.ModifiedDate = DateTime.Now;


                _context.Fundations.Update(fundation);//Este metodo me sirve para actualizar un objeto
                await _context.SaveChangesAsync();

                return fundation;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }




        /*DELETE*/

        public async Task<Fundation> DeleteFundationsAsync(Guid id)
        {
            try
            {
                var fundation = await _context.Fundations.FirstOrDefaultAsync(c => c.IDfundation == id);

                if (fundation == null) return null;


                _context.Fundations.Remove(fundation);

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
