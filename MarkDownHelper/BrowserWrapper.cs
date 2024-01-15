using Markdig;
using Microsoft.Web.WebView2.Core;
using System.Diagnostics;

namespace MarkDownHelper
{
    public partial class BrowserWrapper : UserControl
    {

        public string RootPath { get; set; } = string.Empty;

        public BrowserWrapper()
        {
            InitializeComponent();
        }

        bool initialized = false;

        protected override async void OnCreateControl()
        {
            base.OnCreateControl();
            webView21.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
            await webView21.EnsureCoreWebView2Async(null);

        }

        public void SetUp()
        {
            webView21.CoreWebView2.WebResourceRequested += CoreWebView2_WebResourceRequested;
            //webView21.CoreWebView2.AddWebResourceRequestedFilter("https://www.microsoft.com/*", CoreWebView2WebResourceContext.All);
            webView21.CoreWebView2.AddWebResourceRequestedFilter("notebook://*", CoreWebView2WebResourceContext.All);
            //            webView21.CoreWebView2.Navigate("https://www.microsoft.com");

            //webView21.CoreWebView2.NavigateToString("<html><body><img src=\"notebook://Image+One.jpg\"></body></html>");
        }

        // ShowUrl
        public void ShowUrl(string url)
        {
            if (!initialized)
                return;

            webView21.CoreWebView2.Navigate(url);
        }

        // ShowFile
        public void ShowFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                RootPath = Path.GetDirectoryName(fileName);
            }
            else
                return;

            string fileText = File.ReadAllText(fileName);

            if (Path.GetExtension(fileName).Equals("md", StringComparison.OrdinalIgnoreCase))
            {
                ShowMarkdownText(fileText);
            }
            else
            {
                ShowHtmlText(fileText);
            }
        }

        // ShowText
        public void ShowHtmlText(string textToShow)
        {
            if (!initialized)
                return;

            webView21.CoreWebView2.NavigateToString(textToShow);
        }


        // https://stackoverflow.com/questions/66550671/ensurecorewebview2async-not-ready-even-after-corewebview2initializationcompleted
        //async Task InitializeBrowser()
        //{
        //    webView21.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;

        //    // this bad boy is being a pain in the butt
        //    await webView21.EnsureCoreWebView2Async(null);
        //    //            webView21.CoreWebView2.Navigate("about:blank");


        //    //webView21.CoreWebView2.Navigate("about:blank");
        //    // https://learn.microsoft.com/en-us/microsoft-edge/webview2/concepts/working-with-local-content?tabs=dotnetcsharp#loading-local-content-by-handling-the-webresourcerequested-event
        //    //webView21.CoreWebView2.WebResourceRequested += CoreWebView2_WebResourceRequested;
        //    //webView21.CoreWebView2.Navigate("https://www.microsoft.com");

        //    initialized = true;
        //}

        private void WebView_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            Debug.WriteLine("WebView_CoreWebView2InitializationCompleted");
            initialized = true;
            SetUp();
        }

        // https://learn.microsoft.com/en-us/microsoft-edge/webview2/concepts/working-with-local-content?tabs=dotnetcsharp#loading-local-content-by-handling-the-webresourcerequested-event
        private void CoreWebView2_WebResourceRequested(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2WebResourceRequestedEventArgs e)
        {
            //            throw new NotImplementedException();
        }

        public void ShowMarkdownText(string rawText)
        {
            if (!initialized)
                return;

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

            // https://weblogs.asp.net/gunnarpeipman/displaying-custom-html-in-webbrowser-control
            //control.Navigate("about:blank");
            //if (control.Document != null)
            //{
            //    control.Document.Write(string.Empty);
            //}

            if (!string.IsNullOrEmpty(RootPath))
            {
                ShowHtmlText(Markdig.Markdown.ToHtml(rawText + (rawText.EndsWith('\n') ? "" : "\n")
                    .EnableNewerFeatures()
                    .AddGitHubStyle()
                    .TranslatePaths(RootPath)
                    .GenerateToc(),
                    pipeline));
                //webView21.NavigateToString(Markdig.Markdown.ToHtml(readmeText
                //    .EnableNewerFeatures()
                //    .AddGitHubStyle()
                //    .TranslatePaths(RootPath)
                //    .GenerateToc(),
                //    pipeline));
            }
            else
            {
                webView21.NavigateToString(Markdig.Markdown.ToHtml(rawText + (rawText.EndsWith('\n') ? "" : "\n")
                .EnableNewerFeatures()
                .AddGitHubStyle()
                .GenerateToc(),
                pipeline));
            }
        }
        private string GetEmbedText(string key)
        {
            return key;
        }
    }
}
