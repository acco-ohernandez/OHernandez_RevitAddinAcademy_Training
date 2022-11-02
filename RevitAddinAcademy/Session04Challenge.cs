#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
#endregion

// Video: https://www.archsmarter.com/products/revit-add-in-academy/categories/2151099270/posts/2162072520
namespace RevitAddinAcademy
{
    [Transaction(TransactionMode.Manual)]
    public class Session04Challenge : IExternalCommand
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

            IList<Element> pickList = uidoc.Selection.PickElementsByRectangle("Select Elements");

            Level         curLevel       = GetLevelByName(doc, "Level 1");
            MEPSystemType pipeSystemType = GetMEPSystemTypeByName(doc, "Domestic Hot Water");
            MEPSystemType duckSystemType = GetMEPSystemTypeByName(doc, "Supply Air");
            PipeType      pipeType       = GetPipeTypeByName(doc, "Default");
            DuctType      ductType       = GetDuctTypeByName(doc, "Default");
            WallType      wallType1      = GetWallTypeByName(doc, @"Generic - 8""");
            WallType      wallType2      = GetWallTypeByName(doc, "Storefront");


            foreach (Element element in pickList)
            {
                if (element is CurveElement)
                {
                    


                }
            }

            // Modify document within a transaction

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Transaction Name");
                tx.Commit();
            }
            
            return Result.Succeeded;
        }

        private WallType GetWallTypeByName(Document doc, string typeName)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(WallType));

            foreach (Element element in collector)
            {
                WallType curType = element as WallType;

                if (curType.Name == typeName)
                {
                    return curType;
                }
            }

            return null;
        }

        private DuctType GetDuctTypeByName(Document doc, string typeName)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(DuctType));

            foreach (Element element in collector)
            {
                DuctType curType = element as DuctType;

                if (curType.Name == typeName)
                {
                    return curType;
                }
            }

            return null;
        }

        private PipeType GetPipeTypeByName(Document doc, string typeName)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(PipeType));

            foreach (Element element in collector)
            {
                PipeType curType = element as PipeType;

                if (curType.Name == typeName)
                {
                    return curType;
                }
            }

            return null;
        }

        private MEPSystemType GetMEPSystemTypeByName(Document doc, string typeName)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(MEPSystemType));

            foreach (Element element in collector)
            {
                MEPSystemType curType = element as MEPSystemType;

                if (curType.Name == typeName)
                {
                    return curType;
                }
            }

            return null;
        }

        private Level GetLevelByName(Document doc, string levelName)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(Level));
            collector.WhereElementIsNotElementType();


            foreach (Element element in collector)
            {
                Level curType = element as Level;

                if (curType.Name == levelName)
                {
                    return curType;
                }
            }

            return null;
        }
    }
}
