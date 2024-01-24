using MarkDownHelper;

namespace ProgrammersNotebook
{
    internal class Fragments
    {
        PNContext context = null;
        internal Fragments(PNContext context)
        {
            this.context = context;
        }
        internal PageFragment GetFragment(string key)
        {
            return context.Fragments.Where(p => p.Name == key).First();

            //PageFragment rtnVal = null;

            //string fileName = Path.ChangeExtension(Folders.GetConfigFileName(key), "frag");

            //if (!File.Exists(fileName))
            //{
            //    PageFragment pf = new PageFragment { Name = key, FragmentType = "Text", Content = fileName };
            //    File.WriteAllText(fileName, JsonSerializer.Serialize(pf, new JsonSerializerOptions { WriteIndented = true }));
            //}

            //string text = File.ReadAllText(fileName);

            //rtnVal = JsonSerializer.Deserialize<PageFragment>(text);
            //return rtnVal;
        }

        internal void SaveFragment(PageFragment fragment)
        {
            PageFragment existing = context.Fragments.Where(p => p.Name == fragment.Name).FirstOrDefault();
            if (existing != null)
            {
                existing.FragmentType = fragment.FragmentType;
                existing.Content = fragment.Content;
                existing.Name = fragment.Name;
                //existing.Id = fragment.Id;
                context.Update(existing);
            }
            else
            {
                context.Add(fragment);
            }
            context.SaveChanges();

            //string fileName = Path.ChangeExtension(Folders.GetConfigFileName(fragment.Name), "frag");

            //File.WriteAllText(fileName, JsonSerializer.Serialize(fragment, new JsonSerializerOptions { WriteIndented = true }));
        }

        internal List<string> GetFragmentList(bool isImage)
        {
            List<string> rtnVal = new();

            if (isImage)
            {
                foreach (PageFragment frag in context.Fragments.Where(p => p.FragmentType != "Text").ToArray())
                    rtnVal.Add(frag.Name);
            }
            else
            {
                foreach (PageFragment frag in context.Fragments.Where(p => p.FragmentType == "Text").ToArray())
                    rtnVal.Add(frag.Name);
            }

            //List<string> rtnVal = new();
            //// this will need to be optimized later (maybe)
            //string folder = Folders.ConfigFolder;

            //string[] files = Directory.GetFiles(folder, "*.frag");

            //PageFragment fragment = null;
            //foreach (string fileName in files)
            //{
            //    string text = File.ReadAllText(fileName);
            //    fragment = JsonSerializer.Deserialize<PageFragment>(text);
            //    if (isImage)
            //    {
            //        if (fragment.FragmentType != "Text")
            //        {
            //            rtnVal.Add(fragment.Name);
            //        }
            //    }
            //    else
            //    {
            //        if (fragment.FragmentType == "Text")
            //        {
            //            rtnVal.Add(fragment.Name);
            //        }
            //    }
            //}

            return rtnVal;
        }
    }
}
