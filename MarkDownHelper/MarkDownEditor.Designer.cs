using System.Windows.Forms;

namespace MarkDownHelper
{
    partial class MarkDownEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarkDownEditor));
            splitContainer1 = new SplitContainer();
            richTextBox1 = new RichTextBox();
            browserWrapper1 = new BrowserWrapper();
            toolStrip4 = new ToolStrip();
            toolStripButton15 = new ToolStripButton();
            toolStripDropDownButton5 = new ToolStripDropDownButton();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            defaultToolStripMenuItem = new ToolStripSeparator();
            sampleTextToolStripMenuItem = new ToolStripMenuItem();
            gitHubToolStripMenuItem = new ToolStripMenuItem();
            toolStripButtonSave = new ToolStripButton();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripMenuItem();
            toolStripMenuItem8 = new ToolStripMenuItem();
            toolStripButtonFragments = new ToolStripButton();
            toolStrip2 = new ToolStrip();
            toolStripButtonEdit = new ToolStripButton();
            toolStrip3 = new ToolStrip();
            toolStripButtonEditView = new ToolStripButton();
            imageList1 = new ImageList(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            testToolStripMenuItem = new ToolStripMenuItem();
            test2ToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            toolStrip4.SuspendLayout();
            toolStrip2.SuspendLayout();
            toolStrip3.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 87);
            splitContainer1.Margin = new Padding(4);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(richTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(browserWrapper1);
            splitContainer1.Size = new Size(1200, 532);
            splitContainer1.SplitterDistance = 273;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            richTextBox1.AcceptsTab = true;
            richTextBox1.DetectUrls = false;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Margin = new Padding(4);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1200, 273);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            richTextBox1.KeyDown += richTextBox1_KeyDown;
            richTextBox1.PreviewKeyDown += richTextBox1_PreviewKeyDown;
            // 
            // browserWrapper1
            // 
            browserWrapper1.CodeTheme = "default";
            browserWrapper1.Dock = DockStyle.Fill;
            browserWrapper1.EmbeddedFragmentHandler = null;
            browserWrapper1.IndentSize = 4;
            browserWrapper1.Location = new Point(0, 0);
            browserWrapper1.Name = "browserWrapper1";
            browserWrapper1.NavComplete = false;
            browserWrapper1.RootPath = "";
            browserWrapper1.Size = new Size(1200, 254);
            browserWrapper1.TabIndex = 2;
            // 
            // toolStrip4
            // 
            toolStrip4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStrip4.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip4.ImageScalingSize = new Size(24, 24);
            toolStrip4.Items.AddRange(new ToolStripItem[] { toolStripButton15 });
            toolStrip4.Location = new Point(0, 56);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Size = new Size(1200, 31);
            toolStrip4.TabIndex = 2;
            toolStrip4.Text = "toolStrip4";
            // 
            // toolStripButton15
            // 
            toolStripButton15.Image = (Image)resources.GetObject("toolStripButton15.Image");
            toolStripButton15.ImageTransparentColor = Color.Magenta;
            toolStripButton15.Name = "toolStripButton15";
            toolStripButton15.Size = new Size(91, 28);
            toolStripButton15.Text = "Refresh";
            toolStripButton15.Click += toolStripButton4_Click;
            // 
            // toolStripDropDownButton5
            // 
            toolStripDropDownButton5.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton5.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, defaultToolStripMenuItem, sampleTextToolStripMenuItem, gitHubToolStripMenuItem });
            toolStripDropDownButton5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripDropDownButton5.Image = (Image)resources.GetObject("toolStripDropDownButton5.Image");
            toolStripDropDownButton5.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton5.Name = "toolStripDropDownButton5";
            toolStripDropDownButton5.Size = new Size(47, 25);
            toolStripDropDownButton5.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(257, 26);
            openToolStripMenuItem.Text = "Open...";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(257, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(257, 26);
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // defaultToolStripMenuItem
            // 
            defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            defaultToolStripMenuItem.Size = new Size(254, 6);
            // 
            // sampleTextToolStripMenuItem
            // 
            sampleTextToolStripMenuItem.Name = "sampleTextToolStripMenuItem";
            sampleTextToolStripMenuItem.Size = new Size(257, 26);
            sampleTextToolStripMenuItem.Text = "Sample Text";
            sampleTextToolStripMenuItem.Click += sampleTextToolStripMenuItem_Click;
            // 
            // gitHubToolStripMenuItem
            // 
            gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
            gitHubToolStripMenuItem.Size = new Size(257, 26);
            gitHubToolStripMenuItem.Text = "GitHub - Project Template";
            gitHubToolStripMenuItem.Click += gitHubToolStripMenuItem_Click;
            // 
            // toolStripButtonSave
            // 
            toolStripButtonSave.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripButtonSave.Image = (Image)resources.GetObject("toolStripButtonSave.Image");
            toolStripButtonSave.ImageTransparentColor = Color.Magenta;
            toolStripButtonSave.Name = "toolStripButtonSave";
            toolStripButtonSave.Size = new Size(47, 25);
            toolStripButtonSave.Text = "Save";
            toolStripButtonSave.Click += toolStripButtonSave_Click;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5, toolStripMenuItem6, toolStripMenuItem7, toolStripMenuItem8 });
            toolStripDropDownButton1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(86, 25);
            toolStripDropDownButton1.Text = "Font Size";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(98, 26);
            toolStripMenuItem2.Text = "10";
            toolStripMenuItem2.Click += SetEditorFontSize;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(98, 26);
            toolStripMenuItem3.Text = "11";
            toolStripMenuItem3.Click += SetEditorFontSize;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(98, 26);
            toolStripMenuItem4.Text = "12";
            toolStripMenuItem4.Click += SetEditorFontSize;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(98, 26);
            toolStripMenuItem5.Text = "13";
            toolStripMenuItem5.Click += SetEditorFontSize;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(98, 26);
            toolStripMenuItem6.Text = "14";
            toolStripMenuItem6.Click += SetEditorFontSize;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(98, 26);
            toolStripMenuItem7.Text = "15";
            toolStripMenuItem7.Click += SetEditorFontSize;
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(98, 26);
            toolStripMenuItem8.Text = "16";
            toolStripMenuItem8.Click += SetEditorFontSize;
            // 
            // toolStripButtonFragments
            // 
            toolStripButtonFragments.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonFragments.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripButtonFragments.Image = (Image)resources.GetObject("toolStripButtonFragments.Image");
            toolStripButtonFragments.ImageTransparentColor = Color.Magenta;
            toolStripButtonFragments.Name = "toolStripButtonFragments";
            toolStripButtonFragments.Size = new Size(88, 25);
            toolStripButtonFragments.Text = "Fragments";
            toolStripButtonFragments.ToolTipText = "Fragment Manager";
            toolStripButtonFragments.Click += toolStripButtonFragments_Click;
            // 
            // toolStrip2
            // 
            toolStrip2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStrip2.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripButtonEdit });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1200, 28);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonEdit
            // 
            toolStripButtonEdit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonEdit.Image = (Image)resources.GetObject("toolStripButtonEdit.Image");
            toolStripButtonEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new Size(40, 25);
            toolStripButtonEdit.Text = "Edit";
            toolStripButtonEdit.Click += toolStripButtonEdit_Click;
            // 
            // toolStrip3
            // 
            toolStrip3.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolStripButtonEditView, toolStripDropDownButton5, toolStripButtonSave, toolStripDropDownButton1, toolStripButtonFragments });
            toolStrip3.Location = new Point(0, 28);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(1200, 28);
            toolStrip3.TabIndex = 2;
            toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButtonEditView
            // 
            toolStripButtonEditView.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonEditView.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripButtonEditView.Image = (Image)resources.GetObject("toolStripButtonEditView.Image");
            toolStripButtonEditView.ImageTransparentColor = Color.Magenta;
            toolStripButtonEditView.Name = "toolStripButtonEditView";
            toolStripButtonEditView.Size = new Size(48, 25);
            toolStripButtonEditView.Text = "View";
            toolStripButtonEditView.Click += toolStripButtonEditView_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Bold.png");
            imageList1.Images.SetKeyName(1, "Break.png");
            imageList1.Images.SetKeyName(2, "Check.png");
            imageList1.Images.SetKeyName(3, "Code.png");
            imageList1.Images.SetKeyName(4, "copy.png");
            imageList1.Images.SetKeyName(5, "cut.png");
            imageList1.Images.SetKeyName(6, "Definition.png");
            imageList1.Images.SetKeyName(7, "Dictionary.png");
            imageList1.Images.SetKeyName(8, "Header_1.png");
            imageList1.Images.SetKeyName(9, "Header_2.png");
            imageList1.Images.SetKeyName(10, "Header_3.png");
            imageList1.Images.SetKeyName(11, "Header_4.png");
            imageList1.Images.SetKeyName(12, "Header_5.png");
            imageList1.Images.SetKeyName(13, "Header_6.png");
            imageList1.Images.SetKeyName(14, "highlight.png");
            imageList1.Images.SetKeyName(15, "Image.png");
            imageList1.Images.SetKeyName(16, "Italic.png");
            imageList1.Images.SetKeyName(17, "Link.png");
            imageList1.Images.SetKeyName(18, "paste.png");
            imageList1.Images.SetKeyName(19, "Quote.png");
            imageList1.Images.SetKeyName(20, "Refresh.png");
            imageList1.Images.SetKeyName(21, "Script.png");
            imageList1.Images.SetKeyName(22, "Strike.png");
            imageList1.Images.SetKeyName(23, "subscript.png");
            imageList1.Images.SetKeyName(24, "superscript.png");
            imageList1.Images.SetKeyName(25, "Table.png");
            imageList1.Images.SetKeyName(26, "TableRow.png");
            imageList1.Images.SetKeyName(27, "underline.png");
            imageList1.Images.SetKeyName(28, "UnorderedList.png");
            imageList1.Images.SetKeyName(29, "OrderedList.png");
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { testToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(98, 26);
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { test2ToolStripMenuItem });
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(97, 22);
            testToolStripMenuItem.Text = "test";
            // 
            // test2ToolStripMenuItem
            // 
            test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
            test2ToolStripMenuItem.Size = new Size(104, 22);
            test2ToolStripMenuItem.Text = "test2";
            // 
            // MarkDownEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip4);
            Controls.Add(toolStrip3);
            Controls.Add(toolStrip2);
            Enabled = false;
            Margin = new Padding(4);
            Name = "MarkDownEditor";
            Size = new Size(1200, 619);
            EnabledChanged += MarkDownEditor_EnabledChanged;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton5;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sampleTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubToolStripMenuItem;
        private ToolStripButton toolStripButtonSave;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButtonEdit;
        private BrowserWrapper browserWrapper1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripButton toolStripButtonFragments;
        private ToolStrip toolStrip3;
        private ToolStripButton toolStripButtonEditView;
        private ToolStrip toolStrip4;
        private ToolStripButton toolStripButton15;
        private ImageList imageList1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem testToolStripMenuItem;
        private ToolStripMenuItem test2ToolStripMenuItem;
    }
}