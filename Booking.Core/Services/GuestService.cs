using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Contract.DTO;
using Booking.Infrastructure.Model;
using Booking.Infrastructure.Repository;

namespace Booking.Core.Services
{
  
  
  public class GuestService : IGuestService
  {
    private readonly IGuestRepository _iGuestRepository;

    public GuestService(IGuestRepository iGuestRepository)
    {
      _iGuestRepository = iGuestRepository;
    }


    public async  Task<IEnumerable<GuestDto>> GetAll()
    {
      var guests = await _iGuestRepository.GetAll();
      return guests.Select(GuestDtoMapper)
      .ToList();


    }
    
    public async Task<GuestDto> GetById(long id)
    {
      var guest = await _iGuestRepository.GetById(id);
      return GuestDtoMapper(guest);
    }

    public async Task<GuestDto> GetByReservationNumber(int reservationNumber)
    {
      var guest = await _iGuestRepository.GetByReservationNumber(reservationNumber);
      return GuestDtoMapper(guest);    }

    private GuestDto GuestDtoMapper(Guest guest)
    {
      return new GuestDto()
      { Id = guest.Id,
        FirstName = guest.FirstName,
        LastName = guest.LastName,
        Email = guest.Email,
        CompanyName = guest.CompanyName,
        Nip = guest.Nip,
        Price = guest.Reservation.Price,
        ReservationNumber = guest.Reservation.ReservationNumber,
        CheckIn = guest.Reservation.CheckIn,
        CheckOut = guest.Reservation.CheckOut
        
      };
    }

    private static Guest GuestMapper(GuestDto guest)
    {
      return new Guest()
      {
        FirstName = guest.FirstName,
        LastName = guest.LastName,
        Email = guest.Email,
        CompanyName = guest.CompanyName,
        Nip = guest.Nip,
        Id = guest.Id,
        Reservation = new Reservation()
        {
          Price = guest.Price,
          ReservationNumber = guest.ReservationNumber,
          CheckIn = guest.CheckIn,
          CheckOut = guest.CheckOut
        }
      };
    }
    
    public async Task Add(GuestDto guest)
    {
      await _iGuestRepository.Add(GuestMapper(guest));
    }

    public async Task Update(GuestDto entity)
    {
      await _iGuestRepository.Update(GuestMapper(entity));
    }

    public async Task Delete(long id)
    {
      await _iGuestRepository.Delete(id);
    }
    public async Task<IEnumerable<GuestDto>> GetByTime(int year)
    {
      var guests = await _iGuestRepository.GetByTime(year);
      return guests.Select(GuestDtoMapper)
        .ToList();    
    }
  }
}
