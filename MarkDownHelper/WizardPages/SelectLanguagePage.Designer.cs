using MarkDownHelper.Wizard;
namespace MarkDownHelper.WizardPages
{
    partial class SelectLanguagePage
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
            buttonCSharp = new Button();
            buttonCmd = new Button();
            buttonPowershell = new Button();
            buttonJavascript = new Button();
            buttonHtml = new Button();
            panel1 = new Panel();
            linkLabel1 = new LinkLabel();
            textBox1 = new TextBox();
            buttonSql = new Button();
            buttonHttp = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonCSharp
            // 
            buttonCSharp.Font = new Font("Segoe UI", 14.25F);
            buttonCSharp.Location = new Point(20, 3);
            buttonCSharp.Name = "buttonCSharp";
            buttonCSharp.Size = new Size(160, 30);
            buttonCSharp.TabIndex = 0;
            buttonCSharp.Text = "C#";
            buttonCSharp.UseVisualStyleBackColor = true;
            // 
            // buttonCmd
            // 
            buttonCmd.Font = new Font("Segoe UI", 14.25F);
            buttonCmd.Location = new Point(20, 39);
            buttonCmd.Name = "buttonCmd";
            buttonCmd.Size = new Size(160, 30);
            buttonCmd.TabIndex = 1;
            buttonCmd.Text = "cmd";
            buttonCmd.UseVisualStyleBackColor = true;
            // 
            // buttonPowershell
            // 
            buttonPowershell.Font = new Font("Segoe UI", 14.25F);
            buttonPowershell.Location = new Point(20, 75);
            buttonPowershell.Name = "buttonPowershell";
            buttonPowershell.Size = new Size(160, 30);
            buttonPowershell.TabIndex = 2;
            buttonPowershell.Text = "PowerShell";
            buttonPowershell.UseVisualStyleBackColor = true;
            // 
            // buttonJavascript
            // 
            buttonJavascript.Font = new Font("Segoe UI", 14.25F);
            buttonJavascript.Location = new Point(20, 111);
            buttonJavascript.Name = "buttonJavascript";
            buttonJavascript.Size = new Size(160, 30);
            buttonJavascript.TabIndex = 3;
            buttonJavascript.Text = "JavaScript";
            buttonJavascript.UseVisualStyleBackColor = true;
            // 
            // buttonHtml
            // 
            buttonHtml.Font = new Font("Segoe UI", 14.25F);
            buttonHtml.Location = new Point(20, 147);
            buttonHtml.Name = "buttonHtml";
            buttonHtml.Size = new Size(160, 30);
            buttonHtml.TabIndex = 4;
            buttonHtml.Text = "HTML";
            buttonHtml.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(buttonSql);
            panel1.Controls.Add(buttonHttp);
            panel1.Controls.Add(buttonCSharp);
            panel1.Controls.Add(buttonHtml);
            panel1.Controls.Add(buttonCmd);
            panel1.Controls.Add(buttonJavascript);
            panel1.Controls.Add(buttonPowershell);
            panel1.Location = new Point(12, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(365, 272);
            panel1.TabIndex = 14;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Enabled = false;
            linkLabel1.Location = new Point(208, 111);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(50, 17);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Full List";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(208, 75);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(144, 25);
            textBox1.TabIndex = 8;
            // 
            // buttonSql
            // 
            buttonSql.Font = new Font("Segoe UI", 14.25F);
            buttonSql.Location = new Point(20, 219);
            buttonSql.Name = "buttonSql";
            buttonSql.Size = new Size(160, 30);
            buttonSql.TabIndex = 6;
            buttonSql.Text = "SQL";
            buttonSql.UseVisualStyleBackColor = true;
            // 
            // buttonHttp
            // 
            buttonHttp.Font = new Font("Segoe UI", 14.25F);
            buttonHttp.Location = new Point(20, 183);
            buttonHttp.Name = "buttonHttp";
            buttonHttp.Size = new Size(160, 30);
            buttonHttp.TabIndex = 5;
            buttonHttp.Text = "HTTP";
            buttonHttp.UseVisualStyleBackColor = true;
            // 
            // SelectLanguagePage
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(panel1);
            Name = "SelectLanguagePage";
            Size = new Size(385, 287);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonCSharp;
        private Button buttonCmd;
        private Button buttonPowershell;
        private Button buttonJavascript;
        private Button buttonHtml;
        private Panel panel1;
        private Button buttonSql;
        private Button buttonHttp;
        private LinkLabel linkLabel1;
        private TextBox textBox1;
    }
}
