using API_Adoptame.DAL.Entities;
using API_Adoptame.DAL;
using Microsoft.EntityFrameworkCore;
using API_Adoptame.Domain.Interfaces;

namespace API_Adoptame.Domain.Services
{
    public class PetService : IPetService
    {
        public readonly DataBaseContext _context;
        public PetService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Pet>> GetPetsAsync()
        {

            return await _context.Pets.ToListAsync(); 

        }

        public async Task<Pet> CreatePetsAsync(Pet pet)
        {
            try
            {
                pet.IDpet = Guid.NewGuid();
                pet.CreateDate = DateTime.Now;


                _context.Pets.Add(pet);
                await _context.SaveChangesAsync();

                return pet;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Pet> GetPetsByIdAsync(Guid id)
        {
            return await _context.Pets.FirstOrDefaultAsync(p => p.IDpet == id);
        }
    }
}
