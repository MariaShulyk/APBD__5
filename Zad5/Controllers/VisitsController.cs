using Cwiczenia5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia5.Controllers;

[Route("api/visits")]
[ApiController]
public class VisitsController : ControllerBase
{
    private static readonly List<Visit> _visits= new()
    {
        new Visit { Date = "22.10.2024", IdAnimal = 1, Description = "Second inspection", Price = 20.0},
        new Visit { Date = "12.08.2024", IdAnimal = 2, Description = "Second inspection", Price = 20.0},
        new Visit { Date = "29.06.2024", IdAnimal = 1, Description = "First inspection", Price = 30.0},
        new Visit { Date = "06.11.2024", IdAnimal = 2, Description = "Third inspection", Price = 20.0},
        new Visit { Date = "03.07.2024", IdAnimal = 2, Description = "First inspection", Price = 30.0},
        new Visit { Date = "10.09.2024", IdAnimal = 3, Description = "First inspection", Price = 30.0},
    };
    
    [HttpGet("{id:int}")]
    public IActionResult GetVisits(int id)
    {
        var visits = _visits.Where(v => v.IdAnimal == id).ToList();

        if (!visits.Any())
        {
            return NotFound($"Visits for animal with id {id} were not found.");
        }
    
        return Ok(visits);
    }
    
    [HttpPost]
    public IActionResult CreateVisit(Visit visit)
    {
        _visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
}