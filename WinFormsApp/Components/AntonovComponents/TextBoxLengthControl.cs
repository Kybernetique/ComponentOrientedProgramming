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
    public partial class TextBoxLengthControl : UserControl
    {
        private event EventHandler _textBoxTextChanged;
        public int? minTextLength { get; set; }
        public int? maxTextLength { get; set; }
        private string successMessage = "Все верно";
        private string errorMessage = "Неверно ввели!";
        public string textTypedValue
        {
            get
            {
                if (minTextLength.HasValue && maxTextLength.HasValue)
                {
                    if (textBox.Text.Length > minTextLength && textBox.Text.Length < maxTextLength)
                    {
                        labelError.Text = successMessage;
                        return textBox.Text;
                    }
                    else
                    {
                        labelError.Text = errorMessage;
                        return null;
                    }
                }
                else
                    return null;
            }
            set
            {
                if (minTextLength != null && maxTextLength != null)
                {
                    if (value.Length > minTextLength && value.Length < maxTextLength) // before: textBox.Text.Length > minTextLength && textBox.Text.Length < maxTextLength
                    {
                        textBox.Text = value;
                    }
                }
            }
        }
        public TextBoxLengthControl()
        {
            InitializeComponent();
            textBox.TextChanged += (sender, e) => _textBoxTextChanged?.Invoke(sender, e);
        }
        public event EventHandler textBoxSelectedElementChange
        {
            add { _textBoxTextChanged += value; }
            remove { _textBoxTextChanged -= value; }
        }
    }
}
