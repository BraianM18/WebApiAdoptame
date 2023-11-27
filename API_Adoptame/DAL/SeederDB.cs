using API_Adoptame.DAL;
using API_Adoptame.DAL.Entities;


namespace AvailabilityRooms.DAL;

public class SeederDB
{
    private readonly DataBaseContext _context;

    public SeederDB(DataBaseContext context)
    {
        _context = context;
    }



    public async Task SeederAsync()
    {
        await _context.Database.EnsureCreatedAsync();

        await PopulateFundationsAsync();

        await _context.SaveChangesAsync();
    }


    private async Task PopulateFundationsAsync()
    {
        if (!_context.Fundations.Any())
        {

            /*FUNDACIONES*/
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
                            Size = "Grande",

                            AdoptionDetail = new AdoptionDetail
                        {
                            AdoptionDate = null,
                            AdmissionDate = DateTime.Now,
                            AdoptionStatus = "Disponible",
                            CreateDate = DateTime.Now
                        }
                        },

                        new Pet
                        {
                            CreateDate = DateTime.Now,
                            Name = "Toby",
                            Kind = "Gato",
                            Race = "Siames",
                            Age = 3,
                            Size = "Pequeño",

                            AdoptionDetail = new AdoptionDetail
                        {
                            AdoptionDate = null,
                            AdmissionDate = DateTime.Now,
                            AdoptionStatus = "Disponible",
                            CreateDate = DateTime.Now
                        }
                        },

                        new Pet
                        {
                            CreateDate = DateTime.Now,
                            Name = "Lucy",
                            Kind = "Gato",
                            Race = "Meico",
                            Age = 3,
                            Size = "Mediana",

                                AdoptionDetail = new AdoptionDetail
                        {
                            AdoptionDate = null,
                            AdmissionDate = DateTime.Now,
                            AdoptionStatus = "Disponible",
                            CreateDate = DateTime.Now
                        }

                        },

                        new Pet
                        {
                            CreateDate = DateTime.Now,
                            Name = "Zeus",
                            Kind = "Perro",
                            Race = "Pitbull",
                            Age = 4,
                            Size = "Grande",

                               AdoptionDetail = new AdoptionDetail
                        {
                            AdoptionDate = null,
                            AdmissionDate = DateTime.Now,
                            AdoptionStatus = "Disponible",
                            CreateDate = DateTime.Now
                        }
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
                            Size = "Pequeña",

                               AdoptionDetail = new AdoptionDetail
                        {
                            AdoptionDate = null,
                            AdmissionDate = DateTime.Now,
                            AdoptionStatus = "Disponible",
                            CreateDate = DateTime.Now
                        }
                        },

                        new Pet
                        {
                            CreateDate = DateTime.Now,
                            Name = "Apolo",
                            Kind = "Gato",
                            Race = "Criollo",
                            Age = 4,
                            Size = "Pequeño",

                               AdoptionDetail = new AdoptionDetail
                        {
                            AdoptionDate = null,
                            AdmissionDate = DateTime.Now,
                            AdoptionStatus = "Disponible",
                            CreateDate = DateTime.Now
                        }
                        },

                        new Pet
                        {
                            CreateDate = DateTime.Now,
                            Name = "Sam",
                            Kind = "Perro",
                            Race = "Husky",
                            Age = 2,
                            Size = "Mediano",

                               AdoptionDetail = new AdoptionDetail
                        {
                            AdoptionDate = null,
                            AdmissionDate = DateTime.Now,
                            AdoptionStatus = "Disponible",
                            CreateDate = DateTime.Now
                        }
                        },

                        new Pet
                        {
                            CreateDate = DateTime.Now,
                            Name = "Mailo",
                            Kind = "Perro",
                            Race = "Chiguagua",
                            Age = 5,
                            Size = "pequeño",

                               AdoptionDetail = new AdoptionDetail
                        {
                            AdoptionDate = null,
                            AdmissionDate = DateTime.Now,
                            AdoptionStatus = "Disponible",
                            CreateDate = DateTime.Now
                        }
                        }

                    }
            });


            /*USUARIOS*/
            _context.Users.Add(new User
            {
                Name = "Alejo",
                Email = "Alejo@gmail.com",
                PhoneNumber = 5742536,
                Password = "lerolerocandelero"

            });

            _context.Users.Add(new User
            {
                Name = "Angie",
                Email = "Angie@gmail.com",
                PhoneNumber = 5896415,
                Password = "fnaf"

            });

            _context.Users.Add(new User
            {
                Name = "braian",
                Email = "braian@gmail.com",
                PhoneNumber = 5749685,
                Password = "papupapu"

            });

            /*DETALLES DE ADOPCION*/
            _context.AdoptionDetails.Add(new AdoptionDetail
            {
                AdoptionDate = DateTime.Now,
                AdmissionDate = DateTime.Now,
                AdoptionStatus = "Adoptado",
                CreateDate = DateTime.Now

            });

            _context.AdoptionDetails.Add(new AdoptionDetail
            {
                AdoptionDate = null,
                AdmissionDate = DateTime.Now,
                AdoptionStatus = "No Adoptado",
                CreateDate = DateTime.Now

            });

            _context.AdoptionDetails.Add(new AdoptionDetail
            {
                AdoptionDate = null,
                AdmissionDate = DateTime.Now,
                AdoptionStatus = "En Trámite",
                CreateDate = DateTime.Now

            });
        }
    }//
}

