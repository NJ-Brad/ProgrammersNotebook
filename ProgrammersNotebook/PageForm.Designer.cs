using MarkDownHelper;

namespace ProgrammersNotebook
{
    partial class PageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageForm));
            contextMenuStrip1 = new ContextMenuStrip(components);
            exportToolStripMenuItem = new ToolStripMenuItem();
            markDownEditor1 = new MarkDownEditor();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { exportToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(115, 26);
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(114, 22);
            exportToolStripMenuItem.Text = "Export";
            // 
            // markDownEditor1
            // 
            markDownEditor1.Dirty = false;
            markDownEditor1.Dock = DockStyle.Fill;
            markDownEditor1.DocumentText = "";
            markDownEditor1.DocumentTitle = "";
            markDownEditor1.EmbeddedFragmentHandler = null;
            markDownEditor1.Enabled = false;
            markDownEditor1.FileName = "";
            markDownEditor1.HandleFiles = false;
            markDownEditor1.Location = new Point(0, 0);
            markDownEditor1.Margin = new Padding(5);
            markDownEditor1.Name = "markDownEditor1";
            markDownEditor1.Size = new Size(965, 742);
            markDownEditor1.TabIndex = 1;
            markDownEditor1.ViewMode = MarkDownEditor.EditorMode.ViewEdit;
            markDownEditor1.SaveClicked += markDownEditor1_SaveClicked;
            // 
            // PageForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(965, 742);
            Controls.Add(markDownEditor1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "PageForm";
            Text = "Programmer's Notbook";
            FormClosing += PageForm_FormClosing;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        //private Tools.ActionItems.ActionItemWidgetControl actionItemWidgetControl1;
        //private Tools.Notes.NotesWidgetControl notesWidgetControl1;
        //private Tools.People.PeopleWidgetControl peopleWidgetControl1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem exportToolStripMenuItem;
        private MarkDownHelper.MarkDownEditor markDownEditor1;
    }
}