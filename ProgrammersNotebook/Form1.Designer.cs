namespace ProgrammersNotebook
{
    partial class Form1
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
            buttonEditorForm = new Button();
            SuspendLayout();
            // 
            // buttonEditorForm
            // 
            buttonEditorForm.Location = new Point(24, 24);
            buttonEditorForm.Name = "buttonEditorForm";
            buttonEditorForm.Size = new Size(75, 23);
            buttonEditorForm.TabIndex = 0;
            buttonEditorForm.Text = "Editor Form";
            buttonEditorForm.UseVisualStyleBackColor = true;
            buttonEditorForm.Click += buttonEditorForm_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonEditorForm);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonEditorForm;
    }
}
