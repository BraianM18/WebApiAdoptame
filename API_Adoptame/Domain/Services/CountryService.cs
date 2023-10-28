using API_Adoptame.DAL;
using API_Adoptame.DAL.Entities;
using API_Adoptame.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Adoptame.Domain.Services
{
    //Cada que creo una interfaz o un metodo en interfaces la tengo que implementar aqui
    public class CountryService : ICountryService //esta es la manera de implementar una clase en este caso  implementamos la interfaz ICountryService (es como decirle que hereda de ahi)
    {
        private readonly DataBaseContext _context;

        //Creamos el construtor: lo creamos para poder inyectar la dependencia de la BD, para poderme conectar debo primero
        //inyectar esa dependencia
        public CountryService(DataBaseContext context)//inyeccion de dependencia de la BD
        {
            //aqui inicializamos este campo
            _context = context;//con esto puedo acceder al contexto de mi base de datos, significa que es como un efecto espejo 
            //de lo que tengo aqui en el codigo, en la BD.
        }

        //Aqui tengo que implementar el metodo de la interfaz
        //este servicio es el que se va a conectar ami BD
        //Para eso debo inyectar la dependencia de mi interfaz en el Program eso siempre que cree una nueva interfaz 
        //y toca crear esa dependencia de la interfaz
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            //aqui lo que hago es traerme todo los datos que tengo en mi tabla Countries con el metodo ToListAsync()
            //en la variable nueva countries se conecta al contexto de la BD, va a la tabla countries y me trae una lista de todos los elementos que hay ahi
            //y los guarda en la variable countries y los retorno, para mostrarlos, ese retorno llega a ICountryService.cs
            var countries = await _context.Countries.ToListAsync();

            return countries;
            // tambien se puede hacer asi  return var countries = await _context.Countries.ToListAsync();
            //devuelve un Inumerable de Paises
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid(); //Asi se asigna automaticamente un ID a un nuevo registro
                country.CreateDate = DateTime.Now;

                //estos dos siempre se tiene que crear juntos no puede ir uno solo, por que al tener un add tiene que tener un SaveChangesAsync
                _context.Countries.Add(country);//Adicionar un nuevo pais, por eso pongo el metodo add y de parametro lo que quiero agregar  (estoy creando el objeto Country en el contexto de mi BD)
                await _context.SaveChangesAsync();//Aquí ya estoy yendo a la BD para hacer el INSERT en la tabla countries

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                //esta exception me captura un mensaje cuando el pais ya existe(Duplicados)
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
