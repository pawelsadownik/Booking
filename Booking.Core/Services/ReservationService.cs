//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Booking.Contract.DTO;
//using Booking.Infrastructure.Model;
//using Booking.Infrastructure.Repository;
//
//namespace Booking.Core.Services
//{
//  public class ReservationService : IReservationService
//  {
//    private readonly IReservationRepository _iReservationRepository;
//
//    public ReservationService(IReservationRepository iReservationRepository)
//    {
//      _iReservationRepository = iReservationRepository;
//    }
//    
//    public async  Task<IEnumerable<ReservationDto>> GetAll()
//    {
//      var reservations = await _iReservationRepository.GetAll();
//      return reservations.Select(ReservationDtoMapper)
//        .ToList();
//    }
//    
//    public async Task<ReservationDto> GetById(long id)
//    {
//      var reservation = await _iReservationRepository.GetById(id);
//      return ReservationDtoMapper(reservation);
//    }
//
//    private ReservationDto ReservationDtoMapper(Reservation reservation)
//    {
//      return new ReservationDto()
//      {
//        price = reservation.Price,
//        checkIn = reservation.CheckIn,
//        checkOut = reservation.CheckOut,
//  
//      };
//    }
//
//    private static Reservation ReservationMapper(ReservationDto reservation)
//    {
//      return new Reservation()
//      {
//        Price = reservation.price,
//        CheckIn = reservation.checkIn,
//        CheckOut = reservation.checkOut,
//      
//      };
//    }
//    
//    public async Task Add(ReservationDto reservation)
//    {
//      await _iReservationRepository.Add(ReservationMapper(reservation));
//    }
//
//    public Task Update(ReservationDto entity)
//    {
//      throw new System.NotImplementedException();
//    }
//
//    public async Task Delete(long id)
//    {
//      await _iReservationRepository.Delete(id);
//    }
//    
//  }
//}
