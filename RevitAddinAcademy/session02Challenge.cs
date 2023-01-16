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
    public class Session02Challenge : IExternalCommand
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

            int levelCounter = 0;
            int sheetCounter = 0;
            try
            {
                // Open excel
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook excelWb = excelApp.Workbooks.Open(excelFile);
                // Get the worksheets
                Excel.Worksheet excelWs1 = excelWb.Worksheets.Item[1];
                Excel.Worksheet excelWs2 = excelWb.Worksheets.Item[2];
                // Get the Range of cells in each worksheet
                Excel.Range excelRng1 = excelWs1.UsedRange;
                Excel.Range excelRng2 = excelWs2.UsedRange;
                // Get the cound of rows in each sheet
                int rowCount1 = excelRng1.Rows.Count;
                int rowCount2 = excelRng2.Rows.Count;

                // Transaction codeblock
                using (Transaction tx = new Transaction(doc))
                {
                    tx.Start("Create New Level");

                    // Loop through sheet 1 cells
                    for (int i = 2; i <= rowCount1; i++)
                    {
                        // Get current row cells data
                        Excel.Range levelData1 = excelWs1.Cells[i, 1];
                        Excel.Range levelData2 = excelWs1.Cells[i, 2];
                        
                        // Create variables from cell values
                        string levelName = levelData1.Value.ToString();
                        Double levelElev = levelData2.Value;

                        try
                        {
                            // create new levels with data from current excel cells stored in variables
                            Level newLevel = Level.Create(doc, levelElev);
                            newLevel.Name = levelName;
                            levelCounter++;
                        }
                        catch (Exception ex)
                        {
                            Debug.Print("Error crating new level !!!!: " + ex.Message);
                            //throw;
                        }
                    }

                    
                    FilteredElementCollector collector = new FilteredElementCollector(doc);
                    collector.OfCategory(BuiltInCategory.OST_TitleBlocks);
                    collector.WhereElementIsElementType();

                    // Loop through sheet 2 cells
                    for (int j = 2; j <= rowCount2; j++)
                    {
                        Excel.Range sheetData1 = excelWs2.Cells[j, 1];
                        Excel.Range sheetData2 = excelWs2.Cells[j, 2];

                        string sheetNum = sheetData1.Value.ToString();
                        string sheetName = sheetData2.Value.ToString();

                        try
                        {
                            // Create new Revit sheet from the excel data sheet
                            ViewSheet newSheet = ViewSheet.Create(doc, collector.FirstElementId());
                            newSheet.SheetNumber = sheetNum;
                            newSheet.Name = sheetName;
                            sheetCounter++;
                        }
                        catch (Exception ex)
                        {
                            Debug.Print("Error crating sheet !!!!: " + ex.Message);
                            //throw;
                        }
                    }

                    tx.Commit();
                }

                excelWb.Close();
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                Debug.Print("!!!!!!!!!!!      NO GOOD    !!!!!!!!!!!!!!!!!!");

                //Or
                TaskDialog.Show("Error", "An error occured.");
                //throw;
            }

            TaskDialog.Show("Complete", "Created: " + levelCounter.ToString() + " levels.");
            TaskDialog.Show("Complete", "Created: " + sheetCounter.ToString() + " Sheets.");


            return Result.Succeeded;
        }
    }
}
