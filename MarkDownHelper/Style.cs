using System.Text;

namespace MarkDownHelper
{
    public static class Style
    {
        // from https://gist.github.com/tuzz/3331384
        // copy button came from : https://www.roboleary.net/2022/01/13/copy-code-to-clipboard-blog.html
        static string cssGitHub = @"
body {
  font-family: Helvetica, arial, sans-serif;
  font-size: 14px;
  line-height: 1.6;
  padding-top: 10px;
  padding-bottom: 10px;
  background-color: white;
  padding: 30px;
  color: #333;
}

body > *:first-child {
  margin-top: 0 !important;
}

body > *:last-child {
  margin-bottom: 0 !important;
}

a {
  color: #4183C4;
  text-decoration: none;
}

a.absent {
  color: #cc0000;
}

a.anchor {
  display: block;
  padding-left: 30px;
  margin-left: -30px;
  cursor: pointer;
  position: absolute;
  top: 0;
  left: 0;
  bottom: 0;
}

h1, h2, h3, h4, h5, h6 {
  margin: 20px 0 10px;
  padding: 0;
  font-weight: bold;
  -webkit-font-smoothing: antialiased;
  cursor: text;
  position: relative;
}

h2:first-child, h1:first-child, h1:first-child + h2, h3:first-child, h4:first-child, h5:first-child, h6:first-child {
  margin-top: 0;
  padding-top: 0;
}

h1:hover a.anchor, h2:hover a.anchor, h3:hover a.anchor, h4:hover a.anchor, h5:hover a.anchor, h6:hover a.anchor {
  text-decoration: none;
}

h1 tt, h1 code {
  font-size: inherit;
}

h2 tt, h2 code {
  font-size: inherit;
}

h3 tt, h3 code {
  font-size: inherit;
}

h4 tt, h4 code {
  font-size: inherit;
}

h5 tt, h5 code {
  font-size: inherit;
}

h6 tt, h6 code {
  font-size: inherit;
}

h1 {
  font-size: 28px;
  color: black;
}

h2 {
  font-size: 24px;
  border-bottom: 1px solid #cccccc;
  color: black;
}

h3 {
  font-size: 18px;
}

h4 {
  font-size: 16px;
}

h5 {
  font-size: 14px;
}

h6 {
  color: #777777;
  font-size: 14px;
}

p, blockquote, ul, ol, dl, li, table, pre {
  margin: 15px 0;
}

hr {
  background: transparent url(""http://tinyurl.com/bq5kskr"") repeat-x 0 0;
  border: 0 none;
  color: #cccccc;
  height: 4px;
  padding: 0;
}

body > h2:first-child {
  margin-top: 0;
  padding-top: 0;
}

body > h1:first-child {
  margin-top: 0;
  padding-top: 0;
}

body > h1:first-child + h2 {
  margin-top: 0;
  padding-top: 0;
}

body > h3:first-child, body > h4:first-child, body > h5:first-child, body > h6:first-child {
  margin-top: 0;
  padding-top: 0;
}

a:first-child h1, a:first-child h2, a:first-child h3, a:first-child h4, a:first-child h5, a:first-child h6 {
  margin-top: 0;
  padding-top: 0;
}

h1 p, h2 p, h3 p, h4 p, h5 p, h6 p {
  margin-top: 0;
}

li p.first {
  display: inline-block;
}

ul, ol {
  padding-left: 30px;
}

ul :first-child, ol :first-child {
  margin-top: 0;
}

ul :last-child, ol :last-child {
  margin-bottom: 0;
}

dl {
  padding: 0;
}

dl dt {
  font-size: 14px;
  font-weight: bold;
  font-style: italic;
  padding: 0;
  margin: 15px 0 5px;
}

dl dt:first-child {
  padding: 0;
}

dl dt > :first-child {
  margin-top: 0;
}

dl dt > :last-child {
  margin-bottom: 0;
}

dl dd {
  margin: 0 0 15px;
  padding: 0 15px;
}

dl dd > :first-child {
  margin-top: 0;
}

dl dd > :last-child {
  margin-bottom: 0;
}

blockquote {
  border-left: 4px solid #dddddd;
  padding: 0 15px;
  color: #777777;
}

blockquote > :first-child {
  margin-top: 0;
}

blockquote > :last-child {
  margin-bottom: 0;
}

table {
  padding: 0;
}
table tr {
  border-top: 1px solid #cccccc;
  background-color: white;
  margin: 0;
  padding: 0;
}

table tr:nth-child(2n) {
  background-color: #f8f8f8;
}

table tr th {
  font-weight: bold;
  border: 1px solid #cccccc;
  text-align: left;
  margin: 0;
  padding: 6px 13px;
}

table tr td {
  border: 1px solid #cccccc;
  text-align: left;
  margin: 0;
  padding: 6px 13px;
}

table tr th :first-child, table tr td :first-child {
  margin-top: 0;
}

table tr th :last-child, table tr td :last-child {
  margin-bottom: 0;
}

img {
  max-width: 100%;
}

span.frame {
  display: block;
  overflow: hidden;
}

span.frame > span {
  border: 1px solid #dddddd;
  display: block;
  float: left;
  overflow: hidden;
  margin: 13px 0 0;
  padding: 7px;
  width: auto;
}

span.frame span img {
  display: block;
  float: left;
}

span.frame span span {
  clear: both;
  color: #333333;
  display: block;
  padding: 5px 0 0;
}

span.align-center {
  display: block;
  overflow: hidden;
  clear: both;
}

span.align-center > span {
  display: block;
  overflow: hidden;
  margin: 13px auto 0;
  text-align: center;
}

span.align-center span img {
  margin: 0 auto;
  text-align: center;
}

span.align-right {
  display: block;
  overflow: hidden;
  clear: both;
}

span.align-right > span {
  display: block;
  overflow: hidden;
  margin: 13px 0 0;
  text-align: right;
}

span.align-right span img {
  margin: 0;
  text-align: right;
}

span.float-left {
  display: block;
  margin-right: 13px;
  overflow: hidden;
  float: left;
}

span.float-left span {
  margin: 13px 0 0;
}

span.float-right {
  display: block;
  margin-left: 13px;
  overflow: hidden;
  float: right;
}

span.float-right > span {
  display: block;
  overflow: hidden;
  margin: 13px auto 0;
  text-align: right;
}

code, tt {
  margin: 0 2px;
  padding: 0 5px;
  white-space: nowrap;
  border: 1px solid #eaeaea;
  background-color: #f8f8f8;
  border-radius: 3px;
}

pre code {
  margin: 0;
  padding: 0;
  white-space: pre;
  border: none;
  background: transparent;
}

.highlight pre {
  background-color: #f8f8f8;
  border: 1px solid #cccccc;
  font-size: 13px;
  line-height: 19px;
  overflow: auto;
  padding: 6px 10px;
  border-radius: 3px;
}

pre {
  background-color: #f8f8f8;
  border: 1px solid #cccccc;
  font-size: 13px;
  line-height: 19px;
  overflow: auto;
  padding: 6px 10px;
  border-radius: 3px;
}

pre code, pre tt {
  background-color: transparent;
  border: none;
}

.copybutton {
  position: absolute;
  top: 5px;
  right: 5px;

  font-size: 0.9rem;
  padding: 0.15rem;
  background-color: #828282;

  border: ridge 1px #7b7b7c;
  border-radius: 5px;
  text-shadow: #c4c4c4 0 0 2px;
}

.copybutton:hover {
  cursor: pointer;
  background-color: #bcbabb;
}

";

        public static string AddGitHubStyle(this string html)
        {
            return Add(html, cssGitHub);
        }

        [Obsolete("use UseSoftlineBreakAsHardlineBreak() in the pipeline instead", false)]
        public static string FixLineFeeds(this string html)
        {
            StringBuilder sb = new StringBuilder(html);
            string test = string.Empty;
            // add two spaces at each line feed
            sb.Replace("\n", "  \n");
            test = sb.ToString();

            sb.Replace("  \n  ", "\n");
            test = sb.ToString();

            return sb.ToString();
        }

        // http://stackoverflow.com/questions/8852722/webbrowser-control-wpf-or-windows-forms-cant-display-svg-files-contained-in
        public static string EnableNewerFeatures(this string html)
        {
            StringBuilder sb = new StringBuilder(html);

            // find end of head
            int endOfHead = html.IndexOf("</head>");

            if (endOfHead == -1)
            {
                sb.Insert(0, @"<head>
</head>");
            }

            // ""IE=9""
            // ""IE=Edge; ""
            string style = @"
<meta http-equiv=""X-UA-Compatible"" content=""IE=Edge; ""/>
</head>";

            sb.Replace("</head>", style);
            return sb.ToString();
        }

        public static string Add(string html, string styleToAdd)
        {
            StringBuilder sb = new StringBuilder(html);

            // find end of head
            int endOfHead = html.IndexOf("</head>");

            if (endOfHead == -1)
            {
                sb.Insert(0, @"<head>
</head>");
            }

            string style = string.Format(@"
<style type=""text/css"">
{0}
</style>
</head>", styleToAdd);

            sb.Replace("</head>", style);
            return sb.ToString();
        }

        public static int Occurrences(this string source, char findMe)
        {
            // http://stackoverflow.com/questions/541954/how-would-you-count-occurrences-of-a-string-within-a-string
            // int count = source.Count(f => f == '/');
            int count = source.Split(findMe).Length - 1;

            return count;
        }

        public static string TranslatePaths(this string html, string root)
        {
            if (string.IsNullOrEmpty(root))
            {
                return html;
            }

            string FILE_URL_PREFIX = "file://";
            string PATH_SEPARATOR = Path.AltDirectorySeparatorChar.ToString();

            //String executableName = System.Windows.Forms.Application.ExecutablePath;
            //System.IO.FileInfo executableFileInfo = new System.IO.FileInfo(executableName);
            //String executableDirectoryName = executableFileInfo.DirectoryName;

            string replaceWith = FILE_URL_PREFIX
                + root.Replace("\\", "/")
                + PATH_SEPARATOR;

            return html.Replace("./", replaceWith);
        }

        // Inspired by https://github.com/naokazuterada/MarkdownTOC
        // http://pandoc.org/MANUAL.html#extension-auto_identifiers
        // Auto-identifiers from Markdig project makes this easier
        public static string GenerateToc(this string html)
        {
            int startOfToc = html.IndexOf("<!-- MarkdownTOC -->");
            int endOfToc = html.IndexOf("<!-- /MarkdownTOC -->");

            if ((startOfToc < 0) || (endOfToc < 0))
            {
                return html;
            }

            startOfToc = startOfToc + 20;

            //HeadingItemCollection coll = new HeadingItemCollection();
            //coll.Add("Heading 1", 1);
            //coll.Add("Heading 2", 2);
            //coll.Add("Heading 3", 3);
            //coll.Add("Test 4", 3);
            //coll.Add("Test 5", 2);

            // Headings before MarkdownTOC tags will be ignored.  (You know, the one that says "Table of Contents" <G>)
            HeadingItemCollection coll = BuildHeadingCollection(html.Substring(endOfToc + 21));

            string insert = FormatToc(coll);

            string newHtml = html.Substring(0, startOfToc) + "\n" + insert + "\n" + html.Substring(endOfToc);

            return newHtml;
        }


        // "Inspired" by https://www.roboleary.net/2022/01/13/copy-code-to-clipboard-blog.html
        public static string AddCodeCopyButtons(this string html)
        {
            string buttonScript = @"<script>
const copyButtonLabel = ""Copy Code"";

// use a class selector if available
let blocks = document.querySelectorAll(""pre"");

blocks.forEach((block) => {
  // only add button if browser supports Clipboard API
  if (navigator.clipboard) {
    let button = document.createElement(""button"");

    button.innerText = copyButtonLabel;
    button.className = 'copybutton'
    block.appendChild(button);

    button.addEventListener(""click"", async () => {
      await copyCode(block, button);
    });
  }
});

async function copyCode(block, button) {
  let code = block.querySelector(""code"");
  let text = code.innerText;

  await navigator.clipboard.writeText(text);

  // visual feedback that task is completed
  button.innerText = ""Code Copied"";

  setTimeout(() => {
    button.innerText = copyButtonLabel;
  }, 700);
}
</script>";

            string newHtml = html + buttonScript;

            return newHtml;
        }


        public static string AddCodeCopyButtons2(this string html, string codeTheme = "default")
        {
            string buttonScript = @"
<script src=""https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.7.0/highlight.min.js""></script>
 
<!-- https://github.com/highlightjs/highlight.js/tree/main/src/styles -->
<!-- <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.7.0/styles/androidstudio.min.css"" /> -->
<!-- <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.7.0/styles/lightfair.min.css"" /> -->
<!-- <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.7.0/styles/stackoverflow-light.min.css"" /> -->
<!-- <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.7.0/styles/tomorrow-night-blue.min.css"" /> -->
"
+
$@"<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.7.0/styles/{codeTheme}.min.css"" />"
+
@"
 <script>
     hljs.highlightAll(); // initialize highlighting
 </script>
 
 <!-- Code to append a click to copy button -->
 <script>
     var snippets = document.getElementsByTagName('pre');
     var numberOfSnippets = snippets.length;
     for (var i = 0; i < numberOfSnippets; i++) {

  // only add button if browser supports Clipboard API
<!-- if (navigator.clipboard) -->
{ 

         code = snippets[i].getElementsByTagName('code')[0].innerText;
 
         snippets[i].classList.add('hljs'); // append copy button to pre tag
 
         snippets[i].innerHTML = '<button class=""hljs-copy"">Copy</button>' + snippets[i].innerHTML; // append copy button
 
         snippets[i].getElementsByClassName('hljs-copy')[0].addEventListener(""click"", function () {
            this.innerText = 'Copying..';

            copyToClipboard(code);
<!--
             if (!navigator.userAgent.toLowerCase().includes('safari')) {
                 navigator.clipboard.writeText(code);
             } else {
                 prompt(""Clipboard (Select: ⌘+a > Copy:⌘+c)"", code); 
             }
-->

             this.innerText = 'Copied!';
             button = this;
             setTimeout(function () {
                 button.innerText = 'Copy';
             }, 1000)
         });
}
     }

// https://stackoverflow.com/questions/51805395/navigator-clipboard-is-undefined
async function copyToClipboard(textToCopy) {
    // Navigator clipboard api needs a secure context (https)
    if (navigator.clipboard && window.isSecureContext) {
        await navigator.clipboard.writeText(textToCopy);
    } else {
        // Use the 'out of viewport hidden text area' trick
        const textArea = document.createElement(""textarea"");
        textArea.value = textToCopy;
            
        // Move textarea out of the viewport so it's not visible
        textArea.style.position = ""absolute"";
        textArea.style.left = ""-999999px"";
            
        document.body.prepend(textArea);
        textArea.select();

        try {
            document.execCommand('copy');
        } catch (error) {
            console.error(error);
        } finally {
            textArea.remove();
        }
    }
}

 </script>
 <style>
     .hljs-copy {
         float: right;
         cursor: pointer;
     }
 </style>
";
            string newHtml = html + buttonScript;

            return newHtml;
        }


        public static string SetTabSize(this string html, int tabSize = 4)
        {
            string newHtml = html.Replace("<pre>", $"<pre style=\"tab-size: {tabSize};\">");

            return newHtml;
        }


        public static string AddCodeCopyButtons3(this string html)
        {
            string buttonScript = @"
<script src=""https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.7.0/highlight.min.js""></script>
 
<!-- https://github.com/highlightjs/highlight.js/tree/main/src/styles -->
<!-- <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.7.0/styles/androidstudio.min.css"" /> -->
<!-- <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.7.0/styles/lightfair.min.css"" /> -->
<!-- <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.7.0/styles/stackoverflow-light.min.css"" /> -->
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.7.0/styles/tomorrow-night-blue.min.css"" />



 <script>
    hljs.highlightAll(); // initialize highlighting
 </script>
 
<!-- Code to append a click to copy button -->
 <script>
const copyButtonLabel = ""Copy Code"";

// use a class selector if available
let blocks = document.querySelectorAll(""pre"");

blocks.forEach((block) => {
  // only add button if browser supports Clipboard API
 if (navigator.clipboard) {
    let button = document.createElement(""button"");

    button.innerText = copyButtonLabel;
    button.className = 'hljs-copy'
    block.appendChild(button);

    button.addEventListener(""click"", async () => {
      await copyCode(block, button);
    });

 }
});

async function copyCode(block, button) {
  let code = block.querySelector(""code"");
  let text = code.innerText;

  await navigator.clipboard.writeText(text);

  // visual feedback that task is completed
  button.innerText = ""Code Copied"";

  setTimeout(() => {
    button.innerText = copyButtonLabel;
  }, 700);
}
 </script>
 <style>
     .hljs-copy {
        float: right;
        cursor: pointer;
        position: absolute;
        top: 5px;
        right: 5px;
     }
 </style>
";
            string newHtml = html + buttonScript;

            return newHtml;
        }


        private static HeadingItemCollection BuildHeadingCollection(string html)
        {
            HeadingItemCollection coll = new HeadingItemCollection();

            string[] lines = html.Split('\n');
            int level = 1;
            string text = string.Empty;

            foreach (string str in lines)
            {
                level = 0;
                if (!string.IsNullOrEmpty(str))
                {
                    // there may be "better" ways, but since we are only looking for H1 .. H6, I'm hard coding
                    if (str.StartsWith("# "))
                    {
                        level = 1;
                    }
                    else if (str.StartsWith("## "))
                    {
                        level = 2;
                    }
                    else if (str.StartsWith("### "))
                    {
                        level = 3;
                    }
                    else if (str.StartsWith("#### "))
                    {
                        level = 4;
                    }
                    else if (str.StartsWith("##### "))
                    {
                        level = 5;
                    }
                    else if (str.StartsWith("###### "))
                    {
                        level = 6;
                    }
                    text = str.Substring(level + 1);

                    if (level > 0)
                    {
                        coll.Add(text, level);
                    }

                }
            }

            return coll;
        }

        private static string FormatToc(HeadingItemCollection coll)
        {
            StringBuilder sb = new StringBuilder();

            int indentLevel = 0;
            string indentSpaces = string.Empty;

            foreach (HeadingItem hi in coll)
            {
                indentLevel = hi.Level - 1;
                indentSpaces = new string(' ', indentLevel * 4);

                sb.AppendFormat("{0}- [{1}]\n", indentSpaces, hi.Text);
            }

            //sb.AppendLine("- Heading 1");
            //sb.AppendLine("  - Heading 2");

            return sb.ToString();
        }

        // http://pandoc.org/MANUAL.html#extension-auto_identifiers

        public class HeadingItemCollection : List<HeadingItem>
        {
            public void Add(string text)
            {
                Add(new HeadingItem(text));
            }

            public void Add(string text, int level)
            {
                Add(new HeadingItem(text, level));
            }

            public void Add(string text, int level, string anchorName)
            {
                Add(new HeadingItem(text, level, anchorName));
            }
        }

        public class HeadingItem
        {
            string text = string.Empty;
            int level = 1;
            string anchorName = string.Empty;

            public HeadingItem(string text)
            {
                this.text = text;
            }

            public HeadingItem(string text, int level)
            {
                this.text = text;
                this.level = level;
            }

            public HeadingItem(string text, int level, string anchorName)
            {
                this.text = text;
                this.level = level;
                this.anchorName = anchorName;
            }

            public string Text
            {
                get
                {
                    return this.text;
                }
                set
                {
                    this.text = value;
                }
            }

            public int Level
            {
                get
                {
                    return this.level;
                }
                set
                {
                    this.level = value;
                }
            }

            public string AnchorName
            {
                get
                {
                    return this.anchorName;
                }
                set
                {
                    this.anchorName = value;
                }
            }
        }
    }
}
