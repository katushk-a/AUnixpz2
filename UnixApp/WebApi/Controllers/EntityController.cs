using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Entities;
using WebApi.ViewModels;

namespace WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PersonController: ControllerBase
{
    private readonly EntityDbContext _entityDbContext;

    public PersonController(EntityDbContext entityDbContext)
    {
        _entityDbContext = entityDbContext;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePerson(PersonViewModel person)
    {
        var personToCreate = new Person
        {
            Age = person.Age,
            Name = person.Name
        };

        this._entityDbContext.Persons.Add(personToCreate);
        await this._entityDbContext.SaveChangesAsync();
        return Ok();
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetPersons()
        => new JsonResult(await _entityDbContext.Persons.Select(person => new PersonViewModel
        {
            Age = person.Age,
            Name = person.Name
        }).ToListAsync());
    
}