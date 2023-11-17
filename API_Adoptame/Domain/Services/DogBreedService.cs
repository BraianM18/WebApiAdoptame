using API_Adoptame.DAL;
using API_Adoptame.DAL.Entities;
using API_Adoptame.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Adoptame.Domain.Services
{
    public class DogBreedService : IDogBreedService
    {
        public readonly DataBaseContext _context;
        public DogBreedService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DogBreed>> GetDogBreedAsync()
        {
            //aqui lo que hago es traerme todo los datos que tengo en mi tabla Countries con el metodo ToListAsync()
            //en la variable nueva countries se conecta al contexto de la BD, va a la tabla countries y me trae una lista de todos los elementos que hay ahi
            //y los guarda en la variable countries y los retorno, para mostrarlos, ese retorno llega a ICountryService.cs
            var dogBreeds = await _context.DogBreeds.ToListAsync();

            return dogBreeds;
            // tambien se puede hacer asi  return var countries = await _context.Countries.ToListAsync();
            //devuelve un Inumerable de Paises
        }

        public async Task<DogBreed> CreateDogBreedAsync(DogBreed dogBreed)
        {
            try
            {
                dogBreed.Id = Guid.NewGuid(); //Asi se asigna automaticamente un ID a un nuevo registro
                dogBreed.CreateDate = DateTime.Now;

                //estos dos siempre se tiene que crear juntos no puede ir uno solo, por que al tener un add tiene que tener un SaveChangesAsync
                _context.DogBreeds.Add(dogBreed);//Adicionar un nuevo pais, por eso pongo el metodo add y de parametro lo que quiero agregar  (estoy creando el objeto Country en el contexto de mi BD)
                await _context.SaveChangesAsync();//Aquí ya estoy yendo a la BD para hacer el INSERT en la tabla countries

                return dogBreed;
            }
            catch (DbUpdateException dbUpdateException)
            {
                //esta exception me captura un mensaje cuando el pais ya existe(Duplicados)
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
