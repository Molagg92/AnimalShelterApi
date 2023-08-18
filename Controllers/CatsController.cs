using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelterApi.Models;

namespace AnimalShelterApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CatsController : ControllerBase
  {
    private readonly AnimalShelterApiContext _db;

    public CatsController(AnimalShelterApiContext db)
    {
      _db = db;
    }

    // GET api/cats
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cat>>> Get()
    {
      return await _db.Cats.ToListAsync();
    }

    // GET: api/Cats/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Cat>> GetCat(int id)
    {
      Cat cat = await _db.Cats.FindAsync(id);

      if (cat == null)
      {
        return NotFound();
      }

      return cat;
    }
  }
}