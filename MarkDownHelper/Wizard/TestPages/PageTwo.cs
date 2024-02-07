
using MarkDownHelper.Wizard;
using System.ComponentModel;
namespace MarkDownHelper.WizardPages
{
    [ToolboxItem(false)]
    public partial class PageTwo : WizardPage
    {
        public PageTwo()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                SetNextPage("PageFour");
            }
        }
    }
}
