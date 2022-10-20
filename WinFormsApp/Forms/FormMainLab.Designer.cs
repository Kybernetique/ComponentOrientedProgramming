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
            this.wordTableOne = new NonVisualComponents.WordTableOne();
            this.linearDiagramExcelComponent = new App.Components.AlexandrovComponents.LinearDiagramExcelComponent(this.components);
            this.tablePdfComponent = new App.Components.AntonovComponents.TablePdfComponent(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.лабораторныеРаботыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дисциплиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.линейнаяДиаграммаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxUserControl = new App.Components.AlexandrovComponents.ListBoxUserControl();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.лабораторныеРаботыToolStripMenuItem,
            this.дисциплиныToolStripMenuItem,
            this.отчётWordToolStripMenuItem,
            this.отчётPDFToolStripMenuItem,
            this.линейнаяДиаграммаToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(293, 164);
            // 
            // лабораторныеРаботыToolStripMenuItem
            // 
            this.лабораторныеРаботыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.лабораторныеРаботыToolStripMenuItem.Name = "лабораторныеРаботыToolStripMenuItem";
            this.лабораторныеРаботыToolStripMenuItem.Size = new System.Drawing.Size(292, 32);
            this.лабораторныеРаботыToolStripMenuItem.Text = "Лабораторные работы";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + A";
            this.создатьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.создатьToolStripMenuItem.Text = "Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + U";
            this.изменитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + D";
            this.удалитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // дисциплиныToolStripMenuItem
            // 
            this.дисциплиныToolStripMenuItem.Name = "дисциплиныToolStripMenuItem";
            this.дисциплиныToolStripMenuItem.Size = new System.Drawing.Size(292, 32);
            this.дисциплиныToolStripMenuItem.Text = "Дисциплины";
            this.дисциплиныToolStripMenuItem.Click += new System.EventHandler(this.дисциплиныToolStripMenuItem_Click);
            // 
            // отчётWordToolStripMenuItem
            // 
            this.отчётWordToolStripMenuItem.Name = "отчётWordToolStripMenuItem";
            this.отчётWordToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + S";
            this.отчётWordToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.отчётWordToolStripMenuItem.Size = new System.Drawing.Size(292, 32);
            this.отчётWordToolStripMenuItem.Text = "Отчёт Word";
            this.отчётWordToolStripMenuItem.Click += new System.EventHandler(this.отчётWordToolStripMenuItem_Click);
            // 
            // отчётPDFToolStripMenuItem
            // 
            this.отчётPDFToolStripMenuItem.Name = "отчётPDFToolStripMenuItem";
            this.отчётPDFToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + T";
            this.отчётPDFToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.отчётPDFToolStripMenuItem.Size = new System.Drawing.Size(292, 32);
            this.отчётPDFToolStripMenuItem.Text = "Отчёт PDF";
            this.отчётPDFToolStripMenuItem.Click += new System.EventHandler(this.отчётPDFToolStripMenuItem_Click);
            // 
            // линейнаяДиаграммаToolStripMenuItem
            // 
            this.линейнаяДиаграммаToolStripMenuItem.Name = "линейнаяДиаграммаToolStripMenuItem";
            this.линейнаяДиаграммаToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + C";
            this.линейнаяДиаграммаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.линейнаяДиаграммаToolStripMenuItem.Size = new System.Drawing.Size(292, 32);
            this.линейнаяДиаграммаToolStripMenuItem.Text = "Диаграмма Excel";
            this.линейнаяДиаграммаToolStripMenuItem.Click += new System.EventHandler(this.линейнаяДиаграммаToolStripMenuItem_Click);
            // 
            // listBoxUserControl
            // 
            this.listBoxUserControl.ContextMenuStrip = this.contextMenuStrip;
            this.listBoxUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxUserControl.Location = new System.Drawing.Point(0, 0);
            this.listBoxUserControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxUserControl.Name = "listBoxUserControl";
            this.listBoxUserControl.SelectedIndex = -1;
            this.listBoxUserControl.Size = new System.Drawing.Size(1090, 685);
            this.listBoxUserControl.TabIndex = 1;
            // 
            // FormMainLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 685);
            this.Controls.Add(this.listBoxUserControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMainLab";
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.FormMainLab_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
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
        private Components.AlexandrovComponents.ListBoxUserControl listBoxUserControl;
    }
}