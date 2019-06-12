using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Infrastructure.Model
{
  public class Guest: Entity
  {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string Nip { get; set; }     
        public Reservation reservation { get; set; }

    
  }
  
}
