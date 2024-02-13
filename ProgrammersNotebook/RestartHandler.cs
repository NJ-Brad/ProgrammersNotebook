namespace ProgrammersNotebook
{
    public class RestartHandler
    {
        public RestartHandler() { restartRequired = false; }

        private bool restartRequired = false;
        public void Set(bool restartNow = false)
        {
            restartRequired = true;
            if (restartNow)
            {
                Application.Exit();
            }
        }
        public void Clear() { restartRequired = false; }
        public void RestartIfRequired()
        {
            if (restartRequired)
                Application.Restart();
        }
        public void ExitIfRequired()
        {
            if (restartRequired)
                Application.Exit();
        }
    }
}
