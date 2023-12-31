﻿using API_Adoptame.DAL.Entities;
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

            //TABLA PET//
            modelBuilder.Entity<Pet>()
        .HasOne(p => p.AdoptionDetail)
        .WithOne(ad => ad.Pet)
        .HasForeignKey<AdoptionDetail>(ad => ad.PetID);

            //TABLA USUARIO//
            modelBuilder.Entity<User>().HasIndex(c => c.Email).IsUnique(); //Para que solo hayan correos únicos
            modelBuilder.Entity<User>().HasIndex(c => c.PhoneNumber).IsUnique();

            //TABLA FUNDACIÓN// 
            modelBuilder.Entity<Fundation>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Fundation>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<Fundation>().HasIndex(c => c.PhoneNumber).IsUnique();
            


        }

        //Aqui creamos los Dbset: es para convertir las entidades logicas en entidades de tablas en la BD
     
       
        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Fundation> Fundations { get; set; }
        public DbSet<AdoptionDetail> AdoptionDetails { get; set; }

        //SERVER para crear una tabla llamada COUNTRIES
        //Asi lo hare con todas las tablas.
        //Por cada nueva entidad que yo cree, debo crearle su DbSet.

    }
}
