using System;
using System.Windows.Forms;

namespace WinFormsControlLibrary
{
    public partial class ComboBoxUserControl : UserControl
    {
        private event EventHandler comboBoxSelectedElementChange;

        public string SelectedItem { 
            get { return comboBox.SelectedItem == null ? String.Empty : comboBox.SelectedItem.ToString(); } 
            set { if (comboBox.SelectedItem != null) comboBox.Items[comboBox.Items.IndexOf(comboBox.SelectedItem)] = value; } 
        }

        public ComboBoxUserControl()
        {
            InitializeComponent();
            comboBox.SelectedIndexChanged += (sender, e) => comboBoxSelectedElementChange?.Invoke(sender, e);
        }

        public void AddItem(string item)
        {
            comboBox.Items.Add(item);
        }

        public void ClearItems()
        {
            comboBox.Items.Clear();
            comboBox.SelectedIndex = -1;
            comboBox.Text = string.Empty;
        }

        public void DeleteSelected()
        {
            comboBox.Items.Remove(comboBox.SelectedItem);
            comboBox.SelectedIndex = -1;
            comboBox.Text = string.Empty;
        }

        public event EventHandler ComboBoxSelectedElementChange
        {
            add { comboBoxSelectedElementChange += value; }
            remove { comboBoxSelectedElementChange -= value; }
        }
    }
}
