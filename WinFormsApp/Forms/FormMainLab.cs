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
                // TO-DO
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
                    PropertyName = "Subject"
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
            Dictionary<string, int[]> data = new Dictionary<string, int[]>();
            data.Add("first", new int[] { 1, 2, 3, 4 });
            data.Add("second", new int[] { 2, 3, 2, 1 });
            int[] arr1 = new int[251];
            arr1[50] = 2;
            arr1[100] = 3;
            arr1[150] = 1;
            arr1[200] = 4;
            arr1[250] = 2;

            int[] arr2 = new int[251];
            arr2[50] = 2;
            arr2[100] = 2;
            arr2[150] = 2;
            arr2[200] = 1;
            arr2[250] = 4;

            data.Add("str", arr1);
            data.Add("sss", arr2);
            Tuple<double, double> axis = new Tuple<double, double>(50, 250);

            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    linearDiagramExcelComponent.Save(dialog.FileName, "Title", "Diagram", Components.AlexandrovComponents.HelperEnums.ExcelLegendPosition.Right,
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
