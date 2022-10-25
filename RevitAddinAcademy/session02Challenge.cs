#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
#endregion

namespace RevitAddinAcademy
{
    [Transaction(TransactionMode.Manual)]
    public class session02Challenge : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            string excelFile = @"C:\Visual Studio Files\My_Revit_Add-in_Training\02_Working_With_Excel\Revit_Add-in_Academy_Challenge_2_file\Revit Add-in Academy_Session 2 Challenge.xlsx";

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWb = excelApp.Workbooks.Open(excelFile);
            Excel.Worksheet excelWs = excelWb.Worksheets.Item[1];

            Excel.Range excelRng = excelWs.UsedRange;
            int rowCount = excelRng.Rows.Count;

            // Do stuff in Excel
            List<string[]> dataList = new List<string[]>();

            for (int i = 1; i <= rowCount; i++)
            {
                Excel.Range cell1 = excelWs.Cells[i, 1];
                Excel.Range cell2 = excelWs.Cells[i, 2];
                Excel.Range cell3 = excelWs.Cells[i, 3];

                string data1 = cell1.Value.ToString();
                string data2 = cell2.Value.ToString();
                string data3 = cell3.Value.ToString();

                string[] dataArray = new string[3];
                dataArray[0] = data1;
                dataArray[1] = data2;
                dataArray[2] = data3;

                dataList.Add(dataArray);
            }
            
            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Create New Level");
                
                Level curLevel = Level.Create(doc, 100);

                FilteredElementCollector collector = new FilteredElementCollector(doc);
                collector.OfCategory(BuiltInCategory.OST_TitleBlocks);
                collector.WhereElementIsElementType();


                ViewSheet curSheet = ViewSheet.Create(doc, collector.FirstElementId());
                curSheet.SheetNumber = "A10101012";
                curSheet.Name = "MyNewSheet";

                tx.Commit();
            }

            excelWb.Close();
            excelApp.Quit();
            return Result.Succeeded;
        }
    }
}
