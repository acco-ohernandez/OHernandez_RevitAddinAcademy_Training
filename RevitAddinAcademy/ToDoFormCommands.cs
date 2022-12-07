#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
#endregion

namespace RevitAddinAcademy
{
    [Transaction(TransactionMode.Manual)]
    public class ToDoFormCommands : IExternalCommand
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

            frmToDo curForm = new frmToDo(doc.PathName);
            curForm.TopMost = true;
            curForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            curForm.Show();

            return Result.Succeeded;
        }
    }
}
