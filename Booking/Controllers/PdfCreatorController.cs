using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Booking.Core.Services;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Booking.Utility;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfCreatorController : ControllerBase
    {
        private IConverter _converter;

        public PdfCreatorController(IConverter converter, IGuestService guestService)
        {
            _converter = converter;
            _guestService = guestService;
        }
        private readonly IGuestService _guestService;

        
        [HttpGet("GetInvoice/{Id}")]
        public IActionResult CreatePDF(long id)
        {
          var guest = _guestService.GetById(id);
          
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                //Out = @"D:\PDFCreator\Employee_Report.pdf"  USE THIS PROPERTY TO SAVE PDF TO A PROVIDED LOCATION
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(guest),
                //Page = "https://code-maze.com/", USE THIS PROPERTY TO GENERATE PDF CONTENT FROM AN HTML PAGE
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 25, Right = "Gdynia, "+ DateTime.Now.ToString("dd.MM.yyyy"), Line = true },
                FooterSettings = { FontName = "Arial", FontSize =25, Line = true, Center = "MODERN PLACE" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            //_converter.Convert(pdf); IF WE USE Out PROPERTY IN THE GlobalSettings CLASS, THIS IS ENOUGH FOR CONVERSION

            var file = _converter.Convert(pdf);
            string invoiceName = "Faktura nr " + DateTime.Now.ToString("dd.MM.yyyy")+"-"+DateTime.Now.Millisecond+".pdf";
            
            //return Ok("Successfully created PDF document.");
            
            return File(file, "application/pdf", invoiceName);
            //return File(file, "application/pdf");

        }
    }
}