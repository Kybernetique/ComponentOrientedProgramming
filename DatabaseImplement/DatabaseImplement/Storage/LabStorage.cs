using DatabaseImplement.DatabaseImplement.Models;
using DatabaseImplement.Logics.BindingModels;
using DatabaseImplement.Logics.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.DatabaseImplement.Storage
{
    public class LabStorage
    {
        public List<LabViewModel> GetFullList()
        {
            using (var context = new LabDatabase())
            {
                return context.Labs
                .Select(CreateModel)
               .ToList();
            }
        }

        public LabViewModel GetElement(LabBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new LabDatabase())
            {
                var lab = context.Labs
                .FirstOrDefault(rec => rec.Id == model.Id);
                return lab != null ?
                CreateModel(lab) : null;
            }
        }

        public void Insert(LabBindingModel model)
        {
            using (var context = new LabDatabase())
            {
                context.Labs.Add(CreateModel(model, new Lab()));
                context.SaveChanges();
            }
        }

        public void Update(LabBindingModel model)
        {
            using (var context = new LabDatabase())
            {
                Lab lab = context.Labs
                    .FirstOrDefault(rec => rec.Id == model.Id);
                if (lab == null)
                {
                    throw new Exception("Продукт не найден");
                }
                CreateModel(model, lab);
                context.SaveChanges();
            }
        }

        public void Delete(LabBindingModel model)
        {
            using (var context = new LabDatabase())
            {
                Lab lab = context.Labs
                    .FirstOrDefault(rec => rec.Id == model.Id);
                if (lab != null)
                {
                    context.Labs.Remove(lab);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Продукт не найден");
                }
            }
        }

        private LabViewModel CreateModel(Lab lab)
        {
            return new LabViewModel
            {
                Id = lab.Id,
                Topic = lab.Topic,
                StudentOne = lab.StudentOne,
                StudentTwo = lab.StudentTwo,
                StudentThree = lab.StudentThree,
                StudentFour = lab.StudentFour,
                StudentFive = lab.StudentFive,
                StudentSix = lab.StudentSix, 
                Subject = lab.Subject,
                Questions= lab.Questions
            };
        }

        private Lab CreateModel(LabBindingModel model, Lab lab)
        {
            lab.Topic = model.Topic;
            lab.Subject = model.Subject;
            lab.Questions= model.Questions;
            lab.StudentOne = model.StudentOne;
            lab.StudentTwo = model.StudentTwo;
            lab.StudentThree = model.StudentThree;
            lab.StudentFour = model.StudentFour;
            lab.StudentFive = model.StudentFive;
            lab.StudentSix = model.StudentSix; 
            return lab;
        }
    }
}
