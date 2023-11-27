using API_Adoptame.DAL.Entities;
using API_Adoptame.DAL;
using Microsoft.EntityFrameworkCore;
using API_Adoptame.Domain.Interfaces;

namespace API_Adoptame.Domain.Services
{
    public class AdoptionDetailService : IAdoptionDetailService
    {


        public readonly DataBaseContext _context;


        public AdoptionDetailService(DataBaseContext context)
        {
            _context = context;
        }



        /*CREATE*/

        public async Task<AdoptionDetail> CreateAdoptionDetailsAsync(AdoptionDetail adoptionDetail)
        {
            try
            {
                adoptionDetail.IDadoptiondetail = Guid.NewGuid(); //asi se asigna automaticamente un ID a un nuevo registro
                adoptionDetail.CreateDate = DateTime.Now;//lo mismo aqui con fecha de creacion


                _context.AdoptionDetails.Add(adoptionDetail);//Aqui estoy creando el objeto AdoptionDetail en el contexto de mi BD
                await _context.SaveChangesAsync();//Aqui ya estoy yendo a la BD para hacer el INSERT en la tabla

                return adoptionDetail;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }


        /*GET ALL*/

        public async Task<IEnumerable<AdoptionDetail>> GetAdoptionDetailsAsync()
        {
            var adoptionDetails = await _context.AdoptionDetails
                .Include(a => a.Pet) // Incluye la propiedad de navegación Pet
                .ToListAsync();

            return adoptionDetails;
        }


        /*GET BY ID*/

        public async Task<AdoptionDetail> GetAdoptionDetailsByIdAsync(Guid id)
        {
            return await _context.AdoptionDetails
                .Include(a => a.Pet) // Incluye la propiedad de navegación Pet
                .FirstOrDefaultAsync(a => a.IDadoptiondetail == id);
        }


        /*UPDATE*/

        public async Task<AdoptionDetail> EditAdoptionDetailsAsync(AdoptionDetail adoptiondetail)
        {
            try
            {

                adoptiondetail.ModifiedDate = DateTime.Now;

                _context.AdoptionDetails.Update(adoptiondetail);//Este metodo me sirve para actualizar un objeto
                await _context.SaveChangesAsync();

                return adoptiondetail;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }


        /*DELETE*/

        public async Task<AdoptionDetail> DeleteAdoptionDetailsAsync(Guid id)
        {
            try
            {
                var adoptiondetail = await _context.AdoptionDetails.FirstOrDefaultAsync(c => c.IDadoptiondetail == id);

                if (adoptiondetail == null) return null;


                _context.AdoptionDetails.Remove(adoptiondetail);

                await _context.SaveChangesAsync();

                return adoptiondetail;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

    }
}
