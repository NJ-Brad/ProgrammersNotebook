using System.Drawing.Imaging;
using System.Net;

namespace MarkDownHelper
{
    public partial class ImageForm : Form
    {
        string baseDir = string.Empty;

        public ImageForm()
        {
            InitializeComponent();
            //this.baseDir = baseDir;

            // http://stackoverflow.com/questions/2069048/setting-the-filter-to-an-openfiledialog-to-allow-the-typical-image-formats
            //var imageExtensions = string.Join(";", ImageCodecInfo.GetImageDecoders().Select(ici => ici.FilenameExtension)); dialog.Filter = string.Format("Images|{0}|All Files|*.*", imageExtensions);

            string[] allowedExtensions = new string[] { "BMP", "DIB", "RLE", "JPG", "JPEG", "JPE", "JFIF", "GIF", "TIF", "TIFF", "PNG" };

            //foreach (string fileName in Directory.GetFiles(baseDir))
            //{
            //    string check = fileName.ToUpper();
            //    string[] parts = check.Split('.');
            //    string lastPart = parts[parts.Length - 1];
            //    if (allowedExtensions.Contains<string>(lastPart))
            //    {
            //        listBox1.Items.Add(Path.GetFileName(fileName));
            //    }
            //}
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            MinimumSize = Size; // don't allow it to get smaller than originally set up
            Load();

            if (!string.IsNullOrEmpty(Link))
            {
                string searchFor = Link.Replace("notebook://", "");
                int foundAt = listBox1.FindStringExact(searchFor);
                listBox1.SelectedIndex = foundAt;

                if (foundAt == -1)
                {
                    //pictureBox1.Image = GetImage(Link);
                    pictureBox1.ImageLocation = Link;
                    pictureBox1.Load();

                    panel1.Visible = true;
                    pictureBox1.Visible = true;

                    pictureBox1.Size = pictureBox1.Image.Size;
                }

                textBox2.Text = Link;
                textBox2.Enabled = false;
                listBox1.Enabled = false;
                button3.Enabled = false;
            }
        }

        private Image GetImage(string link)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(link);
            Bitmap bitmap; bitmap = new Bitmap(stream);

            //if (bitmap != null)
            //{
            //    bitmap.Save(filename, format);
            //}

            stream.Flush();
            stream.Close();
            client.Dispose();

            return bitmap;
        }


        public EventHandler<EmbeddedFragmentEventArgs>? EmbeddedFragmentHandler { get; set; }

        public string Link { get; set; }

        private void Load()
        {             // GET
            //listBox1.Items.Clear();
            //EmbeddedFragmentEventArgs args = new();
            //args.Operation = "LIST_TEXT_BLOCKS";
            //EmbeddedFragmentHandler?.Invoke(this, args);
            //foreach (string str in args.Names)
            //{
            //    listBox1.Items.Add(str);
            //}

            listBox1.Items.Clear();
            EmbeddedFragmentEventArgs args = new();
            args = new();
            args.Operation = "LIST_IMAGE_BLOCKS";
            EmbeddedFragmentHandler?.Invoke(this, args);
            foreach (string str in args.Names)
            {
                listBox1.Items.Add(str);
            }
        }

        public string ResultText { get; set; }

        private void FormatResult()
        {
            string display = textBox1.Text;
            string linkText = textBox2.Text;
            string tooltip = textBox3.Text;

            if ((string.IsNullOrEmpty(display)) && (!string.IsNullOrEmpty(linkText)))
            {
                display = linkText;
            }

            if (string.IsNullOrEmpty(linkText))
            {
                ResultText = string.Empty;
                return;
            }

            if (!string.IsNullOrEmpty(tooltip))
            {
                linkText = $"{linkText} \"{tooltip}\"";
            }

            ResultText = $"![{display}]({linkText})\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormatResult();

            Link = textBox2.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = string.Format("./{0}", listBox1.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Images|*.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG|BMP Files: (*.BMP;*.DIB;*.RLE)|*.BMP;*.DIB;*.RLE|JPEG Files: (*.JPG;*.JPEG;*.JPE;*.JFIF)|*.JPG;*.JPEG;*.JPE;*.JFIF|GIF Files: (*.GIF)|*.GIF|TIFF Files: (*.TIF;*.TIFF)|*.TIF;*.TIFF|PNG Files: (*.PNG)|*.PNG|All Files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // https://superuser.com/questions/1199393/is-it-possible-to-directly-embed-an-image-into-a-markdown-document
                Image img = Image.FromFile(ofd.FileName);
                if (img != null)
                {
                    ProcessImage(img);
                }
            }
        }

        private void ProcessImage(Image img)
        {
            EmbeddedFragmentEventArgs args = new();
            args.Operation = "SAVE";

            string name = DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".jpg";
            PageFragment frag = new PageFragment { Id = Guid.NewGuid().ToString("D").ToUpper(), Name = name };

            frag.FragmentType = "image/jpeg";
            frag.Content = ImageToBase64(img);

            args.Value = frag;

            EmbeddedFragmentHandler?.Invoke(this, args);

            //richTextBox1.SelectedText = $"![Alt text](notebook://{name})";
            int itemNum = listBox1.Items.Add(name);
            listBox1.SelectedIndex = itemNum;
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmbeddedFragmentEventArgs args = new();
            args.Operation = "GET";
            args.Key = listBox1.Items[listBox1.SelectedIndex].ToString();
            EmbeddedFragmentHandler?.Invoke(this, args);

            PageFragment frag = args.Value;

            //label6.Text = frag.Id;
            //textBox1.Text = frag.Name;
            //comboBox1.SelectedIndex = 1;

            textBox1.Text = args.Key;

            textBox2.Text = $"notebook://{args.Key}";
            textBox2.ReadOnly = true;

            pictureBox1.Image = Base64ToImage(frag.Content);

            //            textBox2.Visible = false;
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

    }
}
