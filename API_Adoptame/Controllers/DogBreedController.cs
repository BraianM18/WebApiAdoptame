// DogBreedController.cs
using API_Adoptame.DAL.Entities;
using API_Adoptame.Domain.Interfaces;
using API_Adoptame.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class DogBreedController : ControllerBase
{
    private readonly IDogBreedService _dogBreedService;
   

    public DogBreedController(IDogBreedService dogBreedService)
    {
        _dogBreedService = dogBreedService;
    }

    [HttpGet]
    [ActionName("Get")]
    [Route("Get")]
    public async Task<ActionResult<IEnumerable<DogBreed>>> GetDogBreedsAsync()
    {
        
       
            var dogBreeds = await _dogBreedService.GetDogBreedAsync();
            return Ok(dogBreeds);
            if (dogBreeds == null || !dogBreeds.Any())
            {
                return NotFound();//NotFound = 404 Http Status Code
            }

            return Ok(dogBreeds); //Ok = 200 Http Status Code
    }

    [HttpPost]
    [ActionName("Create")]
    [Route("Create")]
    public async Task<ActionResult<DogBreed>> CreateDogBreedAsync(DogBreed dogBreed)
    {
        try
        {
            //                         este es mi servicio
            var createdDobBreed = await _dogBreedService.CreateDogBreedAsync(dogBreed);
            if (createdDobBreed == null)
            {
                return NotFound();//NotFound = 404 Http Status Code
            }

            return Ok(createdDobBreed); //Retorne un 200 y el objeto country
        }
        catch (Exception ex)
        {

            if (ex.Message.Contains("duplicate"))//si el mensaje contiene la palabra duplicate
            {
                return Conflict(String.Format("El país {0} ya existe.", dogBreed.Name));//Conflict = 409 Http Status Code Error
            }
            //si no tiene que ver con duplicate que me muestre la excepcion a la que pertence
            return Conflict(ex.Message);
        }
    }
}