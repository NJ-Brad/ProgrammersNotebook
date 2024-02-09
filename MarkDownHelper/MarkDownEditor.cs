using System.Drawing.Imaging;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace MarkDownHelper
{
    public delegate string OperationDelegate(string s);

    public partial class MarkDownEditor : UserControl //Form
    {
        // https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor2

        public MarkDownEditor()
        {
            InitializeComponent();
            // http://stackoverflow.com/questions/4823468/comments-in-markdown
            // (empty line)
            // [comment]: # (This actually is the most platform independent comment)

            ContextMenuStrip contextMenu = new();
            contextMenu.Font = new Font(Font.FontFamily, 14);

            contextMenu.ImageList = imageList1;
            contextMenu.ImageScalingSize = new Size(24, 24);

            // https://www.markdownguide.org/hacks/#indent-tab
            CreateMenuItem(contextMenu.Items, "Italic", "Italic.png", t => { return $"*{t}*"; });

            CreateMenuItem(contextMenu.Items, "Bold", "Bold.png", t => { return $"**{t}**"; });
            CreateMenuItem(contextMenu.Items, "Underline", "underline.png", t => { return $"__{t}__"; });
            CreateMenuItem(contextMenu.Items, "Strike", "Strike.png", t => { return $"~~{t}~~"; });

            ToolStripMenuItem headingMenuItem = new ToolStripMenuItem("Heading");
            headingMenuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            contextMenu.Items.Add(headingMenuItem);

            //headingMenuItem.DropDownItems

            //CreateMenuItem(contextMenu.Items, "Heading 1", "Header_1.png", t => { return $"# {t}"; });

            CreateMenuItem(headingMenuItem.DropDownItems, "Heading 1", "Header_1.png", t => { return $"# {t}"; });
            CreateMenuItem(headingMenuItem.DropDownItems, "Heading 2", "Header_2.png", t => { return $"## {t}"; });
            CreateMenuItem(headingMenuItem.DropDownItems, "Heading 3", "Header_3.png", t => { return $"### {t}"; });
            CreateMenuItem(headingMenuItem.DropDownItems, "Heading 4", "Header_4.png", t => { return $"#### {t}"; });
            CreateMenuItem(headingMenuItem.DropDownItems, "Heading 5", "Header_5.png", t => { return $"##### {t}"; });
            CreateMenuItem(headingMenuItem.DropDownItems, "Heading 6", "Header_6.png", t => { return $"###### {t}"; });

            CreateMenuItem(contextMenu.Items, "Ordered List", "OrderedList.png", t =>
            {
                string[] lines = t.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                foreach (string line in lines)
                {
                    sb.AppendLine($"1. {line}");
                }
                return sb.ToString().TrimEnd();
            });

            CreateMenuItem(contextMenu.Items, "Unordered List", "UnorderedList.png", t =>
            {
                string[] lines = t.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                foreach (string line in lines)
                {
                    sb.AppendLine($"+ {line}");
                }
                return sb.ToString().TrimEnd();
            });

            CreateMenuItem(contextMenu.Items, "Code", "Code.png", t =>
            {
                string codeString = CodeForm2.CreateLanguageText();
                //return string.IsNullOrEmpty(codeString) ? $"```\n{t}\n```\n" : $"\n{codeString}{t}\n```\n";
                return string.IsNullOrEmpty(codeString) ? t : $"{codeString}{t}\n```";
            });

            CreateMenuItem(contextMenu.Items, "Quote", "Quote.png", t =>
            {
                string[] lines = t.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                foreach (string line in lines)
                {
                    sb.AppendLine($"> {line}");
                }
                return sb.ToString().TrimEnd();
            });

            CreateMenuItem(contextMenu.Items, "Task", "Check.png", t =>
            {
                string[] lines = t.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                foreach (string line in lines)
                {
                    sb.AppendLine($"- [ ] {line}");
                }
                return sb.ToString().TrimEnd();
            });

            // https://www.markdownguide.org/cheat-sheet/
            CreateMenuItem(contextMenu.Items, "Highlight", "highlight.png", t => { return $"=={t}=="; });
            CreateMenuItem(contextMenu.Items, "Superscript", "superscript.png", t => { return $"^{t}^"; });
            CreateMenuItem(contextMenu.Items, "Subscript", "subscript.png", t => { return $"~{t}~"; });

            CreateMenuItem(contextMenu.Items, "Table", "Table.png", t => { return TableForm.CreateTableText(); });
            CreateMenuItem(contextMenu.Items, "Table Row", "TableRow.png", t =>
            {
                string lineBefore = GetLineBefore(richTextBox1);
                int cols = lineBefore.Occurrences('|') + 1; if (lineBefore.StartsWith("|")) cols--; if (lineBefore.TrimEnd().EndsWith("|")) cols--;
                StringBuilder sb = new StringBuilder("|"); for (int i = 0; i < cols; i++) { sb.Append("value|"); }
                sb.AppendLine();
                sb.Append(t);
                return sb.ToString();
            }
            );

            CreateMenuItem(contextMenu.Items, "Dictionary", "Dictionary.png", t => { return $"<dl>\n</dl>"; });
            CreateMenuItem(contextMenu.Items, "Definition", "Definition.png", t => { return DefinitionForm.CreateDefinitionText(); });

            CreateMenuItem(contextMenu.Items, "Divider", "Break.png", t => { return "\r\n----\r\n"; });
            CreateMenuItem(contextMenu.Items, "Link", "Link.png", t =>
            {
                LinkForm lf = new()
                {
                    Link = t
                };
                if (lf.ShowDialog() == DialogResult.OK)
                {
                    return lf.ResultText;
                }

                return string.Empty;
            });

            //ConnectButton(buttonTxtBlock, t => { return $"####{t}####"; });

            //CreateMenuItem(contextMenu.Items, "Image", "Image.png", t => { return ImageForm.CreateImageText(Path.GetDirectoryName(fileName)); });
            CreateMenuItem(contextMenu.Items, "Image", "Image.png", t =>
            {
                ImageForm if2 = new()
                {
                    EmbeddedFragmentHandler = EmbeddedFragmentHandler
                };
                if (if2.ShowDialog() == DialogResult.OK)
                {
                    return if2.ResultText;
                }

                return string.Empty;
                //return ImageForm2.CreateImageText(EmbeddedFragmentHandler, "");
            });

            CreateMenuItem(contextMenu.Items, "Fragment", "outdent.png", t =>
            {
                FragmentForm ff2 = new()
                {
                    EmbeddedFragmentHandler = EmbeddedFragmentHandler
                };
                if (ff2.ShowDialog() == DialogResult.OK)
                {
                    return ff2.ResultText;
                }

                return string.Empty;
                //return ImageForm2.CreateImageText(EmbeddedFragmentHandler, "");
            });

            contextMenu.Items.Add(new ToolStripSeparator());

            ToolStripMenuItem menuItem = new ToolStripMenuItem("Cut");
            menuItem.ImageKey = "cut.png";
            menuItem.Click += new EventHandler(CutAction);
            contextMenu.Items.Add(menuItem);

            menuItem = new ToolStripMenuItem("Copy");
            menuItem.ImageKey = "copy.png";
            menuItem.Click += new EventHandler(CopyAction);
            contextMenu.Items.Add(menuItem);

            menuItem = new ToolStripMenuItem("Paste");
            menuItem.ImageKey = "paste.png";
            menuItem.Click += new EventHandler(PasteAction);
            contextMenu.Items.Add(menuItem);

            richTextBox1.ContextMenuStrip = contextMenu;

            toolStripButtonEdit.Enabled = false;

            //toolStripComboBox1.SelectedItem = "default";
            //toolStripComboBox2.SelectedItem = "default";
            //toolStripComboBox3.SelectedItem = "2";
            //toolStripComboBox4.SelectedItem = "2";
        }

        private ToolStripMenuItem CreateMenuItem(ToolStripItemCollection items, string label, string imageKey, OperationDelegate del)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(label);

            menuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            menuItem.Image = imageList1.Images[imageKey];

            //menuItem.ImageKey = imageKey;
            //            menuItem.Click += new EventHandler(CutAction);
            menuItem.Click += (sender, args) =>
            {
                DoOperation
                (
                    del
                );
            };

            items.Add(menuItem);

            return menuItem;
        }

        private void DoOperation(OperationDelegate del)
        {
            string beforeText = richTextBox1.SelectedText;
            string trimmedText = beforeText.TrimEnd();
            bool replaceEOL = !beforeText.Equals(trimmedText);
            string endText = beforeText.Equals(trimmedText) ? string.Empty : "\r\n";

            string afterText = $"{del(trimmedText)}{endText}";

            richTextBox1.SelectedText = afterText;

            ShowText(richTextBox1.Text);
        }


        public void SetUpHandlers()
        {
            browserWrapper1.SetUpHandlers();
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                this.fileName = value;
                Text = this.fileName;
                if (!string.IsNullOrEmpty(fileName))
                {
                    openToolStripMenuItem.Enabled = false;
                    saveAsToolStripMenuItem.Enabled = false;
                    LoadFileToEdit(fileName);
                }
            }
        }

        public EventHandler<EmbeddedFragmentEventArgs>? EmbeddedFragmentHandler
        {
            get { return browserWrapper1.EmbeddedFragmentHandler; }
            set { browserWrapper1.EmbeddedFragmentHandler = value; }
        }

        public List<CustomProtocolHandler> ProtocolHandlers
        {
            get { return browserWrapper1.ProtocolHandlers; }
            set { browserWrapper1.ProtocolHandlers = value; }
        }

        public bool NavComplete { get { return browserWrapper1.NavComplete; } }

        private bool handleFiles = true;
        public bool HandleFiles
        {
            get { return handleFiles; }
            set
            {
                handleFiles = value;
                toolStripDropDownButton5.Visible = handleFiles;
                toolStripButtonSave.Visible = !handleFiles;
            }
        }

        private bool viewMode = true;
        public bool ViewMode
        {
            get { return viewMode; }
            set
            {
                SuspendLayout();

                viewMode = value;
                toolStripButtonSave.Visible = !handleFiles && !viewMode;
                splitContainer1.Panel1Collapsed = viewMode;
                //toolStrip1.Visible = !viewMode;
                toolStrip3.Visible = !viewMode;
                toolStrip2.Visible = viewMode;

                ResumeLayout(false);
                PerformLayout();
            }
        }

        Operations operations = new Operations();

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ShowText(richTextBox1.Text);
        }

        public Dictionary<string, string> Replacements = new();

        private void ShowText(string rawText)
        {
            browserWrapper1.Replacements = Replacements;

            browserWrapper1.ShowMarkdownText(rawText);
        }

        public string ToHtml(string rawText)
        {
            return browserWrapper1.ToHtml(rawText);
        }

        //private void ShowText(string rawText, WebBrowser control)
        //{
        //    if (!created)
        //        return;

        //    string readmeText = rawText;

        //    // https://talk.commonmark.org/t/markdig-markdown-processor-for-net/2106

        //    //https://github.com/lunet-io/markdig
        //    // https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor
        //    // http://markdownpad.com/
        //    // https://guides.github.com/pdfs/markdown-cheatsheet-online.pdf
        //    // https://confluence.atlassian.com/bitbucketserver/markdown-syntax-guide-776639995.html
        //    // https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet#tables

        //    // https://github.github.com/github-flavored-markdown/sample_content.html

        //    // Configure the pipeline with all advanced extensions active
        //    //var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseSoftlineBreakAsHardlineBreak().Use<EmbeddedImageExtension>().Build();
        //    var pipeline = new MarkdownPipelineBuilder()
        //        .UseAdvancedExtensions()
        //        .UseSoftlineBreakAsHardlineBreak()
        //        .UsePredefinedImageExtension()
        //        //.Use<PredefinedImageExtension>()
        //        .UseEmbeddedImageExtension(GetEmbedText)
        //        //.Use<EmbeddedImageExtension>(new EmbeddedImageExtension(GetEmbedText))
        //        .Build();

        //    //string val = Markdig.Markdown.ToHtml(readmeText.FixLineFeeds(), pipeline);
        //    //            ShowContent(control, Markdig.Markdown.ToHtml(readmeText.FixLineFeeds().TranslatePaths(Path.GetDirectoryName(fileName).GenerateToc()), pipeline));

        //    // https://weblogs.asp.net/gunnarpeipman/displaying-custom-html-in-webbrowser-control
        //    control.Navigate("about:blank");
        //    if (control.Document != null)
        //    {
        //        control.Document.Write(string.Empty);
        //    }

        //    if (!string.IsNullOrEmpty(fileName))
        //    {
        //        //ShowContent(control, Markdig.Markdown.ToHtml(readmeText
        //        //    .EnableNewerFeatures()
        //        //    .AddGitHubStyle()
        //        //    .TranslatePaths(Path.GetDirectoryName(fileName))
        //        //    .GenerateToc(), 
        //        //    pipeline));

        //        control.DocumentText = Markdig.Markdown.ToHtml(readmeText
        //            .EnableNewerFeatures()
        //            .AddGitHubStyle()
        //            .TranslatePaths(Path.GetDirectoryName(fileName))
        //            .GenerateToc(),
        //            pipeline);
        //    }
        //    else
        //    {
        //        //                ShowContent(control, Markdig.Markdown.ToHtml(readmeText.GenerateToc(), pipeline));

        //        control.DocumentText = Markdig.Markdown.ToHtml(readmeText
        //            .EnableNewerFeatures()
        //            .AddGitHubStyle()
        //            .GenerateToc(),
        //            pipeline);

        //        if (created)
        //        {
        //            webView21.NavigateToString(Markdig.Markdown.ToHtml(readmeText
        //            .EnableNewerFeatures()
        //            .AddGitHubStyle()
        //            .GenerateToc(),
        //            pipeline));
        //        }
        //    }
        //}

        //private string GetEmbedText(string key)
        //{
        //    return key;
        //}

        private void Show(string fileName, WebBrowser control)
        {
            if (File.Exists(fileName))
            {
                string readmeText = File.ReadAllText(fileName);

                //ShowText(readmeText, control);
                ShowText(readmeText);
            }
            else
            {
                //ShowText(string.Format("<H3>No {0} found</H3>", Path.GetFileName(fileName)), control);
                ShowText(string.Format("<H3>No {0} found</H3>", Path.GetFileName(fileName)));
            }
        }

        //private void ShowContent(WebBrowser control, string html)
        //{
        //    // https://weblogs.asp.net/gunnarpeipman/displaying-custom-html-in-webbrowser-control
        //    control.Navigate("about:blank");
        //    if (control.Document != null)
        //    {
        //        control.Document.Write(string.Empty);
        //    }
        //    if (!string.IsNullOrEmpty(fileName))
        //    {
        //        control.DocumentText = html.EnableNewerFeatures().AddGitHubStyle().TranslatePaths(Path.GetDirectoryName(fileName));
        //    }
        //    else
        //    {
        //        control.DocumentText = html.EnableNewerFeatures().AddGitHubStyle();

        //        if (created)
        //        {
        //            webView21.NavigateToString(html.EnableNewerFeatures().AddGitHubStyle());
        //        }
        //    }
        //}

        //private void Modify(RichTextBox control, string prefix)
        //{
        //    Modify(control, prefix, string.Empty, true);
        //}

        private void Modify(RichTextBox control, Operation op)
        {
            string currentText = control.SelectedText.TrimEnd();

            string prefix = op.Prefix;
            string suffix = op.Suffix;

            if (op.PrefixDelegate != null)
            {
                prefix = op.PrefixDelegate(currentText);
            }

            if (op.SuffixDelegate != null)
            {
                suffix = op.SuffixDelegate(currentText);
            }

            Modify(richTextBox1, prefix, suffix, op.KeepOriginal);
        }

        private void Modify(RichTextBox control, string prefix, string suffix, bool keepOriginal)
        {
            string currentText = control.SelectedText.TrimEnd();
            bool replaceEOL = !control.SelectedText.Equals(control.SelectedText.TrimEnd());
            string newText = string.Format("{0}{1}{2}{3}", prefix, keepOriginal ? currentText : string.Empty, suffix, replaceEOL ? "\r\n" : string.Empty);
            control.SelectedText = newText;
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            string buttonText = GetButtonText(sender);

            if (operations.ContainsKey(buttonText))
            {
                Operation op = operations[buttonText];

                Modify(richTextBox1, op);
                Show();
            }
        }

        private string GetButtonText(object sender)
        {
            string rtnval = string.Empty;

            if (sender is ToolStripDropDownItem)
            {
                rtnval = (sender as ToolStripDropDownItem).Text;
            }
            if (sender is ToolStripButton)
            {
                rtnval = (sender as ToolStripButton).Text;
            }

            return rtnval;
        }

        //private void toolStripButton6_Click(object sender, EventArgs e)
        //{
        //    string text = LinkForm.CreateLinkText();
        //}

        string fileName = string.Empty;

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Markdown Files (*.md)|*.md|All Files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadFileToEdit(ofd.FileName);
            }
        }

        private void LoadFileToEdit(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                richTextBox1.Text = File.ReadAllText(fileName);
                this.fileName = fileName;
                Show();
                Dirty = false;
            }
        }

        public string DocumentText
        {
            get
            {
                return richTextBox1.Text;
            }
            set
            {
                richTextBox1.Text = value;
                //ShowText(richTextBox1.Text, webBrowser1);
                ShowText(richTextBox1.Text);
                Dirty = false;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                File.WriteAllText(fileName, richTextBox1.Text);
            }
            Dirty = false;
        }

        private void sampleTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = @"# Cake

