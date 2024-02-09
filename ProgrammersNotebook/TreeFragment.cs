namespace ProgrammersNotebook
{
    // This is for use in the tree.  It is not to be used directly in the data domain
    public class TreePage
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("D").ToUpper();
        public string Name { get; set; }
        public string DocumentType { get; set; }
        public List<Page> Pages { get; set; } = new();
    }
}
