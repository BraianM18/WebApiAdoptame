using API_Adoptame.DAL.Entities;
using API_Adoptame.Domain.Interfaces;
using API_Adoptame.Domain.Services;
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





        /*CREATE*/

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





        /*GET ALL*/

        [HttpGet, ActionName("GetAll")]
        [Route("GetAll")]//Aqui concateno la URL inicial: URL = api/pet/get
        public async Task<ActionResult<IEnumerable<Fundation>>> GetFundationsAsync()
        {
            var fundation = await _fundationService.GetFundationsAsync();

            if (fundation == null || !fundation.Any())
            {
                return NotFound();

            }

            return Ok(fundation);
        }

        //GET FUNDATIONSWITHPETS

        [HttpGet, ActionName("GetAllFundationsWithPets")]
        [Route("GetAllFundationsWithPets")] // URL = api/fundation/GetAllFundationsWithPets
        public async Task<ActionResult<IEnumerable<Fundation>>> GetAllFundationsWithPetsAsync()
        {
            var fundationsWithPets = await _fundationService.GetAllFundationsWithPetsAsync();

            if (fundationsWithPets == null || !fundationsWithPets.Any())
            {
                return NotFound();
            }

            return Ok(fundationsWithPets);
        }





        /*GET BY ID*/

        [HttpGet, ActionName("GetById")]
        [Route("GetById/{id}")]//Aqui concateno la URL inicial: URL = api/pet/get
        public async Task<ActionResult<IEnumerable<Fundation>>> GetFundationsByIdAsync(Guid id)
        {
            if (id == null)
            {
                return BadRequest("ID es requerido!");
            }


            var fundation = await _fundationService.GetFundationsByIdAsync(id);

            if (fundation == null)
            {
                return NotFound();

            }

            return Ok(fundation);
        }




        /*GET BY NAME*/

        [HttpGet, ActionName("GetByName")]
        [Route("GetByName/{name}")]//Aqui concateno la URL inicial: URL = api/pet/get
        public async Task<ActionResult<IEnumerable<Fundation>>> GetFundationsByNameAsync(String name)
        {
            if (name == null)
            {
                return BadRequest("El nombre es requerido!");
            }


            var fundation = await _fundationService.GetFundationsByNameAsync(name);

            if (fundation == null)
            {
                return NotFound();

            }

            return Ok(fundation);
        }




        /*UPDATE*/

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult> EditFundationsAsync(Fundation fundation)
        {
            try
            {
                var editedFundation = await _fundationService.EditFundationsAsync(fundation);
                if (editedFundation == null)
                {
                    return NotFound();// = 404 Http Status Code

                }

                return Ok(editedFundation);//Retorne un 200 y el objeto Detalle de adopcion
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("{0} ya existe", fundation.Name));
                }

                return Conflict(ex.Message);
            }
        }





        /*DELETE*/

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Fundation>> DeleteFundationsAsync(Guid id)
        {

            if (id == null) return BadRequest("El ID es requerido!");

            var deletedFundation = await _fundationService.DeleteFundationsAsync(id);

            if (deletedFundation == null) return NotFound("Mascota no encontrada!");
            return Ok(deletedFundation);


        }





    }
}
