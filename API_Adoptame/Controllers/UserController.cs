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


    }
    
}
