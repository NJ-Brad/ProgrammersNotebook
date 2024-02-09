namespace ProgrammersNotebook
{
    internal static class ReplacementExtensions
    {
        internal static void Set(this Dictionary<string, string> dictionary, string key, string value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }
    }
}
