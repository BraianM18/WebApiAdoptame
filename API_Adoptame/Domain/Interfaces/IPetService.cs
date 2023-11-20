using API_Adoptame.DAL.Entities;

namespace API_Adoptame.Domain.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> GetPetAsync();
        Task<Pet> CreatePetAsync(Pet pet);
    }
}
