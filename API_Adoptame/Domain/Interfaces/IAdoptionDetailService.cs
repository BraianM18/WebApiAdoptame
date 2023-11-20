using API_Adoptame.DAL.Entities;

namespace API_Adoptame.Domain.Interfaces
{
    public interface IAdoptionDetailService
    {
        Task<IEnumerable<AdoptionDetail>> GetAdoptionDetailAsync();
        Task<AdoptionDetail> CreateAdoptionDetailAsync(AdoptionDetail adoptionDetail);
    }
}
