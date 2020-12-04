using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace Lab2
{
    class ExcelParser
    {
        static Application xlApp;
        static Workbook xlWorkBook;
        static Worksheet xlWorkSheet;
        static Range range;
        public static List<Threat> GetExcelThreats()
        {
            try
            {
                int rCnt;
                int rw = 0;
                int cl = 0;

                xlApp = new Application();
                //open the excel
                xlWorkBook = xlApp.Workbooks.Open(Environment.CurrentDirectory + @"\thrlist.xlsx");
                //get the first sheet of the excel
                xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

                range = xlWorkSheet.UsedRange;
                // get the total row count
                rw = range.Rows.Count;
                //get the total column count
                cl = range.Columns.Count;

                Threat.threats = new List<Threat>();
                Threat threat;
                // traverse all the row in the excel
                for (rCnt = 3; rCnt <= rw; rCnt++)
                {
                    threat = new Threat(xlWorkSheet.Cells[rCnt, 1].Value.ToString(),
                        xlWorkSheet.Cells[rCnt, 2].Value.ToString(),
                        xlWorkSheet.Cells[rCnt, 3].Value.ToString(),
                        xlWorkSheet.Cells[rCnt, 4].Value.ToString(),
                        xlWorkSheet.Cells[rCnt, 5].Value.ToString(),
                        xlWorkSheet.Cells[rCnt, 6].Value.ToString(),
                        xlWorkSheet.Cells[rCnt, 7].Value.ToString(),
                        xlWorkSheet.Cells[rCnt, 8].Value.ToString());
                }
                return Threat.threats;
            }
            catch
            {
                DownloadExcel();
                return GetExcelThreats();
            }
        }
        public static void SaveExcel(string dir)
        {
            xlWorkBook.SaveAs(dir + @"\thrlist.xlsx");
        }
        public static void DownloadExcel()
        {
            WebClient downloader = new WebClient();
            xlWorkBook.Close();
            downloader.DownloadFile("https://bdu.fstec.ru/files/documents/thrlist.xlsx", Environment.CurrentDirectory + @"\thrlist.xlsx");
            new MainWindow().Show();
        }
        public static void ExitExcel()
        {
            xlWorkBook.Close();
        }
        
    }
}
