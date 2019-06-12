using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Infrastructure.Context;
using Booking.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Repository
{
  public class ReservationRepository : IReservationRepository
  {
    private readonly BookingContext _bookingContext;

    public ReservationRepository(BookingContext bookingContext)
    {
      _bookingContext = bookingContext;
    }
    
    public async Task<IEnumerable<Reservation>> GetAll()
    {
      var reservations = await _bookingContext.Reservations.ToListAsync();
      
      return reservations;
    }

    public async Task<Reservation> GetById(long id)
    {
      var reservation = await _bookingContext.Reservations
        .Where(x => x.Id == id)
        .SingleOrDefaultAsync();
      
      return reservation;    
    }

    public Task<Reservation> GetByReservationNumber(int reservationNumber)
    {
      throw new NotImplementedException();
    }

    public async Task Add(Reservation reservation)
    {
      reservation.DateOfCreation = DateTime.Now;
      await _bookingContext.Reservations
        .Include(x => x.Price)
        .Include(x => x.CheckIn)
        .Include(x => x.CheckOut)
        .FirstAsync();

      await _bookingContext.Reservations.AddAsync(reservation);
      await _bookingContext.SaveChangesAsync();
    }

    public Task Update(Reservation entity)
    {
      throw new System.NotImplementedException();
    }

    public async Task Delete(long id)
    {
      var reservationToDelete = await _bookingContext.Reservations.SingleOrDefaultAsync(reservation => reservation.Id == id);
      if (reservationToDelete != null)
      {
        _bookingContext.Reservations.Remove(reservationToDelete);
        await _bookingContext.SaveChangesAsync();
      }    }

    public Task<IEnumerable<Reservation>> GetByTime(int year)
    {
      throw new NotImplementedException();
    }
  }
}
