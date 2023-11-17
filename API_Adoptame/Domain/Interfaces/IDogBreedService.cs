using API_Adoptame.DAL.Entities;

namespace API_Adoptame.Domain.Interfaces
{
    public interface IDogBreedService
    {
        Task<IEnumerable<DogBreed>> GetDogBreedAsync();
        Task<DogBreed> CreateDogBreedAsync(DogBreed dogBreed);
    }
}
