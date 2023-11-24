using API_Adoptame.DAL.Entities;

namespace API_Adoptame.Domain.Interfaces
{
    public interface IAdoptionDetailService
    {


        Task<IEnumerable<AdoptionDetail>> GetAdoptionDetailsAsync();


        Task<AdoptionDetail> CreateAdoptionDetailsAsync(AdoptionDetail adoptionDetail);


        Task<AdoptionDetail> GetAdoptionDetailsByIdAsync(Guid id);


        Task<AdoptionDetail> GetAdoptionDetailsByAdoptionDateAsync(DateTime AdoptionDate);


        Task<AdoptionDetail> EditAdoptionDetailsAsync(AdoptionDetail adoptiondetail);


        Task<AdoptionDetail> DeleteAdoptionDetailsAsync(Guid id);

    
    }
}
