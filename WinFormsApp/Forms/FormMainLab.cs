using App.Components.AlexandrovComponents.HelperModels;
using App.Components.AntonovComponents;
using App.Components.AntonovComponents.HelperModels;
using App.DatabaseImplement.Models;
using App.Logics.BindingModels;
using App.Logics.BusinessLogics;
using App.Logics.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class FormMainLab : Form
    {
        private readonly LabLogic labLogic = new LabLogic();

        public FormMainLab()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            listBoxUserControl.SetPreValue("{");
            listBoxUserControl.SetPostValue("}");
            listBoxUserControl.SetLayout("Дисциплина: {Subject}," +
                " Идентификатор: {Id}, Тема: {Topic}, Вопросы: {Questions}");
            try
            {
                List<LabViewModel> list = labLogic.Read(null);
                listBoxUserControl.ClearListBox();
                foreach (LabViewModel product in list)
                {
                    listBoxUserControl.AddItem<LabViewModelListBox>(new LabViewModelListBox
                    {

                        Subject = product.Subject,
                        Id = product.Id,
                        Topic = product.Topic,
                        Questions = product.Questions,
                        StudentOne = product.StudentOne,
                        StudentTwo = product.StudentTwo,
                        StudentThree = product.StudentThree,
                        StudentFour = product.StudentFour,
                        StudentFive = product.StudentFive,
                        StudentSix = product.StudentSix
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void CreateLab()
        {
            try
            {
                FormLab form = new FormLab();
                form.ShowDialog();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void DeleteLab()
        {
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    LabViewModelListBox product = listBoxUserControl.GetSelected<LabViewModelListBox>();
                    labLogic.Delete(new LabBindingModel { Id = product.Id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void EditLab()
        {
            try
            {
                LabViewModelListBox lab = listBoxUserControl.GetSelected<LabViewModelListBox>();
                FormLab form = new FormLab();
                form.Id = (int)lab.Id;
                form.ShowDialog();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void дисциплиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSubject form = new FormSubject();
            form.ShowDialog();
            LoadData();
        }

        private void CreateDocumentWord()
        {
            List<LabViewModel> list = labLogic.Read(null);
            string fileName = "";
            try
            {
                using (var dialog = new SaveFileDialog { Filter = "docx|*.docx", FileName = "1" })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = dialog.FileName.ToString();
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    }
                }
                List<string[,]> table = new List<string[,]>();
                int count = list.Count;
                string[,] students = new string[count, 6];
                int i = 0;
                foreach (var listItem in list)
                {
                    students[i, 0] = listItem.StudentOne;
                    students[i, 1] = listItem.StudentTwo;
                    students[i, 2] = listItem.StudentThree;
                    students[i, 3] = listItem.StudentFour;
                    students[i, 4] = listItem.StudentFive;
                    students[i, 5] = listItem.StudentSix;
                    if (i < count)
                        i++;
                }
                table.Add(students);
                wordTableOne.SaveData(fileName, "Отчёт", table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void CreateDocumentPDF()
        {
            List<LabViewModel> labListViewModel = labLogic.Read(null);
            List<Lab> labList = new List<Lab>();
            foreach (var lab in labListViewModel)
            {
                labList.Add
                (
                    new Lab()
                    {
                        Id = lab.Id,
                        Topic = lab.Topic,
                        Subject = lab.Subject,
                        Questions = lab.Questions
                    }
                );
            }
            var columnTablePdfFirst = new List<CellPdfTable>
            {
                new CellPdfTable()
                {
                    Text = "Идентификатор",
                    PropertyName = "Id"
                },
                new CellPdfTable()
                {
                    Text = "Тема",
                    PropertyName = "Topic"
                },

                new CellPdfTable()
                {
                    Text = "Описание",
                    CountCells = 2
                },
                new CellPdfTable()
                {
                    Text = "Дисциплина",
                    PropertyName = "Subject",
                },
                new CellPdfTable()
                {
                    Text = "Вопросы",
                    PropertyName = "Questions"
                }
            };

            using (var d = new SaveFileDialog() { Filter = "pdf|*.pdf", FileName = "2" })
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    var componentTablePdf = new TablePdfComponent();
                    if (componentTablePdf.CreateDocument(new TablePdfParameters<Lab>()
                    {
                        Path = d.FileName,
                        Title = "Таблица",
                        DataList = labList,
                        CellsFirstColumn = columnTablePdfFirst,
                        TitleTextSize = 14,
                        ContentTextSize = 10
                    }))
                    {
                        MessageBox.Show("Файл был создан успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(componentTablePdf.ErrorMessageString, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CreateDiagramExcel()
        {
            Dictionary<string, int[]> data =
                new Dictionary<string, int[]>();
            Tuple<double, double> axis = new Tuple<double, double>(1, 4);

            List<LabViewModel> labListViewModel = labLogic.Read(null);
            List<Lab> labList = new List<Lab>();
            foreach (var lab in labListViewModel)
            {
                labList.Add
                (
                    new Lab()
                    {
                        Id = lab.Id,
                        Topic = lab.Topic,
                        Subject = lab.Subject,
                        Questions = lab.Questions
                    }
                );
            }

            int[] result = new int[4];
            int questionLength;
            foreach (var lab in labList)
            {
                questionLength = lab.Questions.Length;
                if (questionLength >= 50 && questionLength < 101)
                {
                    result[0]++;
                }
                else if (questionLength >= 100 && questionLength < 151)
                {
                    result[1]++;
                }
                else if (questionLength >= 150 && questionLength < 201)
                {
                    result[2]++;
                }
                else if (questionLength >= 200 && questionLength < 251)
                {
                    result[3]++;
                }
            }

            int[] arr0 = new int[4];
            int[] arr1 = new int[4];
            int[] arr2 = new int[4];
            int[] arr3 = new int[4];

            arr0[0] = result[0];
            arr1[1] = result[1];
            arr2[2] = result[2];
            arr3[3] = result[3];

            data.Add("50-100", arr0);
            data.Add("100-150", arr1);
            data.Add("150-200", arr2);
            data.Add("200-250", arr3);

            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx", FileName = "3" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    linearDiagramExcelComponent.Save(dialog.FileName, "Title", "Диаграмма", Components.AlexandrovComponents.HelperEnums.ExcelLegendPosition.TopRight,
                        data, axis);

                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
        }

        private void FormMainLab_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateLab();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditLab();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteLab();
        }

        private void отчётWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDocumentWord();
        }

        private void отчётPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDocumentPDF();
        }

        private void линейнаяДиаграммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDiagramExcel();
        }
    }
}
