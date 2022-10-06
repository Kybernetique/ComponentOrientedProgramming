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
    public partial class FormMainLab : Form
    {
        public FormMainLab()
        {
            InitializeComponent();
        }

/*        private void LoadData()
        {
            userControlListBox.AddTemplate("Страна {Country}, Идентификатор {Id}, Название продукта {name}," +
            " Единица измерения {UnitOfMeasurement}", '{', '}');
            try
            {
                List<ProductViewModel> list = productLogic.Read(null);
                userControlListBox1.ClearListBox();
                foreach (ProductViewModel product in list)
                {
                    userControlListBox1.AddObjectToListBox<ProductViewModelListBoxData>(new ProductViewModelListBoxData
                    {

                        Id = (int)product.Id,
                        name = product.name,
                        Country = product.Country,
                        UnitOfMeasurement = product.UnitOfMeasurement,
                        SupplierOne = product.SupplierOne,
                        SupplierTwo = product.SupplierTwo,
                        SupplierThree = product.SupplierThree
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }*/

        private void дисциплиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSubject form = new FormSubject();
            form.ShowDialog();
/*            LoadData();
*/        }
    }
}
