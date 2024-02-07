using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using System.Text;

namespace MarkDownHelper.AlertExtension
{
    /// <summary>
    /// A HTML renderer for a <see cref="CustomContainer"/>.
    /// </summary>
    /// <seealso cref="HtmlAlertContainerRenderer{CustomContainer}" />
    public class HtmlAlertContainerRenderer : HtmlObjectRenderer<AlertContainer>
    {
        protected override void Write(HtmlRenderer renderer, AlertContainer obj)
        {
            // styling goodies came from here : https://dotnet.github.io/docfx/docs/markdown.html?tabs=linux%2Cdotnet
            // alert icons were found here : https://mdbootstrap.com/docs/standard/components/alerts/
            // obj.Info contains alert type
            AlertContainerStyling styling = null;
            switch (obj.Info.ToLower())
            {
                case "primary":
                    styling = new AlertContainerStyling(@"<i class=""fas fa-info-circle me-3""></i>", "alert", "alert-primary");
                    break;
                case "primary-no_icon":
                    styling = new AlertContainerStyling("", "alert", "alert-primary");
                    break;
                case "primary-docfx":
                    styling = new AlertContainerStyling(@"<H5 class=""alertheading-primary"">Primary</h5>", "alert", "alert-primary");
                    break;

                case "secondary":
                    styling = new AlertContainerStyling(@"<i class=""fas fa-circle me-3""></i>", "alert", "alert-secondary");
                    break;
                case "secondary-no_icon":
                    styling = new AlertContainerStyling("", "alert", "alert-secondary");
                    break;

                case "success":
                    styling = new AlertContainerStyling(@"<i class=""fas fa-check-circle me-3"" ></i>", "alert", "alert-success");
                    break;
                case "success-no_icon":
                    styling = new AlertContainerStyling("", "alert", "alert-success");
                    break;

                case "danger":
                    styling = new AlertContainerStyling(@"<i class= ""fas fa-times-circle me-3"" ></i>", "alert", "alert-danger");
                    break;
                case "danger-no_icon":
                    styling = new AlertContainerStyling("", "alert", "alert-danger");
                    break;
                case ">important":
                    styling = new AlertContainerStyling(@"<H5 class=""alertheading-important"">important</h5>", "alert", "alert-danger");
                    break;
                case ">caution":
                    styling = new AlertContainerStyling(@"<H5 class=""alertheading-caution"">caution</h5>", "alert", "alert-danger");
                    break;

                case "warning":
                    styling = new AlertContainerStyling(@"<i class= ""fas fa-exclamation-triangle me-3"" ></i>", "alert", "alert-warning");
                    break;
                case "warning-no_icon":
                    styling = new AlertContainerStyling("", "alert", "alert-warning");
                    break;
                case ">warning":
                    styling = new AlertContainerStyling(@"<H5 class=""alertheading-warning"">warning</h5>", "alert", "alert-warning");
                    break;

                case "info":
                    styling = new AlertContainerStyling(@"<i class= ""fas fa-chevron-circle-right me-3""></i>", "alert", "alert-info");
                    break;
                case "info-no_icon":
                    styling = new AlertContainerStyling("", "alert", "alert-info");
                    break;
                case ">note":
                    styling = new AlertContainerStyling(@"<H5 class=""alertheading-note"">note</h5>", "alert", "alert-info");
                    break;
                case ">tip":
                    styling = new AlertContainerStyling(@"<H5 class=""alertheading-tip"">tip</h5>", "alert", "alert-info");
                    break;

                case "light":
                    styling = new AlertContainerStyling(@"<i class= ""fab fa-gratipay me-3"" ></i>", "alert", "alert-light");
                    break;
                case "light-no_icon":
                    styling = new AlertContainerStyling("", "alert", "alert-light");
                    break;

                case "dark":
                    styling = new AlertContainerStyling(@"<i class= ""fas fa-gem me-3"" ></i>", "alert", "alert-dark");
                    break;
                case "dark-no_icon":
                    styling = new AlertContainerStyling("", "alert", "alert-dark");
                    break;
                default:
                    if (obj.Info.StartsWith('>'))
                    {
                        styling = new AlertContainerStyling($@"<H5 class=""alertheading-secondary"">{obj.Info.Substring(1)}</h5>", "alert", "alert-secondary");
                    }
                    break;
            }

            renderer.EnsureLine();
            if (renderer.EnableHtmlForBlock)
            {
                //                obj.RemoveData()
                // <div class="alert alert-success">
                HtmlAttributes attribs = obj.GetAttributes();
                int idx = attribs.Classes.IndexOf(obj.Info);
                attribs.Classes.RemoveAt(idx);
                //attribs.Classes.Clear();

                //if (obj.Info == "primary")
                //{
                //    attribs.Classes.Add("alert");
                //    attribs.Classes.Add("alert-primary");
                //}

                //if (obj.Info == "secondary")
                //{
                //    attribs.Classes.Add("alert");
                //    attribs.Classes.Add("alert-secondary");
                //}

                //if (obj.Info == "success")
                //{
                //    attribs.Classes.Add("alert");
                //    attribs.Classes.Add("alert-success");
                //}

                //if (obj.Info == "danger")
                //{
                //    attribs.Classes.Add("alert");
                //    attribs.Classes.Add("alert-danger");
                //}

                //if (obj.Info == "warning")
                //{
                //    attribs.Classes.Add("alert");
                //    attribs.Classes.Add("alert-warning");
                //}

                //if (obj.Info == "info")
                //{
                //    attribs.Classes.Add("alert");
                //    attribs.Classes.Add("alert-info");
                //}

                //if (obj.Info == "light")
                //{
                //    attribs.Classes.Add("alert");
                //    attribs.Classes.Add("alert-light");
                //}

                //if (obj.Info == "dark")
                //{
                //    attribs.Classes.Add("alert");
                //    attribs.Classes.Add("alert-dark");
                //}

                if (styling != null)
                {
                    foreach (string str in styling.Styles)
                    {
                        attribs.Classes.Add(str);
                    }
                }
                /*
                https://getbootstrap.com/docs/4.0/components/alerts/ 
                <div class="alert alert-primary" role="alert">
                  This is a primary alert—check it out!
                </div>
                <div class="alert alert-secondary" role="alert">
                  This is a secondary alert—check it out!
                </div>
                <div class="alert alert-success" role="alert">
                  This is a success alert—check it out!
                </div>
                <div class="alert alert-danger" role="alert">
                  This is a danger alert—check it out!
                </div>
                <div class="alert alert-warning" role="alert">
                  This is a warning alert—check it out!
                </div>
                <div class="alert alert-info" role="alert">
                  This is a info alert—check it out!
                </div>
                <div class="alert alert-light" role="alert">
                  This is a light alert—check it out!
                </div>
                <div class="alert alert-dark" role="alert">
                  This is a dark alert—check it out!
                </div>
                */

                /* icons

 < section class="  text-start p-4 w-100">
      <div class="alert" role="alert" data-mdb-color="primary" data-mdb-alert-init>
        <i class="fas fa-info-circle me-3"></i>A simple primary alert—check it out!
      </div>
      <div class="alert" role="alert" data-mdb-color="secondary" data-mdb-alert-init>
        <i class="fas fa-circle me-3"></i>A simple secondary alert—check it out!
      </div>
      <div class="alert" role="alert" data-mdb-color="success" data-mdb-alert-init>
        <i class="fas fa-check-circle me-3"></i>A simple success alert—check it out!
      </div>
      <div class="alert" role="alert" data-mdb-color="danger" data-mdb-alert-init>
        <i class="fas fa-times-circle me-3"></i>A simple danger alert—check it out!
      </div>
      <div class="alert" role="alert" data-mdb-color="warning" data-mdb-alert-init>
        <i class="fas fa-exclamation-triangle me-3"></i>A simple warning alert—check it out!
      </div>
      <div class="alert" role="alert" data-mdb-color="info" data-mdb-alert-init>
        <i class="fas fa-chevron-circle-right me-3"></i>A simple info alert—check it out!
      </div>
      <div class="alert" role="alert" data-mdb-color="light" data-mdb-alert-init>
        <i class="fab fa-gratipay me-3"></i>A simple light alert—check it out!
      </div>
      <div class="alert" role="alert" data-mdb-color="dark" data-mdb-alert-init>
        <i class="fas fa-gem me-3"></i>A simple dark alert—check it out!
      </div>
    </section>
                */

                obj.SetAttributes(attribs);
                renderer.Write("<div").WriteAttributes(obj).Write('>');
            }


            // We don't escape a CustomContainer
            // add an image
            //renderer.Write("<i class=\"fas fa-times-circle me-3\"></i>");

            //var children = containerBlock;
            //for (int i = 0; i < children.Count; i++)

            if (obj.Count > 0)
            {
                ParagraphBlock blk = obj[0] as ParagraphBlock;
                if (blk != null)
                {
                    string htmlString = "";

                    if (styling != null)
                    {
                        htmlString = styling.BlockPrefix;

                        //if (obj.Info == "primary")
                        //{
                        //    htmlString = @"<i class=""fas fa-info-circle me-3""></i>";
                        //}

                        //if (obj.Info == "secondary")
                        //{
                        //    htmlString = @"<i class=""fas fa-circle me-3""></i>";
                        //}

                        //if (obj.Info == "success")
                        //{
                        //    htmlString = @"<i class=""fas fa-check-circle me-3"" ></i>";
                        //}

                        //if (obj.Info == "danger")
                        //{
                        //    htmlString = @"<i class= ""fas fa-times-circle me-3"" ></i>";
                        //}

                        //if (obj.Info == "warning")
                        //{
                        //    htmlString = @"<i class= ""fas fa-exclamation-triangle me-3"" ></i>";
                        //}

                        //if (obj.Info == "info")
                        //{
                        //    htmlString = @"<i class= ""fas fa-chevron-circle-right me-3""></i>";
                        //}

                        //if (obj.Info == "light")
                        //{
                        //    htmlString = @"<i class= ""fab fa-gratipay me-3"" ></i>";
                        //}

                        //if (obj.Info == "dark")
                        //{
                        //    htmlString = @"<i class= ""fas fa-gem me-3"" ></i>";
                        //}

                        // by literal, they mean "THIS IS WHAT WILL BE VISIBLE" (No HTML parsing)
                        //LiteralInline newPart = new LiteralInline("<i class=\"fas fa-times-circle me-3\"></i>");
                        //Inline newPart = new HtmlInline("<i class=\"fas fa-times-circle me-3\"></i>");
                        Inline newPart = new HtmlInline(htmlString);

                        var inl = blk.Inline.FirstChild;
                        blk.Inline.InsertBefore(newPart);
                        inl.InsertBefore(newPart);
                    }
                }
            }


            var stringBuilder = new StringBuilder();
            using (TextWriter writer = new StringWriter(stringBuilder))
            {
                HtmlRenderer myrend = new HtmlRenderer(writer);
                myrend.WriteChildren(obj);
            }

            string fullString = stringBuilder.ToString();

            if (fullString.StartsWith("<p>"))
                fullString = fullString.Substring(3, fullString.Length - 8);

            renderer.WriteLine(fullString);

            //renderer.WriteChildren(obj);

            if (renderer.EnableHtmlForBlock)
            {
                renderer.WriteLine("</div>");
            }
        }

