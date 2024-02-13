using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammersNotebook
{
    public class Page
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("D").ToUpper();
        public string Name { get; set; }
        public string DocumentType { get; set; }
        public List<Page> Pages { get; set; } = new();
        public string PageContent { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime Modified { get; set; } = DateTime.Now;
        //public string MigrationTest { get; set; } = string.Empty;

        [NotMapped]
        public string LowerName { get { return Name.ToLowerInvariant(); } set { } }
    }
}
