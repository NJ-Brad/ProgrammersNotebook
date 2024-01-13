using System.Drawing.Imaging;

namespace PasteTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image img = Clipboard.GetImage();
            if (img != null)
            {
                pictureBox1.Image = img;

                // https://www.techieclues.com/blogs/converting-image-to-base64-string-in-csharp
                using (MemoryStream stream = new MemoryStream())
                {
                    img.Save(stream, ImageFormat.Bmp);
                    byte[] imageBytes = stream.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    //Console.WriteLine(base64String);
                    textBox1.Text = base64String;
                }
            }
        }
    }
}
