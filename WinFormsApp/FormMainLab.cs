using DatabaseImplement.DatabaseImplement.Models;
using DatabaseImplement.Logics.BindingModels;
using DatabaseImplement.Logics.BusinessLogics;
using DatabaseImplement.Logics.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Plugins;
using Plugins.Plugins;

namespace App
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
            PluginsManager manager = new PluginsManager();
            Dictionary<string, IPluginsConvention> dict = manager.dictionary;

            ToolStripItem[] toolStripMenuItems = new ToolStripItem[2];

            foreach (var key in dict.Keys)
            {
                ToolStripMenuItem labsToolStripMenuItem = new ToolStripMenuItem();
                labsToolStripMenuItem.Text = key;
                labsToolStripMenuItem.Click += LabsToolStripMenuItem_Click;
                toolStripMenuItems[0] = labsToolStripMenuItem;
            }

            ToolStripMenuItem subjectsToolStripMenuItem = new ToolStripMenuItem();
            subjectsToolStripMenuItem.Text = "Дисциплины";
            subjectsToolStripMenuItem.Click += SubjectsToolStripMenuItem_Click;
            toolStripMenuItems[1] = subjectsToolStripMenuItem;

            ControlsStripMenuItem.DropDownItems.AddRange(toolStripMenuItems);
            return dict;
        }

        //private void FormMainLab_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(_selectedPlugin) || !_plugins.ContainsKey(_selectedPlugin))
        //    {
        //        return;
        //    }
        //    if (!e.Control)
        //    {
        //        return;
        //    }
        //    switch (e.KeyCode)
        //    {
        //        case Keys.A:
        //            CreateLab();
        //            break;
        //        case Keys.U:
        //            UpdateLab();
        //            break;
        //        case Keys.D:
        //            DeleteLab();
        //            break;
        //        case Keys.S:
        //            CreateSimpleDoc();
        //            break;
        //        case Keys.T:
        //            CreateTableDoc();
        //            break;
        //        case Keys.C:
        //            CreateChartDoc();
        //            break;
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
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx", FileName = "1" })
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
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf", FileName = "2" })
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
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xls", FileName = "3" })
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
        }

        private void CreateLabToolStripMenuItem_Click(object sender, EventArgs e) => CreateLab();

        private void UpdateLabToolStripMenuItem_Click(object sender, EventArgs e) => UpdateLab();

        private void DeleteLabToolStripMenuItem_Click(object sender, EventArgs e) => DeleteLab();

        private void SimpleDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateSimpleDoc();

        private void TableDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateTableDoc();

        private void ChartDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateChartDoc();


    }
}
