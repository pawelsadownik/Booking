using System;

namespace Booking.Infrastructure.Model
{
  public class Reservation : Entity
  {
    public decimal Price { get; set; }
    
    public int ReservationNumber { get; set;}
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
  }
}
