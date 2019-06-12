/*
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Core;
using Booking.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
  public class ReservationController : ControllerBase
  {
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
      _reservationService = reservationService;
    }
    
    [HttpGet("GetReservation/{Id}")]
    public async Task<IActionResult> GetReservationById(long id)
    {
      try
      {

        var reservation = await _reservationService.GetById(id);
        return Ok(reservation);
      }
      catch (NullReferenceException e)
      {
        return NotFound($"Can't found reservation with id = {id}");
      }
      
    }
  }
}
*/
