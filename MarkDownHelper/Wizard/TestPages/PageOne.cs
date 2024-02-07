using MarkDownHelper.Wizard;
using System.ComponentModel;
namespace MarkDownHelper.WizardPages
{
    [ToolboxItem(false)]
    public partial class PageOne : WizardPage
    {
        public PageOne()
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
            EnableNextPage(checkBox1.Checked);
        }

        public void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            EnableNextPage(checkBox1.Checked);
        }
    }
}
