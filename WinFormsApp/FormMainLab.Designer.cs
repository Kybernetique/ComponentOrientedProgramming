namespace App
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ControlsStripMenuItem,
            this.действияToolStripMenuItem,
            this.документыToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1066, 35);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // ControlsStripMenuItem
            // 
            this.ControlsStripMenuItem.Name = "ControlsStripMenuItem";
            this.ControlsStripMenuItem.Size = new System.Drawing.Size(139, 29);
            this.ControlsStripMenuItem.Text = "Справочники";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateLabToolStripMenuItem,
            this.UpdateLabToolStripMenuItem,
            this.DeleteLabToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(103, 29);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // CreateLabToolStripMenuItem
            // 
            this.CreateLabToolStripMenuItem.Name = "CreateLabToolStripMenuItem";
            this.CreateLabToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + A";
            this.CreateLabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.CreateLabToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.CreateLabToolStripMenuItem.Text = "Создать";
            this.CreateLabToolStripMenuItem.Click += new System.EventHandler(this.CreateLabToolStripMenuItem_Click);
            // 
            // UpdateLabToolStripMenuItem
            // 
            this.UpdateLabToolStripMenuItem.Name = "UpdateLabToolStripMenuItem";
            this.UpdateLabToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + U";
            this.UpdateLabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.UpdateLabToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.UpdateLabToolStripMenuItem.Text = "Изменить";
            this.UpdateLabToolStripMenuItem.Click += new System.EventHandler(this.UpdateLabToolStripMenuItem_Click);
            // 
            // DeleteLabToolStripMenuItem
            // 
            this.DeleteLabToolStripMenuItem.Name = "DeleteLabToolStripMenuItem";
            this.DeleteLabToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + D";
            this.DeleteLabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.DeleteLabToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
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
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(121, 29);
            this.документыToolStripMenuItem.Text = "Документы";
            // 
            // SimpleDocToolStripMenuItem
            // 
            this.SimpleDocToolStripMenuItem.Name = "SimpleDocToolStripMenuItem";
            this.SimpleDocToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + S";
            this.SimpleDocToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SimpleDocToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.SimpleDocToolStripMenuItem.Text = "Отчет Word";
            this.SimpleDocToolStripMenuItem.Click += new System.EventHandler(this.SimpleDocToolStripMenuItem_Click);
            // 
            // TableDocToolStripMenuItem
            // 
            this.TableDocToolStripMenuItem.Name = "TableDocToolStripMenuItem";
            this.TableDocToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + T";
            this.TableDocToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.TableDocToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.TableDocToolStripMenuItem.Text = "Отчет PDF";
            this.TableDocToolStripMenuItem.Click += new System.EventHandler(this.TableDocToolStripMenuItem_Click);
            // 
            // ChartDocToolStripMenuItem
            // 
            this.ChartDocToolStripMenuItem.Name = "ChartDocToolStripMenuItem";
            this.ChartDocToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + C";
            this.ChartDocToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.ChartDocToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.ChartDocToolStripMenuItem.Text = "Диаграмма Excel";
            this.ChartDocToolStripMenuItem.Click += new System.EventHandler(this.ChartDocToolStripMenuItem_Click);
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.pictureBox1);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 35);
            this.panelControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(1066, 728);
            this.panelControl.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::App.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1066, 728);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormMainLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 763);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMainLab";
            this.Text = "Главное меню";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Components.MyComponents.UserControlWordTableOne wordTableOne;
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
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}