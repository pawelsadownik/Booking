using System.Net.NetworkInformation;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Booking.Infrastructure.Model;

namespace Booking.Infrastructure.Context
{
  public class BookingContext : DbContext
  {
    
    public DbSet<Reservation> Reservations { get; protected set; }
    public DbSet<Guest> Guests { get; protected set; }


    public BookingContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("DataSource=dbo.BookingApi.db");
    }
   
  }
}
