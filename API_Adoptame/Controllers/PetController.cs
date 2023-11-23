using API_Adoptame.DAL.Entities;
using API_Adoptame.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Adoptame.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //esta es la primero parte de la URL de esta API: URL = api/adoptame
    public class PetController : Controller
    {
        private readonly IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]//Aqui concateno la URL inicial: URL = api/pet/get
        public async Task<ActionResult<IEnumerable<Pet>>> GetPetsAsync()
        {
            var pet = await _petService.GetPetsAsync();

            if (pet == null || !pet.Any())
            {
                return NotFound();

            }

            return Ok(pet);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreatePetsAsync(Pet pet)
        {
            try
            {
                var createdPet = await _petService.CreatePetsAsync(pet);
                if (createdPet == null)
                {
                    return NotFound();// = 404 Http Status Code

                }

                return Ok(createdPet);//Retorne un 200 y el objeto Detalle de adopcion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el detalle de adopción: {ex.Message}");

                // Puedes devolver un código de error 500 (Internal Server Error) con un mensaje descriptivo
                return StatusCode(500, "Se ha producido un error en el servidor al intentar crear el detalle de adopción.");
            }
        }



        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]//Aqui concateno la URL inicial: URL = api/pet/get
        public async Task<ActionResult<IEnumerable<Pet>>> GetPetByIdAsync(Guid id)
        {
            if(id == null) return BadRequest("ID es requerido!");
            

            var pet = await _petService.GetPetsByIdAsync(id);

            if (pet == null)
            {
                return NotFound();

            }

            return Ok(pet);
        }


    }
}
