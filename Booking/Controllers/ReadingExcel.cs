/*

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using OfficeOpenXml;

namespace Booking
{
  public class ReadingExcel
  {
    public static T ReadFromExcel<T>(string path, bool hasHeader = true)
    {
      using (var excelPack = new ExcelPackage())
      {
        using (var stream = File.OpenRead(path))
        {
          excelPack.Load(stream);
        }

        var ws = excelPack.Workbook.Worksheets[0];

        DataTable excelasTable = new DataTable();
        foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
        {
          if (!string.IsNullOrEmpty(firstRowCell.Text))
          {
            string firstColumn = string.Format("Column {0}", firstRowCell.Start.Column);
            excelasTable.Columns.Add(hasHeader ? firstRowCell.Text : firstColumn);
          }
        }

        var startRow = hasHeader ? 2 : 1;
        for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
        {
          var wsRow = ws.Cells[rowNum, 1, rowNum, excelasTable.Columns.Count];
          DataRow row = excelasTable.Rows.Add();
          foreach (var cell in wsRow)
          {
            row[cell.Start.Column - 1] = cell.Text;
          }
        }

        //var generatedType = JsonConvert.DeserializeObject<List<UserDetails>>(JsonConvert.SerializeObject(excelasTable));
        //return (T) Convert.ChangeType(generatedType, typeof(T));
      }
      
     
    }
    
  }

}*/