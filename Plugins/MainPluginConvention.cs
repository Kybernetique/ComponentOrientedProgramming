using Tools.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using DatabaseImplement.Logics.BusinessLogics;
using System.Windows.Forms;
using DatabaseImplement.Logics.BindingModels;
using DatabaseImplement.Logics.ViewModels;
using DatabaseImplement.DatabaseImplement.Models;
using Components.MyComponents;
using Components.MyComponents.HelperModels;
using Components.AntonovComponents;
using Components.AntonovComponents.HelperModels;
using Components.AlexandrovComponents;

namespace Plugins
{
    [Export(typeof(IPluginsConvention))]
    public class MainPluginConvention : IPluginsConvention
    {
        public string PluginName { get { return "Лабораторные работы"; } }

        public PluginsConventionElement GetElement { get { return dataGridView.GetSelectedObjectIntoRow<PluginsConventionElement>(); } }
        
        private UserControlDataGrid dataGridView = new UserControlDataGrid();

        public UserControl GetControl { get { return dataGridView; } }

        public string PluginVersion => throw new NotImplementedException();

        private LabLogic labLogic = new LabLogic();

        private SubjectLogic subjectLogic = new SubjectLogic();

        public MainPluginConvention()
        {
              dataGridView.AddColumns(new List<TableData>() {
                new TableData() { Header = "Дисциплина", PropertyName = "Subject", Visible = true, Width = 100},
                new TableData() { Header = "Тема", PropertyName = "Topic", Visible = true, Width = 100},
                new TableData() { Header = "Вопросы", PropertyName = "Questions", Visible = true, Width = 200 },
                new TableData() { Header = "Идентификатор", PropertyName = "Id", Visible = true, Width = 50}
                 });
            ReloadData();
        }




        public bool DeleteElement(PluginsConventionElement element)
        {
            try
            {
                labLogic.Delete(new LabBindingModel() { Id = element.Id });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void ReloadData()
        {
            dataGridView.ClearDataGrid();
            var rows = labLogic.Read(null);
            for (int i = 0; i < rows.Count(); ++i)
            {
                dataGridView.AddRow(new LabConventionElement()
                {
                    Id = rows[i].Id,
                    Topic = rows[i].Topic,
                    Subject = rows[i].Subject,
                    Questions = rows[i].Questions
                });
            }
        }
        public Form GetForm(PluginsConventionElement element)
        {
            FormLab formLab = new FormLab();
            if (element != null)
            {
                formLab.Id = element.Id;
            }
            return formLab;
        }

        public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                UserControlWordTableOne tablesComponent = new UserControlWordTableOne();
                var labs = labLogic.Read(null);
                List<string[,]> table = new List<string[,]>();
                int count = labs.Count;
                string[,] students = new string[count, 6];
                int i = 0;

                string[,] strings = new string[labs.Count + 1, 3];
                foreach (var listItem in labs)
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
                tablesComponent.SaveData(saveDocument.FileName, "Отчёт", table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                List<LabViewModel> labListViewModel = labLogic.Read(null);
                TablePdfComponent tablePdfComponent = new TablePdfComponent();
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
                tablePdfComponent.CreateDocument(new TablePdfParameters<LabViewModel>()
                {
                    Path = saveDocument.FileName,
                    Title = "Лабораторные работы",
                    CellsFirstColumn = columnTablePdfFirst,
                    DataList = labListViewModel
                });
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
        {
            LinearDiagramExcelComponent linearDiagramExcelComponent 
                = new LinearDiagramExcelComponent();
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

            linearDiagramExcelComponent.Save(saveDocument.FileName,
                "Title", "Диаграмма", Components.AlexandrovComponents.HelperEnums.ExcelLegendPosition.TopRight,
            data, axis);

            return true;
        }
    }
}
