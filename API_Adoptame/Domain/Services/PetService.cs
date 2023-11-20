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
        public async Task<IEnumerable<Pet>> GetPetAsync()
        {

            var pets = await _context.Pets.ToListAsync();

            return pets;

        }

        public async Task<Pet> CreatePetAsync(Pet pet)
        {
            try
            {
                pet.Id = Guid.NewGuid();
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

    }
}
