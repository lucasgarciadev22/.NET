using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UserController : ControllerBase
  {
    [HttpGet("GetDateHourNow")]
    public IActionResult GetDateHour()
    {
        var obj= new 
        {
            Date = DateTime.Now.ToLongDateString(),
            Hour = DateTime.Now.ToShortTimeString(),
        };

        return Ok(obj);
    }
    [HttpGet("WelcomeMessage/{name}")]
    public IActionResult Show(string name)
    {
      var message = $"Hello {name}, welcome back!";
      return Ok(new {message});
    }
  }
}