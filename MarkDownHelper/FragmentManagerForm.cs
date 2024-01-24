using System.Drawing.Imaging;

namespace MarkDownHelper
{
    public partial class FragmentManagerForm : Form
    {
        public FragmentManagerForm()
        {
            InitializeComponent();
        }

        public EventHandler<EmbeddedFragmentEventArgs>? EmbeddedFragmentHandler { get; set; }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Load();

            ContextMenuStrip contextMenu = new();
            //ToolStripMenuItem menuItem = new ToolStripMenuItem("Cut");
            //menuItem.Click += new EventHandler(CutAction);
            //contextMenu.Items.Add(menuItem);
            //menuItem = new ToolStripMenuItem("Copy");
            //menuItem.Click += new EventHandler(CopyAction);
            //contextMenu.Items.Add(menuItem);

            ToolStripMenuItem menuItem = new ToolStripMenuItem("Paste");
            //menuItem.Click += new EventHandler(PasteAction);
            menuItem.Click += PasteText;
            contextMenu.Items.Add(menuItem);

            textBox2.ContextMenuStrip = contextMenu;

            contextMenu = new();
            menuItem = new ToolStripMenuItem("Paste");
            //menuItem.Click += new EventHandler(PasteAction);
            menuItem.Click += PasteImage;
            contextMenu.Items.Add(menuItem);

            pictureBox1.ContextMenuStrip = contextMenu;
        }

        private void PasteImage(object? sender, EventArgs e)
        {
            Image img = Clipboard.GetImage();
            if (img != null)
            {
                pictureBox1.Image = img;
            }
        }

        private void PasteText(object? sender, EventArgs e)
        {
            string str = Clipboard.GetText();
            textBox2.Paste(str);
        }

        private void Load()
        {             // GET
            listBox1.Items.Clear();
            EmbeddedFragmentEventArgs args = new();
            args.Operation = "LIST_TEXT_BLOCKS";
            EmbeddedFragmentHandler?.Invoke(this, args);
            foreach (string str in args.Names)
            {
                listBox1.Items.Add(str);
            }

            listBox2.Items.Clear();
            args = new();
            args.Operation = "LIST_IMAGE_BLOCKS";
            EmbeddedFragmentHandler?.Invoke(this, args);
            foreach (string str in args.Names)
            {
                listBox2.Items.Add(str);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmbeddedFragmentEventArgs args = new();
            args.Operation = "GET";
            args.Key = listBox1.Items[listBox1.SelectedIndex].ToString();
            EmbeddedFragmentHandler?.Invoke(this, args);

            PageFragment frag = args.Value;

            label6.Text = frag.Id;
            textBox1.Text = frag.Name;
            comboBox1.SelectedIndex = 0;
            textBox2.Text = frag.Content;

            textBox2.Visible = true;
            panel1.Visible = false;
            pictureBox1.Visible = false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmbeddedFragmentEventArgs args = new();
            args.Operation = "GET";
            args.Key = listBox2.Items[listBox2.SelectedIndex].ToString();
            EmbeddedFragmentHandler?.Invoke(this, args);

            PageFragment frag = args.Value;

            label6.Text = frag.Id;
            textBox1.Text = frag.Name;
            comboBox1.SelectedIndex = 1;
            //richTextBox1.Text = frag.Content;

            pictureBox1.Image = Base64ToImage(frag.Content);

            textBox2.Visible = false;
            panel1.Visible = true;
            pictureBox1.Visible = true;

            pictureBox1.Size = pictureBox1.Image.Size;
        }

        // https://stackoverflow.com/questions/18827081/c-sharp-base64-string-to-jpeg-image
        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);

            return image;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            EmbeddedFragmentEventArgs args = new();
            args.Operation = "SAVE";
            args.Key = textBox1.Text;

            // need the ID
            PageFragment frag = new PageFragment { Id = label6.Text, Name = textBox1.Text };

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    frag.FragmentType = "Text";
                    frag.Content = textBox2.Text;
                    break;
                case 1:
                    frag.FragmentType = "image/jpeg";
                    frag.Content = ImageToBase64(pictureBox1.Image);
                    break;
            }

            args.Value = frag;

            EmbeddedFragmentHandler?.Invoke(this, args);

            textBox1.ReadOnly = true;
            comboBox1.Enabled = false;

            Load();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            comboBox1.Enabled = true;

            label6.Text = Guid.NewGuid().ToString("D").ToUpper();
            textBox1.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            textBox2.Text = string.Empty;
            pictureBox1.Image = null;
        }

        private string ImageToBase64(Image image)
        {
            string rtnVal = string.Empty;

            // https://www.techieclues.com/blogs/converting-image-to-base64-string-in-csharp
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Bmp);
                byte[] imageBytes = stream.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                rtnVal = base64String;
            }

            return rtnVal;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonImport.Enabled = comboBox1.SelectedIndex != -1;
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    textBox2.Text = File.ReadAllText(ofd.FileName);
                }
                else
                {
                    pictureBox1.Load(ofd.FileName);
                }
            }
        }
    }
}
