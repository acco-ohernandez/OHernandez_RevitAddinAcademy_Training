using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAddinAcademy
{
    internal static class Utils
    {
        public static void method1()
        {
            TaskDialog.Show("test", "The current user is " + Globals.UserName);
        }

        public static void method2()
        {
            try
            {

            }
            catch (Exception)
            {
                Globals.curLog.method3();
                throw;
            }
        }

    }
}
