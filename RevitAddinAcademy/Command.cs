#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Windows.Forms;

#endregion

namespace RevitAddinAcademy
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
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

            string userName = app.Username;
            string filePath = doc.PathName;
            string date = DateTime.Now.ToString();
            string curAssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string curAssemblyFullname = System.Reflection.Assembly.GetExecutingAssembly().FullName;
            string curMethod = this.GetType().Name;

            Logger curLog = new Logger(filePath, userName);
            Globals.curLog = curLog;
            Globals.FilePath = filePath;
            Globals.UserName = userName;

            curLog.method1();
            curLog.method2();
            try
            {
                ErrorMethor();
            }
            catch (Exception ex)
            {
                curLog.method3(curAssemblyName, curMethod, ex.Message);
            }
            
            TaskDialog td = new TaskDialog("Log results");
            td.MainInstruction = "Here are the log results";
            td.MainContent = "Would you like to view the log file?";
            td.CommonButtons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No;

            TaskDialogResult result = td.Show();
            if (result == TaskDialogResult.Yes)
            {
                Process.Start("notepad.exe",curLog.Logpath);
            }

            return Result.Succeeded;
        }

        private void ErrorMethor()
        {
           throw new NotImplementedException();
        }
    }
}
