namespace ProgrammersNotebook
{
    public class Page
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("D").ToUpper();
        public string Name { get; set; }
        public string DocumentType { get; set; }
        public List<Page> Pages { get; set; } = new();
        public string PageContent { get; set; } = string.Empty;
    }
}
