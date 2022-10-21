using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Components.MyComponents
{
    public partial class UserControlListBox : UserControl
    {
        public string ValueList
        {
            set
            {
                listBox1.Text = value;
            }
            get { return listBox1.Text; }
        }

        public UserControlListBox()
        {
            InitializeComponent();
        }

        // Метод из задания
        public void AddElement(string element)
        {
            if (!string.IsNullOrEmpty(element))
            {
                listBox1.Items.Add(element);
            }
        }

        public void Clear()
        {
            listBox1.Items.Clear();
            listBox1.ResetText();
        }

        public string SelectedElement
        {
            get
            {
                return (listBox1.SelectedIndex >= 0 ? listBox1.SelectedItem.ToString() : string.Empty);
            }
            set
            {
                listBox1.SelectedItem = value;
            }
        }

        public event EventHandler ChangeElement
        {
            add
            {
                listBox1.SelectedIndexChanged += value;
            }
            remove
            {
                listBox1.SelectedIndexChanged -= value;
            }
        }
    }
}
