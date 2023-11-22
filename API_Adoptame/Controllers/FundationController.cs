using API_Adoptame.DAL.Entities;
using API_Adoptame.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Adoptame.Controllers
{
    public class FundationController : Controller
    {
        private readonly IFundationService _fundationService;
        public FundationController(IFundationService fundationService)
        {
            _fundationService = fundationService;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]//Aqui concateno la URL inicial: URL = api/pet/get
        public async Task<ActionResult<IEnumerable<Fundation>>> GetFundationsAsync()
        {
            var fundation = await _fundationService.GetFundationsAsync();

            if (fundation == null || !fundation.Any())
            {
                return NotFound();

            }

            return Ok(fundation);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateFundationsAsync(Fundation fundation)
        {
            try
            {
                var createdFundation = await _fundationService.CreateFundationsAsync(fundation);
                if (createdFundation == null)
                {
                    return NotFound();// = 404 Http Status Code

                }

                return Ok(createdFundation);//Retorne un 200 y el objeto Detalle de adopcion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la fundación: {ex.Message}");

                // Puedes devolver un código de error 500 (Internal Server Error) con un mensaje descriptivo
                return StatusCode(500, "Se ha producido un error en el servidor al intentar crear la fundación.");
            }
        }
    }
}