        // this is from codeblockrenderer
        //protected override void Write(HtmlRenderer renderer, CodeBlock obj)
        //{
        //    renderer.EnsureLine();

        //    if (_blocksAsDiv is not null && (obj as FencedCodeBlock)?.Info is string info && _blocksAsDiv.Contains(info))
        //    {
        //        var infoPrefix = (obj.Parser as FencedCodeBlockParser)?.InfoPrefix ??
        //                         FencedCodeBlockParser.DefaultInfoPrefix;

        //        // We are replacing the HTML attribute `language-mylang` by `mylang` only for a div block
        //        // NOTE that we are allocating a closure here

        //        if (renderer.EnableHtmlForBlock)
        //        {
        //            renderer.Write("<div")
        //                    .WriteAttributes(obj.TryGetAttributes(),
        //                        cls => cls.StartsWith(infoPrefix, StringComparison.Ordinal) ? cls.Substring(infoPrefix.Length) : cls)
        //                    .WriteRaw('>');
        //        }

        //        renderer.WriteLeafRawLines(obj, true, true, true);

        //        if (renderer.EnableHtmlForBlock)
        //        {
        //            renderer.WriteLine("</div>");
        //        }
        //    }
        //    else
        //    {
        //        if (renderer.EnableHtmlForBlock)
        //        {
        //            renderer.Write("<pre");

