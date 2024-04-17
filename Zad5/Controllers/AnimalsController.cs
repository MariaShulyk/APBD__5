using Cwiczenia5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia5.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private static readonly List<Animal> _animals= new()
    {
        new Animal { IdAnimal = 1, Name = "Bob", Category = "Dog", Mass = 12.6, FurColor = "black"},
        new Animal { IdAnimal = 2, Name = "Waffle", Category = "Cat", Mass = 4.5, FurColor = "gold"},
        new Animal { IdAnimal = 3, Name = "Liz", Category = "Rabbit", Mass = 2.3, FurColor = "white"},
    }; 
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(st => st.IdAnimal == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        
        return Ok(animal);
    }
    
    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit= _animals.FirstOrDefault(s => s.IdAnimal == id);

        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        
        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToEdit= _animals.FirstOrDefault(s => s.IdAnimal == id);
        if (animalToEdit == null)
        {
            return NoContent();
        }

        _animals.Remove(animalToEdit);
        return NoContent();
    }
    
}