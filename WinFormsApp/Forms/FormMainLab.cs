using App.Components.AlexandrovComponents.HelperModels;
using App.Components.AntonovComponents;
using App.Components.AntonovComponents.HelperModels;
using App.DatabaseImplement.Models;
using App.Logics.BindingModels;
using App.Logics.BusinessLogics;
using App.Logics.ViewModels;
using App.Plugins;
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
        private readonly Dictionary<string, IPluginsConvention> _plugins;
        private string _selectedPlugin;

        public FormMainLab()
        {
            InitializeComponent();
            _plugins = LoadPlugins();
            _selectedPlugin = string.Empty;
        }


        private Dictionary<string, IPluginsConvention> LoadPlugins()
        {
            // TODO Заполнить IPluginsConvention
            // TODO Заполнить пункт меню "Справочники" на основе
            // IPluginsConvention.PluginName;
            // TODO Например, создавать ToolStripMenuItem, привязывать к ним обработку
            // событий и добавлять в menuStrip
            // TODO При выборе пункта меню получать UserControl и заполнять элемент
            // panelControl этим контролом на всю площадь
            // Пример: panelControl.Controls.Clear(); panelControl.Controls.Add(ctrl);
            var dic = new Dictionary<string, IPluginsConvention>();
            var mainPlugin = new MainPluginConvention();
            dic.Add(mainPlugin.PluginName, mainPlugin);

            ToolStripItem[] toolStripMenuItems = new ToolStripItem[2];
            ToolStripMenuItem labsToolStripMenuItem = new ToolStripMenuItem();
            labsToolStripMenuItem.Text = mainPlugin.PluginName;
            labsToolStripMenuItem.Click += LabsToolStripMenuItem_Click;
            toolStripMenuItems[0] = labsToolStripMenuItem;

            ToolStripMenuItem subjectsToolStripMenuItem = new ToolStripMenuItem();
            subjectsToolStripMenuItem.Text = "Дисциплины";
            subjectsToolStripMenuItem.Click += SubjectsToolStripMenuItem_Click;
            toolStripMenuItems[1] = subjectsToolStripMenuItem;

            ControlsStripMenuItem.DropDownItems.AddRange(toolStripMenuItems);
            return dic;
        }

        private void FormMainLab_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedPlugin) || !_plugins.ContainsKey(_selectedPlugin))
            {
                return;
            }
            if (!e.Control)
            {
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.A:
                    CreateLab();
                    break;
                case Keys.U:
                    UpdateLab();
                    break;
                case Keys.D:
                    DeleteLab();
                    break;
                case Keys.S:
                    CreateSimpleDoc();
                    break;
                case Keys.T:
                    CreateTableDoc();
                    break;
                case Keys.C:
                    CreateChartDoc();
                    break;
            }
        }

        //private void LoadData()
        //{
        //    listBoxUserControl.SetPreValue("{");
        //    listBoxUserControl.SetPostValue("}");
        //    listBoxUserControl.SetLayout("Дисциплина: {Subject}," +
        //        " Идентификатор: {Id}, Тема: {Topic}, Вопросы: {Questions}");
        //    try
        //    {
        //        List<LabViewModel> list = labLogic.Read(null);
        //        listBoxUserControl.ClearListBox();
        //        foreach (LabViewModel product in list)
        //        {
        //            listBoxUserControl.AddItem<LabViewModelListBox>(new LabViewModelListBox
        //            {

        //                Subject = product.Subject,
        //                Id = product.Id,
        //                Topic = product.Topic,
        //                Questions = product.Questions,
        //                StudentOne = product.StudentOne,
        //                StudentTwo = product.StudentTwo,
        //                StudentThree = product.StudentThree,
        //                StudentFour = product.StudentFour,
        //                StudentFive = product.StudentFive,
        //                StudentSix = product.StudentSix
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
        //        MessageBoxIcon.Error);
        //    }
        //}

        private void CreateLab()
        {
            var form = _plugins[_selectedPlugin].GetForm(null);
            if (form != null && form.ShowDialog() == DialogResult.OK)
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }

        private void UpdateLab()
        {
            var lab = _plugins[_selectedPlugin].GetElement;
            if (lab == null)
            {
                MessageBox.Show("Нет выбранного элемента", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = _plugins[_selectedPlugin].GetForm(lab);
            if (form != null && form.ShowDialog() == DialogResult.OK)
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }

        private void DeleteLab()
        {
            if (MessageBox.Show("Удалить выбранный элемент", "Удаление",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            var element = _plugins[_selectedPlugin].GetElement;
            if (element == null)
            {
                MessageBox.Show("Нет выбранного элемента", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_plugins[_selectedPlugin].DeleteElement(element))
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }

        private void CreateSimpleDoc()
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx"})
            {
                if (dialog.ShowDialog() == DialogResult.OK && _plugins[_selectedPlugin].CreateSimpleDocument(
                    new PluginsConventionSaveDocument()
                    {
                        FileName = dialog.FileName
                    }))
                {
                    MessageBox.Show("Документ сохранен", "Создание документа",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при создании документа", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CreateTableDoc()
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf"})
            {
                if (dialog.ShowDialog() == DialogResult.OK && _plugins[_selectedPlugin].CreateTableDocument(
                    new PluginsConventionSaveDocument()
                {
                    FileName = dialog.FileName
                }))
                {
                    MessageBox.Show("Документ сохранен", "Создание документа",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при создании документа", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CreateChartDoc()
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xls"})
            {
                if (dialog.ShowDialog() == DialogResult.OK && _plugins[_selectedPlugin].CreateChartDocument(new
                    PluginsConventionSaveDocument()
                {
                    FileName = dialog.FileName
                }))
                {
                    MessageBox.Show("Документ сохранен", "Создание документа",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при создании документа", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LabsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _selectedPlugin = "Лабораторные работы";
            panelControl.Controls.Clear();
            panelControl.Controls.Add(_plugins[_selectedPlugin].GetControl);
            panelControl.Controls[0].Dock = DockStyle.Fill;
        }

        private void SubjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSubject form = new FormSubject();
            form.ShowDialog();
            //LoadData();
        }

        private void CreateLabToolStripMenuItem_Click(object sender, EventArgs e) => CreateLab();

        private void UpdateLabToolStripMenuItem_Click(object sender, EventArgs e) => UpdateLab();

        private void DeleteLabToolStripMenuItem_Click(object sender, EventArgs e) => DeleteLab();

        private void SimpleDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateSimpleDoc();

        private void TableDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateTableDoc();

        private void ChartDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateChartDoc();


    }
}
