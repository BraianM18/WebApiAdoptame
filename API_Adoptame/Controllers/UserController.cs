using API_Adoptame.DAL.Entities;
using API_Adoptame.Domain.Interfaces;
using API_Adoptame.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Adoptame.Controllers
{
        [ApiController]
        [Route("api/[controller]")] //esta es la primero parte de la URL de esta API: URL = api/adoptame
        public class UserController : Controller
        {


            private readonly IUserService _userService;


            public UserController(IUserService UserService)
            {
                _userService = UserService;
            }




            /*GET ALL*/

            [HttpGet, ActionName("Get")]
            [Route("Get")]//Aqui concateno la URL inicial: URL = api/pet/get
            public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
            {
                var user = await _userService.GetUsersAsync();

                if (user == null || !user.Any())
                {
                    return NotFound();

                }

                return Ok(user);
            }




            /*CREATE*/

            [HttpPost, ActionName("Create")]
            [Route("Create")]
            public async Task<ActionResult> CreateUsersAsync(User user)
            {
                try
                {
                    var createdUser = await _userService.CreateUsersAsync(user);
                    if (createdUser == null)
                    {
                        return NotFound();// = 404 Http Status Code

                    }

                    return Ok(createdUser);//Retorne un 200 y el objeto Detalle de adopcion
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al crear el usuario: {ex.Message}");

                    // Puedes devolver un código de error 500 (Internal Server Error) con un mensaje descriptivo
                    return StatusCode(500, "Se ha producido un error en el servidor al intentar crear el usuario.");
                }
            }




            /*GET BY ID*/

            [HttpGet, ActionName("GetById")]
            [Route("GetById/{id}")]
            public async Task<ActionResult<IEnumerable<User>>> GetUsersByIdAsync(Guid id)
            {
                if (id == null)
                {
                    return BadRequest("ID es requerido!");
                }


                var user = await _userService.GetUsersByIdAsync(id);

                if (user == null)
                {
                    return NotFound();

                }

                return Ok(user);
            }




            /*GET BY NAME*/

            [HttpGet, ActionName("GetByName")]
            [Route("GetByName/{name}")]//Aqui concateno la URL inicial: URL = api/pet/get
            public async Task<ActionResult<IEnumerable<User>>> GetUsersByNameAsync(String name)
            {
                if (name == null)
                {
                    return BadRequest("El nombre es requerido!");
                }


                var user = await _userService.GetUsersByNameAsync(name);

                if (user == null)
                {
                    return NotFound();

                }

                return Ok(user);
            }





            /*UPDATE*/

            [HttpPut, ActionName("EditUser")]
            [Route("EditUser")]
            public async Task<ActionResult> EditUsersAsync(User user)
            {
                try
                {
                    var editedUser = await _userService.EditUsersAsync(user);
                    if (editedUser == null)
                    {
                        return NotFound();// = 404 Http Status Code

                    }

                    return Ok(editedUser);//Retorne un 200 y el objeto Detalle de adopcion
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("duplicate"))
                    {
                        return Conflict(String.Format("{0} ya existe", user.Name));
                    }

                    return Conflict(ex.Message);
                }
            }





            /*DELETE*/

            [HttpDelete, ActionName("Delete")]
            [Route("Delete")]
            public async Task<ActionResult<User>> DeleteUsersAsync(Guid id)
            {

                if (id == null) return BadRequest("El ID es requerido!");

                var deletedUser = await _userService.DeleteUsersAsync(id);

                if (deletedUser == null) return NotFound("Usuario no encontrado!");
                return Ok(deletedUser);


            }


    }
    
}
