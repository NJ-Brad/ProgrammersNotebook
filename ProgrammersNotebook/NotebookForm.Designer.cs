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
            tabControl1 = new TabControl();
            tabPagePages = new TabPage();
            imageTree1 = new ImageTree();
            contextMenuStrip1 = new ContextMenuStrip(components);
            exportToolStripMenuItem = new ToolStripMenuItem();
            tabPageFragments = new TabPage();
            imageTree2 = new ImageTree();
            toolStrip1 = new ToolStrip();
            toolStripButtonAdd = new ToolStripButton();
            toolStripButtonRemove = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            markDownEditor1 = new MarkDownHelper.MarkDownEditor();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPagePages.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            tabPageFragments.SuspendLayout();
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
            button1.Location = new Point(1164, 699);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(96, 28);
            button1.TabIndex = 16;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(1268, 699);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(96, 28);
            button2.TabIndex = 17;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(tabControl1);
            panel1.Controls.Add(toolStrip1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(464, 742);
            panel1.TabIndex = 19;
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Bottom;
            tabControl1.Controls.Add(tabPagePages);
            tabControl1.Controls.Add(tabPageFragments);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 25);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(464, 717);
            tabControl1.TabIndex = 2;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPagePages
            // 
            tabPagePages.Controls.Add(imageTree1);
            tabPagePages.Location = new Point(4, 4);
            tabPagePages.Name = "tabPagePages";
            tabPagePages.Padding = new Padding(3);
            tabPagePages.Size = new Size(456, 683);
            tabPagePages.TabIndex = 0;
            tabPagePages.Text = "Pages";
            tabPagePages.UseVisualStyleBackColor = true;
            // 
            // imageTree1
            // 
            imageTree1.ContextMenuStrip = contextMenuStrip1;
            imageTree1.Dock = DockStyle.Fill;
            imageTree1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            imageTree1.FullRowSelect = true;
            imageTree1.HideSelection = false;
            imageTree1.ImageIndex = 0;
            imageTree1.LabelEdit = true;
            imageTree1.Location = new Point(3, 3);
            imageTree1.Margin = new Padding(4);
            imageTree1.Name = "imageTree1";
            imageTree1.SelectedImageIndex = 0;
            imageTree1.Size = new Size(450, 677);
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
            // tabPageFragments
            // 
            tabPageFragments.Controls.Add(imageTree2);
            tabPageFragments.Location = new Point(4, 4);
            tabPageFragments.Name = "tabPageFragments";
            tabPageFragments.Padding = new Padding(3);
            tabPageFragments.Size = new Size(456, 683);
            tabPageFragments.TabIndex = 1;
            tabPageFragments.Text = "Fragments";
            tabPageFragments.UseVisualStyleBackColor = true;
            // 
            // imageTree2
            // 
            imageTree2.ContextMenuStrip = contextMenuStrip1;
            imageTree2.Dock = DockStyle.Fill;
            imageTree2.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            imageTree2.FullRowSelect = true;
            imageTree2.HideSelection = false;
            imageTree2.ImageIndex = 0;
            imageTree2.LabelEdit = true;
            imageTree2.Location = new Point(3, 3);
            imageTree2.Margin = new Padding(4);
            imageTree2.Name = "imageTree2";
            imageTree2.SelectedImageIndex = 0;
            imageTree2.Size = new Size(450, 677);
            imageTree2.TabIndex = 2;
            imageTree2.AfterLabelEdit += imageTree2_AfterLabelEdit;
            imageTree2.AfterSelect += imageTree2_AfterSelect;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonAdd, toolStripButtonRemove });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.ShowItemToolTips = false;
            toolStrip1.Size = new Size(464, 25);
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
            splitContainer1.Margin = new Padding(4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(markDownEditor1);
            splitContainer1.Size = new Size(1398, 742);
            splitContainer1.SplitterDistance = 464;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 20;
            // 
            // markDownEditor1
            // 
            markDownEditor1.Dirty = false;
            markDownEditor1.Dock = DockStyle.Fill;
            markDownEditor1.DocumentText = "";
            markDownEditor1.EmbeddedFragmentHandler = null;
            markDownEditor1.Enabled = false;
            markDownEditor1.FileName = "";
            markDownEditor1.HandleFiles = false;
            markDownEditor1.Location = new Point(0, 0);
            markDownEditor1.Margin = new Padding(5);
            markDownEditor1.Name = "markDownEditor1";
            markDownEditor1.Size = new Size(929, 742);
            markDownEditor1.TabIndex = 1;
            markDownEditor1.ViewMode = true;
            markDownEditor1.SaveClicked += markDownEditor1_SaveClicked;
            // 
            // NotebookForm
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button2;
            ClientSize = new Size(1398, 742);
            Controls.Add(splitContainer1);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "NotebookForm";
            Text = "Programmer's Notbook";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPagePages.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            tabPageFragments.ResumeLayout(false);
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
        private TabControl tabControl1;
        private TabPage tabPagePages;
        private TabPage tabPageFragments;
        private ImageTree imageTree2;
    }
}