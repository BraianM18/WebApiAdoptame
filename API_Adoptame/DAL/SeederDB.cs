using API_Adoptame.DAL;
using API_Adoptame.DAL.Entities;
using System.Net;
using System.Xml.Linq;

namespace Adoptame.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        //Crearemos un metodo SeederAsync
        //Este método es una especie de MAIN()
        //Este metodo tendra la responsabilidad de prepoblar mis diferentes tablas de la BD

        public async Task SeederAsync()
        {
            //Primero agregare un metodo propio de EntityFramework que hace las veces del comando 'update-database'
            //En otras palabras: un metodo que me creara la BD inmediatamente ponga en ejecucion mi API
            await _context.Database.EnsureCreatedAsync();

            //A partir de aqui vamosa  ir creando metodos que me srivan para prepoblar mi BD
            await PopulateFundationsAsync();

            await _context.SaveChangesAsync(); //esta linea me guarda los datos en la BD
        }



        #region Private Methos

        private async Task PopulateFundationsAsync()
        {
            //El metodo Any() me indica si la tabla tiene al menos un registro
            //el metodo Any negado (!) me indica que no hay absolutamente nada en la tabla Fundation
            if (_context.Fundations.Any())
            {
                //Asi creo yo una fundacion con sus respectivas mascotas
                _context.Fundations.Add(new Fundation
                {
                    Name = "Huellitas",
                    Email = "huellitas@hotmail.com",
                    Address = "Via Santa Elena",
                    PhoneNumber = 121324344,
                    Pets = new List<Pet>()
                    {
                        new Pet
                        {
                            CreateDate = DateTime.Now,
                            Name = "Leo",
                            Kind = "Perro",
                            Race = "Labrador",
                            Age = 2,
                            Size = "Grande"
                        },

                        new Pet
                        {
                            CreateDate = DateTime.Now,
                            Name = "Toby",
                            Kind = "Gato",
                            Race = "Siames",
                            Age = 3,
                            Size = "Pequeño"
                        },

                        new Pet
                        {
                            CreateDate = DateTime.Now,
                            Name = "Lucy",
                            Kind = "Gato",
                            Race = "Meico",
                            Age = 3,
                            Size = "Mediana"
                        },

                        new Pet
                        {
                            CreateDate = DateTime.Now,
                            Name = "Zeus",
                            Kind = "Perro",
                            Race = "Pitbull",
                            Age = 4,
                            Size = "Grande"
                        }

                    }
                });

                _context.Fundations.Add(new Fundation
                {
                    Name = "Almas del cielo",
                    Email = "Almasdelcielo@hotmail.com",
                    Address = "Ruta 2",
                    PhoneNumber = 143543632,
                    Pets = new List<Pet>()
                    {
                        new Pet
                        {
                            CreateDate = DateTime.Now,
                            Name = "Mia",
                            Kind = "Gato",
                            Race = "Siames",
                            Age = 6,
                            Size = "Pequeña"
                        },

                        new Pet
                        {
                            CreateDate = DateTime.Now,
                            Name = "Apolo",
                            Kind = "Gato",
                            Race = "Criollo",
                            Age = 4,
                            Size = "Pequeño"
                        },

                        new Pet
                        {
                            CreateDate = DateTime.Now,
                            Name = "Sam",
                            Kind = "Perro",
                            Race = "Husky",
                            Age = 2,
                            Size = "Mediano"
                        },

                        new Pet
                        {
                            CreateDate = DateTime.Now,
                            Name = "Mailo",
                            Kind = "Perro",
                            Race = "Chiguagua",
                            Age = 5,
                            Size = "pequeño"
                        }

                    }
                });
            }
        }

        #endregion
    }
}