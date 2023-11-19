using API_Adoptame.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Adoptame.DAL
{
    public class DataBaseContext : DbContext
    {
        //Con este constructor me podre conectar a la BD, me brinda unas opciones de configuracion que ya están
        //definidas internamente
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(c => c.Email).IsUnique(); //Para que solo hayan correos únicos
            //Esto es un indice para evitar nombres duplicados en países
        }

        //Aqui creamos los Dbset: es para convertir las entidades logicas en entidades de tablas en la BD
        public DbSet<Country> Countries { get; set; }//Esta linea me toma la clase Country y me la mapea en SQL
        public DbSet<DogBreed> DogBreeds { get; set; }
       
        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }

        //SERVER para crear una tabla llamada COUNTRIES
        //Asi lo hare con todas las tablas.
        //Por cada nueva entidad que yo cree, debo crearle su DbSet.

    }
}
