using API_Adoptame.DAL.Entities;
using API_Adoptame.Domain.Interfaces;
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

        [HttpGet, ActionName("Get")]
        [Route("Get")]//Aqui concateno la URL inicial: URL = api/countries/get
        public async Task<ActionResult<IEnumerable<AdoptionDetail>>> GetAdoptionDetailAsync()
        {
            var adoptionDetail = await _adoptionDetailService.GetAdoptionDetailAsync();

            if (adoptionDetail == null || !adoptionDetail.Any()) 
            {
                return NotFound();            
                
            }

            return Ok(adoptionDetail); 
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateAdoptionDetailAsync(AdoptionDetail adoptionDetail) 
        {
            try
            {
                var createdAdoptionDetail = await _adoptionDetailService.CreateAdoptionDetailAsync(adoptionDetail);
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
    }
}
