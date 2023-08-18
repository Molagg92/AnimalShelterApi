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
    // POST api/Cats
    [HttpPost]
    public async Task<ActionResult<Cat>> Post(Cat cat)
    {
      _db.Cats.Add(cat);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetCat), new { id = cat.CatId }, cat);
    }
     // PUT: api/Cats/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Cat cat)
    {
      if (id != cat.CatId)
      {
        return BadRequest();
      }

      _db.Cats.Update(cat);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CatExists(id))
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

    // DELETE: api/Cats/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCat(int id)
    {
      Cat cat = await _db.Cats.FindAsync(id);
      if (cat == null)
      {
        return NotFound();
      }

      _db.Cats.Remove(cat);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool CatExists(int id)
    {
      return _db.Cats.Any(e => e.CatId == id);
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