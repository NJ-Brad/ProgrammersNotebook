using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace WinForms.JumpLists
{
    public class JumpListHandler
    {
        public static bool Process()
        {
            bool firstInstance = false;

            // some Mutex notes : https://stackoverflow.com/questions/6486195/ensuring-only-one-application-instance

            Mutex mtx = new Mutex(true, MutexName, out firstInstance);

            if (!firstInstance)
            {
                string[] args = Environment.GetCommandLineArgs();
                if (args.Length > 1)
                {
                    IntPtr val = GlobalAddAtom(args[1]);

                    PostMessage(HWND_BROADCAST, MessageId, val, IntPtr.Zero);
                }
                //else
                //{
                //    MessageBox.Show("Nothing passed - application already running - start not necessary");
                //}
            }
            //else
            //{
            //    MessageBox.Show("First Instance");
            //}

            return !firstInstance;
        }

        public static string AppName
        {
            get
            {
                //    Assembly assembly = Assembly.GetEntryAssembly();     // this points to the .dll instead of the .exe (Welcome to Core)
                return Environment.GetCommandLineArgs()[0];
            }
        }

        private static string MutexName
        {
            get
            {
                Assembly assembly = Assembly.GetEntryAssembly();     // this points to the .dll instead of the .exe (Welcome to Core)
                return assembly.ManifestModule.ModuleVersionId.ToString();
            }
        }

        private static string MessageName
        {
            get
            {
                Assembly assembly = Assembly.GetEntryAssembly();     // this points to the .dll instead of the .exe (Welcome to Core)
                return ($"JUMPLIST_EVENT:{assembly.ManifestModule.ModuleVersionId.ToString()}");
            }
        }

        [DllImport("user32.dll")]
        public static extern int RegisterWindowMessage(string msgName);

        //https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-postmessagea?redirectedfrom=MSDN
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int PostMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        const int HWND_BROADCAST = 0xffff;

        // http://www.pinvoke.net/default.aspx/kernel32/GlobalAddAtom.html
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern ushort GlobalAddAtom(string lpString);

        // http://groups.google.com/group/microsoft.public.dotnet.languages.csharp/browse_thread/thread/9e30918747b7c242/4e7f635a000ff6fa?hl=en&lnk=st&q=GlobalGetAtomName+c%23#4e7f635a000ff6fa
        [DllImport("kernel32.dll", SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall,
            EntryPoint = "GlobalGetAtomNameW")]
        public static extern int GlobalGetAtomName(ushort nAtom, StringBuilder lpBuffer, int nSize);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern ushort GlobalDeleteAtom(ushort nAtom);

        public static string GetAtomValue(uint atom)
        {
            string rtnVal = "";

            StringBuilder stringVal = new StringBuilder(1024);
            int val = GlobalGetAtomName((ushort)atom, stringVal, stringVal.Capacity);
            GlobalDeleteAtom((ushort)atom);

            return stringVal.ToString();
        }


        public static int MessageId
        {
            get
            {
                return RegisterWindowMessage(MessageName);
            }
        }

        /*
        // startup location
        Assembly.GetEntryAssembly Method - https://learn.microsoft.com/en-us/dotnet/api/system.reflection.assembly.getentryassembly

        // current location (could be the library, instead of the application)
        Assembly.GetExecutingAssembly Method - https://learn.microsoft.com/en-us/dotnet/api/system.reflection.assembly.getexecutingassembly 

        // https://stackoverflow.com/questions/15407340/difference-between-assembly-getexecutingassembly-and-typeofprogram-assembly
        If you control all the code I think you should always use typeof(program).Assembly. If you provided source code that other people could build into their assemblies, you would need to use Assembly.GetExecutingAssembly().

        // https://stackoverflow.com/questions/27059748/which-is-better-for-getting-assembly-location-getassembly-location-or-getexe

        // https://stackoverflow.com/questions/1222190/what-is-the-best-way-to-get-the-executing-exes-path-in-net

        // https://github.com/dotnet/corert/issues/6947

        // ****************************************
        // https://github.com/dotnet/runtime/discussions/61000
        // ****************************************

        // https://www.codeproject.com/Questions/334267/How-do-I-do-Unit-Testing-with-System-Reflection-As

        */
    }
}
