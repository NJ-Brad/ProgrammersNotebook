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
            buttonHeader.Location = new Point(20, 3);
            buttonHeader.Name = "buttonHeader";
            buttonHeader.Size = new Size(160, 30);
            buttonHeader.TabIndex = 3;
            buttonHeader.Text = "Table Header";
            buttonHeader.UseVisualStyleBackColor = true;
            // 
            // buttonRow
            // 
            buttonRow.Font = new Font("Segoe UI", 14.25F);
            buttonRow.Location = new Point(20, 39);
            buttonRow.Name = "buttonRow";
            buttonRow.Size = new Size(160, 30);
            buttonRow.TabIndex = 4;
            buttonRow.Text = "Table Row";
            buttonRow.UseVisualStyleBackColor = true;
            // 
            // buttonDictionary
            // 
            buttonDictionary.Font = new Font("Segoe UI", 14.25F);
            buttonDictionary.Location = new Point(20, 75);
            buttonDictionary.Name = "buttonDictionary";
            buttonDictionary.Size = new Size(160, 30);
            buttonDictionary.TabIndex = 5;
            buttonDictionary.Text = "Dictionary";
            buttonDictionary.UseVisualStyleBackColor = true;
            // 
            // buttonDefinition
            // 
            buttonDefinition.Font = new Font("Segoe UI", 14.25F);
            buttonDefinition.Location = new Point(20, 111);
            buttonDefinition.Name = "buttonDefinition";
            buttonDefinition.Size = new Size(160, 30);
            buttonDefinition.TabIndex = 6;
            buttonDefinition.Text = "Definition";
            buttonDefinition.UseVisualStyleBackColor = true;
            // 
            // buttonDivider
            // 
            buttonDivider.Font = new Font("Segoe UI", 14.25F);
            buttonDivider.Location = new Point(20, 147);
            buttonDivider.Name = "buttonDivider";
            buttonDivider.Size = new Size(160, 30);
            buttonDivider.TabIndex = 7;
            buttonDivider.Text = "Divider";
            buttonDivider.UseVisualStyleBackColor = true;
            // 
            // buttonLink
            // 
            buttonLink.Font = new Font("Segoe UI", 14.25F);
            buttonLink.Location = new Point(20, 183);
            buttonLink.Name = "buttonLink";
            buttonLink.Size = new Size(160, 30);
            buttonLink.TabIndex = 8;
            buttonLink.Text = "Link";
            buttonLink.UseVisualStyleBackColor = true;
            // 
            // buttonTxtBlock
            // 
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
            buttonImage.Font = new Font("Segoe UI", 14.25F);
            buttonImage.Location = new Point(20, 255);
            buttonImage.Name = "buttonImage";
            buttonImage.Size = new Size(160, 30);
            buttonImage.TabIndex = 10;
            buttonImage.Text = "Image";
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
