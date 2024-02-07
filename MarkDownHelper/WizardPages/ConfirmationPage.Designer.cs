using MarkDownHelper.Wizard;
namespace MarkDownHelper.WizardPages
{
    partial class ConfirmationPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmationPage));
            tabControl1 = new TabControl();
            tabPageText = new TabPage();
            richTextBox1 = new RichTextBox();
            tabPageBrowser = new TabPage();
            browserWrapper1 = new BrowserWrapper();
            tabControl1.SuspendLayout();
            tabPageText.SuspendLayout();
            tabPageBrowser.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageText);
            tabControl1.Controls.Add(tabPageBrowser);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(640, 357);
            tabControl1.TabIndex = 0;
            // 
            // tabPageText
            // 
            tabPageText.Controls.Add(richTextBox1);
            tabPageText.Location = new Point(4, 26);
            tabPageText.Name = "tabPageText";
            tabPageText.Padding = new Padding(3);
            tabPageText.Size = new Size(632, 327);
            tabPageText.TabIndex = 0;
            tabPageText.Text = "Text";
            tabPageText.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(3, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(626, 321);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // tabPageBrowser
            // 
            tabPageBrowser.Controls.Add(browserWrapper1);
            tabPageBrowser.Location = new Point(4, 26);
            tabPageBrowser.Name = "tabPageBrowser";
            tabPageBrowser.Padding = new Padding(3);
            tabPageBrowser.Size = new Size(632, 327);
            tabPageBrowser.TabIndex = 1;
            tabPageBrowser.Text = "Browser";
            tabPageBrowser.UseVisualStyleBackColor = true;
            // 
            // browserWrapper1
            // 
            browserWrapper1.CodeTheme = "default";
            browserWrapper1.Dock = DockStyle.Fill;
            browserWrapper1.EmbeddedFragmentHandler = null;
            browserWrapper1.IndentSize = 4;
            browserWrapper1.Location = new Point(3, 3);
            browserWrapper1.Name = "browserWrapper1";
            browserWrapper1.NavComplete = false;
            browserWrapper1.RootPath = "";
            browserWrapper1.Size = new Size(626, 321);
            browserWrapper1.TabIndex = 0;
            // 
            // ConfirmationPage
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Name = "ConfirmationPage";
            Size = new Size(640, 357);
            tabControl1.ResumeLayout(false);
            tabPageText.ResumeLayout(false);
            tabPageBrowser.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageText;
        private RichTextBox richTextBox1;
        private TabPage tabPageBrowser;
        private BrowserWrapper browserWrapper1;
    }
}
