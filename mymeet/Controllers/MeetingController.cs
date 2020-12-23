using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mymeet.Models;
using mymeet.Data;

namespace mymeet.Controllers
{
  [ApiController]
  [Route("v1/meeting")]

  public class MeetingController : ControllerBase
  {
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Meeting>>> Get([FromServices] DataContextAplication context)
    {
      var meetings = await context.Meetings.ToListAsync();
      return meetings;
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Meeting>> Post(
      [FromServices] DataContextAplication context,
      [FromBody] Meeting model)
    {

      var meetings = await context.Meetings.ToListAsync();
      //var meetings = await context.Meetings.Include(x => x.Room).Where(x => x.RoomId == model.RoomId).ToListAsync();
      if (ModelState.IsValid)
      {

        if (context.Meetings.Any(x => x.Start <= model.Start && x.Start <= model.End))
        {

          return BadRequest(new { message = "Horário indisponível, reservado para outra reunião" });

        }

        context.Meetings.Add(model);
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