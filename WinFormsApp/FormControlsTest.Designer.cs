namespace WinFormsApp
{
    partial class FormControlsTest
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userControlListBox = new WinFormsControlLibrary.UserControlListBox();
            this.buttonAddToList = new System.Windows.Forms.Button();
            this.userControlTextBox1 = new WinFormsControlLibrary.UserControlTextBox();
            this.userControlDataGrid = new WinFormsControlLibrary.UserControlDataGrid();
            this.SuspendLayout();
            // 
            // userControlListBox
            // 
            this.userControlListBox.Location = new System.Drawing.Point(12, 78);
            this.userControlListBox.Name = "userControlListBox";
            this.userControlListBox.SelectedElement = "";
            this.userControlListBox.Size = new System.Drawing.Size(314, 146);
            this.userControlListBox.TabIndex = 0;
            // 
            // buttonAddToList
            // 
            this.buttonAddToList.Location = new System.Drawing.Point(87, 49);
            this.buttonAddToList.Name = "buttonAddToList";
            this.buttonAddToList.Size = new System.Drawing.Size(75, 23);
            this.buttonAddToList.TabIndex = 1;
            this.buttonAddToList.Text = "Add To List";
            this.buttonAddToList.UseVisualStyleBackColor = true;
            this.buttonAddToList.Click += new System.EventHandler(this.buttonAddToList_Click);
            // 
            // userControlTextBox1
            // 
            this.userControlTextBox1.Location = new System.Drawing.Point(12, 12);
            this.userControlTextBox1.Name = "userControlTextBox1";
            this.userControlTextBox1.Size = new System.Drawing.Size(231, 31);
            this.userControlTextBox1.TabIndex = 2;
            // 
            // userControlDataGrid
            // 
            this.userControlDataGrid.Location = new System.Drawing.Point(453, 12);
            this.userControlDataGrid.Name = "userControlDataGrid";
            this.userControlDataGrid.Size = new System.Drawing.Size(282, 250);
            this.userControlDataGrid.TabIndex = 3;
            this.userControlDataGrid.Load += new System.EventHandler(this.userControlDataGrid_Load);
            // 
            // FormControlsTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 281);
            this.Controls.Add(this.userControlDataGrid);
            this.Controls.Add(this.userControlTextBox1);
            this.Controls.Add(this.buttonAddToList);
            this.Controls.Add(this.userControlListBox);
            this.Name = "FormControlsTest";
            this.Text = "Тест";
            this.ResumeLayout(false);

        }

        #endregion

        private WinFormsControlLibrary.UserControlListBox userControlListBox;
        private System.Windows.Forms.Button buttonAddToList;
        private WinFormsControlLibrary.UserControlTextBox userControlTextBox1;
        private WinFormsControlLibrary.UserControlDataGrid userControlDataGrid;
    }
}
