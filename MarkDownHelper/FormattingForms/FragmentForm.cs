namespace MarkDownHelper
{
    public partial class FragmentForm : Form
    {
        string baseDir = string.Empty;

        public FragmentForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            MinimumSize = Size; // don't allow it to get smaller than originally set up
            Load();
        }

        public EventHandler<EmbeddedFragmentEventArgs>? EmbeddedFragmentHandler { get; set; }

        private void Load()
        {
            listBox1.Items.Clear();
            EmbeddedFragmentEventArgs args = new();
            args = new();
            args.Operation = "LIST_TEXT_BLOCKS";
            EmbeddedFragmentHandler?.Invoke(this, args);
            foreach (string str in args.Names)
            {
                listBox1.Items.Add(str);
            }
        }


        public string ResultText { get; set; }

        private void FormatResult()
        {
            //string display = textBox1.Text;
            //string linkText = textBox2.Text;
            //string tooltip = textBox3.Text;

            //if ((string.IsNullOrEmpty(display)) && (!string.IsNullOrEmpty(linkText)))
            //{
            //    display = linkText;
            //}

            //if (string.IsNullOrEmpty(linkText))
            //{
            //    ResultText = string.Empty;
            //    return;
            //}

            //if (!string.IsNullOrEmpty(tooltip))
            //{
            //    linkText = $"{linkText} \"{tooltip}\"";
            //}

            //ResultText = $"![{display}]({linkText})\n";

            ResultText = $"[embeddedfragment:{fragmentId}]";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormatResult();

            DialogResult = DialogResult.OK;
            Close();
        }

        string fragmentId = string.Empty;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmbeddedFragmentEventArgs args = new();
            args.Operation = "GET";
            fragmentId = listBox1.Items[listBox1.SelectedIndex].ToString();
            args.Key = fragmentId;
            EmbeddedFragmentHandler?.Invoke(this, args);

            PageFragment frag = args.Value;

            textBox1.Text = frag.Content.Replace("\n", "\r\n");

            //            textBox2.Visible = false;
            panel1.Visible = true;
            textBox1.Visible = true;
        }
    }
}
