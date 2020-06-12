using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ParksApi.Services;
using ParksApi.Models;
using System;

namespace ParksApi.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ControllerBase
  {

    private ParksApiContext _db;
    private IUserService _userService;

    public UsersController(ParksApiContext db, IUserService userService)
    {
      _db = db;
      _userService = userService;
    }

    [HttpPost]
    public void Post([FromBody] User user)
    {
      _db.Users.Add(user);
      _db.SaveChanges();
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] User userParam)
    {
      var user = _userService.Authenticate(userParam.Username, userParam.Password);

      if (user == null)
      {
        return BadRequest(new { message = "Username or password is incorrect" });
      }
      return Ok(user);
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetAll()
    {
      var users = _userService.GetAll();
      return Ok(users);
    }
  }
}
