using MarkDownHelper;
using Microsoft.EntityFrameworkCore;

namespace ProgrammersNotebook
{
    public class PNContext : DbContext
    {

        // Tables
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageFragment> Fragments { get; set; }


        public string DataSource { get; }

        public PNContext()
        {
            //var config = new ConfigurationBuilder().AddUserSecrets < [Class Name] > ().Build();

            //var secretProvider = config.Providers.First();
            //secretProvider.TryGet("[ProjectName]:ConnectionString", out var secretPass);

            //DataSource = secretPass;

            string dataFile = Path.Combine(Folders.DbFolder, "ProgrammersNotebook.db");
            DataSource = $"Data Source={dataFile}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"{DataSource}");
    }
}
