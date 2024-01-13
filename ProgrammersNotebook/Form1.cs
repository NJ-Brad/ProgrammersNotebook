using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ProgrammersNotebook
{
    public partial class Form1 : Form
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly IHost host;

        public Form1(ILogger<Form1> logger, IConfiguration configuration, IHost host)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.host = host;
            InitializeComponent();
        }

        private void buttonEditorForm_Click(object sender, EventArgs e)
        {
            //EditorForm ef = new EditorForm();
            EditorForm ef = host.Services.GetRequiredService<EditorForm>();
            ef.ShowDialog();
        }
    }
}
