using API_Adoptame.DAL.Entities;

namespace API_Adoptame.Domain.Interfaces
{
    public interface IPetService
    {

        Task<Pet> CreatePetsAsync(Pet pet);

        
        Task<IEnumerable<Pet>> GetPetsByFundationsIdAsync(Guid fundationId);


        Task<IEnumerable<Pet>> GetPetsAsync();


        Task<Pet> GetPetsByIdAsync(Guid id);


        Task<Pet> GetPetsByNameAsync(String name);


        Task<Pet> EditPetsAsync(Pet pet);


        Task<Pet> DeletePetsAsync(Guid id);
    }
}
