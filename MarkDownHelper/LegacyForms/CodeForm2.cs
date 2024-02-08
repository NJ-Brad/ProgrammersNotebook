namespace MarkDownHelper
{
    public partial class CodeForm2 : Form
    {
        public CodeForm2()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ConnectButton(buttonCSharp, "csharp");
            ConnectButton(buttonCmd, "cmd");
            ConnectButton(buttonPowershell, "powershell");
            ConnectButton(buttonJavascript, "javascript");
            ConnectButton(buttonHtml, "html");
            ConnectButton(buttonHttp, "http");
            ConnectButton(buttonSql, "sql");
        }

        private void ConnectButton(Button button, string language)
        {
            button.Click += (sender, args) =>
            {
                textBox1.Text = language;
                this.Language = language;
                DialogResult = DialogResult.OK;
                Close();
            };
        }


        public string Language
        {
            get
            {
                return this.language;
            }
            set
            {
                this.language = value;
            }
        }

        public static string CreateLanguageText()
        {
            string rtnVal = string.Empty;

            CodeForm2 form = new CodeForm2();
            if (form.ShowDialog() == DialogResult.OK)
            {
                rtnVal = string.Format("```{0}\n", form.Language);
            }
            return rtnVal;
        }

        string language = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            language = textBox1.Text;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
