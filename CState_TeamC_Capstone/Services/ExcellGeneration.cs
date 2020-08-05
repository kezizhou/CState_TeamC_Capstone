using ClosedXML.Excel;
using CState_TeamC_Capstone.DomainObjects;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;

namespace CState_TeamC_Capstone.Services
{
    public static class ExcellGeneration
    {
        public static byte[] CreateExcelDocument(List<ExcellTableExport> export)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {                
                var ws = wb.Worksheets.Add("Near Miss Reports");
                ws.Cell("A1").Value = "ID";
                ws.Cell("B1").Value = "Date Entered";
                ws.Cell("C1").Value = "Operator Name";
                ws.Cell("D1").Value = "Department";
                ws.Cell("E1").Value = "NearMiss Solution";
                ws.Cell("F1").Value = "NearMiss Action Taken";
                ws.Cell("G1").Value = "Additional Actions Taken";
                ws.Cell("H1").Value = "Near Miss Type";
                ws.Cell("I1").Value = "Assigned To";
                ws.Cell("J1").Value = "Severity Type";
                ws.Cell("K1").Value = "Risk Type";
                ws.Cell("L1").Value = "Comments";
                ws.Cell("M1").Value = "Reviewed By";
                ws.Cell("N1").Value = "Review Date";
                for (int i = 0; i < export.Count; i++)
                {
                    ws.Cell("A" + (i+2)).Value = export[i].ID;
                    ws.Cell("B" + (i + 2)).Value = export[i].DateEntered;
                    ws.Cell("C" + (i + 2)).Value = export[i].OperatorName;
                    ws.Cell("D" + (i + 2)).Value = export[i].Department;
                    ws.Cell("E" + (i + 2)).Value = export[i].NearMiss_Solution;
                    ws.Cell("F" + (i + 2)).Value = export[i].NearMiss_ActionTaken;
                    ws.Cell("G" + (i + 2)).Value = export[i].Additional_Actions_Taken;
                    ws.Cell("H" + (i + 2)).Value = export[i].NearMissType;
                    ws.Cell("I" + (i + 2)).Value = export[i].AssignedTo;
                    ws.Cell("J" + (i + 2)).Value = export[i].SeverityType;
                    ws.Cell("K" + (i + 2)).Value = export[i].RiskType;
                    ws.Cell("L" + (i + 2)).Value = export[i].Comments;
                    ws.Cell("M" + (i + 2)).Value = export[i].ReviewedBy;
                    ws.Cell("N" + (i + 2)).Value = export[i].ReviewDate;
                }
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;
                ws.Columns().AdjustToContents();
                Stream fs = new MemoryStream();
                wb.SaveAs(fs);
                fs.Position = 0;
                return fs.ToByteArray();
            }
        }
        public static byte[] ToByteArray(this Stream stream)
        {
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            for (int totalBytesCopied = 0; totalBytesCopied < stream.Length;)
                totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);
            return buffer;
        }
    }
}


