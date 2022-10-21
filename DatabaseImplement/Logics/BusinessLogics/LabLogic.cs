using DatabaseImplement.DatabaseImplement.Storage;
using DatabaseImplement.Logics.BindingModels;
using DatabaseImplement.Logics.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Logics.BusinessLogics
{
    public class LabLogic
    {
        private readonly LabStorage labStorage = new LabStorage();

        public LabLogic()
        {

        }

        public List<LabViewModel> Read(LabBindingModel model)
        {
            if (model == null)
            {
                return labStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<LabViewModel> { labStorage.GetElement(model) };
            }
            return null;
        }

        public void Create(LabBindingModel model)
        {
            labStorage.Insert(model);
        }

        public void Update(LabBindingModel model)
        {
            var element = labStorage.GetElement(new LabBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            labStorage.Update(model);
        }

        public void Delete(LabBindingModel model)
        {
            var element = labStorage.GetElement(new LabBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            labStorage.Delete(model);
        }
    }
}
