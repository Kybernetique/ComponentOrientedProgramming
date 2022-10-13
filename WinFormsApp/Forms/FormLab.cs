using App.Logics.BindingModels;
using App.Logics.BusinessLogics;
using App.Logics.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class FormLab : Form
    {
        public int Id { set { id = value; } }
        private readonly LabLogic productLogic = new LabLogic();
        private readonly SubjectLogic unitOfMeasurementLogic = new SubjectLogic();
        private int? id;
        
        public FormLab()
        {
            InitializeComponent();
            textBoxQuestions.textTypedValue = "";
        }

        private void FormLab_Load(object sender, EventArgs e)
        {
            textBoxQuestions.minTextLength = 50;
            textBoxQuestions.maxTextLength = 250;
            List<SubjectViewModel> list = unitOfMeasurementLogic.Read(null);
            List<String> listStr = new List<String>();
            foreach (var name in list)
            {
                if (!listStr.Contains(name.Name))
                {
                    listStr.Add(name.Name);
                    listBoxSubject.AddElement(name.Name);
                }
            }

            if (id.HasValue)
            {
                try
                {
                    var view = productLogic.Read(new LabBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxTopic.Text = view.Topic;
                        listBoxSubject.ValueList = view.Subject;
                        textBoxQuestions.textTypedValue = view.Questions;
                        textBoxStudentOne.Text = view.StudentOne;
                        textBoxStudentTwo.Text = view.StudentTwo;
                        textBoxStudentThree.Text = view.StudentThree;
                        textBoxStudentFour.Text = view.StudentFour;
                        textBoxStudentFive.Text = view.StudentFive;
                        textBoxStudentSix.Text = view.StudentSix;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void changeUnit(object sender, EventArgs e)
        {
            listBoxSubject.ValueList = listBoxSubject.ValueList;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTopic.Text))
            {
                MessageBox.Show("Введите название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxStudentOne.Text))
            {
                textBoxStudentOne.Text = "Отсутсвует";
            }
            if (string.IsNullOrEmpty(textBoxStudentTwo.Text))
            {
                textBoxStudentTwo.Text = "Отсутсвует";
            }
            if (string.IsNullOrEmpty(textBoxStudentThree.Text))
            {
                textBoxStudentThree.Text = "Отсутсвует";
            }
            if (string.IsNullOrEmpty(textBoxStudentFour.Text))
            {
                textBoxStudentFour.Text = "Отсутсвует";
            }
            if (string.IsNullOrEmpty(textBoxStudentFive.Text))
            {
                textBoxStudentFive.Text = "Отсутсвует";
            }
            if (string.IsNullOrEmpty(textBoxStudentSix.Text))
            {
                textBoxStudentSix.Text = "Отсутсвует";
            }
            if (string.IsNullOrEmpty(textBoxQuestions.textTypedValue.ToString()))
            {
                MessageBox.Show("Введите вопрос", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(listBoxSubject.ValueList))
            {
                MessageBox.Show("Выберите дисциплину", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                LabBindingModel product = new LabBindingModel
                {
                    Id = id,
                    Topic = textBoxTopic.Text,
                    Questions = textBoxQuestions.textTypedValue,
                    StudentOne = textBoxStudentOne.Text,
                    StudentTwo = textBoxStudentTwo.Text,
                    StudentThree = textBoxStudentThree.Text,
                    StudentFour = textBoxStudentFour.Text,
                    StudentFive = textBoxStudentFive.Text,
                    StudentSix = textBoxStudentSix.Text,
                    Subject = listBoxSubject.ValueList.ToString(),
                };
                if (product.Id.HasValue)
                {
                    productLogic.Update(product);
                }
                else
                {
                    productLogic.Create(product);
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
