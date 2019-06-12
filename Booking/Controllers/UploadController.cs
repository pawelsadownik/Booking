using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using Booking.Core;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UploadController : ControllerBase
  {
    
    static string nowaSciezka;

      [HttpPost, DisableRequestSizeLimit]
      public IActionResult Upload()
      {
      try
      {
        var file = Request.Form.Files[0];
        var folderName = Path.Combine("Resources", "DataFiles");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
 
       if (file.Length > 0)
        {
          var fileName = GetTimestamp(DateTime.UtcNow);
          var fullPath = Path.Combine(pathToSave, fileName);
          var dbPath = Path.Combine(folderName, fileName);
          nowaSciezka = dbPath;

      using (var stream = new FileStream(fullPath, FileMode.Create))
      {
        file.CopyTo(stream);
      }
 
      return Ok(new { dbPath });
        
        }
        else
      {
        return BadRequest();
      }
  }
      catch (Exception ex)
      {
          return StatusCode(500, "Internal server error");
      }
      
     }
      //private List<UserDetails> userDetails = ReadingExcel.ReadFromExcel<List<UserDetails>>(nowaSciezka);

      public static String GetTimestamp(DateTime value)
      {
        return value.ToString("yyyyMMddHHmmssfff");
       
      }

     
  }
  
  
 
}