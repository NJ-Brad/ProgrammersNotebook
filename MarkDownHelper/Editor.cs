namespace MarkDownHelper
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
        }

        private string fileName;
        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                this.fileName = value;
                Text = this.fileName;
            }
        }

        public static void Edit(string fileName = "")
        {
            Editor ed = new Editor();
            ed.FileName = fileName;
            ed.ShowDialog();
        }

    }
}
