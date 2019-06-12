using System;

namespace Booking.Contract.DTO
{
  public class GuestDto
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string CompanyName { get; set; }
    public string Nip { get; set; }
    
    public decimal Price { get; set; }
    
    public int ReservationNumber { get; set;}
    
    public DateTime CheckIn { get; set; }
    
    public DateTime CheckOut { get; set; }


    public GuestDto()
    {
      
    }
    public GuestDto(string firstName, string lastName, string email, string companyName, string nip, decimal price, int reservationNumber, DateTime checkIn, DateTime checkOut)
    {
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      CompanyName = companyName;
      Nip = nip;
      Price = price;
      ReservationNumber = reservationNumber;
      CheckIn = checkIn;
      CheckOut = checkOut;
    }
  }
}
