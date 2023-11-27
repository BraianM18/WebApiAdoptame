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

        public async Task<IEnumerable<Pet>> GetPetsByFundationsIdAsync(Guid fundationId)
        {
 

            return await _context.Pets.Where(f => f.FundationID == fundationId).ToListAsync();
            
        }
        //public async Task<Pet> CreatePetsAsync(Pet pet, Guid fundationId, Guid userId)
        //{


        //    try
        //    {
        //        pet.IDpet = Guid.NewGuid();
        //        pet.CreateDate = DateTime.Now;
        //        pet.FundationID = fundationId;
        //        pet.UserID = userId;
        //        pet.Fundation = await _context.Fundations.FirstOrDefaultAsync(f => f.IDfundation == fundationId);
        //        pet.User = await _context.Users.FirstOrDefaultAsync(u => u.IDuser == userId);

        //        pet.ModifiedDate = null;

        //        _context.Pets.Add(pet);

        //        await _context.SaveChangesAsync();

        //        return pet;
        //    }
        //    catch (DbUpdateException dbUpdateException)
        //    {

        //        throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
        //    }


        //}
        //public async Task<Pet> EditPetsAsync(Pet pet, Guid fundationId)
        //{


        //    try
        //    {

        //        pet.ModifiedDate = DateTime.Now;

        //        _context.Pets.Update(pet);//Este metodo me sirve para actualizar un objeto
        //        await _context.SaveChangesAsync();

        //        return pet;
        //    }
        //    catch (DbUpdateException dbUpdateException)
        //    {

        //        throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
        //    }


        //}*/



        /*CREATE*/

        public async Task<Pet> CreatePetsAsync(Pet pet)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    pet.IDpet = Guid.NewGuid();
                    pet.CreateDate = DateTime.Now;

                    // Configurar la relación con AdoptionDetail
                    var adoptionDetail = new AdoptionDetail
                    {
                        AdoptionDate = null,
                        AdmissionDate = DateTime.Now,
                        AdoptionStatus = "Disponible",
                        PetID = pet.IDpet // Configura la relación aquí usando la clave foránea
                    };

                    // Agregar la mascota al contexto
                    _context.Pets.Add(pet);

                    // Guardar cambios en la base de datos (aquí se crea la mascota)
                    await _context.SaveChangesAsync();

                    // Configurar la relación inversa
                    pet.AdoptionDetail = adoptionDetail;

                    // Guardar cambios en la base de datos (aquí se crea el AdoptionDetail)
                    await _context.SaveChangesAsync();

                    // Confirmar la transacción
                    transaction.Commit();

                    return pet;
                }
                catch (DbUpdateException dbUpdateException)
                {
                    // En caso de error, hacer rollback de la transacción
                    transaction.Rollback();
                    throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
                }
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
