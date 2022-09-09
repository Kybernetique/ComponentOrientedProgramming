using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            Test obj = new Test();
            obj.name = userControlTextBox2.Value.ToString();
            userControlDataGrid.AddRow(obj);

        }
    }
}
