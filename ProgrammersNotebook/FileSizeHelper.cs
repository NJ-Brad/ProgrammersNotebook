namespace ProgrammersNotebook
{

    // https://sebnilsson.com/blog/create-human-readable-file-size-strings-in-c/
    public static class FileSizeHelper
    {
        private static readonly string[] Units = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static string GetReadableFileSize(long size) // Size in bytes
        {
            int unitIndex = 0;
            while (size >= 1024)
            {
                size /= 1024;
                ++unitIndex;
            }

            string unit = Units[unitIndex];
            return string.Format("{0:0.#} {1}", size, unit);
        }
    }
}
