using Markdig;

namespace MarkDownHelper
{
    partial class MarkDownDisplay : UserControl
    {
        public MarkDownDisplay()
        {
            InitializeComponent();
        }

        private bool readOnly;

        private string fileName;

        public string FileName { get => fileName; set { fileName = value; Show(fileName); } }

        public bool ReadOnly { get => readOnly; set { readOnly = value; panel1.Visible = !readOnly; } }

        //private void ShowContent(string html)
        //{
        //    // https://weblogs.asp.net/gunnarpeipman/displaying-custom-html-in-webbrowser-control
        //    webBrowser1.Navigate("about:blank");
        //    if (webBrowser1.Document != null)
        //    {
        //        webBrowser1.Document.Write(string.Empty);
        //    }

        //    string newText = html.EnableNewerFeatures().AddGitHubStyle();
        //    if (!string.IsNullOrEmpty(FileName))
        //    {
        //        newText = newText.TranslatePaths(Path.GetDirectoryName(FileName));
        //    }
        //    webBrowser1.DocumentText = newText;
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, "");
            }

            Editor.Edit(fileName);
            Show(fileName);
        }

        private void Show(string fileName)
        {
            if (File.Exists(fileName))
            {
                this.fileName = fileName;

                string readmeText = File.ReadAllText(fileName);

                // Configure the pipeline with all advanced extensions active
                var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseSoftlineBreakAsHardlineBreak().Build();


                string val = Markdig.Markdown.ToHtml(readmeText, pipeline);
                ShowContent(Markdig.Markdown.ToHtml(readmeText, pipeline));
            }
            else
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    ShowContent("<H3>No file selected</H3>");
                }
                else
                {
                    ShowContent(string.Format("<H3>No {0} found</H3>", Path.GetFileName(fileName)));
                }
            }
        }

        private void ShowContent(string content)
        {
            ShowText(content, webBrowser1);
        }

        private void ShowText(string rawText, WebBrowser control)
        {
            //if (!created)
            //    return;

            string readmeText = rawText;

            // https://talk.commonmark.org/t/markdig-markdown-processor-for-net/2106

            //https://github.com/lunet-io/markdig
            // https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor
            // http://markdownpad.com/
            // https://guides.github.com/pdfs/markdown-cheatsheet-online.pdf
            // https://confluence.atlassian.com/bitbucketserver/markdown-syntax-guide-776639995.html
            // https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet#tables

            // https://github.github.com/github-flavored-markdown/sample_content.html

            // Configure the pipeline with all advanced extensions active
            //var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseSoftlineBreakAsHardlineBreak().Use<EmbeddedImageExtension>().Build();
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseSoftlineBreakAsHardlineBreak()
                .UsePredefinedImageExtension()
                //.Use<PredefinedImageExtension>()
                .UseEmbeddedImageExtension(GetEmbedText)
                //.Use<EmbeddedImageExtension>(new EmbeddedImageExtension(GetEmbedText))
                .Build();

            //string val = Markdig.Markdown.ToHtml(readmeText.FixLineFeeds(), pipeline);
            //            ShowContent(control, Markdig.Markdown.ToHtml(readmeText.FixLineFeeds().TranslatePaths(Path.GetDirectoryName(fileName).GenerateToc()), pipeline));

            // https://weblogs.asp.net/gunnarpeipman/displaying-custom-html-in-webbrowser-control
            control.Navigate("about:blank");
            if (control.Document != null)
            {
                control.Document.Write(string.Empty);
            }

            if (!string.IsNullOrEmpty(fileName))
            {
                //ShowContent(control, Markdig.Markdown.ToHtml(readmeText
                //    .EnableNewerFeatures()
                //    .AddGitHubStyle()
                //    .TranslatePaths(Path.GetDirectoryName(fileName))
                //    .GenerateToc(), 
                //    pipeline));

                control.DocumentText = Markdig.Markdown.ToHtml(readmeText
                    .EnableNewerFeatures()
                    .AddGitHubStyle()
                    .TranslatePaths(Path.GetDirectoryName(fileName))
                    .GenerateToc(),
                    pipeline);
            }
            else
            {
                //                ShowContent(control, Markdig.Markdown.ToHtml(readmeText.GenerateToc(), pipeline));

                control.DocumentText = Markdig.Markdown.ToHtml(readmeText
                    .EnableNewerFeatures()
                    .AddGitHubStyle()
                    .GenerateToc(),
                    pipeline);

                //if (created)
                //{
                //    webView21.NavigateToString(Markdig.Markdown.ToHtml(readmeText
                //    .EnableNewerFeatures()
                //    .AddGitHubStyle()
                //    .GenerateToc(),
                //    pipeline));
                //}
            }
        }

        private string GetEmbedText(string key)
        {
            return key;
        }

    }
}
