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
                CreateDate = DateTime.Now,
                Name = "CorazonesDeHierro",
                Email = "CorazonesDeHierro@gmail.com",
                Address = "la dalia marinilla",
                PhoneNumber = 5741413

            });


            _context.Fundations.Add(new Fundation
            {
                CreateDate = DateTime.Now,
                Name = "Pepitas",
                Email = "Pepitas@gmail.com",
                Address = "Bello Antioquia",
                PhoneNumber = 5748591

            });


            _context.Fundations.Add(new Fundation
            {
                CreateDate = DateTime.Now,
                Name = "GordoBachicha",
                Email = "GordoBachicha@hotmail.com",
                Address = "Rionegro Antioquia",
                PhoneNumber = 5741462

            });

            /*MASCOTAS*/
            _context.Pets.Add(new Pet
            {
                Name = "Romeo",
                Kind = "Gato",
                Race = "Persa",
                Age = 10,
                Size = "Mediano",
                CreateDate = DateTime.Now

            });

            _context.Pets.Add(new Pet
            {
                Name = "Julieta",
                Kind = "Gato",
                Race = "unknown",
                Age = 5,
                Size = "Pequeño",
                CreateDate = DateTime.Now

            });

            _context.Pets.Add(new Pet
            {
                Name = "Blanquito",
                Kind = "Gato",
                Race = "khao Manee",
                Age = 12,
                Size = "Mediano",
                CreateDate = DateTime.Now

            });

            _context.Pets.Add(new Pet
            {
                Name = "Negrita",
                Kind = "Gato",
                Race = "Bombay",
                Age = 7,
                Size = "Pequeño",
                CreateDate = DateTime.Now

            });

            _context.Pets.Add(new Pet
            {
                Name = "felix",
                Kind = "Gato",
                Race = "Británico",
                Age = 15,
                Size = "Grande",
                CreateDate = DateTime.Now

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

