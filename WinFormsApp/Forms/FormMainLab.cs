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
    public partial class FormMainLab : Form
    {
        private readonly LabLogic productLogic = new LabLogic();

        public FormMainLab()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            listBoxUserControl.SetLayout("Дисциплина {Subject}, Идентификатор {Id}, Тема {Topic}," +
            " Вопросы {Question}");
            try
            {
                List<LabViewModel> list = productLogic.Read(null);
/*                listBoxUserControl.ClearListBox();
*/                foreach (LabViewModel product in list)
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
                    productLogic.Delete(new LabBindingModel { Id = product.Id });
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
            List<LabViewModel> list = productLogic.Read(null);
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
                //доделать!!!
                List<string[,]> datas = new List<string[,]>();
                int count = list.Count;
                string[,] data = new string[count, 3];
                int i = 0;
                foreach (var listItem in list)
                {
                    data[i, 0] = listItem.StudentOne;
                    data[i, 1] = listItem.StudentTwo;
                    data[i, 2] = listItem.StudentThree;
                    data[i, 2] = listItem.StudentFour;
                    data[i, 2] = listItem.StudentFive;
                    data[i, 2] = listItem.StudentSix;
                    if (i < count)
                        i++;
                }
                datas.Add(data);
                wordTableOne.SaveData(fileName, "otchet", datas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {

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

        }

        private void линейнаяДиаграммаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
