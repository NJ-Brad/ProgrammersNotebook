using MarkDownHelper;
using System.Text.Json;

namespace ProgrammersNotebook
{
    internal class Fragments
    {
        internal PageFragment GetFragment(string key)
        {
            PageFragment rtnVal = null;

            string fileName = Path.ChangeExtension(Folders.GetConfigFileName(key), "frag");

            if (!File.Exists(fileName))
            {
                PageFragment pf = new PageFragment { Name = key, FragmentType = "Text", Content = fileName };
                File.WriteAllText(fileName, JsonSerializer.Serialize(pf, new JsonSerializerOptions { WriteIndented = true }));
            }

            string text = File.ReadAllText(fileName);

            rtnVal = JsonSerializer.Deserialize<PageFragment>(text);
            return rtnVal;
        }

        internal void SaveFragment(PageFragment fragment)
        {
            string fileName = Path.ChangeExtension(Folders.GetConfigFileName(fragment.Name), "frag");

            File.WriteAllText(fileName, JsonSerializer.Serialize(fragment, new JsonSerializerOptions { WriteIndented = true }));
        }

        internal List<string> GetFragmentList(bool isImage)
        {
            List<string> rtnVal = new();
            // this will need to be optimized later (maybe)
            string folder = Folders.ConfigFolder;

            string[] files = Directory.GetFiles(folder, "*.frag");

            PageFragment fragment = null;
            foreach (string fileName in files)
            {
                string text = File.ReadAllText(fileName);
                fragment = JsonSerializer.Deserialize<PageFragment>(text);
                if (isImage)
                {
                    if (fragment.FragmentType != "Text")
                    {
                        rtnVal.Add(fragment.Name);
                    }
                }
                else
                {
                    if (fragment.FragmentType == "Text")
                    {
                        rtnVal.Add(fragment.Name);
                    }
                }
            }

            return rtnVal; ;
        }
    }
}