        //            if (OutputAttributesOnPre)
        //            {
        //                renderer.WriteAttributes(obj);
        //            }

        //            renderer.WriteRaw("><code");

        //            if (!OutputAttributesOnPre)
        //            {
        //                renderer.WriteAttributes(obj);
        //            }

        //            renderer.WriteRaw('>');
        //        }

        //        renderer.WriteLeafRawLines(obj, true, true);

        //        if (renderer.EnableHtmlForBlock)
        //        {
        //            renderer.WriteLine("</code></pre>");
        //        }
        //    }

        //    renderer.EnsureLine();
        //}
    }

    internal class AlertContainerStyling
    {
        public List<string> Styles { get; set; } = new List<string>();
        public string BlockPrefix { get; set; } = string.Empty;

        public AlertContainerStyling(string blockPrefix, params string[] styles)
        {
            BlockPrefix = blockPrefix;
            foreach (string str in styles)
                Styles.Add(str.Trim());
        }
    }

    /// <summary>
    /// Writes the specified <see cref="HtmlAttributes"/>.
    /// </summary>
    /// <param name="attributes">The attributes to render.</param>
    /// <param name="classFilter">A class filter used to transform a class into another class at writing time</param>
    /// <returns>This instance</returns>
    //public HtmlRenderer WriteAttributes2(HtmlAttributes? attributes, Func<string, string>? classFilter = null)
    //{
    //    if (attributes is null)
    //    {
    //        return this;
    //    }

    //    if (attributes.Id != null)
    //    {
    //        Write(" id=\"");
    //        WriteEscape(attributes.Id);
    //        WriteRaw('"');
    //    }

    //    if (attributes.Classes is { Count: > 0 })
    //    {
    //        Write(" class=\"");
    //        for (int i = 0; i < attributes.Classes.Count; i++)
    //        {
    //            var cssClass = attributes.Classes[i];
    //            if (i > 0)
    //            {
    //                WriteRaw(' ');
    //            }
    //            WriteEscape(classFilter != null ? classFilter(cssClass) : cssClass);
    //        }
    //        WriteRaw('"');
    //    }

    //    if (attributes.Properties is { Count: > 0 })
    //    {
    //        foreach (var property in attributes.Properties)
    //        {
    //            Write(' ');
    //            WriteRaw(property.Key);
    //            WriteRaw("=\"");
    //            WriteEscape(property.Value ?? "");
    //            WriteRaw('"');
    //        }
    //    }

    //    return this;
    //}

}
