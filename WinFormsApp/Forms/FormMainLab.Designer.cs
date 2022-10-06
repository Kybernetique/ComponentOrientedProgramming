namespace App.Forms
{
    partial class FormMainLab
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.userControlListBox = new WinFormsControlLibrary.ListBox();
            this.wordTableOne = new NonVisualComponents.WordTableOne();
            this.linearDiagramExcelComponent = new App.Components.AlexandrovComponents.LinearDiagramExcelComponent(this.components);
            this.tablePdfComponent = new App.Components.AntonovComponents.TablePdfComponent(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.лабораторныеРаботыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дисциплиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.линейнаяДиаграммаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // userControlListBox
            // 
            this.userControlListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlListBox.Location = new System.Drawing.Point(0, 0);
            this.userControlListBox.Name = "userControlListBox";
            this.userControlListBox.SelectedElement = "";
            this.userControlListBox.Size = new System.Drawing.Size(763, 411);
            this.userControlListBox.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.лабораторныеРаботыToolStripMenuItem,
            this.дисциплиныToolStripMenuItem,
            this.отчётWordToolStripMenuItem,
            this.отчётPDFToolStripMenuItem,
            this.линейнаяДиаграммаToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(245, 114);
            // 
            // лабораторныеРаботыToolStripMenuItem
            // 
            this.лабораторныеРаботыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.лабораторныеРаботыToolStripMenuItem.Name = "лабораторныеРаботыToolStripMenuItem";
            this.лабораторныеРаботыToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.лабораторныеРаботыToolStripMenuItem.Text = "Лабораторные работы";
            // 
            // дисциплиныToolStripMenuItem
            // 
            this.дисциплиныToolStripMenuItem.Name = "дисциплиныToolStripMenuItem";
            this.дисциплиныToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.дисциплиныToolStripMenuItem.Text = "Дисциплины";
            this.дисциплиныToolStripMenuItem.Click += new System.EventHandler(this.дисциплиныToolStripMenuItem_Click);
            // 
            // отчётWordToolStripMenuItem
            // 
            this.отчётWordToolStripMenuItem.Name = "отчётWordToolStripMenuItem";
            this.отчётWordToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.отчётWordToolStripMenuItem.Text = "Отчёт Word (Ctrl + S)";
            // 
            // отчётPDFToolStripMenuItem
            // 
            this.отчётPDFToolStripMenuItem.Name = "отчётPDFToolStripMenuItem";
            this.отчётPDFToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.отчётPDFToolStripMenuItem.Text = "Отчёт PDF (Ctrl + T)";
            // 
            // линейнаяДиаграммаToolStripMenuItem
            // 
            this.линейнаяДиаграммаToolStripMenuItem.Name = "линейнаяДиаграммаToolStripMenuItem";
            this.линейнаяДиаграммаToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.линейнаяДиаграммаToolStripMenuItem.Text = "Линейная диаграмма (Ctrl + C)";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.создатьToolStripMenuItem.Text = "Создать (Cntrl + A)";
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить (Ctrl + U)";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить (Ctrl + D)";
            // 
            // FormMainLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 411);
            this.Controls.Add(this.userControlListBox);
            this.Name = "FormMainLab";
            this.Text = "FormMainLab";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WinFormsControlLibrary.ListBox userControlListBox;
        private NonVisualComponents.WordTableOne wordTableOne;
        private Components.AlexandrovComponents.LinearDiagramExcelComponent linearDiagramExcelComponent;
        private Components.AntonovComponents.TablePdfComponent tablePdfComponent;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem лабораторныеРаботыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дисциплиныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem линейнаяДиаграммаToolStripMenuItem;
    }
}