using API_Adoptame.DAL.Entities;
using API_Adoptame.Domain.Interfaces;
using API_Adoptame.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Adoptame.Controllers
{
    //antes de la clase debo definir los dataanotatios (post)
    [ApiController]
    [Route("api/[controller]")]//Esta es la primera parte de la URL de esta API: URL= api/countries (countries es el nombre del controlador)

    //Este controller siempre lleva la herencia de la clase controller para poder proeveerme a mi unos metodos para poder 
    //exponerme hacia swager o un frontend
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
            //Lo que le estoy pasando del readonly se lo paso a este campo

        }

        //En un controlador los metodos cambian de nombre y realmente se llaman ACCIONES(ACTIONS)
        //Si es una API, de denomina ENDPOINT.
        //Todo ENDPOINT retorna un ActionResult, significa que retorna el resultado de una ACCIÓN.
        //la acción en este caso es obtener una lista de países.
        //esta es la misma notacion que tenemos en la interfaz y el servicio country, pero con action result
        //ya que es el resultado de la accion en este caso el retorno de la lista de los paises

        [HttpGet]
        [ActionName("Get")]
        [Route("Get")] //Aqui concateno la URL inicial: URL = api/countries/get
        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()//trae informacion
        {
            //esto me trae =      depen del ser  -  metodo
            var countries = await _countryService.GetCountriesAsync();
            //Aqui estoy yendo a mi capa de Domain para traer la lista de paises
            //va a la interfaz y como esta ya tiene la implementacion luego va al servicio y este lista los paises
            //de la BD y luego los retorna, luego va a la interfaz y retorna esa misma lista de Paises
            //y la interfaz le devuelve al controlador esa misma lista de paises en esta linea.

            // si countries esta vacion o si hay algun elemento(any)
            // El metodo !Any() significa si no hay absolutamnete nada
            if (countries == null || !countries.Any())
            {
                return NotFound();//NotFound = 404 Http Status Code
            }

            return Ok(countries); //Ok = 200 Http Status Code
        }

        [HttpPost]//esto es como el titulo que se muestra
        [ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateCountryAsync(Country country) //el parametro es country por que alli tengo los atributos osea el name
        {
            try
            {
                //                         este es mi servicio
                var createdCountry = await _countryService.CreateCountryAsync(country);
                if (createdCountry == null )
                {
                    return NotFound();//NotFound = 404 Http Status Code
                }

                return Ok(createdCountry); //Retorne un 200 y el objeto country
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("duplicate"))//si el mensaje contiene la palabra duplicate
                {
                    return Conflict(String.Format("El país {0} ya existe.", country.Name));//Conflict = 409 Http Status Code Error
                }
                //si no tiene que ver con duplicate que me muestre la excepcion a la que pertence
                return Conflict(ex.Message);
            }
        }

    }
}
