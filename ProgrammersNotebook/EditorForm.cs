namespace ProgrammersNotebook
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
        }
        public string FileName { get; set; }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            //markDownDisplay1.FileName = @"C:\Users\bbruce\source\repos\ADRn\ADRn\template.md";
            markDownDisplay1.FileName = FileName;
            markDownDisplay1.ReadOnly = false;
        }
    }
}
