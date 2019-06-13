/*
using System;
using System.Threading.Tasks;
using Booking.Contract.DTO;
using Booking.Core.Services;
using Booking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Booking.Specs.Repositories
{
  public class GuestRepositoryTests : IClassFixture<DbFixture>
  {
    private ServiceProvider _serviceProvide;

    //private readonly IGuestService _guestService;

    public GuestRepositoryTests(DbFixture dbFixture)
    {
                  _serviceProvide = dbFixture.ServiceProvider;

      //_guestService = guestService;
    }

    [Fact]
    public async Task when_add_should_add()
    {

      using (var context = _serviceProvide.GetService<BookingContext>())
      {
        GuestService _guestService = new GuestService(context);
        //Arrange
        var Guest = new GuestDto("ppp", "ppp", "ppp", "ppp", "ppp", 300, 3, DateTime.Now, DateTime.Now);

        //Act/*#1#
        await _guestService.Add(Guest);

        //Assert
        var existingGuest = await _guestService.GetByReservationNumber(3);
        Assert.Equal(Guest, existingGuest);
      }

    }
  }
  
  public class DbFixture
  {
    public IConfiguration Configuration { get; }


    public DbFixture()
    {
           
      var services = new ServiceCollection();

      services.AddDbContext<BookingContext>(options =>
        options.UseSqlite("DataSource=dbo.BookingApi.db",
          builder => builder.MigrationsAssembly("Booking.Infrastructure")));
 

      ServiceProvider = services.BuildServiceProvider();

    }

    public ServiceProvider ServiceProvider { get; private set; }

  }
}
*/
