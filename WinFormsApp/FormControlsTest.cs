using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsControlLibrary.HelperModel;

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

        private void buttonAddToTable_Click(object sender, EventArgs e)
        {

        }

        /*        private void buttonAddToTable_Click(object sender, EventArgs e)
                {
                    userControlDataGrid.LoadColumns(new List<TableConfig>
                    {
                        new TableConfig(){ 
                            Header = "Name",
                            Width= 150,
                            Visible = true,
                            PropertyName = "Name1",
                        }
                    });
                    userControlDataGrid.AddElement("Object");
                }*/
    }
}
