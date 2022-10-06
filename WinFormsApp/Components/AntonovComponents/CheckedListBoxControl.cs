using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Components.AntonovComponents
{
    public partial class CheckedListBoxControl : UserControl
    {
        private event EventHandler _listBoxSelectedElementChange;

        public CheckedListBoxControl()
        {
            InitializeComponent();
            checkedListBox.SelectedIndexChanged += (sender, e) => _listBoxSelectedElementChange?.Invoke(sender, e);
        }

        public string SelectedItem
        {
            get => checkedListBox.SelectedItem == null ? string.Empty : checkedListBox.SelectedItem.ToString();
            set => checkedListBox.SelectedItem = value;
        }
        public void addSelectionOption(string selectionData)
        {
            checkedListBox.Items.Add(selectionData);
        }

        public event EventHandler ListBoxSelectedElementChange
        {
            add { _listBoxSelectedElementChange += value; }
            remove { _listBoxSelectedElementChange -= value; }
        }
        public void ClearItems()
        {
            checkedListBox.Items.Clear();
        }
    }
}
