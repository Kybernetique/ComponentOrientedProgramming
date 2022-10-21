using System;
using System.Windows.Forms;

namespace Components.MyComponents
{
    public partial class UserControlTextBox : UserControl
    {
        public UserControlTextBox()
        {
            InitializeComponent();
        }

        // Проверка на null
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            textBox.Enabled = !checkBox.Checked;
        }

        public double? Value
        {
            get
            {
                double? el;

                if (checkBox.Checked)
                {
                    el = null;
                }
                else
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        throw new ArgumentNullException();
                    }

                    if (!double.TryParse(textBox.Text, out double elem))
                    {
                        throw new ArgumentException();
                    }

                    el = new double?(elem);
                }
                return el;
            }
            set
            {
                if (value.HasValue)
                {
                    textBox.Text = value.Value.ToString();
                }
                checkBox.Checked = !value.HasValue;
            }
        }
    }
}
