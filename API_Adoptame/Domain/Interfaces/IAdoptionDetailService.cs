using API_Adoptame.DAL.Entities;

namespace API_Adoptame.Domain.Interfaces
{
    public interface IAdoptionDetailService
    {
        Task<IEnumerable<AdoptionDetail>> GetAdoptionDetailsAsync();
        Task<AdoptionDetail> CreateAdoptionDetailsAsync(AdoptionDetail adoptionDetail);

        Task<AdoptionDetail> GetAdoptionDetailByAsync(Guid id);
        Task GetAdoptionDetailByIdAsync(Guid id);
    }
}
