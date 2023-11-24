using API_Adoptame.DAL.Entities;
using API_Adoptame.Domain.Interfaces;
using API_Adoptame.Domain.Services;
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




        /*CREATE*/

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





        /*GET ALL*/

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





        /*GET BY ID*/

        [HttpGet, ActionName("GetById")]
        [Route("GetById/{id}")]//Aqui concateno la URL inicial: URL = api/pet/get
        public async Task<ActionResult<IEnumerable<Pet>>> GetPetsByIdAsync(Guid id)
        {
            if (id == null)
            {
                return BadRequest("ID es requerido!");
            } 
            

            var pet = await _petService.GetPetsByIdAsync(id);

            if (pet == null)
            {
                return NotFound();

            }

            return Ok(pet);
        }





        /*GET BY NAME*/

        [HttpGet, ActionName("GetByName")]
        [Route("GetByName/{name}")]//Aqui concateno la URL inicial: URL = api/pet/get
        public async Task<ActionResult<IEnumerable<Pet>>> GetPetsByNameAsync(String name)
        {
            if (name == null)
            {
                return BadRequest("El nombre es requerido!");
            }


            var pet = await _petService.GetPetsByNameAsync(name);

            if (pet == null)
            {
                return NotFound();

            }

            return Ok(pet);
        }





        /*UPDATE*/

        [HttpPut, ActionName("EditPet")]
        [Route("EditPet")]
        public async Task<ActionResult> EditPetsAsync(Pet pet)
        {
            try
            {
                var editedPet = await _petService.EditPetsAsync(pet);
                if (editedPet == null)
                {
                    return NotFound();// = 404 Http Status Code

                }

                return Ok(editedPet);//Retorne un 200 y el objeto Detalle de adopcion
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("{0} ya existe", pet.Name));
                }

                return Conflict(ex.Message);
            }
        }





        /*DELETE*/

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Pet>> DeletePetsAsync(Guid id)
        {

            if (id == null) return BadRequest("El ID es requerido!");
                
            var deletedPet = await _petService.DeletePetsAsync(id);

            if (deletedPet == null) return NotFound("Mascota no encontrada!");
            return Ok(deletedPet);
            
            
        }




    }
}
