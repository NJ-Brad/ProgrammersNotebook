using MarkDownHelper.Wizard;
using System.ComponentModel;
using System.Text;
namespace MarkDownHelper.WizardPages
{
    [ToolboxItem(false)]
    public partial class SelectFormatPage : WizardPage
    {
        public SelectFormatPage()
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

            // https://www.markdownguide.org/hacks/#indent-tab
            ConnectButton(buttonItalic, t => { return $"*{t}*"; });
            ConnectButton(buttonBold, t => { return $"**{t}**"; });
            //ConnectButton(buttonUnderline, t => { return $"<ins>{t}</ins>"; });
            //ConnectButton(buttonUnderline, t => { return $"<u>{t}</u>"; });
            ConnectButton(buttonUnderline, t => { return $"__{t}__"; });

            //< span style = "text-decoration:underline" > text </ span >
            ConnectButton(buttonStrike, t => { return $"~~{t}~~"; });
            ConnectButton(buttonHd1, t => { return $"#{t}#"; });
            ConnectButton(buttonHd2, t => { return $"##{t}##"; });
            ConnectButton(buttonHd3, t => { return $"###{t}###"; });
            ConnectButton(buttonHd4, t => { return $"####{t}####"; });
            ConnectButton(buttonHd5, t => { return $"#####{t}#####"; });
            ConnectButton(buttonHd6, t => { return $"######{t}######"; });

            ConnectButton(buttonOList, t =>
            {
                string[] lines = t.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                foreach (string line in lines)
                {
                    sb.AppendLine($"1. {line}");
                }
                return sb.ToString().TrimEnd();
            });

            ConnectButton(buttonUList, t =>
            {
                string[] lines = t.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                foreach (string line in lines)
                {
                    sb.AppendLine($"+ {line}");
                }
                return sb.ToString().TrimEnd();
            });

            buttonCode.Click += (sender, args) => { NavigateTo("SelectLanguagePage"); };

            ConnectButton(buttonQuote, t =>
            {
                string[] lines = t.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                foreach (string line in lines)
                {
                    sb.AppendLine($"> {line}");
                }
                return sb.ToString().TrimEnd();
            });

            ConnectButton(buttonTask, t =>
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
            ConnectButton(buttonHighlight, t => { return $"=={t}=="; });
            ConnectButton(buttonSuperscript, t => { return $"^{t}^"; });
            ConnectButton(buttonSubscript, t => { return $"~{t}~"; });

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

        private string Modify(string beforeText, Operation op)
        {
            string prefix = op.Prefix;
            string suffix = op.Suffix;

            if (op.PrefixDelegate != null)
            {
                prefix = op.PrefixDelegate(beforeText);
            }

            if (op.SuffixDelegate != null)
            {
                suffix = op.SuffixDelegate(beforeText);
            }

            return Modify(beforeText, prefix, suffix, op.KeepOriginal);
        }

        private string Modify(string beforeText, string prefix, string suffix, bool keepOriginal)
        {
            string currentText = beforeText.TrimEnd();
            bool replaceEOL = !beforeText.Equals(beforeText.TrimEnd());
            string newText = string.Format("{0}{1}{2}{3}", prefix, keepOriginal ? currentText : string.Empty, suffix, replaceEOL ? "\r\n" : string.Empty);
            return newText;
        }

    }
}
