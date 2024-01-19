namespace MarkDownHelper
{
    public class CustomProtocolHandler
    {
        public string Prefix { get; set; }
        public EventHandler<CustomProtocolEventArgs> Handler { get; set; }
    }

    public class CustomProtocolEventArgs : EventArgs
    {
        public string Protocol { get; set; } = "*";
        public string Requested { get; set; } = string.Empty;
        public bool Found { get; set; } = false;
        public Stream? ReturnData { get; set; } = null;
        public List<string> Headers { get; set; } = new();
    }
}
