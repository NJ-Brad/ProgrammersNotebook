namespace MarkDownHelper
{
    public partial class AlertForm : Form
    {
        public AlertForm()
        {
            InitializeComponent();
        }

        public static string CreateAlertText()
        {
            string rtnVal = string.Empty;

            AlertForm form = new AlertForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                //rtnVal = string.Format("<dt>{0}</dt>\n<dd>{1}</dd>\n", form.Term, form.Meaning);
                rtnVal = form.ResultText;
            }
            return rtnVal;
        }

        public string ResultText { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    ResultText = $"!!!{comboBox2.SelectedItem}\n{textBox2.Text}r\n!!!\n";
                    break;
                case 1:
                    ResultText = $"!!!{comboBox2.SelectedItem}-no_icon\n{textBox2.Text}r\n!!!\n";
                    break;
                case 2:
                    ResultText = $"!!!>{comboBox2.SelectedItem}\n{textBox2.Text}r\n!!!\n";
                    break;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                case 1:
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("primary");
                    comboBox2.Items.Add("secondary");
                    comboBox2.Items.Add("success");
                    comboBox2.Items.Add("danger");
                    comboBox2.Items.Add("warning");
                    comboBox2.Items.Add("info");
                    comboBox2.Items.Add("light");
                    comboBox2.Items.Add("dark");
                    break;
                case 2:
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("Note");
                    comboBox2.Items.Add("Tip");
                    comboBox2.Items.Add("important");
                    comboBox2.Items.Add("caution");
                    comboBox2.Items.Add("warning");
                    comboBox2.Items.Add("ToDo");
                    break;
            }

        }
    }
}
