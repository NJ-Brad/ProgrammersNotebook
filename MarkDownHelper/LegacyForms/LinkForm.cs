namespace MarkDownHelper
{
    public partial class LinkForm : Form
    {
        public LinkForm()
        {
            InitializeComponent();
        }

        public string Link { get; set; }
        public string Description { get; set; }
        public string ResultText { get; set; }

        protected async override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            MinimumSize = Size; // don't allow it to get smaller than originally set up
            //Load();

            if (!string.IsNullOrEmpty(Link))
            {
                textBox2.Text = Link;
                //                string description = await GetDescription(Link);
                textBox1.Text = textBox3.Text = Description;
            }
        }


        //private async Task<string> GetDescription(string url)
        //{
        //    string rtnVal = "";

        //    using HttpClient client = new()
        //    {
        //        BaseAddress = new Uri(url),
        //    };

        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.Add("User-Agent", "web api client");

        //    using HttpResponseMessage response = await client.GetAsync("");

        //    var stringResponse = await response.Content.ReadAsStringAsync();

        //    int titleStart = stringResponse.IndexOf("<title>", StringComparison.OrdinalIgnoreCase);
        //    if (titleStart != -1)
        //    {
        //        titleStart += 7;
        //        int titleEnd = stringResponse.IndexOf("</title>", titleStart, StringComparison.OrdinalIgnoreCase);

        //        rtnVal = stringResponse.Substring(titleStart, (titleEnd - titleStart));
        //        //                textBox6.DataBindings[0].ReadValue();
        //    }

        //    return rtnVal;
        //}


        //public string Display
        //{
        //    get
        //    {
        //        return this.display;
        //    }
        //    set
        //    {
        //        this.display = value;
        //    }
        //}

        //public string LinkText
        //{
        //    get
        //    {
        //        return this.link;
        //    }
        //    set
        //    {
        //        this.link = value;
        //    }
        //}

        //public string Tooltip
        //{
        //    get
        //    {
        //        return this.tooltip;
        //    }
        //    set
        //    {
        //        this.tooltip = value;
        //    }
        //}

        //public static string CreateLinkText()
        //{
        //    string rtnVal = string.Empty;

        //    LinkForm form = new LinkForm();
        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        string display = string.Empty;
        //        string linkText = string.Empty;
        //        string tooltip = string.Empty;

        //        if (!string.IsNullOrEmpty(form.Display))
        //        {
        //            display = form.Display;
        //        }
        //        else
        //        {
        //            if (!string.IsNullOrEmpty(form.LinkText))
        //            {
        //                display = form.LinkText;
        //            }
        //        }

        //        linkText = form.LinkText;
        //        tooltip = form.Tooltip;

        //        if (string.IsNullOrEmpty(linkText))
        //        {
        //            return string.Empty;
        //        }

        //        if (!string.IsNullOrEmpty(tooltip))
        //        {
        //            linkText = string.Format("{0} \"{1}\"", linkText, tooltip);
        //        }

        //        rtnVal = string.Format("[{0}]({1})", display, linkText);
        //    }
        //    return rtnVal;
        //}

        private void button1_Click(object sender, EventArgs e)
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
            }
            else
            {
                if (!string.IsNullOrEmpty(tooltip))
                {
                    linkText = $"{linkText} \"{tooltip}\"";
                }

                ResultText = $"[{display}]({linkText})";
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
