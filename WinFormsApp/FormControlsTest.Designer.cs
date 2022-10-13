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
            this.components = new System.ComponentModel.Container();
            this.userControlListBox = new WinFormsControlLibrary.ListBox();
            this.buttonAddToList = new System.Windows.Forms.Button();
            this.userControlTextBox1 = new WinFormsControlLibrary.TextBox();
            this.userControlDataGrid = new WinFormsControlLibrary.DataGrid();
            this.userControlTextBox2 = new WinFormsControlLibrary.TextBox();
            this.buttonAddToTable = new System.Windows.Forms.Button();
            this.buttonSaveStorage = new System.Windows.Forms.Button();
            this.buttonHistogram = new System.Windows.Forms.Button();
            this.buttonSaveСustomizableData = new System.Windows.Forms.Button();
            this.wordTableFirst = new NonVisualComponents.WordTableFirst();
            this.wordTableSecond = new NonVisualComponents.WordTableSecond(this.components);
            this.wordHistogram = new NonVisualComponents.WordHistogram();
            this.SuspendLayout();
            // 
            // userControlListBox
            // 
            this.userControlListBox.Location = new System.Drawing.Point(17, 130);
            this.userControlListBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.userControlListBox.Name = "userControlListBox";
            this.userControlListBox.SelectedElement = "";
            this.userControlListBox.Size = new System.Drawing.Size(459, 243);
            this.userControlListBox.TabIndex = 0;
            // 
            // buttonAddToList
            // 
            this.buttonAddToList.Location = new System.Drawing.Point(17, 81);
            this.buttonAddToList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddToList.Name = "buttonAddToList";
            this.buttonAddToList.Size = new System.Drawing.Size(213, 38);
            this.buttonAddToList.TabIndex = 1;
            this.buttonAddToList.Text = "Добавить в список";
            this.buttonAddToList.UseVisualStyleBackColor = true;
            this.buttonAddToList.Click += new System.EventHandler(this.buttonAddToList_Click);
            // 
            // userControlTextBox1
            // 
            this.userControlTextBox1.Location = new System.Drawing.Point(17, 20);
            this.userControlTextBox1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.userControlTextBox1.Name = "userControlTextBox1";
            this.userControlTextBox1.Size = new System.Drawing.Size(330, 52);
            this.userControlTextBox1.TabIndex = 2;
            // 
            // userControlDataGrid
            // 
            this.userControlDataGrid.Location = new System.Drawing.Point(649, 130);
            this.userControlDataGrid.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.userControlDataGrid.Name = "userControlDataGrid";
            this.userControlDataGrid.Size = new System.Drawing.Size(372, 229);
            this.userControlDataGrid.TabIndex = 3;
            this.userControlDataGrid.Load += new System.EventHandler(this.userControlDataGrid_Load);
            // 
            // userControlTextBox2
            // 
            this.userControlTextBox2.Location = new System.Drawing.Point(649, 14);
            this.userControlTextBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userControlTextBox2.Name = "userControlTextBox2";
            this.userControlTextBox2.Size = new System.Drawing.Size(363, 45);
            this.userControlTextBox2.TabIndex = 4;
            // 
            // buttonAddToTable
            // 
            this.buttonAddToTable.Location = new System.Drawing.Point(649, 81);
            this.buttonAddToTable.Name = "buttonAddToTable";
            this.buttonAddToTable.Size = new System.Drawing.Size(214, 38);
            this.buttonAddToTable.TabIndex = 5;
            this.buttonAddToTable.Text = "Добавить в таблицу";
            this.buttonAddToTable.UseVisualStyleBackColor = true;
            this.buttonAddToTable.Click += new System.EventHandler(this.buttonAddToTable_Click);
            // 
            // buttonSaveStorage
            // 
            this.buttonSaveStorage.Location = new System.Drawing.Point(331, 384);
            this.buttonSaveStorage.Name = "buttonSaveStorage";
            this.buttonSaveStorage.Size = new System.Drawing.Size(457, 34);
            this.buttonSaveStorage.TabIndex = 6;
            this.buttonSaveStorage.Text = "Сохранить";
            this.buttonSaveStorage.UseVisualStyleBackColor = true;
            this.buttonSaveStorage.Click += new System.EventHandler(this.buttonSaveStorage_Click);
            // 
            // buttonHistogram
            // 
            this.buttonHistogram.Location = new System.Drawing.Point(331, 424);
            this.buttonHistogram.Name = "buttonHistogram";
            this.buttonHistogram.Size = new System.Drawing.Size(457, 34);
            this.buttonHistogram.TabIndex = 7;
            this.buttonHistogram.Text = "Гистограмма";
            this.buttonHistogram.UseVisualStyleBackColor = true;
            this.buttonHistogram.Click += new System.EventHandler(this.buttonHistogram_Click);
            // 
            // buttonSaveСustomizableData
            // 
            this.buttonSaveСustomizableData.Location = new System.Drawing.Point(331, 464);
            this.buttonSaveСustomizableData.Name = "buttonSaveСustomizableData";
            this.buttonSaveСustomizableData.Size = new System.Drawing.Size(457, 34);
            this.buttonSaveСustomizableData.TabIndex = 8;
            this.buttonSaveСustomizableData.Text = "Сохранить настраиваемую таблицу";
            this.buttonSaveСustomizableData.UseVisualStyleBackColor = true;
            this.buttonSaveСustomizableData.Click += new System.EventHandler(this.buttonSaveСustomizableData_Click);
            // 
            // FormControlsTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 637);
            this.Controls.Add(this.buttonSaveСustomizableData);
            this.Controls.Add(this.buttonHistogram);
            this.Controls.Add(this.buttonSaveStorage);
            this.Controls.Add(this.buttonAddToTable);
            this.Controls.Add(this.userControlTextBox2);
            this.Controls.Add(this.userControlDataGrid);
            this.Controls.Add(this.userControlTextBox1);
            this.Controls.Add(this.buttonAddToList);
            this.Controls.Add(this.userControlListBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormControlsTest";
            this.Text = "Тест";
            this.ResumeLayout(false);

        }

        #endregion

        private WinFormsControlLibrary.ListBox userControlListBox;
        private System.Windows.Forms.Button buttonAddToList;
        private WinFormsControlLibrary.TextBox userControlTextBox1;
        private WinFormsControlLibrary.DataGrid userControlDataGrid;
        private WinFormsControlLibrary.TextBox userControlTextBox2;
        private System.Windows.Forms.Button buttonAddToTable;
        private System.Windows.Forms.Button buttonSaveStorage;
        private System.Windows.Forms.Button buttonHistogram;
        private System.Windows.Forms.Button buttonSaveСustomizableData;
        private NonVisualComponents.WordTableFirst wordTableFirst;
        private NonVisualComponents.WordTableSecond wordTableSecond;
        private NonVisualComponents.WordHistogram wordHistogram;
    }
}
