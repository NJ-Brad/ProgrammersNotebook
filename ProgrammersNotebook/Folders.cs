using System.Runtime.InteropServices;

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

        // https://ourcodeworld.com/articles/read/1447/how-to-retrieve-the-downloads-directory-path-in-winforms-c-sharp

        //  THERE ARE ISSUES WITH THE ABOVE (IT'S WHAT IS IMPLEMENTEE BELOW, FOR NOW)
        // More information
        // https://www.codeproject.com/articles/878605/getting-all-special-folders-in-net
        // OR, IT MAY BE GOOD
        // https://stackoverflow.com/questions/10667012/getting-downloads-folder-in-c


        // 1. Import InteropServices
        //using System.Runtime.InteropServices;

        /// 2. Declare DownloadsFolder KNOWNFOLDERID
        private static Guid FolderDownloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");

        /// 3. Import SHGetKnownFolderPath method
        /// <summary>
        /// Retrieves the full path of a known folder identified by the folder's KnownFolderID.
        /// </summary>
        /// <param name="id">A KnownFolderID that identifies the folder.</param>
        /// <param name="flags">Flags that specify special retrieval options. This value can be
        ///     0; otherwise, one or more of the KnownFolderFlag values.</param>
        /// <param name="token">An access token that represents a particular user. If this
        ///     parameter is NULL, which is the most common usage, the function requests the known
        ///     folder for the current user. Assigning a value of -1 indicates the Default User.
        ///     The default user profile is duplicated when any new user account is created.
        ///     Note that access to the Default User folders requires administrator privileges.
        ///     </param>
        /// <param name="path">When this method returns, contains the address of a string that
        ///     specifies the path of the known folder. The returned path does not include a
        ///     trailing backslash.</param>
        /// <returns>Returns S_OK if successful, or an error value otherwise.</returns>
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetKnownFolderPath(ref Guid id, int flags, IntPtr token, out IntPtr path);

        /// 4. Declare method that returns the Downloads Path as string
        /// <summary>
        /// Returns the absolute downloads directory specified on the system.
        /// </summary>
        /// <returns></returns>
        //public static string GetDownloadsPath()
        //{
        //    if (Environment.OSVersion.Version.Major < 6) throw new NotSupportedException();

        //    IntPtr pathPtr = IntPtr.Zero;

        //    try
        //    {
        //        SHGetKnownFolderPath(ref FolderDownloads, 0, IntPtr.Zero, out pathPtr);
        //        return Marshal.PtrToStringUni(pathPtr);
        //    }
        //    finally
        //    {
        //        Marshal.FreeCoTaskMem(pathPtr);
        //    }
        //}

        internal static string DownloadsFolder
        {
            get
            {
                if (Environment.OSVersion.Version.Major < 6) throw new NotSupportedException();

                IntPtr pathPtr = IntPtr.Zero;

                try
                {
                    SHGetKnownFolderPath(ref FolderDownloads, 0, IntPtr.Zero, out pathPtr);
                    return Marshal.PtrToStringUni(pathPtr);
                }
                finally
                {
                    Marshal.FreeCoTaskMem(pathPtr);
                }
            }
        }

        /// 5. Display the downloads directory in the console
        // prints something like: C:\Users\username\Downloads
        //Console.WriteLine(GetDownloadsPath());
    }
}
