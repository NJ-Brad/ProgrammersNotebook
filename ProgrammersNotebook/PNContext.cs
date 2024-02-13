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

            // testing creation
            //string dataFile = Path.Combine("C:\\Test Data", "ProgrammersNotebook.db");
            //if (File.Exists(dataFile))
            //{
            //}

            DataSource = $"Data Source={dataFile}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"{DataSource}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<string> pending = this.Database.GetPendingMigrations().ToList<string>();

            // this applies the special treatment, only until the migration has completed
            //if (pending.First(p => p == "20240212212026_MigrationTest") != null)
            //{
            //    // this handles when a field is in the model, but not in the database
            //    modelBuilder.Entity<Page>().Ignore(c => c.MigrationTest);
            //}

            //builder.Entity<Employee>().Property<string>("AddressAs");


            // https://stackoverflow.com/questions/1707663/exclude-a-field-property-from-the-database-with-entity-framework-4-code-first
            //builder.Entity<Employee>().Property<string>("AddressAs");
            //Then you can query on that column like so:

            //context.Employees.Where(e => EF.Property<string>(e, "AddressAs") == someValue);

            // this is for whan a field is in the database, but not the model
            //modelBuilder.Entity<Page>().Property<string>("LowerName");
        }
    }
}
