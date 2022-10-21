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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ControlsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateLabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateLabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteLabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SimpleDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TableDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChartDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ControlsStripMenuItem,
            this.действияToolStripMenuItem,
            this.документыToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(763, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // ControlsStripMenuItem
            // 
            this.ControlsStripMenuItem.Name = "ControlsStripMenuItem";
            this.ControlsStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.ControlsStripMenuItem.Text = "Справочники";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateLabToolStripMenuItem,
            this.UpdateLabToolStripMenuItem,
            this.DeleteLabToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // CreateLabToolStripMenuItem
            // 
            this.CreateLabToolStripMenuItem.Name = "CreateLabToolStripMenuItem";
            this.CreateLabToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + A";
            this.CreateLabToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.CreateLabToolStripMenuItem.Text = "Создать";
            this.CreateLabToolStripMenuItem.Click += new System.EventHandler(this.CreateLabToolStripMenuItem_Click);
            // 
            // UpdateLabToolStripMenuItem
            // 
            this.UpdateLabToolStripMenuItem.Name = "UpdateLabToolStripMenuItem";
            this.UpdateLabToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + U";
            this.UpdateLabToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.UpdateLabToolStripMenuItem.Text = "Изменить";
            this.UpdateLabToolStripMenuItem.Click += new System.EventHandler(this.UpdateLabToolStripMenuItem_Click);
            // 
            // DeleteLabToolStripMenuItem
            // 
            this.DeleteLabToolStripMenuItem.Name = "DeleteLabToolStripMenuItem";
            this.DeleteLabToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + D";
            this.DeleteLabToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.DeleteLabToolStripMenuItem.Text = "Удалить";
            this.DeleteLabToolStripMenuItem.Click += new System.EventHandler(this.DeleteLabToolStripMenuItem_Click);
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SimpleDocToolStripMenuItem,
            this.TableDocToolStripMenuItem,
            this.ChartDocToolStripMenuItem});
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.документыToolStripMenuItem.Text = "Документы";
            // 
            // SimpleDocToolStripMenuItem
            // 
            this.SimpleDocToolStripMenuItem.Name = "SimpleDocToolStripMenuItem";
            this.SimpleDocToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + S";
            this.SimpleDocToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.SimpleDocToolStripMenuItem.Text = "Отчет Word";
            this.SimpleDocToolStripMenuItem.Click += new System.EventHandler(this.SimpleDocToolStripMenuItem_Click);
            // 
            // TableDocToolStripMenuItem
            // 
            this.TableDocToolStripMenuItem.Name = "TableDocToolStripMenuItem";
            this.TableDocToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + T";
            this.TableDocToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.TableDocToolStripMenuItem.Text = "Отчет PDF";
            this.TableDocToolStripMenuItem.Click += new System.EventHandler(this.TableDocToolStripMenuItem_Click);
            // 
            // ChartDocToolStripMenuItem
            // 
            this.ChartDocToolStripMenuItem.Name = "ChartDocToolStripMenuItem";
            this.ChartDocToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + C";
            this.ChartDocToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.ChartDocToolStripMenuItem.Text = "Диаграмма Excel";
            this.ChartDocToolStripMenuItem.Click += new System.EventHandler(this.ChartDocToolStripMenuItem_Click);
            // 
            // panelControl
            // 
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 24);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(763, 387);
            this.panelControl.TabIndex = 2;
            // 
            // FormMainLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 411);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMainLab";
            this.Text = "Главное меню";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMainLab_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private App.Components.MyComponents.UserControlWordTableOne wordTableOne;
        private Components.AlexandrovComponents.LinearDiagramExcelComponent linearDiagramExcelComponent;
        private Components.AntonovComponents.TablePdfComponent tablePdfComponent;
        private Components.AlexandrovComponents.ListBoxUserControl listBoxUserControl;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem ControlsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateLabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateLabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteLabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SimpleDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TableDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChartDocToolStripMenuItem;
        private System.Windows.Forms.Panel panelControl;
    }
}