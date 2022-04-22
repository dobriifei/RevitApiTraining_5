
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitApiTraining_5
{
   public class MainVeiwNewModel
    {
        private ExternalCommandData _commandData;

        public DelegateCommand SelectCommand { get; }

        public MainVeiwNewModel(ExternalCommandData commandData)
        {
            _commandData = commandData;
            SelectCommand = new DelegateCommand(OnSelectCommand);
        }

        public event EventHandler CloseRequest;
        private void RaiseCloseRequest()
        {
            CloseRequest?.Invoke(this, EventArgs.Empty);
        }

        private void OnSelectCommand()
        {
            RaiseCloseRequest();
            UIApplication uiapp = _commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var selectedObject = uidoc.Selection.PickObject(ObjectType.Element, "выберите элемент");
            var oElement = doc.GetElement(selectedObject);

            TaskDialog.Show("сообщение", $"ID:{oElement.Id}");
        }
    }
}
