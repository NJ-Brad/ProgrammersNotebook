using Markdig;
using MarkDownHelper.AlertExtension;
using Microsoft.Web.WebView2.Core;
using System.Diagnostics;
using System.Text;

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
        public Dictionary<string, string> Replacements = new();

        protected override async void OnCreateControl()
        {
            base.OnCreateControl();
            webView21.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
            await webView21.EnsureCoreWebView2Async(null);
        }

        private void CoreWebView2_PermissionRequested(object? sender, CoreWebView2PermissionRequestedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private bool setUpHandlersPending = true;

        public void SetUpHandlers()
        {
            if (initialized)
            {
                if (ProtocolHandlers.Count > 0)
                {
                    webView21.CoreWebView2.WebResourceRequested += CoreWebView2_WebResourceRequested;

                    foreach (CustomProtocolHandler handler in ProtocolHandlers)
                    {
                        webView21.CoreWebView2.AddWebResourceRequestedFilter(handler.Prefix, CoreWebView2WebResourceContext.All);
                    }
                }

                webView21.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;

                //webView21.CoreWebView2.WebResourceRequested += CoreWebView2_WebResourceRequested;
                ////webView21.CoreWebView2.AddWebResourceRequestedFilter("https://www.microsoft.com/*", CoreWebView2WebResourceContext.All);
                //webView21.CoreWebView2.AddWebResourceRequestedFilter("notebook://*", CoreWebView2WebResourceContext.All);
                ////            webView21.CoreWebView2.Navigate("https://www.microsoft.com");

                ////webView21.CoreWebView2.NavigateToString("<html><body><img src=\"notebook://Image+One.jpg\"></body></html>");
            }
            else
            {
                setUpHandlersPending = true;
            }
        }

        public bool NavComplete { get; set; }

        private void CoreWebView2_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            NavComplete = true;
        }

        public EventHandler<EmbeddedFragmentEventArgs>? EmbeddedFragmentHandler { get; set; } = null;

        public List<CustomProtocolHandler> ProtocolHandlers { get; set; } = new();

        // ShowUrl
        public void ShowUrl(string url)
        {
            if (!initialized)
                return;

            NavComplete = false;

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

            NavComplete = false;
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

            NavComplete = false;

            webView21.CoreWebView2.NavigateToString(textToShow);
            // This looks promising : https://www.rgraph.net/blog/2023/how-to-add-a-copy-to-clipboard-button-to-your-code-examples.html

            // use docfx instead? : https://dotnet.github.io/docfx/docs/markdown.html?tabs=linux%2Cdotnet

            // http://www.tcbin.com/2017/12/copy-clipboard-button-code-prettify-google.html
            // https://www.codewithfaraz.com/content/164/create-a-code-snippet-box-with-copy-functionality
            // https://stackoverflow.com/questions/49110041/how-can-i-copy-pre-tag-code-into-clipboard-in-html
            // https://www.dbaplus.ca/2021/11/javascriptcss-add-copy-to-clipboard.html
            // mkdocs is written in python : https://www.mkdocs.org/getting-started/
            // https://squidfunk.github.io/mkdocs-material/reference/code-blocks/
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
            //SetUp();

            webView21.CoreWebView2.PermissionRequested += CoreWebView2_PermissionRequested;

            if (setUpHandlersPending)
                SetUpHandlers();

            if (!string.IsNullOrEmpty(showThisOnceInitialized))
            {
                ShowMarkdownText(showThisOnceInitialized);
                showThisOnceInitialized = string.Empty;
            }
        }

        // https://learn.microsoft.com/en-us/microsoft-edge/webview2/concepts/working-with-local-content?tabs=dotnetcsharp#loading-local-content-by-handling-the-webresourcerequested-event
        private void CoreWebView2_WebResourceRequested(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2WebResourceRequestedEventArgs e)
        {

            if (ProtocolHandlers.Count > 0)
            {
                webView21.CoreWebView2.WebResourceRequested += CoreWebView2_WebResourceRequested;

                foreach (CustomProtocolHandler handler in ProtocolHandlers)
                {
                    string protocolValue = handler.Prefix.Substring(0, handler.Prefix.Length - 1);

                    if (e.Request.Uri.Substring(0, handler.Prefix.Length - 1).Equals(protocolValue, StringComparison.OrdinalIgnoreCase))
                    {
                        // testing purposes only (empty args)
                        //                        handler.Handler(this, new CustomProtocolEventArgs());


                        CustomProtocolEventArgs args = new CustomProtocolEventArgs
                        {
                            Protocol = protocolValue,
                            Requested = e.Request.Uri.Substring(handler.Prefix.Length - 1)
                        };
                        handler.Handler(this, args);

                        /*
                                public string Protocol { get; set; } = "*";
                                public string Requested { get; set; } = string.Empty;
                                public bool Found { get; set; } = false;
                                public Stream? ReturnData { get; set; } = null;
                                public List<string> Headers { get; set; } = new();
                         */

                        if (args.Found)
                        {

                            StringBuilder headers = new StringBuilder();
                            foreach (string str in args.Headers)
                            {
                                headers.AppendLine(str);
                            }
                            e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(
                                                                                args.ReturnData, 200, "OK", headers.ToString());
                        }
                        else
                        {
                            e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(
                                                                            null, 404, "Not found", "");

                        }
                    }
                }
            }
            // this goes in Setup - one for each protocol
            // webView.CoreWebView2.AddWebResourceRequestedFilter("https://demo/*", CoreWebView2WebResourceContext.All);

            // this goes in Setup - Once - This calls a separate method
            // webView21.CoreWebView2.WebResourceRequested += CoreWebView2_WebResourceRequested;

            // this uses an inline delegate
            //webView.CoreWebView2.WebResourceRequested += delegate (object sender, CoreWebView2WebResourceRequestedEventArgs args)
            //{
            //    string assetsFilePath = "C:\\Demo\\" + args.Request.Uri.Substring("https://demo/*".Length - 1);
            //    try
            //    {
            //        FileStream fs = File.OpenRead(assetsFilePath);
            //        ManagedStream ms = new ManagedStream(fs);
            //        string headers = "";
            //        if (assetsFilePath.EndsWith(".html"))
            //        {
            //            headers = "Content-Type: text/html";
            //        }
            //        else if (assetsFilePath.EndsWith(".jpg"))
            //        {
            //            headers = "Content-Type: image/jpeg";
            //        } else if (assetsFilePath.EndsWith(".png"))
            //{
            //    headers = "Content-Type: image/png";
            //}
            //else if (assetsFilePath.EndsWith(".css"))
            //{
            //    headers = "Content-Type: text/css";
            //}
            //else if (assetsFilePath.EndsWith(".js"))
            //{
            //    headers = "Content-Type: application/javascript";
            //}

            //args.Response = webView.CoreWebView2.Environment.CreateWebResourceResponse(
            //                                                    ms, 200, "OK", headers);
            //    }
            //    catch (Exception)
            //    {
            //    args.Response = webView.CoreWebView2.Environment.CreateWebResourceResponse(
            //                                                    null, 404, "Not found", "");
            //}
            //};
        }

        public string CodeTheme { get; set; } = "default";
        public int IndentSize { get; set; } = 4;

        public string ToHtml(string rawText)
        {
            // https://talk.commonmark.org/t/markdig-markdown-processor-for-net/2106

            // https://github.com/lunet-io/markdig
            // https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor
            // http://markdownpad.com/
            // https://guides.github.com/pdfs/markdown-cheatsheet-online.pdf
            // https://confluence.atlassian.com/bitbucketserver/markdown-syntax-guide-776639995.html
            // https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet#tables

            // https://github.github.com/github-flavored-markdown/sample_content.html

            return InternalConverter(rawText);

            //Replacer rep = new Replacer();
            //rep.Replacements = Replacements;
            //string repText = rep.DoReplacements(rawText);

            //// https://digitaltapestry.net/posts/markdig-cheat-sheet
            //// Configure the pipeline with all advanced extensions active
            ////var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseSoftlineBreakAsHardlineBreak().Use<EmbeddedImageExtension>().Build();
            //var pipeline = new MarkdownPipelineBuilder()
            //    .UseAlertContainerExtension(true)
            //    .UseAdvancedExtensions()
            //    .UseSoftlineBreakAsHardlineBreak()
            //    //.UsePredefinedImageExtension()
            //    //.UseEmbeddedImageExtension(GetEmbedImage)
            //    //.UseEmbeddedLinkResolverExtension("HelloBrad")
            //    //.UseEmbeddedLinkResolverExtension("HTTPS")
            //    .UseEmbeddedFragmentExtension(GetEmbedText)
            //    .Build();

            //return Markdig.Markdown.ToHtml(repText + (repText.EndsWith('\n') ? "" : "\n"), pipeline)
            //    .EnableNewerFeatures()
            //    .AddGitHubStyle()
            //    .TranslatePaths(RootPath)
            //    .GenerateToc()
            //    //.AddCodeCopyButtons2(CodeTheme)
            //    .AddCodeCopyButtons3(CodeTheme)
            //    .SetTabSize(IndentSize)
            //    ;

            // https://github.com/xoofx/markdig/issues/344
            // use of custom containers
            // https://github.com/xoofx/markdig/blob/master/src/Markdig.Tests/Specs/CustomContainerSpecs.md
            // bootstrap alert
            // https://github.com/xoofx/markdig/issues/162

            // markdown cheatsheet
            // https://digitaltapestry.net/posts/markdig-cheat-sheet
        }

        string showThisOnceInitialized = string.Empty;
        public void ShowMarkdownText(string rawText)
        {
            if (!initialized)
            {
                showThisOnceInitialized = rawText;
                return;
            }

            NavComplete = false;

            ShowHtmlText(ToHtml(rawText));
        }

        private string GetEmbedText(string key)
        {
            EmbeddedFragmentEventArgs args = new();
            args.Key = key;
            EmbeddedFragmentHandler?.Invoke(this, args);

            // This version will NOT convert the embedded text
            //return args.Value.Content;

            // This version will convert the embedded text.  I wonder how deep it can go.
            return InternalConverter(args.Value.Content);
        }

        private string InternalConverter(string rawText)
        {
            Replacer rep = new Replacer();
            rep.Replacements = Replacements;
            string repText = rep.DoReplacements(rawText);

            var pipeline = new MarkdownPipelineBuilder()
                .UseAlertContainerExtension(true)
                .UseAdvancedExtensions()
                .UseSoftlineBreakAsHardlineBreak()
                //.UsePredefinedImageExtension()
                //.UseEmbeddedImageExtension(GetEmbedImage)
                //.UseEmbeddedLinkResolverExtension("HelloBrad")
                //.UseEmbeddedLinkResolverExtension("HTTPS")
                .UseEmbeddedFragmentExtension(GetEmbedText)
                .Build();

            return Markdig.Markdown.ToHtml(repText + (repText.EndsWith('\n') ? "" : "\n"), pipeline)
                .EnableNewerFeatures()
                .AddGitHubStyle()
                .TranslatePaths(RootPath)
                .GenerateToc()
                //.AddCodeCopyButtons2(CodeTheme)
                .AddCodeCopyButtons3(CodeTheme)
                .SetTabSize(IndentSize)
                ;
        }

        private List<string> GetTextFragmentList()
        {
            //EmbeddedFragmentEventArgs args = new();
            //args.Key = key;
            //EmbeddedFragmentHandler?.Invoke(this, args);

            //return args.Value;

            return new();
        }

        private List<string> GetImageFragmentList()
        {
            //EmbeddedFragmentEventArgs args = new();
            //args.Key = key;
            //EmbeddedFragmentHandler?.Invoke(this, args);

            //return args.Value;

            return new();
        }

        // Reading of response content stream happens asynchronously, and WebView2 does not 
        // directly dispose the stream once it read.  Therefore, use the following stream
        // class, which properly disposes when WebView2 has read all data.  For details, see
        // [CoreWebView2 does not close stream content](https://github.com/MicrosoftEdge/WebView2Feedback/issues/2513).
        class ManagedStream : Stream
        {
            public ManagedStream(Stream s)
            {
                s_ = s;
            }

            public override bool CanRead => s_.CanRead;

            public override bool CanSeek => s_.CanSeek;

            public override bool CanWrite => s_.CanWrite;

            public override long Length => s_.Length;

            public override long Position { get => s_.Position; set => s_.Position = value; }

            public override void Flush()
            {
                throw new NotImplementedException();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                return s_.Seek(offset, origin);
            }

            public override void SetLength(long value)
            {
                throw new NotImplementedException();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                int read = 0;
                try
                {
                    read = s_.Read(buffer, offset, count);
                    if (read == 0)
                    {
                        s_.Dispose();
                    }
                }
                catch
                {
                    s_.Dispose();
                    throw;
                }
                return read;
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotImplementedException();
            }

            private Stream s_;
        }

    }
}
