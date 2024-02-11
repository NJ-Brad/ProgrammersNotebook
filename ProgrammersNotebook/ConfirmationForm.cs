namespace ProgrammersNotebook
{
    public partial class ConfirmationForm : Form
    {
        public ConfirmationForm()
        {
            InitializeComponent();
        }

        public static bool ConfirmRemoval(string name)
        {
            bool rtnVal = false;

            ConfirmationForm form = new ConfirmationForm();
            form.ItemName = name;
            if (form.ShowDialog() == DialogResult.OK)
            {
                rtnVal = true;
            }
            return rtnVal;
        }


        public string ItemName { get; set; }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            label2.Text = ItemName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != ItemName)
            {
                MessageBox.Show("Names do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
