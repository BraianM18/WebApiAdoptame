using API_Adoptame.DAL.Entities;

namespace API_Adoptame.Domain.Interfaces
{
    public interface IPetService
    {

        Task<Pet> CreatePetsAsync(Pet pet);

        
        Task<IEnumerable<Pet>> GetPetsByFundationsIdAsync(Guid fundationId);


        //Task<Pet> CreatePetsAsync(Pet pet, Guid fundationId, Guid userId);


        //Task<Pet> EditPetsAsync(Pet pet, Guid fundationId);

        //prueba*/
        Task<IEnumerable<Pet>> GetPetsAsync();


        Task<Pet> GetPetsByIdAsync(Guid id);


        Task<Pet> GetPetsByNameAsync(String name);


        Task<Pet> EditPetsAsync(Pet pet);


        Task<Pet> DeletePetsAsync(Guid id);
    }
}
