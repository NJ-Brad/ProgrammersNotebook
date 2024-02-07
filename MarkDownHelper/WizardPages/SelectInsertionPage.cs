using MarkDownHelper.Wizard;
using System.ComponentModel;
using System.Text;
namespace MarkDownHelper.WizardPages
{
    [ToolboxItem(false)]
    public partial class SelectInsertionPage : WizardPage
    {
        public SelectInsertionPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NavigateTo("PageThree");
        }

        //protected override void OnVisibleChanged(EventArgs e)
        //{
        //    base.OnVisibleChanged(e);
        //    if (Visible)
        //    {
        //        EnableNextPage(checkBox1.Checked);
        //    }
        //}

        protected override void FirstShown()
        {
            base.FirstShown();

            AutoScrollMinSize = panel1.Size;

            //EnableNextPage(checkBox1.Checked);

            EnableNextPage(false);  // user needs to select a formatting

            ConnectButtonNav(buttonHeader, nameof(TableHeaderPage));
            ConnectButton(buttonRow, t =>
                {
                    string lineBefore = Data["LineBefore"].ToString();

                    //                    int cols = t.Occurrences('|') + 1; if (t.StartsWith("|")) cols--; if (t.TrimEnd().EndsWith("|")) cols--;
                    int cols = lineBefore.Occurrences('|') + 1; if (lineBefore.StartsWith("|")) cols--; if (lineBefore.TrimEnd().EndsWith("|")) cols--;
                    //StringBuilder sb = new StringBuilder("\n|"); for (int i = 0; i < cols; i++) { sb.Append("value|"); }
                    StringBuilder sb = new StringBuilder("|"); for (int i = 0; i < cols; i++) { sb.Append("value|"); }
                    sb.AppendLine();
                    sb.Append(t);
                    return sb.ToString();
                }
            );
            ConnectButton(buttonDictionary, t => { return $"<dl>\n</dl>"; });
            ConnectButtonNav(buttonDefinition, nameof(DefinitionPage));
            ConnectButton(buttonDivider, t => { return "\r\n----\r\n"; }); // [X]
            ConnectButtonNav(buttonLink, nameof(LinkPage));

            ConnectButton(buttonTxtBlock, t => { return $"####{t}####"; });
            ConnectButton(buttonImage, t => { return $"#####{t}#####"; });
            //ConnectButton(buttonHd6, t => { return $"######{t}######"; });

            //ConnectButton(buttonOList, t =>
            //{
            //    string[] lines = t.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            //    StringBuilder sb = new StringBuilder();
            //    foreach (string line in lines)
            //    {
            //        sb.AppendLine($"1. {line}");
            //    }
            //    return sb.ToString();
            //});

            //ConnectButton(buttonUList, t =>
            //{
            //    string[] lines = t.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            //    StringBuilder sb = new StringBuilder();
            //    foreach (string line in lines)
            //    {
            //        sb.AppendLine($"+ {line}");
            //    }
            //    return sb.ToString();
            //});
        }

        private string InsertTableRow()
        {
            //wf.Data["LineBefore"] = GetLineBefore(richTextBox1);

            return "";
        }


        private void ConnectButton(Button button, OperationDelegate del)
        {
            button.Click += (sender, args) =>
            {
                DoOperation
                (
                    del
                );
                NavigateTo("ConfirmationPage");
            };
        }

        private void ConnectButtonNav(Button button, string nextPage)
        {
            button.Click += (sender, args) =>
            {
                NavigateTo(nextPage);
            };
        }


        public void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            //EnableNextPage(checkBox1.Checked);
        }

        //private void buttonItalic_Click(object sender, EventArgs e)
        //{
        //    //            Data["ResultText"] = $"_{Data["TestText"]}_";
        //    Data["ResultText"] = $"_{Data["TestText"]}_";

        //    string beforeText = Data["TestText"].ToString();

        //    //string prefix = () => { return LinkForm.CreateLinkText(); }
        //    //string prefix = (OperationDelegate) t => { return LinkForm.CreateLinkText(); };

        //    //OperationDelegate del = (t => { return LinkForm.CreateLinkText(); });
        //    OperationDelegate del = (t => { return t.ToUpper(); });

        //    string afterText = del(beforeText);

        //    //            operations.Add("Link", t => { return LinkForm.CreateLinkText(); }, string.Empty);

        //    NavigateTo("ConfirmationPage");
        //}

        //public string Test { get { return ""; } }

        //public string Test2 { get => "A"; }

        private void DoOperation(OperationDelegate del)
        {
            string beforeText = Data["TestText"].ToString();
            string trimmedText = beforeText.TrimEnd();
            bool replaceEOL = !beforeText.Equals(trimmedText);
            string endText = beforeText.Equals(trimmedText) ? string.Empty : "\r\n";

            string afterText = $"{del(trimmedText)}{endText}";

            Data["ResultText"] = afterText;
        }

        //private string Modify(string beforeText, Operation op)
        //{
        //    string prefix = op.Prefix;
        //    string suffix = op.Suffix;

        //    if (op.PrefixDelegate != null)
        //    {
        //        prefix = op.PrefixDelegate(beforeText);
        //    }

        //    if (op.SuffixDelegate != null)
        //    {
        //        suffix = op.SuffixDelegate(beforeText);
        //    }

        //    return Modify(beforeText, prefix, suffix, op.KeepOriginal);
        //}

        //private string Modify(string beforeText, string prefix, string suffix, bool keepOriginal)
        //{
        //    string currentText = beforeText.TrimEnd();
        //    bool replaceEOL = !beforeText.Equals(beforeText.TrimEnd());
        //    string newText = string.Format("{0}{1}{2}{3}", prefix, keepOriginal ? currentText : string.Empty, suffix, replaceEOL ? "\r\n" : string.Empty);
        //    return newText;
        //}

    }
}
