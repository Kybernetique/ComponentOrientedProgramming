namespace Components.AntonovComponents
{
    partial class TextBoxLengthControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox = new System.Windows.Forms.TextBox();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(4, 5);
            this.textBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(225, 31);
            this.textBox.TabIndex = 0;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(41, 41);
            this.labelError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 25);
            this.labelError.TabIndex = 1;
            // 
            // TextBoxLengthControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.textBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TextBoxLengthControl";
            this.Size = new System.Drawing.Size(243, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label labelError;
    }
}
