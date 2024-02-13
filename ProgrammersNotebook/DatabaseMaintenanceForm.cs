using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ProgrammersNotebook
{
    public partial class DatabaseMaintenanceForm : Form
    {

        private readonly ILogger _logger;
        private readonly IHost _host;
        private readonly IConfiguration _config;

        private readonly IDbContextFactory<PNContext> _contextFactory;
        private RestartHandler? restart = null;

        public DatabaseMaintenanceForm(ILogger<NotebookForm> logger, IConfiguration config, IHost host, IDbContextFactory<PNContext> contextFactory, RestartHandler restart)
        {
            InitializeComponent();

            _logger = logger;
            _config = config;
            _host = host;
            _contextFactory = contextFactory;
            this.restart = restart;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            string dataFile = Path.Combine(Folders.DbFolder, "ProgrammersNotebook.db");
            textBox1.Text = dataFile;

            LoadBackups(Folders.DbFolder, -1);
        }

        private List<FileInfo> GetBackups(string folderName, int orderBy = 0)
        {
            List<FileInfo> rtnVal = new();

            List<FileInfo> firstCut = new();

            string[] files = Directory.GetFiles(folderName, "*.db");

            foreach (string file in files)
            {
                if (Path.GetFileNameWithoutExtension(file).Equals("ProgrammersNotebook", StringComparison.OrdinalIgnoreCase))
                {

                }
                else
                {
                    FileInfo fi = new FileInfo(file);

                    firstCut.Add(fi);
                }
            }

            switch (orderBy)
            {
                case 0:
                    rtnVal.AddRange(firstCut);
                    break;
                case 1:
                    rtnVal.AddRange(firstCut.OrderBy(x => x.CreationTime));
                    break;
                case -1:
                    rtnVal.AddRange(firstCut.OrderByDescending(x => x.CreationTime));
                    break;
                case 2:
                    rtnVal.AddRange(firstCut.OrderBy(x => x.Length));
                    break;
                case -2:
                    rtnVal.AddRange(firstCut.OrderByDescending(x => x.Length));
                    break;
                case 3:
                    rtnVal.AddRange(firstCut.OrderBy(x => x.Name));
                    break;
                case -3:
                    rtnVal.AddRange(firstCut.OrderByDescending(x => x.Name));
                    break;
            }

            return rtnVal;
        }

        private void LoadBackups(string folderName, int orderBy)
        {
            listViewBackups.Items.Clear();

            List<FileInfo> backups = GetBackups(folderName, orderBy);

            foreach (FileInfo fi in backups)
            {
                ListViewItem lvi = listViewBackups.Items.Add(fi.CreationTime.ToString());

                string sizeString = FileSizeHelper.GetReadableFileSize(fi.Length); // Size in bytes

                lvi.SubItems.Add(sizeString);
                lvi.SubItems.Add(fi.Name);

                lvi.Tag = fi;
            }


            listViewBackups.SetSortIcon(Math.Abs(orderBy) - 1, orderBy > 0 ? SortOrder.Ascending : SortOrder.Descending);
        }


        private void buttonBackup_Click(object sender, EventArgs e)
        {
            string dataFile = Path.Combine(Folders.DbFolder, "ProgrammersNotebook.db");

            // https://stackoverflow.com/questions/114983/given-a-datetime-object-how-do-i-get-an-iso-8601-date-in-string-format
            // Prefer this, to avoid having to manually define a framework-provided format
            //DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture);
            //string nowString = DateTime.Now.ToString("o", CultureInfo.InvariantCulture);

            string backupName = GenerateName(Folders.DbFolder);
            File.Copy(dataFile, backupName, true);

            LoadBackups(Folders.DbFolder, sortBy);
        }

        private string GenerateName(string folderName)
        {
            string rtnVal = string.Empty;

            string dataFile = Path.Combine(folderName, "ProgrammersNotebook.db");

            string timePortion = DateTime.Now.ToString("yyyy-MM-dd");

            string candidateTimePortion = timePortion;
            int currentCount = 0;

            string candidateName = $"ProgrammersNotebook{candidateTimePortion}.db";

            while (File.Exists(Path.Combine(folderName, candidateName)))
            {
                currentCount++;
                candidateName = $"ProgrammersNotebook{candidateTimePortion}_{currentCount}.db";
            }

            return Path.Combine(folderName, candidateName);
        }

        int sortBy = 0;

        private void listViewBackups_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int sortByColumn = e.Column + 1;

            if (Math.Abs(sortBy) == sortByColumn)
            {
                sortBy = -sortBy;
            }
            else
            {
                sortBy = sortByColumn;
            }

            LoadBackups(Folders.DbFolder, sortBy);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listViewBackups.SelectedItems)
            {
                FileInfo fi = lvi.Tag as FileInfo;
                if (fi != null)
                {
                    File.Delete(fi.FullName);
                }
            }
            LoadBackups(Folders.DbFolder, sortBy);
        }

        FileCopier fc = null;

        private void buttonRevert_Click(object sender, EventArgs e)
        {
            if (listViewBackups.SelectedItems.Count > 0)
            {
                FileInfo fi = listViewBackups.SelectedItems[0].Tag as FileInfo;
                if (fi != null)
                {
                    if (MessageBox.Show("Your current database will be overwritten.  Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string dataFile = Path.Combine(Folders.DbFolder, "ProgrammersNotebook.db");

                        try
                        {

                            string recoverFile = Path.Combine(Folders.DbFolder, "ProgrammersNotebook.recover");

                            //File.Copy(fi.FullName, recoverFile, true);

                            //File.Copy(fi.FullName, dataFile, true);

                            //fc = new FileCopier(fi.FullName, dataFile);
                            fc = new FileCopier(fi.FullName, recoverFile);
                            fc.OnComplete += Fc_OnComplete;
                            fc.CopyAsync();
                        }
                        catch { MessageBox.Show("Unable to revert database"); }
                    }
                }
            }
        }

        private void Fc_OnComplete()
        {
            MessageBox.Show("Database reverted\r\nYour application will restart now");
            restart.Set(true);
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new();
            sfd.Title = "Export";
            sfd.Filter = "Database Files (*.db)|*.db|All Files (*.*)|*.*";
            sfd.AddExtension = true;
            sfd.AutoUpgradeEnabled = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string dataFile = Path.Combine(Folders.DbFolder, "ProgrammersNotebook.db");

                try
                {
                    File.Copy(sfd.FileName, dataFile, true);
                    MessageBox.Show("Database exported");
                }
                catch { MessageBox.Show("Unable to export database"); }
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            ofd.Title = "Import";
            ofd.Multiselect = false;
            ofd.Filter = "Database Files (*.db)|*.db|All Files (*.*)|*.*";
            ofd.AddExtension = true;
            ofd.AutoUpgradeEnabled = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (listViewBackups.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Your current database will be overwritten.  Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string dataFile = Path.Combine(Folders.DbFolder, "ProgrammersNotebook.db");

                        try
                        {
                            File.Copy(ofd.FileName, dataFile, true);
                            MessageBox.Show("Database reverted");
                        }
                        catch { MessageBox.Show("Unable to revert database"); }
                    }
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string dataFile = Path.Combine(Folders.DbFolder, "ProgrammersNotebook.db");

            using (PNContext context = _contextFactory.CreateDbContext())
            {

                // https://stackoverflow.com/questions/31710038/how-to-apply-migrations-from-code-ef-core
                //var migrator = context.GetInfrastructure.GetInfrastructure().GetService<IMigrator>();
                List<string> pending = context.Database.GetPendingMigrations().ToList<string>();

                if (pending.Count == 0)
                {
                    MessageBox.Show("There are no pending updates");
                    return;
                }

                // do migrations
                context.Database.Migrate();
            }

            MessageBox.Show("Your application will restart now");

            restart.Set(true);
        }
    }
}
