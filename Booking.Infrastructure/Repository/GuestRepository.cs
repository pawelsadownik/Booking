using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Infrastructure.Context;
using Booking.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Repository
{
  public class GuestRepository : IGuestRepository
  {
    private readonly BookingContext _bookingContext;

    public GuestRepository(BookingContext bookingContext)
    {
      _bookingContext = bookingContext;
    }

    public async Task<IEnumerable<Guest>> GetAll()
    {
      var guests = await _bookingContext.Guests.ToListAsync();
      
      guests.ForEach(x => { _bookingContext.Entry(x).Reference(y => y.reservation).LoadAsync();});
      return guests;
    }

    public async Task<Guest> GetById(long id)
    {
      var guest = await _bookingContext.Guests
        .Where(x => x.Id == id)
        .SingleOrDefaultAsync();

      try
      {
        await _bookingContext.Entry(guest).Reference(x => x.reservation).LoadAsync();

      }
      catch (ArgumentException e)
      {
        return null;
      }

      return guest;
    }

    public async Task<Guest> GetByReservationNumber(int reservationNumber)
    {
      var guest = await _bookingContext.Guests
        .Where(x => x.reservation.ReservationNumber == reservationNumber)
        .SingleOrDefaultAsync();

      try
      {
        await _bookingContext.Entry(guest).Reference(x => x.reservation).LoadAsync();

      }
      catch (ArgumentException e)
      {
        return null;
      }

      return guest;    }

    public async Task Add(Guest guest)
    {
      guest.DateOfCreation = DateTime.Now;
      /*await _bookingContext.Guests
        .Include(x => x.reservation)
        .FirstAsync();*/
      await _bookingContext.Guests.AddAsync(guest);
      await _bookingContext.SaveChangesAsync();
    }

    public async Task Update(Guest entity)
    {
      var guestToUpdate = await _bookingContext.Guests
        .Include(x => x.reservation)
        .SingleOrDefaultAsync(x => x.Id == entity.Id);
      
      if (guestToUpdate != null)
      {
        guestToUpdate.FirstName = entity.FirstName;
        guestToUpdate.LastName = entity.FirstName;
        guestToUpdate.Nip = entity.FirstName;
        guestToUpdate.CompanyName = entity.FirstName;
        guestToUpdate.Email = entity.FirstName;
        guestToUpdate.DateOfUpdate = DateTime.Now;
        guestToUpdate.reservation.Price = entity.reservation.Price;
        guestToUpdate.reservation.ReservationNumber = entity.reservation.ReservationNumber;
        guestToUpdate.reservation.CheckIn = entity.reservation.CheckIn;
        guestToUpdate.reservation.CheckOut = entity.reservation.CheckOut;

        if (entity.reservation != null && guestToUpdate.reservation != null)
        {
          entity.reservation.Id = guestToUpdate.reservation.Id;
                    
          _bookingContext.Entry(guestToUpdate.reservation).CurrentValues.SetValues(entity.reservation);
        }
        await _bookingContext.SaveChangesAsync();
      }
    }

    public async Task Delete(long id)
    {
      var guestToDelete = await _bookingContext.Guests.SingleOrDefaultAsync(guest => guest.Id == id);
      if (guestToDelete != null)
      {
        _bookingContext.Guests.Remove(guestToDelete);
        await _bookingContext.SaveChangesAsync();
      }
    }

    public async Task<IEnumerable<Guest>> GetByTime(int year)
    {
      var guests = await _bookingContext.Guests
        .Where(x => x.reservation.CheckOut.Year == year)
        .ToListAsync();
        try
          {
            guests.ForEach(x => { _bookingContext.Entry(x).Reference(y => y.reservation).LoadAsync();});

          }
          catch (ArgumentException e)
            {
              return null;
            }
        return guests;
    }
}
 
}



