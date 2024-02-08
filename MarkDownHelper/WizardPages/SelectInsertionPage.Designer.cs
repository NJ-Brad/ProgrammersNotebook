using MarkDownHelper.Wizard;
namespace MarkDownHelper.WizardPages
{
    partial class SelectInsertionPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectInsertionPage));
            buttonHeader = new Button();
            buttonRow = new Button();
            buttonDictionary = new Button();
            buttonDefinition = new Button();
            buttonDivider = new Button();
            buttonLink = new Button();
            buttonTxtBlock = new Button();
            buttonImage = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonHeader
            // 
            buttonHeader.Font = new Font("Segoe UI", 14.25F);
            buttonHeader.Image = (Image)resources.GetObject("buttonHeader.Image");
            buttonHeader.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHeader.Location = new Point(20, 3);
            buttonHeader.Name = "buttonHeader";
            buttonHeader.Size = new Size(160, 30);
            buttonHeader.TabIndex = 3;
            buttonHeader.Text = "Table Header";
            buttonHeader.TextAlign = ContentAlignment.MiddleLeft;
            buttonHeader.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonHeader.UseVisualStyleBackColor = true;
            // 
            // buttonRow
            // 
            buttonRow.Font = new Font("Segoe UI", 14.25F);
            buttonRow.Image = (Image)resources.GetObject("buttonRow.Image");
            buttonRow.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRow.Location = new Point(20, 39);
            buttonRow.Name = "buttonRow";
            buttonRow.Size = new Size(160, 30);
            buttonRow.TabIndex = 4;
            buttonRow.Text = "Table Row";
            buttonRow.TextAlign = ContentAlignment.MiddleLeft;
            buttonRow.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonRow.UseVisualStyleBackColor = true;
            // 
            // buttonDictionary
            // 
            buttonDictionary.Font = new Font("Segoe UI", 14.25F);
            buttonDictionary.Image = (Image)resources.GetObject("buttonDictionary.Image");
            buttonDictionary.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDictionary.Location = new Point(20, 75);
            buttonDictionary.Name = "buttonDictionary";
            buttonDictionary.Size = new Size(160, 30);
            buttonDictionary.TabIndex = 5;
            buttonDictionary.Text = "Dictionary";
            buttonDictionary.TextAlign = ContentAlignment.MiddleLeft;
            buttonDictionary.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonDictionary.UseVisualStyleBackColor = true;
            // 
            // buttonDefinition
            // 
            buttonDefinition.Font = new Font("Segoe UI", 14.25F);
            buttonDefinition.Image = (Image)resources.GetObject("buttonDefinition.Image");
            buttonDefinition.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDefinition.Location = new Point(20, 111);
            buttonDefinition.Name = "buttonDefinition";
            buttonDefinition.Size = new Size(160, 30);
            buttonDefinition.TabIndex = 6;
            buttonDefinition.Text = "Definition";
            buttonDefinition.TextAlign = ContentAlignment.MiddleLeft;
            buttonDefinition.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonDefinition.UseVisualStyleBackColor = true;
            // 
            // buttonDivider
            // 
            buttonDivider.Font = new Font("Segoe UI", 14.25F);
            buttonDivider.Image = (Image)resources.GetObject("buttonDivider.Image");
            buttonDivider.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDivider.Location = new Point(20, 147);
            buttonDivider.Name = "buttonDivider";
            buttonDivider.Size = new Size(160, 30);
            buttonDivider.TabIndex = 7;
            buttonDivider.Text = "Divider";
            buttonDivider.TextAlign = ContentAlignment.MiddleLeft;
            buttonDivider.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonDivider.UseVisualStyleBackColor = true;
            // 
            // buttonLink
            // 
            buttonLink.Font = new Font("Segoe UI", 14.25F);
            buttonLink.Image = (Image)resources.GetObject("buttonLink.Image");
            buttonLink.ImageAlign = ContentAlignment.MiddleLeft;
            buttonLink.Location = new Point(20, 183);
            buttonLink.Name = "buttonLink";
            buttonLink.Size = new Size(160, 30);
            buttonLink.TabIndex = 8;
            buttonLink.Text = "Link";
            buttonLink.TextAlign = ContentAlignment.MiddleLeft;
            buttonLink.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonLink.UseVisualStyleBackColor = true;
            // 
            // buttonTxtBlock
            // 
            buttonTxtBlock.Enabled = false;
            buttonTxtBlock.Font = new Font("Segoe UI", 14.25F);
            buttonTxtBlock.Location = new Point(20, 219);
            buttonTxtBlock.Name = "buttonTxtBlock";
            buttonTxtBlock.Size = new Size(160, 30);
            buttonTxtBlock.TabIndex = 9;
            buttonTxtBlock.Text = "Text Block";
            buttonTxtBlock.UseVisualStyleBackColor = true;
            // 
            // buttonImage
            // 
            buttonImage.Enabled = false;
            buttonImage.Font = new Font("Segoe UI", 14.25F);
            buttonImage.Image = (Image)resources.GetObject("buttonImage.Image");
            buttonImage.ImageAlign = ContentAlignment.MiddleLeft;
            buttonImage.Location = new Point(20, 255);
            buttonImage.Name = "buttonImage";
            buttonImage.Size = new Size(160, 30);
            buttonImage.TabIndex = 10;
            buttonImage.Text = "Image";
            buttonImage.TextAlign = ContentAlignment.MiddleLeft;
            buttonImage.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonImage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(buttonHeader);
            panel1.Controls.Add(buttonRow);
            panel1.Controls.Add(buttonDictionary);
            panel1.Controls.Add(buttonDefinition);
            panel1.Controls.Add(buttonImage);
            panel1.Controls.Add(buttonDivider);
            panel1.Controls.Add(buttonTxtBlock);
            panel1.Controls.Add(buttonLink);
            panel1.Location = new Point(3, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 297);
            panel1.TabIndex = 14;
            // 
            // SelectInsertionPage
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(panel1);
            Name = "SelectInsertionPage";
            Size = new Size(212, 316);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button buttonHeader;
        private Button buttonRow;
        private Button buttonDictionary;
        private Button buttonDefinition;
        private Button buttonDivider;
        private Button buttonLink;
        private Button buttonTxtBlock;
        private Button buttonImage;
        private Panel panel1;
    }
}
