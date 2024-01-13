using System.Text.RegularExpressions;

namespace RegexTest2
{
    internal static partial class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //            Application.Run(new Form1());

            bool matches = false;
            matches = Test("[embeddedimage:NJ-Brad]");
        }

        public static bool Test(string testValue)
        {
            var regex = EmbeddedImageTagRegex();
            var match = regex.Match(testValue);

            if (!match.Success)
            {
                return false;
            }

            var username = match.Groups["username"].Value;
            var literal = $"<a href=\"https://github.com/{username}\"/>{username}</a>";

            return true;
        }

        //        [GeneratedRegex(@"\[embeddedimage:(?<username>\w+)]")]

        [GeneratedRegex(@"\[embeddedimage:(?<username>[a-zA-Z0-9_-]+)]")]
        private static partial Regex EmbeddedImageTagRegex();

    }
}
