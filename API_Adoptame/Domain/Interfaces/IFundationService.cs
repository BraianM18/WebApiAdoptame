using API_Adoptame.DAL.Entities;

namespace API_Adoptame.Domain.Interfaces
{
    public interface IFundationService
    {
        Task<IEnumerable<Fundation>> GetFundationsAsync();
        Task<Fundation> CreateFundationsAsync(Fundation fundation);

        Task<Fundation> GetFundationsByIdAsync(Guid id);

        Task<Fundation> GetFundationsByNameAsync(String name);

        Task<Fundation> EditFundationsAsync(Fundation fundation);
    }
}