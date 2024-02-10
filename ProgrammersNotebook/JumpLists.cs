//using Avalonia;
using System.Text;
using WinForms.JumpLists.JumpLists;
#if NETFRAMEWORK
using System.Windows.Shell;
using JumpList = Avalonia.Win32.JumpLists.JumpList;
#endif

namespace ProgrammersNotebook;

public static class JumpLists
{
    public static JumpList Init()
    {
        // https://docs.microsoft.com/zh-cn/dotnet/api/system.windows.shell.jumplist?view=net-5.0
        var jumpList1 = new JumpList();

        jumpList1.JumpItemsRejected += JumpList1_JumpItemsRejected;
        jumpList1.JumpItemsRemovedByUser += JumpList1_JumpItemsRemovedByUser;
        JumpList.SetJumpList(System.Diagnostics.Process.GetCurrentProcess().Id.ToString(), jumpList1);

        return jumpList1;
    }



    //public static JumpList Init()
    //{
    //    // https://docs.microsoft.com/zh-cn/dotnet/api/system.windows.shell.jumplist?view=net-5.0
    //    var jumpList1 = new JumpList
    //    {
    //        ShowRecentCategory = true,
    //        ShowFrequentCategory = true,
    //    };
    //    jumpList1.JumpItemsRejected += JumpList1_JumpItemsRejected;
    //    jumpList1.JumpItemsRemovedByUser += JumpList1_JumpItemsRemovedByUser;
    //    jumpList1.JumpItems.Add(new JumpTask
    //    {
    //        Title = "Notepad",
    //        Description = "Open Notepad.",
    //        ApplicationPath = @"C:\Windows\notepad.exe",
    //        IconResourcePath = @"C:\Windows\notepad.exe",
    //    });
    //    jumpList1.JumpItems.Add(new JumpTask
    //    {
    //        Title = "Read Me",
    //        Description = "Open readme.txt in Notepad.",
    //        ApplicationPath = @"C:\Windows\notepad.exe",
    //        IconResourcePath = @"C:\Windows\System32\imageres.dll",
    //        IconResourceIndex = 14,
    //        WorkingDirectory = @"C:\Users\Public\Documents",
    //        Arguments = "readme.txt",
    //    });
    //    //JumpList.SetJumpList(Application.Current!, jumpList1);
    //    JumpList.SetJumpList(System.Diagnostics.Process.GetCurrentProcess().Id.ToString(), jumpList1);

    //    return jumpList1;
    //}

    public static void AddAppkicationTask(string categoryText, string displayText, string description, string taskParameters)
    {
        var jumpList1 = GetJumpList();

        jumpList1.JumpItems.Add(new JumpTask
        {
            CustomCategory = categoryText,
            Title = displayText,
            Description = description,
            Arguments = taskParameters
            //,
            //WorkingDirectory = Path.GetDirectoryName(JumpListHandler.AppName)
        });

        JumpList.SetJumpList(System.Diagnostics.Process.GetCurrentProcess().Id.ToString(), jumpList1);
    }


    public static void Clear()
    {
        // https://docs.microsoft.com/zh-cn/dotnet/api/system.windows.shell.jumplist?view=net-5.0
        var jumpList1 = GetJumpList();

        while (jumpList1.JumpItems.Count > 0)
        {
            jumpList1.JumpItems.RemoveAt(0);
        }
        JumpList.SetJumpList(System.Diagnostics.Process.GetCurrentProcess().Id.ToString(), jumpList1);
    }

    public static void AddToRecent(string fileName)
    {
        var jumpList1 = GetJumpList();
        JumpList.AddToRecentCategory(fileName);
    }

    public static void AddToRecent2(string fileName)
    {
        var jumpList1 = GetJumpList();

        if (File.Exists(fileName))
        {
            //jumpList1.JumpItems.Add(new JumpPath
            //{
            //    CustomCategory = "Recent",
            //    Path = Path.GetFullPath(fileName)
            //});

            jumpList1.JumpItems.Add(new JumpTask
            {
                CustomCategory = "Recent",
                Title = Path.GetFileName(fileName),
                Description = fileName,
                Arguments = Path.GetFullPath(fileName)
            });
        }
        JumpList.SetJumpList(System.Diagnostics.Process.GetCurrentProcess().Id.ToString(), jumpList1);
    }

    public static JumpList GetJumpList()
    {
        JumpList rtnVal = JumpList.GetJumpList(System.Diagnostics.Process.GetCurrentProcess().Id.ToString());
        if (rtnVal == null)
        {
            rtnVal = Init();
        }
        return rtnVal;
    }

    static void JumpList1_JumpItemsRejected(object? sender, JumpItemsRejectedEventArgs e)
    {
        StringBuilder sb = new();
        sb.AppendFormat("{0} Jump Items Rejected:\n", e.RejectionReasons.Count);
        for (int i = 0; i < e.RejectionReasons.Count; ++i)
        {
            if (e.RejectedItems[i].GetType() == typeof(JumpPath))
                sb.AppendFormat("Reason: {0}\tItem: {1}\n", e.RejectionReasons[i], ((JumpPath)e.RejectedItems[i]).Path);
            else
                sb.AppendFormat("Reason: {0}\tItem: {1}\n", e.RejectionReasons[i], ((JumpTask)e.RejectedItems[i]).ApplicationPath);
        }

        //MessageBoxShow(sb.ToString());
        MessageBox.Show(sb.ToString());
    }

    static void JumpList1_JumpItemsRemovedByUser(object? sender, JumpItemsRemovedEventArgs e)
    {
        StringBuilder sb = new();
        sb.AppendFormat("{0} Jump Items Removed by the user:\n", e.RemovedItems.Count);
        for (int i = 0; i < e.RemovedItems.Count; ++i)
        {
            sb.AppendFormat("{0}\n", e.RemovedItems[i]);
        }

        //MessageBoxShow(sb.ToString());
        MessageBox.Show(sb.ToString());
    }
}