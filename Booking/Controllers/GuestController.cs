using System;
using System.Threading.Tasks;
using Booking.Contract.DTO;
using Booking.Core.Services;
using Booking.Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Storage;

namespace Booking.Controllers
{
  
  [Route("api/[controller]")]
  [ApiController]
  public class GuestController : ControllerBase
  {
    private readonly IGuestService _guestService;

    public GuestController(IGuestService guestService)
    {
      _guestService = guestService;
    }



    [HttpGet("GetGuest/{Id}")]
    public async Task<IActionResult> GetGuestById(long id)
    {
      try
      {
        var guest = await _guestService.GetById(id);
        return Ok(guest);
      }
      catch (NullReferenceException e)
      {
        return NotFound($"Can't found guest with id = {id}");
      }
      
    }
    
    [HttpGet("GetAllGuests")]
    public async Task<IActionResult> GetAllGuests()
    {
      var guests = await _guestService.GetAll();
      return Ok(guests);
    }

    [HttpPost]
    public async Task<IActionResult> CreateGuest([FromBody] GuestDto guest)
    {
      if (guest == null)
      {
        return BadRequest();
      }

      await _guestService.Add(guest);
      return Created("Created new Guest", guest);
    }
    
    [HttpPut("UpdateGuest")]
    public async Task<IActionResult> UpdateGuest([FromBody] GuestDto guest)
    {
      if (guest == null)
      {
        return BadRequest();
      }

      await _guestService.Update(guest);
      return Ok();
    }
    
    [HttpDelete("DeleteGuest/{id}")]
    public async Task<IActionResult> DeleteGuest(long id)
    {
     
      await _guestService.Delete(id);
      return Ok();
    }
  }
}
