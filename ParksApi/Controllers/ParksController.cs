using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParksApi.Models;
using Microsoft.EntityFrameworkCore;


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

    // GET api/Parks
    [HttpGet]
    public ActionResult<IEnumerable<Park>> Get()
    {
      return _db.Parks.ToList();
    }

    // POST api/Parks
    [HttpPost]
    public void Post([FromBody] Park park)
    {
      _db.Parks.Add(park);
      _db.SaveChanges();
    }

    // GET api/parks/#
    [HttpGet("{id}")]
    public ActionResult<Park> Get(int id)
    {
      return _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
    }

    // PUT api/parks/userId/parkId
    [HttpPut("{userId}/{id}")]
    public void Put(int id, int userId, [FromBody] Park park)
    {
      park.ParkId = id;
      if (park.UserId == userId)
      {
        _db.Entry(park).State = EntityState.Modified;
        _db.SaveChanges();
      }
    }

    //http://localhost:5000/api/parks/1/9
    [HttpDelete("{userId}/{id}")]
    public void Delete(int id, int userId)
    {
      var parkToDelete = _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
      if (parkToDelete.UserId == userId)
      {
        _db.Parks.Remove(parkToDelete);
        _db.SaveChanges();
      }
    }

    // // GET api/Parks
    // [HttpGet]
    // // public ActionResult<IEnumerable<Park>> Get(string name, string type, string rating, string category, string description, int userId)
    // public ActionResult<Dictionary<string, object>> Get(string name, string type, string rating, string category, string description, int userId)
    // {
    //   var query = _db.Parks.AsQueryable();

    //   if (name != null)
    //   {
    //     query = query.Where(entry => entry.Name == name);
    //   }

    //   if (type != null)
    //   {
    //     query = query.Where(entry => entry.Type.Contains(type));
    //   }

    //   if (description != null)
    //   {
    //     query = query.Where(entry => entry.Description.Contains(description));
    //   }

    //   if (rating != null)
    //   {
    //     query = query.Where(entry => entry.Rating == rating);
    //   }

    // //   if (userId != 0)
    // //   {
    // //     query = query.Where(entry => entry.UserId == userId);
    // //   }
    //   Dictionary<string, object> response = new Dictionary<string, object>();
    //   response.Add("parks", query);
    //   return response;
    // }
    // Token:
    // eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1OTE5OTQ4NzAsImV4cCI6MTU5MjU5OTY3MCwiaWF0IjoxNTkxOTk0ODcwfQ.2NuRz_P1wDyKoFwu54Tykw_e3gMv3ab1MvxGbUy8qbc   
  }
}
