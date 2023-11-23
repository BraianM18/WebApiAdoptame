using API_Adoptame.DAL.Entities;

namespace API_Adoptame.Domain.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> GetPetsAsync();
        Task<Pet> CreatePetsAsync(Pet pet);

        Task<Pet> GetPetsByIdAsync(Guid id);
    }
}
