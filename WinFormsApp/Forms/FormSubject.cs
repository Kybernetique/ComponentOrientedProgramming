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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class FormSubject : Form
    {
        private readonly SubjectLogic logic = new SubjectLogic();
        List<SubjectViewModel> list;

        public FormSubject()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                list = logic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void FormSubject_Load(object sender, EventArgs e)
        {
            LoadData();

        }


        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(((DataGridView)sender).CurrentCell.EditedFormattedValue.ToString()))
            {

                if (dataGridView.CurrentRow.Cells[0].Value != null)
                {
                    var listSBM = logic.Read(new SubjectBindingModel() { Id = (int)dataGridView.CurrentRow.Cells[0].Value });
                    dataGridView.CurrentRow.Cells[1].Value = ((SubjectViewModel)listSBM[0]).Name;
                }

            }
            else
            {
                if (dataGridView.CurrentRow.Cells[0].Value != null)
                {
                    logic.Update(new SubjectBindingModel()
                    {
                        Id = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value),
                        Name = (string)dataGridView.CurrentRow.Cells[1].EditedFormattedValue
                    });
                }
                else
                {
                    logic.Create(new SubjectBindingModel()
                    {
                        Name = (string)dataGridView.CurrentRow.Cells[1].EditedFormattedValue
                    });
                }
            }

            LoadData();
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                if (dataGridView.Rows.Count == 0)
                {
                    list.Add(new SubjectViewModel());
                    dataGridView.DataSource = new List<SubjectViewModel>(list);
                    dataGridView.CurrentCell = dataGridView.Rows[0].Cells[1];
                    return;
                }
                else if (dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[1].Value != null)
                {
                    list.Add(new SubjectViewModel());
                    dataGridView.DataSource = new List<SubjectViewModel>(list);
                    dataGridView.CurrentCell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[1];
                    return;
                }
            }
            if (e.KeyData == Keys.Delete)
            {
                if (MessageBox.Show("Вы действительно хотите удалить?", "Предупреждение",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    logic.Delete(new SubjectBindingModel() { Id = (int)dataGridView.CurrentRow.Cells[0].Value });
                    list = logic.Read(null);
                    dataGridView.DataSource = new List<SubjectViewModel>(list);
                }

            }
        }
    }
}
