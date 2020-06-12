using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ParksApi.Models;

namespace ParksApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private ParksApiContext _db;

    public ParksController(ParksApiContext db)
    {
      _db = db;
    }

    [HttpPost]  //  api/parks
    public void Post([FromBody] Park park)
    {
      _db.Parks.Add(park);
      _db.SaveChanges();
    }

    [HttpGet("{id}")] //  api/parks/{ParkId}
    public ActionResult<Park> Get(int id)
    {
      return _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
    }

    [Authorize]
    [HttpPut("{id}")] // api/parks/{ParkId}
    public void Put(int id, [FromBody] Park park)
    {
      park.ParkId = id;
      _db.Entry(park).State = EntityState.Modified;
      _db.SaveChanges();
    }
    
    [Authorize]
    [HttpDelete("{id}")] // api/parks/{ParkId}
    public void Delete(int id)
    {
      var parkToDelete = _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
      _db.Parks.Remove(parkToDelete);
      _db.SaveChanges();
    }

    [HttpGet] // api/parks
    public ActionResult<Dictionary<string, object>> Get(string name, string type, string description) //`int userId` for intergrating UserId into Park Model + Authentication
    {
      var query = _db.Parks.AsQueryable();

      if (name != null){ query = query.Where(entry => entry.Name == name); }
      if (type != null){ query = query.Where(entry => entry.Type.Contains(type)); }
      if (description != null){ query = query.Where(entry => entry.Description.Contains(description)); }
      // if (userId != 0){ query = query.Where(entry => entry.UserId == userId); }
      
      Dictionary<string, object> response = new Dictionary<string, object>();
      response.Add("parks", query);
      return response;
    }
  }
}
