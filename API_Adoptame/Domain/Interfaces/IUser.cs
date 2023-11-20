using API_Adoptame.DAL.Entities;

namespace API_Adoptame.Domain.Interfaces
{
    public interface IUser
    {
        Task<IEnumerable<Pet>> GetPetAsync();
        Task<Pet> CreatePetAsync(Pet pet);
    }
}
