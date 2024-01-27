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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarkDownEditor));
            splitContainer1 = new SplitContainer();
            richTextBox1 = new RichTextBox();
            browserWrapper1 = new BrowserWrapper();
            toolStrip1 = new ToolStrip();
            toolStripSeparator8 = new ToolStripSeparator();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripDropDownButtonInsert = new ToolStripDropDownButton();
            toolStripButton5 = new ToolStripMenuItem();
            toolStripButton6 = new ToolStripMenuItem();
            toolStripButton7 = new ToolStripMenuItem();
            toolStripButton8 = new ToolStripMenuItem();
            toolStripButton9 = new ToolStripMenuItem();
            toolStripButton10 = new ToolStripMenuItem();
            textBlockToolStripMenuItem = new ToolStripMenuItem();
            placeholderToolStripMenuItem = new ToolStripMenuItem();
            imageToolStripMenuItem = new ToolStripMenuItem();
            placeholderToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripButton11 = new ToolStripButton();
            toolStripButton29 = new ToolStripButton();
            toolStripButton28 = new ToolStripButton();
            toolStripButton27 = new ToolStripButton();
            toolStripButton26 = new ToolStripButton();
            toolStripButton25 = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripButton24 = new ToolStripButton();
            toolStripButton23 = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripButton22 = new ToolStripButton();
            toolStripButton21 = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            toolStripButton12 = new ToolStripButton();
            toolStripButton13 = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            toolStripButton4 = new ToolStripButton();
            toolStripLabel1 = new ToolStripLabel();
            toolStripComboBox2 = new ToolStripComboBox();
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
            toolStripLabel2 = new ToolStripLabel();
            toolStripComboBox1 = new ToolStripComboBox();
            toolStripLabel3 = new ToolStripLabel();
            toolStripComboBox3 = new ToolStripComboBox();
            toolStrip3 = new ToolStrip();
            toolStripButtonEditView = new ToolStripButton();
            toolStripLabel4 = new ToolStripLabel();
            toolStripComboBox4 = new ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            toolStrip1.SuspendLayout();
            toolStrip2.SuspendLayout();
            toolStrip3.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 88);
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
            splitContainer1.Size = new Size(1200, 531);
            splitContainer1.SplitterDistance = 275;
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
            richTextBox1.Size = new Size(1200, 275);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
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
            browserWrapper1.Size = new Size(1200, 251);
            browserWrapper1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripSeparator8, toolStripButton1, toolStripButton2, toolStripButton3, toolStripSeparator2, toolStripDropDownButtonInsert, toolStripSeparator3, toolStripButton11, toolStripButton29, toolStripButton28, toolStripButton27, toolStripButton26, toolStripButton25, toolStripSeparator5, toolStripButton24, toolStripButton23, toolStripSeparator4, toolStripButton22, toolStripButton21, toolStripSeparator6, toolStripButton12, toolStripButton13, toolStripSeparator7, toolStripButton4, toolStripLabel1, toolStripComboBox2, toolStripLabel4, toolStripComboBox4 });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1200, 31);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(6, 31);
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(28, 28);
            toolStripButton1.Text = "Italic";
            toolStripButton1.Click += MenuItem_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(28, 28);
            toolStripButton2.Text = "Bold";
            toolStripButton2.Click += MenuItem_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(28, 28);
            toolStripButton3.Text = "Strike";
            toolStripButton3.Click += MenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 31);
            // 
            // toolStripDropDownButtonInsert
            // 
            toolStripDropDownButtonInsert.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButtonInsert.DropDownItems.AddRange(new ToolStripItem[] { toolStripButton5, toolStripButton6, toolStripButton7, toolStripButton8, toolStripButton9, toolStripButton10, textBlockToolStripMenuItem, imageToolStripMenuItem });
            toolStripDropDownButtonInsert.Image = (Image)resources.GetObject("toolStripDropDownButtonInsert.Image");
            toolStripDropDownButtonInsert.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButtonInsert.Name = "toolStripDropDownButtonInsert";
            toolStripDropDownButtonInsert.Size = new Size(62, 28);
            toolStripDropDownButtonInsert.Text = "Insert";
            // 
            // toolStripButton5
            // 
            toolStripButton5.Image = (Image)resources.GetObject("toolStripButton5.Image");
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(155, 30);
            toolStripButton5.Text = "HR";
            toolStripButton5.Click += MenuItem_Click;
            // 
            // toolStripButton6
            // 
            toolStripButton6.Image = (Image)resources.GetObject("toolStripButton6.Image");
            toolStripButton6.ImageTransparentColor = Color.Magenta;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Size = new Size(155, 30);
            toolStripButton6.Text = "Link";
            toolStripButton6.Click += MenuItem_Click;
            // 
            // toolStripButton7
            // 
            toolStripButton7.Image = (Image)resources.GetObject("toolStripButton7.Image");
            toolStripButton7.ImageTransparentColor = Color.Magenta;
            toolStripButton7.Name = "toolStripButton7";
            toolStripButton7.Size = new Size(155, 30);
            toolStripButton7.Text = "Image";
            toolStripButton7.Click += MenuItem_Click;
            // 
            // toolStripButton8
            // 
            toolStripButton8.Image = (Image)resources.GetObject("toolStripButton8.Image");
            toolStripButton8.ImageTransparentColor = Color.Magenta;
            toolStripButton8.Name = "toolStripButton8";
            toolStripButton8.Size = new Size(155, 30);
            toolStripButton8.Text = "Code";
            toolStripButton8.Click += MenuItem_Click;
            // 
            // toolStripButton9
            // 
            toolStripButton9.Image = (Image)resources.GetObject("toolStripButton9.Image");
            toolStripButton9.ImageTransparentColor = Color.Magenta;
            toolStripButton9.Name = "toolStripButton9";
            toolStripButton9.Size = new Size(155, 30);
            toolStripButton9.Text = "Quote";
            toolStripButton9.Click += MenuItem_Click;
            // 
            // toolStripButton10
            // 
            toolStripButton10.Image = (Image)resources.GetObject("toolStripButton10.Image");
            toolStripButton10.ImageTransparentColor = Color.Magenta;
            toolStripButton10.Name = "toolStripButton10";
            toolStripButton10.Size = new Size(155, 30);
            toolStripButton10.Text = "Task";
            toolStripButton10.Click += MenuItem_Click;
            // 
            // textBlockToolStripMenuItem
            // 
            textBlockToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { placeholderToolStripMenuItem });
            textBlockToolStripMenuItem.Name = "textBlockToolStripMenuItem";
            textBlockToolStripMenuItem.Size = new Size(155, 30);
            textBlockToolStripMenuItem.Text = "Text Block";
            textBlockToolStripMenuItem.DropDownOpening += textBlockToolStripMenuItem_DropDownOpening;
            // 
            // placeholderToolStripMenuItem
            // 
            placeholderToolStripMenuItem.Name = "placeholderToolStripMenuItem";
            placeholderToolStripMenuItem.Size = new Size(161, 26);
            placeholderToolStripMenuItem.Text = "Placeholder";
            // 
            // imageToolStripMenuItem
            // 
            imageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { placeholderToolStripMenuItem1 });
            imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            imageToolStripMenuItem.Size = new Size(155, 30);
            imageToolStripMenuItem.Text = "Image";
            imageToolStripMenuItem.DropDownOpening += imageToolStripMenuItem_DropDownOpening;
            // 
            // placeholderToolStripMenuItem1
            // 
            placeholderToolStripMenuItem1.Name = "placeholderToolStripMenuItem1";
            placeholderToolStripMenuItem1.Size = new Size(161, 26);
            placeholderToolStripMenuItem1.Text = "Placeholder";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 31);
            // 
            // toolStripButton11
            // 
            toolStripButton11.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton11.Image = (Image)resources.GetObject("toolStripButton11.Image");
            toolStripButton11.ImageTransparentColor = Color.Magenta;
            toolStripButton11.Name = "toolStripButton11";
            toolStripButton11.Size = new Size(28, 28);
            toolStripButton11.Text = "H1";
            toolStripButton11.Click += MenuItem_Click;
            // 
            // toolStripButton29
            // 
            toolStripButton29.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton29.Image = (Image)resources.GetObject("toolStripButton29.Image");
            toolStripButton29.ImageTransparentColor = Color.Magenta;
            toolStripButton29.Name = "toolStripButton29";
            toolStripButton29.Size = new Size(28, 28);
            toolStripButton29.Text = "H2";
            toolStripButton29.Click += MenuItem_Click;
            // 
            // toolStripButton28
            // 
            toolStripButton28.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton28.Image = (Image)resources.GetObject("toolStripButton28.Image");
            toolStripButton28.ImageTransparentColor = Color.Magenta;
            toolStripButton28.Name = "toolStripButton28";
            toolStripButton28.Size = new Size(28, 28);
            toolStripButton28.Text = "H3";
            toolStripButton28.Click += MenuItem_Click;
            // 
            // toolStripButton27
            // 
            toolStripButton27.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton27.Image = (Image)resources.GetObject("toolStripButton27.Image");
            toolStripButton27.ImageTransparentColor = Color.Magenta;
            toolStripButton27.Name = "toolStripButton27";
            toolStripButton27.Size = new Size(28, 28);
            toolStripButton27.Text = "H4";
            toolStripButton27.Click += MenuItem_Click;
            // 
            // toolStripButton26
            // 
            toolStripButton26.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton26.Image = (Image)resources.GetObject("toolStripButton26.Image");
            toolStripButton26.ImageTransparentColor = Color.Magenta;
            toolStripButton26.Name = "toolStripButton26";
            toolStripButton26.Size = new Size(28, 28);
            toolStripButton26.Text = "H5";
            toolStripButton26.Click += MenuItem_Click;
            // 
            // toolStripButton25
            // 
            toolStripButton25.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton25.Image = (Image)resources.GetObject("toolStripButton25.Image");
            toolStripButton25.ImageTransparentColor = Color.Magenta;
            toolStripButton25.Name = "toolStripButton25";
            toolStripButton25.Size = new Size(28, 28);
            toolStripButton25.Text = "H6";
            toolStripButton25.Click += MenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 31);
            // 
            // toolStripButton24
            // 
            toolStripButton24.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton24.Image = (Image)resources.GetObject("toolStripButton24.Image");
            toolStripButton24.ImageTransparentColor = Color.Magenta;
            toolStripButton24.Name = "toolStripButton24";
            toolStripButton24.Size = new Size(28, 28);
            toolStripButton24.Text = "Unordered List";
            toolStripButton24.Click += MenuItem_Click;
            // 
            // toolStripButton23
            // 
            toolStripButton23.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton23.Image = (Image)resources.GetObject("toolStripButton23.Image");
            toolStripButton23.ImageTransparentColor = Color.Magenta;
            toolStripButton23.Name = "toolStripButton23";
            toolStripButton23.Size = new Size(28, 28);
            toolStripButton23.Text = "Ordered List";
            toolStripButton23.Click += MenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 31);
            // 
            // toolStripButton22
            // 
            toolStripButton22.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton22.Image = (Image)resources.GetObject("toolStripButton22.Image");
            toolStripButton22.ImageTransparentColor = Color.Magenta;
            toolStripButton22.Name = "toolStripButton22";
            toolStripButton22.Size = new Size(28, 28);
            toolStripButton22.Text = "Header";
            toolStripButton22.Click += MenuItem_Click;
            // 
            // toolStripButton21
            // 
            toolStripButton21.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton21.Image = (Image)resources.GetObject("toolStripButton21.Image");
            toolStripButton21.ImageTransparentColor = Color.Magenta;
            toolStripButton21.Name = "toolStripButton21";
            toolStripButton21.Size = new Size(28, 28);
            toolStripButton21.Text = "Row";
            toolStripButton21.Click += MenuItem_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 31);
            // 
            // toolStripButton12
            // 
            toolStripButton12.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton12.Image = (Image)resources.GetObject("toolStripButton12.Image");
            toolStripButton12.ImageTransparentColor = Color.Magenta;
            toolStripButton12.Name = "toolStripButton12";
            toolStripButton12.Size = new Size(28, 28);
            toolStripButton12.Text = "Dictionary";
            toolStripButton12.Click += MenuItem_Click;
            // 
            // toolStripButton13
            // 
            toolStripButton13.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton13.Image = (Image)resources.GetObject("toolStripButton13.Image");
            toolStripButton13.ImageTransparentColor = Color.Magenta;
            toolStripButton13.Name = "toolStripButton13";
            toolStripButton13.Size = new Size(28, 28);
            toolStripButton13.Text = "Definition";
            toolStripButton13.Click += MenuItem_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 31);
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(28, 28);
            toolStripButton4.Text = "Refresh";
            toolStripButton4.Click += toolStripButton4_Click;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(141, 28);
            toolStripLabel1.Text = "Code Block Theme:";
            // 
            // toolStripComboBox2
            // 
            toolStripComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripComboBox2.Items.AddRange(new object[] { "1c-light", "a11y-dark", "a11y-light", "agate", "an-old-hope", "androidstudio", "arduino-light", "arta", "ascetic", "atom-one-dark-reasonable", "atom-one-dark", "atom-one-light", "brown-paper", "brown-papersq.png", "codepen-embed", "color-brewer", "dark", "default", "devibeans", "docco", "far", "felipec", "foundation", "github-dark-dimmed", "github-dark", "github", "gml", "googlecode", "gradient-dark", "gradient-light", "grayscale", "hybrid", "idea", "intellij-light", "ir-black", "isbl-editor-dark", "isbl-editor-light", "kimbie-dark", "kimbie-light", "lightfair", "lioshi", "magula", "mono-blue", "monokai-sublime", "monokai", "night-owl", "nnfx-dark", "nnfx-light", "nord", "obsidian", "panda-syntax-dark", "panda-syntax-light", "paraiso-dark", "paraiso-light", "pojoaque", "pojoaque.jpg", "purebasic", "qtcreator-dark", "qtcreator-light", "rainbow", "routeros", "school-book", "shades-of-purple", "srcery", "stackoverflow-dark", "stackoverflow-light", "sunburst", "tokyo-night-dark", "tokyo-night-light", "tomorrow-night-blue", "tomorrow-night-bright", "vs", "vs2015", "xcode", "xt256" });
            toolStripComboBox2.Name = "toolStripComboBox2";
            toolStripComboBox2.Size = new Size(175, 31);
            toolStripComboBox2.SelectedIndexChanged += toolStripComboBox2_SelectedIndexChanged;
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
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripButtonEdit, toolStripLabel2, toolStripComboBox1, toolStripLabel3, toolStripComboBox3 });
            toolStrip2.Location = new Point(0, 59);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1200, 29);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonEdit
            // 
            toolStripButtonEdit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonEdit.Image = (Image)resources.GetObject("toolStripButtonEdit.Image");
            toolStripButtonEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new Size(40, 26);
            toolStripButtonEdit.Text = "Edit";
            toolStripButtonEdit.Click += toolStripButtonEdit_Click;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(141, 26);
            toolStripLabel2.Text = "Code Block Theme:";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripComboBox1.Items.AddRange(new object[] { "1c-light", "a11y-dark", "a11y-light", "agate", "an-old-hope", "androidstudio", "arduino-light", "arta", "ascetic", "atom-one-dark-reasonable", "atom-one-dark", "atom-one-light", "brown-paper", "brown-papersq.png", "codepen-embed", "color-brewer", "dark", "default", "devibeans", "docco", "far", "felipec", "foundation", "github-dark-dimmed", "github-dark", "github", "gml", "googlecode", "gradient-dark", "gradient-light", "grayscale", "hybrid", "idea", "intellij-light", "ir-black", "isbl-editor-dark", "isbl-editor-light", "kimbie-dark", "kimbie-light", "lightfair", "lioshi", "magula", "mono-blue", "monokai-sublime", "monokai", "night-owl", "nnfx-dark", "nnfx-light", "nord", "obsidian", "panda-syntax-dark", "panda-syntax-light", "paraiso-dark", "paraiso-light", "pojoaque", "pojoaque.jpg", "purebasic", "qtcreator-dark", "qtcreator-light", "rainbow", "routeros", "school-book", "shades-of-purple", "srcery", "stackoverflow-dark", "stackoverflow-light", "sunburst", "tokyo-night-dark", "tokyo-night-light", "tomorrow-night-blue", "tomorrow-night-bright", "vs", "vs2015", "xcode", "xt256" });
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(175, 29);
            toolStripComboBox1.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(89, 26);
            toolStripLabel3.Text = "Indent Size:";
            // 
            // toolStripComboBox3
            // 
            toolStripComboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox3.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            toolStripComboBox3.Name = "toolStripComboBox3";
            toolStripComboBox3.Size = new Size(121, 29);
            toolStripComboBox3.SelectedIndexChanged += toolStripComboBox3_SelectedIndexChanged;
            // 
            // toolStrip3
            // 
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolStripButtonEditView, toolStripDropDownButton5, toolStripButtonSave, toolStripDropDownButton1, toolStripButtonFragments });
            toolStrip3.Location = new Point(0, 0);
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
            // toolStripLabel4
            // 
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(89, 28);
            toolStripLabel4.Text = "Indent Size:";
            // 
            // toolStripComboBox4
            // 
            toolStripComboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox4.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            toolStripComboBox4.Name = "toolStripComboBox4";
            toolStripComboBox4.Size = new Size(121, 31);
            toolStripComboBox4.SelectedIndexChanged += toolStripComboBox4_SelectedIndexChanged;
            // 
            // MarkDownEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip2);
            Controls.Add(toolStrip1);
            Controls.Add(toolStrip3);
            Margin = new Padding(4);
            Name = "MarkDownEditor";
            Size = new Size(1200, 619);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem toolStripButton6;
        private System.Windows.Forms.ToolStripMenuItem toolStripButton7;
        private System.Windows.Forms.ToolStripMenuItem toolStripButton8;
        private System.Windows.Forms.ToolStripMenuItem toolStripButton9;
        private System.Windows.Forms.ToolStripMenuItem toolStripButton10;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton5;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sampleTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripButton toolStripButton29;
        private System.Windows.Forms.ToolStripButton toolStripButton28;
        private System.Windows.Forms.ToolStripButton toolStripButton27;
        private System.Windows.Forms.ToolStripButton toolStripButton26;
        private System.Windows.Forms.ToolStripButton toolStripButton25;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton24;
        private System.Windows.Forms.ToolStripButton toolStripButton23;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton22;
        private System.Windows.Forms.ToolStripButton toolStripButton21;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
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
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripDropDownButton toolStripDropDownButtonInsert;
        private ToolStripMenuItem textBlockToolStripMenuItem;
        private ToolStripMenuItem placeholderToolStripMenuItem;
        private ToolStripMenuItem imageToolStripMenuItem;
        private ToolStripMenuItem placeholderToolStripMenuItem1;
        private ToolStripButton toolStripButtonFragments;
        private ToolStrip toolStrip3;
        private ToolStripButton toolStripButtonEditView;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripComboBox toolStripComboBox2;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripLabel toolStripLabel3;
        private ToolStripComboBox toolStripComboBox3;
        private ToolStripLabel toolStripLabel4;
        private ToolStripComboBox toolStripComboBox4;
    }
}