[![NuGet](https://img.shields.io/nuget/v/Cake.svg)](https://www.nuget.org/packages/Cake) [![MyGet](https://img.shields.io/myget/cake/vpre/Cake.svg?label=myget)](https://www.myget.org/gallery/cake) [![Chocolatey](https://img.shields.io/chocolatey/v/Cake.portable.svg)](https://chocolatey.org/packages/cake.portable)
[![homebrew](https://img.shields.io/homebrew/v/cake.svg)](http://braumeister.org/formula/cake)

[![Source Browser](https://img.shields.io/badge/Browse-Source-green.svg)](http://sourcebrowser.io/Browse/cake-build/cake)

Cake (C# Make) is a build automation system with a C# DSL to do things like compiling code, copy files/folders, running unit tests, compress files and build NuGet packages.

## Continuous integration

| Build server                | Platform     | Build status                                                                                                                                                        | Integration tests                                                                                                                                                   |
|-----------------------------|--------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| AppVeyor                    | Windows      | [![AppVeyor branch](https://img.shields.io/appveyor/ci/cakebuild/cake/develop.svg)](https://ci.appveyor.com/project/cakebuild/cake/branch/develop)                  | [![AppVeyor branch](https://img.shields.io/appveyor/ci/cakebuild/cake-eijwj/develop.svg)](https://ci.appveyor.com/project/cakebuild/cake-eijwj)  |
| Travis                      | Linux / OS X | [![Travis build status](https://travis-ci.org/cake-build/cake.svg?branch=develop)](https://travis-ci.org/cake-build/cake)                                           |                                                                                                                                                                     |
| TeamCity                    | Windows      | [![TeamCity Build Status](http://img.shields.io/teamcity/codebetter/Cake_CakeMaster.svg)](http://teamcity.codebetter.com/viewType.html?buildTypeId=Cake_CakeMaster) |                                                                                                                                                                     |
| Bitrise                     | OS X         | ![Bitrise Build Status](https://www.bitrise.io/app/7a9d707b00881436.svg?token=m8zsF3tNONLaF03eHU-Ftg&branch=develop)                                                | ![Build Status](https://www.bitrise.io/app/804b431c1f27e0a0.svg?token=qKosHEaJAJEqzZcq4s5WRg&branch=develop)                                                        |
| Bitrise                     | Linux        | ![Bitrise Build Status](https://www.bitrise.io/app/b811c91a26b1ea80.svg?token=zdwab0niOTRF4p3HcFYaxQ&branch=develop)                                                | ![Build Status](https://www.bitrise.io/app/5a406f34f22113c6.svg?token=TQPbsmA9yP-iJOhzunIP4w&branch=develop)                                                        |
| Jenkins                     | Windows      | [![Jenkins](https://img.shields.io/jenkins/s/https/cake-jenkins.azurewebsites.net/Cake.svg)](http://cake-jenkins.azurewebsites.net/job/Cake/lastStableBuild/)       |                                                                                                                                                                     |
| Bamboo                      | Windows      | [![Bamboo Build Status](https://bambooshield.azurewebsites.net/planstatus/Flat/CAKE-CAKE.svg)](https://cakebuild.atlassian.net/builds/browse/CAKE-CAKE)             |                                                                                                                                                                     |
| Visual Studio Team Services | Windows      | ![VSTS Build Status](https://img.shields.io/vso/build/cake-build/af63183c-ac1f-4dbb-93bc-4fa862ea5809/1.svg)                                                        |                                                                                                                                                                     |
| MyGet Build Services        | Windows      | [![MyGet Build Status](https://www.myget.org/BuildSource/Badge/cake-myget-build-service?identifier=53513546-050e-45de-9500-f161c99df6e2)](https://www.myget.org/)   |  &nbsp;                                                                                                                                                             |
| Bitbucket Pipelines         | Linux        | [![Build Status](https://bitbucketshield.azurewebsites.net/status/cakebuild/cake-integration-tests/develop)](https://bitbucketshield.azurewebsites.net/url/cakebuild/cake-integration-tests/develop) | [![Build Status](https://bitbucketshield.azurewebsites.net/status/cakebuild/cake-integration-tests/IntegrationTests_develop)](https://bitbucketshield.azurewebsites.net/url/cakebuild/cake-integration-tests/IntegrationTests_develop) |

## Code Coverage

[![Coverage Status](https://coveralls.io/repos/github/cake-build/cake/badge.svg?branch=develop)](https://coveralls.io/github/cake-build/cake?branch=develop)

## Table of Contents

1. [Documentation](https://github.com/cake-build/cake#documentation)
2. [Example](https://github.com/cake-build/cake#example)
    - [Install the Cake bootstrapper](https://github.com/cake-build/cake#1-install-the-cake-bootstrapper)
    - [Create a Cake script](https://github.com/cake-build/cake#2-create-a-cake-script)
    - [Run it!](https://github.com/cake-build/cake#3-run-it)
3. [Contributing](https://github.com/cake-build/cake#contributing)
4. [Get in touch](https://github.com/cake-build/cake#get-in-touch)
5. [License](https://github.com/cake-build/cake#license)

## Documentation

You can read the latest documentation at [http://cakebuild.net/](http://cakebuild.net/).

## Example

This example downloads the Cake bootstrapper and executes a simple build script.
The bootstrapper is used to bootstrap Cake in a simple way and is not in
required in any way to execute build scripts. If you prefer to invoke the Cake
executable yourself, [take a look at the command line usage](http://cakebuild.net/docs/cli/usage).

This example is also available on our homepage:
[http://cakebuild.net/docs/tutorials/setting-up-a-new-project](http://cakebuild.net/docs/tutorials/setting-up-a-new-project)

### 1. Install the Cake bootstrapper

The bootstrapper is used to download Cake and the tools required by the
build script.

##### Windows

```powershell
Invoke-WebRequest http://cakebuild.net/download/bootstrapper/windows -OutFile build.ps1
```

##### Linux

```console
curl -Lsfo build.sh http://cakebuild.net/download/bootstrapper/linux
```

##### OS X

```console
curl -Lsfo build.sh http://cakebuild.net/download/bootstrapper/osx
```

### 2. Create a Cake script

Add a cake script called `build.cake` to the same location as the
bootstrapper script that you downloaded.

```csharp
var target = Argument(""target"", ""Default"");

Task(""Default"")
  .Does(() =>
{
  Information(""Hello World!"");
});

RunTarget(target);
```

### 3. Run it!

##### Windows

```powershell
# Execute the bootstrapper script.
./build.ps1
```

##### Linux / OS X

```console
# Adjust the permissions for the bootstrapper script.
chmod +x build.sh

# Execute the bootstrapper script.
./build.sh
```

## Contributing

So you’re thinking about contributing to Cake? Great! It’s **really** appreciated.

Make sure you've read the [contribution guidelines](http://cakebuild.net/contribute/contribution-guidelines/) before sending that epic pull request. You'll also need to sign the [contribution license agreement](https://cla2.dotnetfoundation.org/) (CLA) for anything other than a trivial change.  **NOTE:** The .Net Foundation CLA Bot will provide a link to this CLA within the PR that you submit if it is deemed as required.

* Fork the repository.
* Create a branch to work in.
* Make your feature addition or bug fix.
* Don't forget the unit tests.
* Send a pull request.

## Get in touch

[![Follow @cakebuildnet](https://img.shields.io/badge/Twitter-Follow%20%40cakebuildnet-blue.svg)](https://twitter.com/intent/follow?screen_name=cakebuildnet)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## License

Copyright © Patrik Svensson, Mattias Karlsson, Gary Ewan Park and contributors.
Cake is provided as-is under the MIT license. For more information see [LICENSE](https://github.com/cake-build/cake/blob/develop/LICENSE).

* For Roslyn, see https://github.com/dotnet/roslyn/blob/master/License.txt
* For Mono.CSharp, see https://github.com/mono/mono/blob/master/mcs/LICENSE
* For Autofac, see https://github.com/autofac/Autofac/blob/master/LICENSE
* For NuGet.Core, see https://nuget.codeplex.com/license

## Thanks

A big thank you has to go to [JetBrains](https://www.jetbrains.com) who provide each of the Cake Developers with an [Open Source License](https://www.jetbrains.com/support/community/#section=open-source) for [ReSharper](https://www.jetbrains.com/resharper/) that helps with the development of Cake.

The Cake Team would also like to say thank you to the guys at [MyGet](https://www.myget.org/) for their support in providing a Professional Subscription which allows us to continue to push all of our pre-release editions of Cake NuGet packages for early consumption by the Cake Community.

## Code of Conduct

This project has adopted the code of conduct defined by the [Contributor Covenant](http://contributor-covenant.org/)
to clarify expected behavior in our community.
For more information see the [.NET Foundation Code of Conduct](http://www.dotnetfoundation.org/code-of-conduct).

## Contribution License Agreement

By signing the [CLA](https://cla2.dotnetfoundation.org/), the community is free to use your contribution to .NET Foundation projects.

## .NET Foundation

This project is supported by the [.NET Foundation](http://www.dotnetfoundation.org).";
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Markdown Files (*.md)|*.md|All Files (*.*)|*.*";
            sfd.OverwritePrompt = true;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = sfd.FileName;
                File.WriteAllText(fileName, richTextBox1.Text);
            }
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {

        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Dirty)
            {
                switch (MessageBox.Show("Changes have not been saved.  Save now?", "Warning", MessageBoxButtons.YesNoCancel))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        File.WriteAllText(fileName, richTextBox1.Text);
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        bool dirty = false;

        public bool Dirty
        {
            get { return dirty; }
            set
            {
                dirty = value;
                toolStripButtonSave.Enabled = dirty;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Dirty = true;
        }

        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = @"[https://guides.github.com/features/wikis/](https://guides.github.com/features/wikis/)
# Project name:
Your project’s name is the first thing people will see upon scrolling down to your README, and is included upon creation of your README file.

# Description:
A description of your project follows. A good description is clear, short, and to the point. Describe the importance of your project, and what it does.

# Table of Contents:
Optionally, include a table of contents in order to allow other people to quickly naviagte especially long or detailed READMEs.

# Installation:
Installation is the next section in an effective README. Tell other users how to install your project locally. Optionally, include a gif to make the process even more clear for other people.

# Usage:
The next section is usage, in which you instruct other people on how to use your project after they’ve installed it. This would also be a good place to include screenshots of your project in action.

# Contributing:
Larger projects often have sections on contributing to their project, in which contribution instructions are outlined. Sometimes, this is a separate file. If you have specific contribution preferences, explain them so that other developers know how to best contribute to your work. To learn more about how to help others contribute, check out the guide for (setting guidelines for repository contributors)[https://help.github.com/articles/setting-guidelines-for-repository-contributors/].

# Credits:
Include a section for credits in order to highlight and link to the authors of your project.

# License:
Finally, include a section for the license of your project. For more information on choosing a license, check out GitHub’s licensing guide!";

        }

        //private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == System.Windows.Forms.MouseButtons.Right)
        //    {   //click event
        //        //MessageBox.Show("you got it!");

        //        ContextMenuStrip contextMenu = new();
        //        ToolStripMenuItem menuItem = new ToolStripMenuItem("Cut");
        //        menuItem.Click += new EventHandler(CutAction);
        //        contextMenu.Items.Add(menuItem);
        //        menuItem = new ToolStripMenuItem("Copy");
        //        menuItem.Click += new EventHandler(CopyAction);
        //        contextMenu.Items.Add(menuItem);
        //        menuItem = new ToolStripMenuItem("Paste");
        //        menuItem.Click += new EventHandler(PasteAction);
        //        contextMenu.Items.Add(menuItem);

        //        richTextBox1.ContextMenuStrip = contextMenu;
        //    }
        //}

        void CutAction(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        //void CopyAction(object sender, EventArgs e)
        //{
        //    Graphics objGraphics;
        //    Clipboard.SetData(DataFormats.Rtf, richTextBox1.SelectedRtf);
        //    Clipboard.Clear();
        //}

        //void PasteAction(object sender, EventArgs e)
        //{
        //    if (Clipboard.ContainsText(TextDataFormat.Rtf))
        //    {
        //        richTextBox1.SelectedRtf
        //            = Clipboard.GetData(DataFormats.Rtf).ToString();
        //    }
        //}

        void CopyAction(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);
        }

        async void PasteAction(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                // https://superuser.com/questions/1199393/is-it-possible-to-directly-embed-an-image-into-a-markdown-document
                Image img = Clipboard.GetImage();
                InsertImage(img);
            }

            if (Clipboard.ContainsText())
            {
                //richTextBox1.Text
                //    += Clipboard.GetText(TextDataFormat.Text).ToString();

                string text = Clipboard.GetText();

                if (IsUrl(text))
                {
                    //if (dataString.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    //{

                    //}
                    //else
                    //{
                    //    // because Chrome removes this part, by default
                    //    // If you drag the lock icon, instead of the text it will include the full https://
                    //    dataString = "https://" + dataString;
                    //}

                    //string descr = await GetDescription(text);

                    Dictionary<string, object> val = await GetInformation(text);

                    string descr = val.ContainsKey("Title") ? val["Title"].ToString() : text;

                    if ((val.ContainsKey("Content-Type")) && val["Content-Type"].ToString().StartsWith("image"))
                    {
                        if (MessageBox.Show("Would you like to insert an image?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Would you like to use a local copy of the image?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                InsertImage(GetImage(text));
                            }
                            else // use the remote link
                            {
                                InsertRemoteImage(text);
                            }
                        }
                        else // paste as link
                        {
                            richTextBox1.SelectedText = $"[{descr}]({text})";
                        }
                    }
                    else
                    {
                        LinkForm lf = new()
                        {
                            Link = text,
                            Description = descr
                        };
                        if (lf.ShowDialog() == DialogResult.OK)
                        {
                            richTextBox1.SelectedText = lf.ResultText;
                        }

                        richTextBox1.SelectedText = string.Empty;
                    }
                }
                else
                {
                    //richTextBox1.SelectedText = Clipboard.GetText(TextDataFormat.Text).ToString();
                    richTextBox1.SelectedText = text;
                }

            }

            ShowText(richTextBox1.Text);
        }

        private void InsertImage(Image img)
        {
            if (img != null)
            {
                //// https://www.techieclues.com/blogs/converting-image-to-base64-string-in-csharp
                //using (MemoryStream stream = new MemoryStream())
                //{
                //    img.Save(stream, ImageFormat.Bmp);
                //    byte[] imageBytes = stream.ToArray();
                //    string base64String = Convert.ToBase64String(imageBytes);
                //    //Console.WriteLine(base64String);
                //    richTextBox1.Text += $"![Hello World](data:image/png;base64,{base64String})";
                //}


                EmbeddedFragmentEventArgs args = new();
                args.Operation = "SAVE";

                string name = DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".jpg";
                PageFragment frag = new PageFragment { Id = Guid.NewGuid().ToString("D").ToUpper(), Name = name };

                frag.FragmentType = "image/jpeg";
                frag.Content = ImageToBase64(img);

                args.Value = frag;

                EmbeddedFragmentHandler?.Invoke(this, args);

                // take a trip through the image form to set additional fields
                ImageForm if2 = new()
                {
                    EmbeddedFragmentHandler = EmbeddedFragmentHandler,
                    Link = $"<$LOCATION$>{name}"
                };
                if (if2.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectedText = if2.ResultText;
                }

                //richTextBox1.SelectedText = $"![Alt text](notebook://{name})";
            }
        }

        private void InsertRemoteImage(string url)
        {
            // take a trip through the image form to set additional fields
            ImageForm if2 = new()
            {
                EmbeddedFragmentHandler = EmbeddedFragmentHandler,
                Link = url
            };
            if (if2.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectedText = if2.ResultText;
            }
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


        private void toolStripButtonEditView_Click(object sender, EventArgs e)
        {
            ViewMode = true;
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            ViewMode = false;
        }

        // from : https://stackoverflow.com/questions/85137/how-to-add-an-event-to-a-class
        public event EventHandler SaveClicked;

        public void OnSaveClicked()
        {
            //AwesomeJump?.Invoke(42);
            SaveClicked?.Invoke(this, EventArgs.Empty);
        }

        // handle the request for an embedded image
        public string ResolveEmbeddedImage(string mdInfo)
        {
            return "";
        }


        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            OnSaveClicked();
            ShowText(richTextBox1.Text);
            Dirty = false;
        }

        private void SetEditorFontSize(object sender, EventArgs e)
        {
            //+AccessibilityObject { ToolStripItemAccessibleObject: Owner = 10}
            //System.Windows.Forms.AccessibleObject { System.Windows.Forms.ToolStripMenuItem.ToolStripMenuItemAccessibleObject}
            string txt = (sender as ToolStripMenuItem).Text;

            Font f = richTextBox1.Font;
            int newSize = int.Parse(txt);

            Font newFont = new Font(f.FontFamily, newSize);

            richTextBox1.Font = newFont;
        }

        private void textBlockToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi != null)
            {
                tsmi.DropDownItems.Clear();

                EmbeddedFragmentEventArgs args = new();
                args.Operation = "LIST_TEXT_BLOCKS";
                EmbeddedFragmentHandler?.Invoke(this, args);

                foreach (string str in args.Names)
                {
                    ToolStripMenuItem newItem = new ToolStripMenuItem { Text = str, Tag = str };
                    newItem.Click += InsertTextBlockClicked;
                    tsmi.DropDownItems.Add(newItem);
                }
            }
        }

        private void imageToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi != null)
            {
                tsmi.DropDownItems.Clear();

                EmbeddedFragmentEventArgs args = new();
                args.Operation = "LIST_IMAGE_BLOCKS";
                EmbeddedFragmentHandler?.Invoke(this, args);
                foreach (string str in args.Names)
                {
                    ToolStripMenuItem newItem = new ToolStripMenuItem { Text = str, Tag = str };
                    newItem.Click += InsertImageClicked;
                    tsmi.DropDownItems.Add(newItem);
                }
            }
        }

        private void InsertImageClicked(object? sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi != null)
            {
                //ToolStripMenuItem newItem = new ToolStripMenuItem { Text = str, Tag = $"![Alt text](https://cloudfront-us-east-2.images.arcpublishing.com/reuters/AP7S7SPQ2NJTJLBWW7ROT6W3VQ.jpg)\r\n" };

                string newText = $"![Alt text](notebook://{tsmi.Tag.ToString()})";

                Modify(richTextBox1, newText, string.Empty, true);
                ShowText(richTextBox1.Text);
            }
        }
        private void InsertTextBlockClicked(object? sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi != null)
            {
                //EmbeddedFragmentEventArgs args = new();
                //args.Operation = "GET";
                //args.Key = tsmi.Tag.ToString();
                //EmbeddedFragmentHandler?.Invoke(this, args);
                //Modify(richTextBox1, args.Value.Content, string.Empty, true);

                string newText = $"[embeddedfragment:{tsmi.Tag.ToString()}]";
                Modify(richTextBox1, newText, string.Empty, true);

                ShowText(richTextBox1.Text);
            }
        }

        private async Task<string> GetDescription(string url)
        {
            string rtnVal = "";

            using HttpClient client = new()
            {
                BaseAddress = new Uri(url),
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "web api client");

            using HttpResponseMessage response = await client.GetAsync("");

            var stringResponse = await response.Content.ReadAsStringAsync();

            int titleStart = stringResponse.IndexOf("<title>", StringComparison.OrdinalIgnoreCase);
            if (titleStart != -1)
            {
                titleStart += 7;
                int titleEnd = stringResponse.IndexOf("</title>", titleStart, StringComparison.OrdinalIgnoreCase);

                rtnVal = stringResponse.Substring(titleStart, (titleEnd - titleStart));
                //                textBox6.DataBindings[0].ReadValue();
            }

            return rtnVal;
        }

        private async Task<Dictionary<string, object>> GetInformation(string url)
        {
            Dictionary<string, object> rtnVal = new();

            using HttpClient client = new()
            {
                BaseAddress = new Uri(url),
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "web api client");

            using HttpResponseMessage response = await client.GetAsync("");

            var stringResponse = await response.Content.ReadAsStringAsync();

            rtnVal.Add("Content-Type", response.Content.Headers.ContentType);

            int titleStart = stringResponse.IndexOf("<title>", StringComparison.OrdinalIgnoreCase);
            if (titleStart != -1)
            {
                titleStart += 7;
                int titleEnd = stringResponse.IndexOf("</title>", titleStart, StringComparison.OrdinalIgnoreCase);

                //rtnVal = stringResponse.Substring(titleStart, (titleEnd - titleStart));
                rtnVal.Add("Title", stringResponse.Substring(titleStart, (titleEnd - titleStart)));
            }

            return rtnVal;
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

        //public static bool IsUrl(string urlAsString)
        public bool IsUrl(string urlAsString)
        {
            if (urlAsString != null && urlAsString.Trim().Length > 0)
            {
                Uri uri;
                return Uri.TryCreate(urlAsString, UriKind.Absolute, out uri);
            }

            return false;
        }

        private void MarkDownEditor_EnabledChanged(object sender, EventArgs e)
        {
            toolStripButtonEdit.Enabled = Enabled;
        }

        //private string GetLineBefore(TextBox tb)
        private string GetLineBefore(RichTextBox tb)
        {
            // from https://stackoverflow.com/questions/2693984/how-to-get-the-current-line-in-a-richtextbox-control
            tb.WordWrap = false;
            int cursorPosition = tb.SelectionStart;
            int lineIndex = tb.GetLineFromCharIndex(cursorPosition);
            string lineText = lineIndex < 1 ? "" : tb.Lines[lineIndex - 1];
            tb.WordWrap = true;

            return lineText;
        }

        // https://stackoverflow.com/questions/44815528/handle-ctrlv-in-a-multiline-textbox-c-sharp
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // https://stackoverflow.com/questions/11806166/how-do-i-tell-when-the-enter-key-is-pressed-in-a-textbox
            // keycode allows checking modifiers
            // keydata does not
            if ((e.KeyCode == Keys.V) && (e.Control))
            {
                //richTextBox1.SelectedText = "PASTED";
                PasteAction(sender, EventArgs.Empty);
                e.Handled = true;
            }
            if ((e.KeyCode == Keys.C) && (e.Control))
            {
                //richTextBox1.SelectedText = "PASTED";
                CopyAction(sender, EventArgs.Empty);
                e.Handled = true;
            }
            if ((e.KeyCode == Keys.X) && (e.Control))
            {
                //richTextBox1.SelectedText = "PASTED";
                CutAction(sender, EventArgs.Empty);
                e.Handled = true;
            }

            // https://stackoverflow.com/questions/1876663/how-do-i-allow-ctrl-v-paste-on-a-winforms-textbox
            // other goodies in that link, as well
            //private void textBox1_KeyUp(object sender, KeyEventArgs e)
            //{
            //    if (e.KeyData == Keys.V && e.Modifiers == Keys.Control)
            //        (sender as Textbox).Paste();
            //}
        }

        private void richTextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //            if (e.KeyCode == Keys.V) { }
        }

        //private async void dataGridView1_DragDrop(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.StringFormat))
        //    {
        //        string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

        //        if (dataString.StartsWith("http", StringComparison.OrdinalIgnoreCase))
        //        {

        //        }
        //        else
        //        {
        //            // because Chrome removes this part, by default
        //            // If you drag the lock icon, instead of the text it will include the full https://
        //            dataString = "https://" + dataString;
        //        }

        //        await SaveEdits();

        //        ChainLink newLink = new ChainLink();
        //        newLink.Chain = string.Empty;
        //        newLink.Url = dataString;
        //        newLink.DisplayText = await GetDescription(dataString);

        //        links.Add(newLink);
        //        await dataService.CreateChainLink(newLink);

        //        //Item = newJob;
        //        //bs.DataSource = Item;

        //        dataGridView1.CurrentCell = dataGridView1.Rows[idxNewRow].Cells[0];
        //        dataGridView1.CurrentRow.Selected = true;

        //        dataGridView1_SelectionChanged(sender, EventArgs.Empty);
        //    }
        //}

        //private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.Text))
        //        e.Effect = DragDropEffects.Copy;
        //    else
        //        e.Effect = DragDropEffects.None;
        //}
    }

    public class Operations : Dictionary<string, Operation>
    {
        public void Add(string trigger, string prefix)
        {
            Add(trigger, prefix, string.Empty);
        }

        public void Add(string trigger, string prefix, string suffix)
        {
            base.Add(trigger, new Operation(trigger, prefix, suffix));
        }

        public void Add(string trigger, OperationDelegate prefix, string suffix)
        {
            base.Add(trigger, new Operation(trigger, prefix, suffix));
        }

        public void Add(string trigger, string prefix, OperationDelegate suffix)
        {
            base.Add(trigger, new Operation(trigger, prefix, suffix));
        }

        public void Add(string trigger, OperationDelegate prefix, OperationDelegate suffix)
        {
            base.Add(trigger, new Operation(trigger, prefix, suffix));
        }
    }

    public class Operation
    {
        string trigger = string.Empty;
        string prefix = string.Empty;
        string suffix = string.Empty;
        OperationDelegate prefixDelegate = null;
        OperationDelegate suffixDelegate = null;
        bool keepOriginal = true;

        public Operation(string trigger, string prefix)
        {
            this.trigger = trigger;
            this.prefix = prefix;
        }

        public Operation(string trigger, OperationDelegate prefix)
        {
            this.trigger = trigger;
            this.prefixDelegate = prefix;
        }

        public Operation(string trigger, string prefix, string suffix)
        {
            this.trigger = trigger;
            this.prefix = prefix;
            this.suffix = suffix;
        }

        public Operation(string trigger, OperationDelegate prefix, string suffix)
        {
            this.trigger = trigger;
            this.prefixDelegate = prefix;
            this.suffix = suffix;
        }

        public Operation(string trigger, string prefix, OperationDelegate suffix)
        {
            this.trigger = trigger;
            this.prefix = prefix;
            this.suffixDelegate = suffix;
        }

        public Operation(string trigger, OperationDelegate prefix, OperationDelegate suffix)
        {
            this.trigger = trigger;
            this.prefixDelegate = prefix;
            this.suffixDelegate = suffix;
        }

        public bool KeepOriginal
        {
            get
            {
                return this.keepOriginal;
            }
            set
            {
                this.keepOriginal = value;
            }
        }

        public OperationDelegate PrefixDelegate
        {
            get
            {
                return this.prefixDelegate;
            }
            set
            {
                this.prefixDelegate = value;
            }
        }

        public OperationDelegate SuffixDelegate
        {
            get
            {
                return this.suffixDelegate;
            }
            set
            {
                this.suffixDelegate = value;
            }
        }

        public string Trigger
        {
            get
            {
                return this.trigger;
            }
            set
            {
                this.trigger = value;
            }
        }

        public string Prefix
        {
            get
            {
                return this.prefix;
            }
            set
            {
                this.prefix = value;
            }
        }

        public string Suffix
        {
            get
            {
                return this.suffix;
            }
            set
            {
                this.suffix = value;
            }
        }
    }
}
