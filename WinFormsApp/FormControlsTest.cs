using App;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NonVisualComponents;
using NonVisualComponents.HelperModels;
using WinFormsControlLibrary;

namespace WinFormsApp
{
    public partial class FormControlsTest : Form
    {
        public FormControlsTest()
        {
            InitializeComponent();
        }

        private void buttonAddToList_Click(object sender, EventArgs e)
        {
            userControlListBox.AddElement(userControlTextBox1.Value.ToString());
        }

        private void userControlDataGrid_Load(object sender, EventArgs e)
        {
            ColumnsDataGrid column = new ColumnsDataGrid();
            column.CountColumn = 1;
            column.NameColumn = new string[] { "name" };
            column.Width = new int[] { 450 };
            column.Visible = new bool[] { true, true };
            column.PropertiesObject = new string[] { "name" };

            userControlDataGrid.ConfigColumn(column);
        }

        private void buttonAddToTable_Click(object sender, EventArgs e)
        {
            Lab1 obj = new Lab1();
            obj.name = userControlTextBox2.Value.ToString();
            userControlDataGrid.AddRow(obj);

        }

        private void buttonSaveStorage_Click(object sender, EventArgs e)
        {
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
            List<string[,]> datas = new List<string[,]>();
            string[,] data = new string[,] 
            {
                { "Иванов ИИ", "Николаев НН" },
                { "Сергеев СС", "Петров ПП" }
            };
            datas.Add(data);
            wordTableFirst.SaveData(fileName, "отчёт", datas);
        }

        private void buttonHistogram_Click(object sender, EventArgs e)
        {
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
            List<Test> data = new List<Test>();
            data.Add(new Test { name = "123", value =312 });
            data.Add(new Test { name = "456", value=654});
            data.Add(new Test { name = "789", value=987 });
            data.Add(new Test { name = "101112", value= 121110});
            data.Add(new Test { name = "aaaaa", value = 999999 });
            Legend legend = new Legend();
            wordHistogram.ReportSaveGistogram(fileName, "histogram", "histogram", legend, data);
        }

        private void buttonSaveСustomizableData_Click(object sender, EventArgs e)
        {
            Data data = new Data();
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
            wordTableSecond.SaveData<Test>(new WordTableConfig<Test>
            {
                WordInfo = new WordInfo
                {
                    FileName = fileName,
                    Title = "Тестовые данные"
                },
                ColumnsWidth = data.getColumnsWidth(2, 2400),
                RowsHeight = data.getRowsHeight(5, 1000),
                Headers = data.GetHeader(2),
                PropertiesQueue = data.GetHeader(2),
                ListData = data.GetTests()
            });
        }
    }
}
