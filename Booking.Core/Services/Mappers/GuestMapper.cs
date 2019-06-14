/*
namespace Booking.Core.Services.Mappers
{
  internal static class GuestMapper
  {
    public static FlatDto MapFlatToDto(Flat flat)
    {
      return new FlatDto()
      {
        Id = flat.Id,
        District = flat.District,
        Floor = flat.Floor,
        IsElevator = flat.IsElevator,
        NumberOfRooms = flat.NumberOfRooms,
        Price = flat.Price,
        SquareMeters = flat.SquareMeters,
                
        City = flat.Address?.City,
        Country = flat.Address?.Country,
        Street = flat.Address?.Street,
        ZipCode = flat.Address?.ZipCode,
      };
    }

    public static Flat MapDtoToFlat(FlatDto flat)
    {
      return new Flat()
      {
        Floor = flat.Floor,
        Price = flat.Price,
        District = flat.District,
        IsElevator = flat.IsElevator,
        SquareMeters = flat.SquareMeters,
        NumberOfRooms = flat.NumberOfRooms,
        Id = flat.Id,
                
        Address = new Address()
        {
          City = flat.City,
          Country = flat.Country,
          Street = flat.Street,
          ZipCode = flat.ZipCode,
        }
      };
    }
  }
}
*/
