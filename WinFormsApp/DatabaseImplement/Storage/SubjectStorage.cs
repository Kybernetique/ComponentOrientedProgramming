using App.DatabaseImplement.Models;
using App.Logics.BindingModels;
using App.Logics.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DatabaseImplement.Storage
{
    public class SubjectStorage
    {
        public List<SubjectViewModel> GetFullList()
        {
            using (var context = new LabDatabase())
            {
                return context.Subjects
                .Select(CreateModel)
               .ToList();
            }
        }

        public SubjectViewModel GetElement(SubjectBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new LabDatabase())
            {
                var subject = context.Subjects
                .FirstOrDefault(rec => rec.Id == model.Id);
                return subject != null ?
                CreateModel(subject) : null;
            }
        }

        public void Insert(SubjectBindingModel model)
        {
            using (var context = new LabDatabase())
            {
                context.Subjects.Add(CreateModel(model, new Subject()));
                context.SaveChanges();
            }
        }

        public void Update(SubjectBindingModel model)
        {
            using (var context = new LabDatabase())
            {
                Subject subject = context.Subjects
                    .FirstOrDefault(rec => rec.Id == model.Id);
                if (subject == null)
                {
                    throw new Exception("Дисциплина не найдена");
                }
                CreateModel(model, subject);
                context.SaveChanges();
            }
        }

        public void Delete(SubjectBindingModel model)
        {
            using (var context = new LabDatabase())
            {
                Subject subject = context.Subjects
                    .FirstOrDefault(rec => rec.Id == model.Id);
                if (subject != null)
                {
                    context.Subjects.Remove(subject);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Дисциплина не найдена");
                }
            }
        }

        private SubjectViewModel CreateModel(Subject subject)
        {
            return new SubjectViewModel
            {
                Id = subject.Id,
                Name = subject.Name
            };
        }

        private Subject CreateModel(SubjectBindingModel model, Subject subject)
        {
            subject.Name = model.Name;
            return subject;
        }
    }
}
