using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Repository
{
  public interface IRepository <TEntity>
  {
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(long id);
    Task<TEntity> GetByReservationNumber(int reservationNumber);
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(long id);
    Task<IEnumerable<TEntity>> GetByTime(int year);
  }
  
  
}
