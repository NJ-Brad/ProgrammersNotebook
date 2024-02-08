namespace MarkDownHelper
{
    partial class FragmentManagerForm
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
            label1 = new Label();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            comboBox1 = new ComboBox();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            buttonNew = new Button();
            buttonSave = new Button();
            buttonImport = new Button();
            label6 = new Label();
            textBox2 = new TextBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 18);
            label1.Name = "label1";
            label1.Size = new Size(96, 17);
            label1.TabIndex = 0;
            label1.Text = "Text Fragments";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(21, 38);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(167, 174);
            listBox1.Sorted = true;
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 17;
            listBox2.Location = new Point(21, 235);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(167, 174);
            listBox2.Sorted = true;
            listBox2.TabIndex = 3;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 215);
            label2.Name = "label2";
            label2.Size = new Size(50, 17);
            label2.TabIndex = 2;
            label2.Text = "Images";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(295, 56);
            label3.Name = "label3";
            label3.Size = new Size(43, 17);
            label3.TabIndex = 4;
            label3.Text = "Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(344, 53);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(249, 25);
            textBox1.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(244, 87);
            label4.Name = "label4";
            label4.Size = new Size(94, 17);
            label4.TabIndex = 6;
            label4.Text = "Fragment Type";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Enabled = false;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Text", "image/jpeg" });
            comboBox1.Location = new Point(344, 84);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(249, 25);
            comboBox1.TabIndex = 7;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(285, 115);
            label5.Name = "label5";
            label5.Size = new Size(53, 17);
            label5.TabIndex = 8;
            label5.Text = "Content";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Window;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(138, 242);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // buttonNew
            // 
            buttonNew.Location = new Point(212, 12);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(75, 23);
            buttonNew.TabIndex = 12;
            buttonNew.Text = "New";
            buttonNew.UseVisualStyleBackColor = true;
            buttonNew.Click += buttonNew_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(293, 12);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 13;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonImport
            // 
            buttonImport.Enabled = false;
            buttonImport.Location = new Point(374, 12);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(75, 23);
            buttonImport.TabIndex = 14;
            buttonImport.Text = "Import";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(225, 53);
            label6.Name = "label6";
            label6.Size = new Size(43, 17);
            label6.TabIndex = 15;
            label6.Text = "label6";
            label6.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(261, 136);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(329, 274);
            textBox2.TabIndex = 16;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(194, 139);
            panel1.Name = "panel1";
            panel1.Size = new Size(399, 274);
            panel1.TabIndex = 17;
            panel1.Visible = false;
            // 
            // FragmentManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 425);
            Controls.Add(textBox2);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(buttonImport);
            Controls.Add(buttonSave);
            Controls.Add(buttonNew);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(listBox2);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FragmentManagerForm";
            ShowInTaskbar = false;
            Text = "Fragment Manager";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox listBox1;
        private ListBox listBox2;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private ComboBox comboBox1;
        private Label label5;
        private PictureBox pictureBox1;
        private Button buttonNew;
        private Button buttonSave;
        private Button buttonImport;
        private Label label6;
        private TextBox textBox2;
        private Panel panel1;
    }
}