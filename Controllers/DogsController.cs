using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using AnimalShelterApi.Models;

namespace AnimalShelterApi.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class DogsController : ControllerBase
  {
    private readonly AnimalShelterApiContext _db;

    public DogsController(AnimalShelterApiContext db)
    {
      _db = db;
    }

    // GET api/Dogs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Dog>>> Get()
    {
      return await _db.Dogs.ToListAsync();
    }

    // GET: api/Dogs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Dog>> GetDog(int id)
    {
      Dog dog = await _db.Dogs.FindAsync(id);

      if (dog == null)
      {
        return NotFound();
      }

      return dog;
    }
    // POST api/Dogs
    [HttpPost]
    public async Task<ActionResult<Dog>> Post(Dog dog)
    {
      _db.Dogs.Add(dog);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetDog), new { id = dog.DogId }, dog);
    }
     // PUT: api/Dogs/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Dog dog)
    {
      if (id != dog.DogId)
      {
        return BadRequest();
      }

      _db.Dogs.Update(dog);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DogExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool DogExists(int id)
    {
      return _db.Dogs.Any(e => e.DogId == id);
    }
    // DELETE: api/Dogs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDog(int id)
    {
      Dog dog = await _db.Dogs.FindAsync(id);
      if (dog == null)
      {
        return NotFound();
      }

      _db.Dogs.Remove(dog);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    [HttpGet("GetToken")]
    [AllowAnonymous]
    public ActionResult GetToken()
    {
      var accessToken = GenerateJSONWebToken();

      return Ok(accessToken);
    }

    private string GenerateJSONWebToken()
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MynameisJamesBond007MynameisJamesBond007MynameisJamesBond007"));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
  
      var token = new JwtSecurityToken(
          issuer: "https://www.yogihosting.com",
          audience: "https://www.yogihosting.com",
          expires: DateTime.Now.AddHours(3),
          signingCredentials: credentials
          );
  
      return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    private void SetJWTCookie(string token)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddHours(3),
        };
        Response.Cookies.Append("jwtCookie", token, cookieOptions);
    }

  }
}