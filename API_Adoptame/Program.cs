//el program me sirve a mí para poder correr cuando yo corra el código desde acá es lo primero que hace es que venir a esta clase y poder verificar qué servicios tengo yo acá inyectados para yo poder cumplir con este pipeline. ¿Qué es un pipeline? Es una es una que secuencia de tareas que se ejecutan una tras otra listo. 
using API_Adoptame.DAL;
using API_Adoptame.DAL.Entities;
using API_Adoptame.Domain.Interfaces;
using API_Adoptame.Domain.Services;
using AvailabilityRooms.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Esta linea me crea el contexto de la BD a la hora de correr esta API (la o es options => y esto significa tal)
//Funcionaes anonimas (x => x....) Arrow Functions - Lambda Functions(esos 3 nombres son lo mismo)
builder.Services.AddDbContext<DataBaseContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFundationService, FundationService>();
builder.Services.AddScoped<IAdoptionDetailService, AdoptionDetailService>();
builder.Services.AddTransient<SeederDB>();



//Por cada nuevo servicio/interfaz que yo creo en mi API, debo agregar aquí esa nueva dependencia

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();//build.service que sirve para abrirlo en el explorer
builder.Services.AddSwaggerGen();

var app = builder.Build();

SeederData();
void SeederData()
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory.CreateScope())
    {
        SeederDB? service = scope.ServiceProvider.GetService<SeederDB>();
        service.SeederAsync().Wait();
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
