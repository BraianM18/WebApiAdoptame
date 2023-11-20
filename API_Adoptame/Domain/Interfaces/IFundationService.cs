using API_Adoptame.DAL.Entities;

namespace API_Adoptame.Domain.Interfaces
{
    public interface IFundationService
    {
        Task<IEnumerable<Fundation>> GetFundationAsync();
        Task<Fundation> CreateFundationAsync(Fundation fundation);
    }
}
