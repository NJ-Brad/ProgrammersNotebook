using System.Text;

namespace MarkDownHelper
{
    public class Replacer
    {
        public string VarStart = "<$";
        public string VarEnd = "$>";
        public Dictionary<string, string> Replacements = new();

        //public string DoReplacements(string input)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    foreach (char ch in input)
        //    {
        //        sb.Append(ch);
        //    }

        //    return sb.ToString();
        //}

        public string DoReplacements(string input)
        {
            StringBuilder sb = new StringBuilder();

            int lastCopied = -1;
            int startOfVar = -1;
            startOfVar = input.IndexOf(VarStart, startOfVar + 1);
            int endOfVar = -1;

            while (startOfVar >= 0)
            {
                endOfVar = input.IndexOf(VarEnd, startOfVar + 1);
                if (endOfVar >= 0)
                {
                    string var = input.Substring(startOfVar + 2, (endOfVar - startOfVar - 2));

                    sb.Append(input.Substring(lastCopied + 1, startOfVar - lastCopied - 1));

                    // I want this to be case insensitive
                    //foreach(string str in Replacements.Keys)
                    foreach (KeyValuePair<string, string> kvp in Replacements)
                    {
                        if (kvp.Key.Equals(var, StringComparison.OrdinalIgnoreCase))
                        {
                            sb.Append(kvp.Value);
                        }
                    }
                    //sb.Append("A variable was here");

                    lastCopied = endOfVar + 1;
                }
                startOfVar = input.IndexOf(VarStart, startOfVar + 1);
            }

            // copy rest of string (if there is anything)
            {
                sb.Append(input.Substring(lastCopied + 1));
            }

            return sb.ToString();
        }
    }
}
