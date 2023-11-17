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

        }
        public async Task<DogBreed> CreateDogBreedAsync(DogBreed dogBreed)
        {
            try
            {
                // Lógica de validación: asegurarse de que el nombre de la raza no esté duplicado
                var existingBreed = await _context.DogBreeds.FirstOrDefaultAsync(b => b.Name == dogBreed.Name);
                if (existingBreed != null)
                {
                    // Puedes personalizar el mensaje de error según tus necesidades
                    throw new ApplicationException("Ya existe una raza de perro con este nombre.");
                }

                // Si la validación pasa, agrega la nueva raza del perro al contexto y guarda los cambios
                _context.DogBreeds.Add(dogBreed);
                await _context.SaveChangesAsync();

                return dogBreed;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, registro, etc.
                throw new ApplicationException("Error al crear la raza del perro.", ex);
            }
        }

        public async Task<IEnumerable<DogBreed>> GetDogBreedAsync()
        {
            try
            {
                // Lógica para obtener todas las razas de perros.
                var dogBreeds = await _context.DogBreeds.ToListAsync();

                return dogBreeds;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, registro, etc.
                throw new ApplicationException("Error al obtener las razas de perros.", ex);
            }
        }
    }
}
