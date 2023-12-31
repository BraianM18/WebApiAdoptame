﻿using API_Adoptame.DAL.Entities;

namespace API_Adoptame.Domain.Interfaces
{
    public interface IAdoptionDetailService
    {


        Task<IEnumerable<AdoptionDetail>> GetAdoptionDetailsAsync();


        Task<AdoptionDetail> GetAdoptionDetailsByIdAsync(Guid id);


        Task<AdoptionDetail> EditAdoptionDetailsAsync(AdoptionDetail adoptiondetail);


        Task<AdoptionDetail> DeleteAdoptionDetailsAsync(Guid id);

    
    }
}
