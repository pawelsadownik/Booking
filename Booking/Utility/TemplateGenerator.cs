using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Booking.Contract.DTO;
using Booking.Infrastructure.Model;

namespace Booking.Utility
{
  public static class TemplateGenerator
  {
    public static string GetHTMLString(Task<GuestDto> guest)
    {
      var customer = guest;

      //var sb = new StringBuilder();
      //sb.Append(customer.Result.Email);
      DataTable dt = new DataTable();
      dt.Columns.AddRange(new DataColumn[9] { 
        new DataColumn("Lp.",typeof(string)),
        new DataColumn("Nr rezerwacji",typeof(string)),
        new DataColumn("Nazwa uslugi", typeof(string)),
        new DataColumn("Podstawa prawna",typeof(string)),
        new DataColumn("PKWIU",typeof(string)),
        new DataColumn("Jm",typeof(string)),
        new DataColumn("Zameldowanie",typeof(string)),
        new DataColumn("Wymeldowanie",typeof(string)),
        new DataColumn("Cena",typeof(string))
        
      });
      dt.Rows.Add(1,customer.Result.ReservationNumber,
                                       "Wynajem",
                                       "Art. 113 Ust. 1 i 9",
                                       " ",
                                       "Doba",
                                       customer.Result.CheckIn,
                                       customer.Result.CheckOut,
                                       customer.Result.Price+"zl");
      dt.Rows.Add(2,customer.Result.ReservationNumber,
        "Sprzatanie",
        "Art. 113 Ust. 1 i 9",
        " ",
        "Szt.",
        customer.Result.CheckIn,
        customer.Result.CheckOut,
        "40zl");
     
      
 
      StringBuilder sb = new StringBuilder();
      sb.Append("<h1 style='font-size: 70pt;font-family:Arial'>");

      sb.AppendLine("<br/>");
      sb.AppendLine("<br/>");
      sb.AppendLine("<br/>");
     
      
      sb.Append("<h1 style='font-size: 70pt;font-family:Arial'>FAKTURA NR  " + customer.Result.CheckOut.ToString("dd/MM/yyyy"));
      sb.AppendLine("<br/>");
      sb.AppendLine("<br/>");
      sb.AppendLine("<br/>");
      //Table II
      sb.Append("<table cellpadding='5' cellspacing='0'  style='border: 1px solid black;font-size: 40pt;font-family:Arial'>");
      sb.Append("<tr>");
      sb.Append("<th style='background-color: lightgrey;border: 1px solid black'>" + "Termin Platnosci" + "</th>");
      sb.Append("<th style='background-color: lightgrey;border: 1px solid black'>" + "Forma Platnosci" + "</th>");
      sb.Append("</tr>");
      
      sb.Append("<tr>");
      sb.Append("<th style='background-color: white;border: 1px solid black'>" + customer.Result.CheckOut.AddMonths(1)+"</th>");
      sb.Append("<th style='background-color: white; border: 1px solid black'>"+"Przelew"+"</th>");
      sb.Append("</tr>");
      sb.Append("</table>");

      sb.AppendLine("<br/>");
      sb.AppendLine("<br/>");
      //Table III
     sb.Append("<table cellpadding='5' cellspacing='0'  style='border: 1px solid black;font-size: 40pt;font-family:Arial'>");
      sb.Append("<tr>");
        sb.Append("<th style='background-color: lightgrey;border: 1px solid black'>" + "SPRZEDAWCA" + "</th>");
        sb.Append("<th style='background-color: lightgrey;border: 1px solid black'>" + "NABYWCA" + "</th>");
      sb.Append("</tr>");
      
      sb.Append("<tr>");
        sb.Append("<th style='background-color: white;border: 1px solid black'>"+"Natalia Sadownik Modern Place"+"<br/>"+ "ul. Karpinskiego 8/7"+"<br/>"+ "81-173 Gdynia"+"<br/>"+ "NIP 5882212929"+"</th>");
        sb.Append("<th style='background-color: white; border: 1px solid black'>"+customer.Result.CompanyName+" "+customer.Result.FirstName+" "+customer.Result.LastName+"<br/>"+ "NIP: "+customer.Result.Nip+"</th>");
      sb.Append("</tr>");
     sb.Append("</table>");

     sb.AppendLine("<br/>");
     sb.AppendLine("<br/>");
     
  
      //Table wih datastart.
      sb.Append("<table cellpadding='5' cellspacing='0' style='border: 1px solid black;font-size: 40pt;font-family:Arial'>");
 
      //Adding HeaderRow.
      sb.Append("<tr>");
      foreach (DataColumn column in dt.Columns)
      {
        sb.Append("<th style='background-color: lightgrey;border: 1px solid black'>" + column.ColumnName + "</th>");
      }
      sb.Append("</tr>");
 
 
      //Adding DataRow.
      foreach (DataRow row in dt.Rows)
      {
        sb.Append("<tr>");
        foreach (DataColumn column in dt.Columns)
        {
          sb.Append("<td style='width:100px;border: 1px solid #ccc'>" + row[column.ColumnName].ToString() + "</td>");
        }
        sb.Append("</tr>");
      }
 
      //Table end.
      sb.Append("</table>");
      sb.AppendLine("<br/>");
      sb.AppendLine("<br/>");

      decimal kwota = customer.Result.Price + 40;

      sb.Append("DO ZAPLATY: " + kwota+ "zl");
      sb.AppendLine("<br/>");
      sb.AppendLine("<br/>");
      sb.AppendLine("<br/>");
      sb.AppendLine("<br/>");
      sb.Append("Fakture wystawil: ");
      sb.AppendLine("<br/>");
      sb.AppendLine("<br/>");
      return sb.ToString();
    }
  }
}