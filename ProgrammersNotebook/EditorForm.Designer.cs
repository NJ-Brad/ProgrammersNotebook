namespace ProgrammersNotebook
{
    partial class EditorForm
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
            markDownDisplay1 = new MarkDownHelper.MarkDownDisplay();
            SuspendLayout();
            // 
            // markDownDisplay1
            // 
            markDownDisplay1.Dock = DockStyle.Fill;
            markDownDisplay1.FileName = null;
            markDownDisplay1.Location = new Point(0, 0);
            markDownDisplay1.Margin = new Padding(5);
            markDownDisplay1.Name = "markDownDisplay1";
            markDownDisplay1.ReadOnly = false;
            markDownDisplay1.Size = new Size(800, 450);
            markDownDisplay1.TabIndex = 1;
            // 
            // EditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(markDownDisplay1);
            Name = "EditorForm";
            Text = "EditorForm";
            ResumeLayout(false);
        }

        #endregion

        private MarkDownHelper.MarkDownDisplay markDownDisplay1;
    }
}