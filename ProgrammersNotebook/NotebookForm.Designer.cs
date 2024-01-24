namespace ProgrammersNotebook
{
    partial class NotebookForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotebookForm));
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            imageTree1 = new ImageTree();
            contextMenuStrip1 = new ContextMenuStrip(components);
            exportToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripButtonAdd = new ToolStripButton();
            toolStripButtonRemove = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            markDownEditor1 = new MarkDownHelper.MarkDownEditor();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(905, 566);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 16;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(986, 566);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 17;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(imageTree1);
            panel1.Controls.Add(toolStrip1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(361, 601);
            panel1.TabIndex = 19;
            // 
            // imageTree1
            // 
            imageTree1.ContextMenuStrip = contextMenuStrip1;
            imageTree1.Dock = DockStyle.Fill;
            imageTree1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            imageTree1.HideSelection = false;
            imageTree1.ImageIndex = 0;
            imageTree1.LabelEdit = true;
            imageTree1.Location = new Point(0, 25);
            imageTree1.Name = "imageTree1";
            imageTree1.SelectedImageIndex = 0;
            imageTree1.Size = new Size(361, 576);
            imageTree1.TabIndex = 1;
            imageTree1.AfterLabelEdit += imageTree1_AfterLabelEdit;
            imageTree1.AfterSelect += imageTree1_AfterSelect;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { exportToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(115, 26);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(114, 22);
            exportToolStripMenuItem.Text = "Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonAdd, toolStripButtonRemove });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.ShowItemToolTips = false;
            toolStrip1.Size = new Size(361, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            toolStripButtonAdd.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonAdd.Image = (Image)resources.GetObject("toolStripButtonAdd.Image");
            toolStripButtonAdd.ImageTransparentColor = Color.Magenta;
            toolStripButtonAdd.Name = "toolStripButtonAdd";
            toolStripButtonAdd.Size = new Size(36, 22);
            toolStripButtonAdd.Text = "Add";
            toolStripButtonAdd.Click += toolStripButtonAdd_Click;
            // 
            // toolStripButtonRemove
            // 
            toolStripButtonRemove.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonRemove.Image = (Image)resources.GetObject("toolStripButtonRemove.Image");
            toolStripButtonRemove.ImageTransparentColor = Color.Magenta;
            toolStripButtonRemove.Name = "toolStripButtonRemove";
            toolStripButtonRemove.Size = new Size(59, 22);
            toolStripButtonRemove.Text = "Remove";
            toolStripButtonRemove.Click += toolStripButtonRemove_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(markDownEditor1);
            splitContainer1.Size = new Size(1087, 601);
            splitContainer1.SplitterDistance = 361;
            splitContainer1.TabIndex = 20;
            // 
            // markDownEditor1
            // 
            markDownEditor1.Dirty = false;
            markDownEditor1.Dock = DockStyle.Fill;
            markDownEditor1.DocumentText = "";
            markDownEditor1.EmbeddedFragmentHandler = null;
            markDownEditor1.FileName = "";
            markDownEditor1.HandleFiles = false;
            markDownEditor1.Location = new Point(0, 0);
            markDownEditor1.Margin = new Padding(4);
            markDownEditor1.Name = "markDownEditor1";
            markDownEditor1.Size = new Size(722, 601);
            markDownEditor1.TabIndex = 1;
            markDownEditor1.ViewMode = true;
            markDownEditor1.SaveClicked += markDownEditor1_SaveClicked;
            // 
            // NotebookForm
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button2;
            ClientSize = new Size(1087, 601);
            Controls.Add(splitContainer1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "NotebookForm";
            Text = "Programmer's Notbook";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private Panel panel1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonRemove;
        //private Tools.ActionItems.ActionItemWidgetControl actionItemWidgetControl1;
        //private Tools.Notes.NotesWidgetControl notesWidgetControl1;
        //private Tools.People.PeopleWidgetControl peopleWidgetControl1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem exportToolStripMenuItem;
        private SplitContainer splitContainer1;
        private ImageTree imageTree1;
        private ToolStripButton toolStripButtonAdd;
        private MarkDownHelper.MarkDownEditor markDownEditor1;
    }
}