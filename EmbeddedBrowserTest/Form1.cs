namespace EmbeddedBrowserTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            browserWrapper1.ShowUrl("https://www.microsoft.com");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            browserWrapper1.ShowHtmlText("<html><body><img src=\"notebook://Image+One.jpg\"></body></html>");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            browserWrapper1.ShowMarkdownText("# Hello Brad  ");
        }
    }
}
