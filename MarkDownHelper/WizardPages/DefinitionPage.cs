using MarkDownHelper.Wizard;

namespace MarkDownHelper.WizardPages
{
    public partial class DefinitionPage : WizardPage
    {
        public DefinitionPage()
        {
            InitializeComponent();
        }

        protected override void FirstShown()
        {
            base.FirstShown();
            AutoScrollMinSize = panel1.Size;

            SetNextPage(nameof(ConfirmationPage));
            EnableNextPage(true);
        }

        public override void BeforeNextPage(WizardPageEventArgs args)
        {
            base.BeforeNextPage(args);

            //rtnVal = string.Format("<dt>{0}</dt>\n<dd>{1}</dd>\n", form.Term, form.Meaning);
            string newText = $"<dt>{textBox1.Text}</dt>\n<dd>{textBox2.Text}</dd>\n";
            Data["ResultText"] = newText;
        }
    }
}
