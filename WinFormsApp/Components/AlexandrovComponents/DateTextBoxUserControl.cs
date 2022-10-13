using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace App.Components
{
    public partial class DateTextBoxUserControl : UserControl
    {
        private event EventHandler textChange;

        public string example = "07.09.2022";
        public string Pattern { get { return pattern; } set { pattern = value; } }
        private string pattern = @"\b(?<day>\d{1,2}).(?<month>\d{1,2}).(?<year>\d{2,4})\b";
        public string Value
        {
            get
            {
                if (Pattern != null && !Regex.IsMatch(textBox.Text, Pattern))
                {
                    throw new ArgumentException();
                }
                return textBox.Text;
            }
            set { if (Pattern != null && Regex.IsMatch(textBox.Text, Pattern)) textBox.Text = value; }
        }

        public DateTextBoxUserControl()
        {
            InitializeComponent();
            toolTip.SetToolTip(textBox, example);
            textBox.TextChanged += (sender, e) => textChange?.Invoke(sender, e);
        }

        public void SetExample(string value)
        {
            if (!String.IsNullOrEmpty(value) && !Regex.IsMatch(value, Pattern))
            {
                example = value;
                toolTip.SetToolTip(textBox, value);
            }
        }

        public event EventHandler TextChange
        {
            add { textChange += value; }
            remove { textChange -= value; }
        }
    }
}
