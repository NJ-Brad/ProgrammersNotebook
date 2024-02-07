using System.ComponentModel;

namespace MarkDownHelper.Wizard
{
    public partial class WizardForm : Form
    {
        /*
         * Notes:
         * https://stackoverflow.com/questions/35278227/hiding-tab-headers-in-tabcontrol-in-winforms
        */

        public WizardForm()
        {
            InitializeComponent();
        }
        public WizardData Data { get { return book1.Data; } }
        public List<WizardPage> Pages { get { return book1.Pages; } }
        public void Start(string startingPoint = "")
        {
            book1.Start(startingPoint);
        }

        private string startingPage = string.Empty;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // set the buttons, before the book becomes visible
            book1.BackButton = button1;
            book1.NextButton = button2;
            book1.Visible = true;

            book1.Start(startingPage);
        }

        public WizardResult StartWizard(string startingPage = "")
        {
            this.startingPage = startingPage;
            return ToWizardResult(base.ShowDialog());
        }

        private WizardResult ToWizardResult(DialogResult result)
        {
            WizardResult rtnVal = WizardResult.None;

            switch (result)
            {
                case DialogResult.None:
                    rtnVal = WizardResult.None;
                    break;
                case DialogResult.OK:
                    rtnVal = WizardResult.OK;
                    break;
                case DialogResult.Cancel:
                    rtnVal = WizardResult.Cancel;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(result));
            }
            return rtnVal;
        }

        [Obsolete("Use StartWizard instead", true)] // true will cause a compile-time error
        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        public System.Windows.Forms.DialogResult ShowDialog() { return DialogResult.Cancel; }

        [Obsolete("Use StartWizard instead", true)] // true will cause a compile-time error
        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        public System.Windows.Forms.DialogResult ShowDialog(System.Windows.Forms.IWin32Window? owner) { return DialogResult.Cancel; }

        private void button1_Click(object sender, EventArgs e)
        {
            book1.Back();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (book1.IsLastPage)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                book1.Next();
            }
        }

        /*
         * TL:DR - Each page is a component (UserControl)
         * 
         * A tab control allows a developer to edit the content of all pages on the same form
         * unfortunately, this also means that all of the controls belong to the same form
         * It also means that all of the supporting code is in the same class.
         * 
         * If I am working on moving this to a collection of components  (UserControls), go ahead and make the 
         * components  (UserControls) derive from a class that will support the navigation better (you can inquire 
         * for "next" page.  They can also have an event set, that can be called for triggering
         * navigation from within the component
        */
    }
}
