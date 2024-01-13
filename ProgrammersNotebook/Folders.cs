namespace ProgrammersNotebook
{
    internal class Folders
    {
        internal static string DefaultProjectFolder
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProgrammersNotebook\\Notes");
            }
        }

        //internal static string TemplateFolder
        //{
        //    get
        //    {
        //        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PrjectCrossroads\\Templates");
        //    }
        //}

        //internal static string ProjectTemplateFolder
        //{
        //    get
        //    {
        //        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PrjectCrossroads\\ProjectTemplates");
        //    }
        //}

        //internal static string FileTemplateFolder
        //{
        //    get
        //    {
        //        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PrjectCrossroads\\FileTemplates");
        //    }
        //}

        internal static string ConfigFolder
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProgrammersNotebook\\Notes");
            }
        }

        //internal static string GetProjectFolder(string projectId)
        //{
        //    return "";
        //}

        //internal static string GetTemplateFolder(string templateName)
        //{
        //    return Path.GetFullPath(Path.Combine(Folders.ProjectTemplateFolder, templateName));
        //}

        internal static string GetConfigFileName(string configFileId)
        {
            return Path.GetFullPath(Path.Combine(Folders.ConfigFolder, configFileId));
        }

    }
}
