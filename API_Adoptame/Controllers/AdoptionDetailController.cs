using API_Adoptame.DAL.Entities;
using API_Adoptame.Domain.Interfaces;
using API_Adoptame.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Adoptame.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //esta es la primero parte de la URL de esta API: URL = api/adoptame
    public class AdoptionDetailController : Controller
    {


        private readonly IAdoptionDetailService _adoptionDetailService;


        public AdoptionDetailController(IAdoptionDetailService adoptionDetailService)
        {
            _adoptionDetailService = adoptionDetailService;
        }





        /*CREATE*/


        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateAdoptionDetailAsync(AdoptionDetail adoptionDetail)
        {
            try
            {
                var createdAdoptionDetail = await _adoptionDetailService.CreateAdoptionDetailsAsync(adoptionDetail);
                if (createdAdoptionDetail == null)
                {
                    return NotFound();// = 404 Http Status Code

                }

                return Ok(createdAdoptionDetail);//Retorne un 200 y el objeto Detalle de adopcion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el detalle de adopción: {ex.Message}");

                // Puedes devolver un código de error 500 (Internal Server Error) con un mensaje descriptivo
                return StatusCode(500, "Se ha producido un error en el servidor al intentar crear el detalle de adopción.");
            }
        }





        /*GET ALL*/

        [HttpGet, ActionName("Get")]
        [Route("Get")]//Aqui concateno la URL inicial: URL = api/countries/get
        public async Task<ActionResult<IEnumerable<AdoptionDetail>>> GetAdoptionDetailAsync()
        {
            var adoptionDetail = await _adoptionDetailService.GetAdoptionDetailsAsync();

            if (adoptionDetail == null || !adoptionDetail.Any()) 
            {
                return NotFound();            
                
            }

            return Ok(adoptionDetail); 
        }





        /*GET BY ID*/

        [HttpGet, ActionName("GetById")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<AdoptionDetail>> GetAdoptionDetailsByIdAsync(Guid id)
        {
            if (id == null)
                return BadRequest("El Id es requerido.");

            var adoptionDetail = await _adoptionDetailService.GetAdoptionDetailsByIdAsync(id);
            if (adoptionDetail == null)
                return NotFound();

            // Puedes personalizar la forma en que devuelves la respuesta según tus necesidades.
            return Ok(new
            {
                adoptionDetail.IDadoptiondetail,
                adoptionDetail.AdoptionDate,
                adoptionDetail.AdmissionDate,
                adoptionDetail.AdoptionStatus,
                PetName = adoptionDetail.Pet?.Name // Accede al nombre de la mascota
            });
        }






        /*GET BY ADOPTION DATE*/

        [HttpGet, ActionName("GetByAdoptionDate")]
        [Route("GetByAdoptionDate/{AdoptionDate}")]
        public async Task<ActionResult<AdoptionDetail>> GetAdoptionDetailsByAdoptionDetailAsync(DateTime AdoptionDate)
        {
            if (AdoptionDate == null) return BadRequest("La Fecha de Adopción es requerido.");
            //una fecha puede ser null(?


            var adoptionDetail = await _adoptionDetailService.GetAdoptionDetailsByAdoptionDateAsync(AdoptionDate);
            if (adoptionDetail == null) return NotFound();


            return Ok(adoptionDetail);
        }





        /*UPDATE*/

        [HttpPut, ActionName("EditAdoptionDetail")]
        [Route("EditAdoptionDetail")]
        public async Task<ActionResult> EditAdoptionDetailsAsync(AdoptionDetail adoptiondetail)
        {
            try
            {
                var editedadoptiondetail = await _adoptionDetailService.EditAdoptionDetailsAsync(adoptiondetail);
                if (editedadoptiondetail == null)
                {
                    return NotFound();// = 404 Http Status Code

                }

                return Ok(editedadoptiondetail);//Retorne un 200 y el objeto Detalle de adopcion
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("{0} ya existe", adoptiondetail.IDadoptiondetail));
                }

                return Conflict(ex.Message);
            }
        }




        /*DELETE*/

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<AdoptionDetail>> DeleteAdoptionDetailsAsync(Guid id)
        {

            if (id == null) return BadRequest("El ID es requerido!");

            var deletedDetail = await _adoptionDetailService.DeleteAdoptionDetailsAsync(id);

            if (deletedDetail == null) return NotFound("Detalle de adopción no encontrado!");
            return Ok(deletedDetail);


        }


    }
}
