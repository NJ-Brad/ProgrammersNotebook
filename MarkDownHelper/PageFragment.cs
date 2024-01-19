namespace MarkDownHelper
{
    public class PageFragment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("D").ToUpper();
        public string Name { get; set; }
        public string FragmentType { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
