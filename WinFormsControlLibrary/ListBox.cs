using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsControlLibrary
{
    public partial class ListBox : UserControl
    {
        public ListBox()
        {
            InitializeComponent();
        }

        // Метод из задания
        public void AddElement(string element)
        {
            if (!string.IsNullOrEmpty(element))
            {
                listBox.Items.Add(element);
            }
        }

        public void Clear()
        {
            listBox.Items.Clear();
        }

        public string SelectedElement
        {
            get
            {
                return (listBox.SelectedIndex >= 0 ? listBox.SelectedItem.ToString() : string.Empty);
            }
            set
            {
                listBox.SelectedItem = value;
            }
        }

        public event EventHandler ChangeElement
        {
            add
            {
                listBox.SelectedIndexChanged += value;
            }
            remove
            {
                listBox.SelectedIndexChanged -= value;
            }
        }
    }
}
