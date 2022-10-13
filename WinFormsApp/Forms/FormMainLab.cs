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

// Наши лабы
List<Lab> labs = new List<Lab>
        {
                new Lab { Id = 1, Topic = "Базы данных",Subject = "Программная инженерия", Questions= "Какие бывают базы данных?" },
                new Lab { Id = 2, Topic = "Программирование",Subject = "Программная инженерия", Questions= "Какие бывают модификаторы доступа? В чём их отличие"},
                new Lab { Id = 3,Topic = "Операционные системы", Subject = "Программная инженерия", Questions = "Что такое драйвер?"},
                new Lab { Id = 4,Topic = "Комплексные числа",Subject = "Математика", Questions="Что такое комплексное число?"},
                new Lab { Id = 5,Topic = "Булева алгебра",Subject = "Математика", Questions= "Виды логических операций"} 
        };
           

        public FormMainLab()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            listBoxUserControl.SetPreValue("{");
            listBoxUserControl.SetPostValue("}");
            listBoxUserControl.SetLayout("Дисциплина {Subject}, Идентификатор {Id}, Тема {Topic}," +
            " Вопросы {Questions}");
            try
            {
                List<LabViewModel> list = labLogic.Read(null);
                listBoxUserControl.ClearListBox();
                foreach (LabViewModel product in list)
                {
                    listBoxUserControl.AddItem<LabViewModelListBox>(new LabViewModelListBox
                    {

                        Subject = product.Subject,
                        Id = (int)product.Id,
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
                using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = dialog.FileName.ToString();
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    }
                }
                // TO-DO
                List<string[,]> datas = new List<string[,]>();
                int count = list.Count;
                string[,] data = new string[count, 6];
                int i = 0;
                foreach (var listItem in list)
                {
                    data[i, 0] = listItem.StudentOne;
                    data[i, 1] = listItem.StudentTwo;
                    data[i, 2] = listItem.StudentThree;
                    data[i, 3] = listItem.StudentFour;
                    data[i, 4] = listItem.StudentFive;
                    data[i, 5] = listItem.StudentSix;
                    if (i < count)
                        i++;
                }
                datas.Add(data);
                wordTableOne.SaveData(fileName, "Отчёт", datas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        [Obsolete]
        private void CreateDocumentPDF()
        {
            // HEAD
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
                    Text = "Дисциплина",
                    PropertyName = "Subject"
                },
                new CellPdfTable()
                {
                    Text = "Вопросы",
                    PropertyName = "Questions"
                }
            };

            using (var d = new SaveFileDialog() { Filter = "pdf|*.pdf", FileName = "Table" })
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    var componentTablePdf = new TablePdfComponent();
                    if (componentTablePdf.CreateDocument(new TablePdfParameters<Lab>()
                    {
                        Path = d.FileName,
                        Title = "Таблица",
                        DataList = labs,
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
