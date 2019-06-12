using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Booking.Core.Services;
using Booking.Infrastructure.Context;
using Booking.Infrastructure.Repository;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace Booking
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(); 
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
      services.AddScoped<IGuestRepository, GuestRepository>();
      services.AddScoped<IGuestService, GuestService>();
      services.AddScoped<IReservationRepository, ReservationRepository>();
      //PDF library
      services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
      services.AddDbContext<BookingContext>(options =>
        options.UseSqlite("DataSource=dbo.BookingApi.db",
          builder => builder.MigrationsAssembly("Booking.Infrastructure")));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }
 
      app.UseHttpsRedirection();
      app.UseCors(
        options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
      );
      app.UseStaticFiles();
      app.UseStaticFiles(new StaticFileOptions()
      {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
        RequestPath = new PathString("/Resources")
      });
      app.UseMvc();
    }
  }
}
