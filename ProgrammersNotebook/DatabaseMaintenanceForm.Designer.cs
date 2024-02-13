namespace ProgrammersNotebook
{
    partial class DatabaseMaintenanceForm
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
            tabControl1 = new TabControl();
            tabPageSqlite = new TabPage();
            groupBox1 = new GroupBox();
            buttonDelete = new Button();
            buttonRevert = new Button();
            listViewBackups = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            buttonImport = new Button();
            buttonExport = new Button();
            buttonBackup = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPageSqlite.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageSqlite);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 426);
            tabControl1.TabIndex = 0;
            // 
            // tabPageSqlite
            // 
            tabPageSqlite.Controls.Add(groupBox1);
            tabPageSqlite.Controls.Add(buttonImport);
            tabPageSqlite.Controls.Add(buttonExport);
            tabPageSqlite.Controls.Add(buttonBackup);
            tabPageSqlite.Controls.Add(textBox1);
            tabPageSqlite.Controls.Add(label1);
            tabPageSqlite.Location = new Point(4, 29);
            tabPageSqlite.Name = "tabPageSqlite";
            tabPageSqlite.Padding = new Padding(3);
            tabPageSqlite.Size = new Size(768, 393);
            tabPageSqlite.TabIndex = 0;
            tabPageSqlite.Text = "SQLite";
            tabPageSqlite.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonDelete);
            groupBox1.Controls.Add(buttonRevert);
            groupBox1.Controls.Add(listViewBackups);
            groupBox1.Location = new Point(113, 131);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(649, 256);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Backups";
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(393, 72);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(140, 40);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonRevert
            // 
            buttonRevert.Location = new Point(393, 26);
            buttonRevert.Name = "buttonRevert";
            buttonRevert.Size = new Size(140, 40);
            buttonRevert.TabIndex = 1;
            buttonRevert.Text = "Revert To";
            buttonRevert.UseVisualStyleBackColor = true;
            buttonRevert.Click += buttonRevert_Click;
            // 
            // listViewBackups
            // 
            listViewBackups.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listViewBackups.Location = new Point(6, 26);
            listViewBackups.Name = "listViewBackups";
            listViewBackups.Size = new Size(372, 224);
            listViewBackups.TabIndex = 0;
            listViewBackups.UseCompatibleStateImageBehavior = false;
            listViewBackups.View = View.Details;
            listViewBackups.ColumnClick += listViewBackups_ColumnClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Backup Date";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Size";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "File Name";
            // 
            // buttonImport
            // 
            buttonImport.Location = new Point(259, 85);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(140, 40);
            buttonImport.TabIndex = 5;
            buttonImport.Text = "Import";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(259, 39);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(140, 40);
            buttonExport.TabIndex = 4;
            buttonExport.Text = "Export";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // buttonBackup
            // 
            buttonBackup.Location = new Point(113, 39);
            buttonBackup.Name = "buttonBackup";
            buttonBackup.Size = new Size(140, 40);
            buttonBackup.TabIndex = 2;
            buttonBackup.Text = "Create Backup";
            buttonBackup.UseVisualStyleBackColor = true;
            buttonBackup.Click += buttonBackup_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(113, 6);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(649, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 9);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 0;
            label1.Text = "File Name:";
            // 
            // DatabaseMaintenanceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DatabaseMaintenanceForm";
            ShowInTaskbar = false;
            Text = "Database Maintenance";
            tabControl1.ResumeLayout(false);
            tabPageSqlite.ResumeLayout(false);
            tabPageSqlite.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageSqlite;
        private TextBox textBox1;
        private Label label1;
        private GroupBox groupBox1;
        private Button buttonRevert;
        private ListView listViewBackups;
        private Button buttonImport;
        private Button buttonExport;
        private Button buttonBackup;
        private Button buttonDelete;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
    }
}