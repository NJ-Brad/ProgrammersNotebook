namespace LanguagePuller
{
    internal class ComboBoxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    internal class ComboBoxItemList : List<ComboBoxItem>
    {

        public List<string> Values
        {
            get
            {
                List<string> values = new List<string>();
                foreach (ComboBoxItem cbi in this)
                {
                    values.Add(cbi.Value);
                }
                return values;
            }
        }
    }
}
