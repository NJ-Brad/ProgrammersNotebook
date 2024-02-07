using MarkDownHelper.Wizard;
using System.ComponentModel;
namespace MarkDownHelper.WizardPages
{
    [ToolboxItem(false)]
    public partial class ConfirmationPage : WizardPage
    {
        public ConfirmationPage()
        {
            InitializeComponent();
        }

        //bool firstVisible = true;

        //protected override void OnVisibleChanged(EventArgs e)
        //{
        //    base.OnVisibleChanged(e);
        //    if (Visible && firstVisible)
        //    {
        //        firstVisible = false;
        //        EnableNextPage(true);
        //        //EnableNextPage(checkBox1.Checked);
        //        richTextBox1.Text = Data["ResultText"].ToString();
        //        browserWrapper1.ShowMarkdownText(richTextBox1.Text);
        //    }
        //}

        protected override void FirstShown()
        {
            base.FirstShown();

            AutoScrollMinSize = tabControl1.Size;
            richTextBox1.Text = Data["ResultText"].ToString();
            browserWrapper1.ShowMarkdownText(richTextBox1.Text);

            EnableNextPage(true);
            SetNextPage("");    // this will mark this as an ending page
        }
    }
}