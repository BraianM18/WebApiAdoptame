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






        /*CREATE*/

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





        /*GET ALL*/

        public async Task<IEnumerable<Pet>> GetPetsAsync()
        {

            return await _context.Pets.ToListAsync(); 

        }


        


        /*GET BY ID*/

        public async Task<Pet> GetPetsByIdAsync(Guid id)
        {
            return await _context.Pets.FirstOrDefaultAsync(p => p.IDpet == id);
        }


        /*GET BY NAME*/

        public async Task<Pet> GetPetsByNameAsync(String name)
        {
            return await _context.Pets.FirstOrDefaultAsync(c => c.Name == name); //es un método propio del db context (db set)

        }


        /*UPDATE*/

        public async Task<Pet> EditPetsAsync(Pet pet)
        {
            try
            {

                pet.ModifiedDate = DateTime.Now;

                _context.Pets.Update(pet);//Este metodo me sirve para actualizar un objeto
                await _context.SaveChangesAsync();

                return pet;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }


        /*DELETE*/

        public async Task<Pet> DeletePetsAsync(Guid id)
        {
            try
            {
                var pet = await _context.Pets.FirstOrDefaultAsync(c => c.IDpet == id);

                if (pet == null) return null;


                _context.Pets.Remove(pet);

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
