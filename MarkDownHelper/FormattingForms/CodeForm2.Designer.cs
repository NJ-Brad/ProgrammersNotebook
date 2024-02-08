namespace MarkDownHelper
{
    partial class CodeForm2
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
            button1 = new Button();
            button2 = new Button();
            linkLabel1 = new LinkLabel();
            textBox1 = new TextBox();
            buttonSql = new Button();
            buttonHttp = new Button();
            buttonCSharp = new Button();
            buttonHtml = new Button();
            buttonCmd = new Button();
            buttonJavascript = new Button();
            buttonPowershell = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(161, 267);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(88, 30);
            button1.TabIndex = 6;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(256, 267);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(88, 30);
            button2.TabIndex = 7;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Enabled = false;
            linkLabel1.Location = new Point(200, 120);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(50, 17);
            linkLabel1.TabIndex = 18;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Full List";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(200, 84);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(144, 25);
            textBox1.TabIndex = 17;
            // 
            // buttonSql
            // 
            buttonSql.Font = new Font("Segoe UI", 14.25F);
            buttonSql.Location = new Point(12, 228);
            buttonSql.Name = "buttonSql";
            buttonSql.Size = new Size(160, 30);
            buttonSql.TabIndex = 16;
            buttonSql.Text = "SQL";
            buttonSql.UseVisualStyleBackColor = true;
            // 
            // buttonHttp
            // 
            buttonHttp.Font = new Font("Segoe UI", 14.25F);
            buttonHttp.Location = new Point(12, 192);
            buttonHttp.Name = "buttonHttp";
            buttonHttp.Size = new Size(160, 30);
            buttonHttp.TabIndex = 15;
            buttonHttp.Text = "HTTP";
            buttonHttp.UseVisualStyleBackColor = true;
            // 
            // buttonCSharp
            // 
            buttonCSharp.Font = new Font("Segoe UI", 14.25F);
            buttonCSharp.Location = new Point(12, 12);
            buttonCSharp.Name = "buttonCSharp";
            buttonCSharp.Size = new Size(160, 30);
            buttonCSharp.TabIndex = 10;
            buttonCSharp.Text = "C#";
            buttonCSharp.UseVisualStyleBackColor = true;
            // 
            // buttonHtml
            // 
            buttonHtml.Font = new Font("Segoe UI", 14.25F);
            buttonHtml.Location = new Point(12, 156);
            buttonHtml.Name = "buttonHtml";
            buttonHtml.Size = new Size(160, 30);
            buttonHtml.TabIndex = 14;
            buttonHtml.Text = "HTML";
            buttonHtml.UseVisualStyleBackColor = true;
            // 
            // buttonCmd
            // 
            buttonCmd.Font = new Font("Segoe UI", 14.25F);
            buttonCmd.Location = new Point(12, 48);
            buttonCmd.Name = "buttonCmd";
            buttonCmd.Size = new Size(160, 30);
            buttonCmd.TabIndex = 11;
            buttonCmd.Text = "cmd";
            buttonCmd.UseVisualStyleBackColor = true;
            // 
            // buttonJavascript
            // 
            buttonJavascript.Font = new Font("Segoe UI", 14.25F);
            buttonJavascript.Location = new Point(12, 120);
            buttonJavascript.Name = "buttonJavascript";
            buttonJavascript.Size = new Size(160, 30);
            buttonJavascript.TabIndex = 13;
            buttonJavascript.Text = "JavaScript";
            buttonJavascript.UseVisualStyleBackColor = true;
            // 
            // buttonPowershell
            // 
            buttonPowershell.Font = new Font("Segoe UI", 14.25F);
            buttonPowershell.Location = new Point(12, 84);
            buttonPowershell.Name = "buttonPowershell";
            buttonPowershell.Size = new Size(160, 30);
            buttonPowershell.TabIndex = 12;
            buttonPowershell.Text = "PowerShell";
            buttonPowershell.UseVisualStyleBackColor = true;
            // 
            // CodeForm2
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button2;
            ClientSize = new Size(355, 307);
            Controls.Add(linkLabel1);
            Controls.Add(textBox1);
            Controls.Add(buttonSql);
            Controls.Add(buttonHttp);
            Controls.Add(buttonCSharp);
            Controls.Add(buttonHtml);
            Controls.Add(buttonCmd);
            Controls.Add(buttonJavascript);
            Controls.Add(buttonPowershell);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CodeForm2";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Code";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private LinkLabel linkLabel1;
        private TextBox textBox1;
        private Button buttonSql;
        private Button buttonHttp;
        private Button buttonCSharp;
        private Button buttonHtml;
        private Button buttonCmd;
        private Button buttonJavascript;
        private Button buttonPowershell;
    }
}