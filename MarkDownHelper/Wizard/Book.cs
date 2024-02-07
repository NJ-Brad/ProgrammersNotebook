using System.ComponentModel;

namespace MarkDownHelper.Wizard
{
    [ToolboxItem(false)]
    public partial class Book : UserControl
    {
        bool firstVisible = true;
        public Book()
        {
            InitializeComponent();
        }

        bool isLastPage = false;

        public bool IsLastPage { get => isLastPage; }

        public void Back()
        {
            if (navigationHistory.Count > 1)
            {
                WizardPage navPage = navigationHistory.Pop();
                if (navPage != null)
                {
                    navPage = navigationHistory.Pop();
                }

                if (navPage != null)
                {
                    SelectPage(navPage);
                }
            }
        }

        public void Next()
        {
            if (nextPage != null)
                SelectPage(nextPage);
        }

        private void SelectPage(WizardPage page)
        {
            if (currentPage != null)
            {
                WizardPageEventArgs args = new WizardPageEventArgs
                { NextPage = page.Name };
                currentPage.BeforeNextPage(args);

                if (args.Cancel)
                {
                    return;
                }

                currentPage.Visible = false;
            }

            if (!Controls.Contains(page))
            {
                Controls.Add(page);
                page.NavigateToPageHandler += NavigateToPage;
                page.SetNextPageHandler += SetNextPage;
                page.EnableNextPageHandler += EnableNextPage;
                page.NextPageHandler += NextPage;
                page.Data = Data;
                page.Visible = false;
            }

            currentPage = page;
            int idx = Pages.IndexOf(currentPage);
            if (idx == Pages.Count - 1)
            {
                nextPage = null;
                isLastPage = true;
            }
            else
            {
                // default to the next page in order of addition
                nextPage = Pages[idx + 1];
                isLastPage = false;
            }

            currentPage.Dock = DockStyle.Fill;
            //currentPage.BackColor = Color.LightBlue;
            currentPage.Visible = true;
            navigationHistory.Push(currentPage);

            if (navigationHistory.Count < 2)
            {
                BackButton.Enabled = false;
            }
            else
            {
                BackButton.Enabled = true;
            }

            if (nextPage == null)
            {
                NextButton.Text = "Finish";
            }
            else
            {
                NextButton.Text = "Next >>";
            }
        }

        private void NavigateToPage(object sender, WizardPageEventArgs e)
        {
            WizardPage pg = FindPage(e.NextPage);

            if (pg == null) throw new KeyNotFoundException($"Page {e.NextPage} is not in the list of available pages");

            if (pg != null)
            {
                SelectPage(pg);
            }
        }

        private void SetNextPage(object sender, WizardPageEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NextPage))
            {
                isLastPage = true;
                nextPage = null;
                return;
            }

            WizardPage pg = FindPage(e.NextPage);

            if (pg == null) throw new KeyNotFoundException($"Page {e.NextPage} is not in the list of available pages");

            if (pg != null)
            {
                nextPage = pg;
                isLastPage = false;
            }
        }

        private void EnableNextPage(object sender, WizardPageEventArgs e)
        {
            NextButton.Enabled = e.NextPageEnabled;
        }
        private void NextPage(object sender, WizardPageEventArgs e)
        {
            Next();
        }

        public System.Windows.Forms.Button BackButton { get; set; }
        public System.Windows.Forms.Button NextButton { get; set; }

        public List<WizardPage> Pages { get; } = new List<WizardPage>();
        public WizardData Data { get; } = new WizardData();

        WizardPage? currentPage = null;
        WizardPage? nextPage = null;
        Stack<WizardPage> navigationHistory = new Stack<WizardPage>();

        public void Start(string startingPoint = "")
        {
            WizardPage startingPage = FindPage(startingPoint);
            if (startingPage == null)
            {
                startingPage = Pages[0];
            }
            //SelectPage(Pages[0]);
            SelectPage(startingPage);
        }

        private WizardPage FindPage(string name)
        {
            WizardPage page = null;

            foreach (WizardPage pg in Pages)
            {
                System.Diagnostics.Debug.WriteLine(pg.Name);
                if (pg.Name == name)
                {
                    page = pg;
                    break;
                }
            }

            return page;
        }
    }
}
