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
    public class SubjectLogic
    {
        private readonly SubjectStorage subjectStorage = new SubjectStorage();

        public SubjectLogic()
        {

        }

        public List<SubjectViewModel> Read(SubjectBindingModel model)
        {
            if (model == null)
            {
                return subjectStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SubjectViewModel> { subjectStorage.GetElement(model) };
            }
            return null;
        }

        public void Create(SubjectBindingModel model)
        {
            subjectStorage.Insert(model);
        }

        public void Update(SubjectBindingModel model)
        {
            var element = subjectStorage.GetElement(new SubjectBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            subjectStorage.Update(model);
        }

        public void Delete(SubjectBindingModel model)
        {
            var element = subjectStorage.GetElement(new SubjectBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            subjectStorage.Delete(model);
        }
    }
}
