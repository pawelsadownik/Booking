using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StatisticController : ControllerBase  
  {
    private readonly IGuestService _guestService;

    public StatisticController(IGuestService guestService)
    {
      _guestService = guestService;
    }
    
    [HttpGet("GetStatistics/{Year}")]
    public decimal  GetStatisticsByTime(int year)
    {
        decimal sum = 0;
        var guests = _guestService.GetByTime(year);
      
        for (int i = 0; i < guests.Result.Count(); i++ )
        {
          sum += guests.Result.ElementAtOrDefault(i).Price;
        
        }
        return sum;
    }
    
    [HttpGet("GetStatistics")]
    public decimal  GetStatisticsByAll()
    {
      decimal sum = 0;
      var guests = _guestService.GetAll();
      
      for (int i = 0; i < guests.Result.Count(); i++ )
      {
        sum += guests.Result.ElementAtOrDefault(i).Price;
        
      }
      return sum;
    }
    
  }
}
