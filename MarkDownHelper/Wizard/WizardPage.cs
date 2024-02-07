using System.ComponentModel;

namespace MarkDownHelper.Wizard
{
    [ToolboxItem(false)]
    public partial class WizardPage : UserControl
    {
        public WizardPage()
        {
            InitializeComponent();
        }

        public WizardData Data { get; set; }

        public EventHandler<WizardPageEventArgs>? SetNextPageHandler { get; set; } = null;

        protected void SetNextPage(string nextPage)
        {
            WizardPageEventArgs args = new WizardPageEventArgs
            { NextPage = nextPage };

            SetNextPageHandler?.Invoke(this, args);

            //return args.Value.Content;
        }

        public virtual void BeforeNextPage(WizardPageEventArgs args)
        {

        }

        public EventHandler<WizardPageEventArgs>? EnableNextPageHandler { get; set; } = null;

        protected void EnableNextPage(bool enable)
        {
            WizardPageEventArgs args = new WizardPageEventArgs
            { NextPageEnabled = enable };

            EnableNextPageHandler?.Invoke(this, args);

            //return args.Value.Content;
        }


        public EventHandler<WizardPageEventArgs>? NavigateToPageHandler { get; set; } = null;

        protected void NavigateTo(string nextPage)
        {
            WizardPageEventArgs args = new WizardPageEventArgs
            { NextPage = nextPage };

            NavigateToPageHandler?.Invoke(this, args);

            //return args.Value.Content;
        }

        public EventHandler<WizardPageEventArgs>? NextPageHandler { get; set; } = null;

        protected void Next()
        {
            NextPageHandler?.Invoke(this, new WizardPageEventArgs());
        }

        //public EventHandler<EmbeddedFragmentEventArgs>? EmbeddedFragmentHandler { get; set; } = null;

        //private string GetEmbedText(string key)
        //{
        //    EmbeddedFragmentEventArgs args = new();
        //    args.Key = key;
        //    EmbeddedFragmentHandler?.Invoke(this, args);

        //    return args.Value.Content;
        //}

        bool firstVisible = true;

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible && firstVisible)
            {
                firstVisible = false;
                FirstShown();
            }
        }

        protected virtual void FirstShown()
        {

        }
    }
}
