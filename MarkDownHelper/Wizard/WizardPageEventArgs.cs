namespace MarkDownHelper.Wizard
{
    public class WizardPageEventArgs : EventArgs
    {
        public bool Cancel { get; set; }
        public string NextPage { get; set; }
        public bool NextPageEnabled { get; set; }
    }
}
