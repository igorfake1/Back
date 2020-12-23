using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using mymeet.Models;
using mymeet.Data;

namespace mymeet.Controllers
{
  [Route("v1/rooms")]
  public class RoomController : ControllerBase
  {


    [HttpGet]
    [Route("")]
    public async Task<ActionResult> Get([FromServices] DataContextAplication context)
    {

      var rooms = await context.Rooms.Include(x => x.Meetings).ToListAsync();


      return Ok(rooms.Select(x => new
      {
        x.Id,
        x.NameRoom,
        meetings = x.Meetings?.Select(x => new
        {
          x.Id,
          x.Title,
          x.Start,
          x.End
        })

      }));
    }

    [HttpPost]
    [Route("")]
    [AllowAnonymous]
    public async Task<ActionResult<Room>> Post(
      [FromServices] DataContextAplication context,
      [FromBody] Room model)
    {
      if (ModelState.IsValid)
      {
        context.Rooms.Add(model);
        await context.SaveChangesAsync();
        return model;
      }
      else
      {
        return BadRequest(ModelState);
      }
    }
  }
}

