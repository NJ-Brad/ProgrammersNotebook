// Building a Better ExtractAssociatedIcon
// Bradley Smith - 2010/07/28
// (updated 2014/11/13)

// https://www.brad-smith.info/blog/archives/763

// Additional references (if needed)
// https://stackoverflow.com/questions/49349374/extract-icon-from-dll-with-transparency

// additional notes:
// https://stackoverflow.com/questions/2701263/get-the-icon-for-a-given-extension
// https://stackoverflow.com/questions/3388264/how-can-i-get-file-icon
// https://stackoverflow.com/questions/616718/how-do-i-get-common-file-type-icons-in-c
// https://stackoverflow.com/questions/48846682/how-to-extract-icons-from-an-executable

// Details regarding getting icons
// https://stackoverflow.com/questions/24786234/correct-usage-of-the-extracticonex-niconindex-parameter


using System.Drawing.Imaging;
using System.Runtime.InteropServices;

/// <summary>
/// Defines a set of utility methods for extracting icons for files and file 
/// types.
/// </summary>
public static class IconTools
{

    #region Win32

    /// <summary>
    /// Retrieve the handle to the icon that represents the file and the index 
    /// of the icon within the system image list. The handle is copied to the 
    /// hIcon member of the structure specified by psfi, and the index is 
    /// copied to the iIcon member.
    /// </summary>
    internal const uint SHGFI_ICON = 0x100;
    /// <summary>
    /// Modify SHGFI_ICON, causing the function to retrieve the file's large 
    /// icon. The SHGFI_ICON flag must also be set.
    /// </summary>
    internal const uint SHGFI_LARGEICON = 0x0;
    /// <summary>
    /// Modify SHGFI_ICON, causing the function to retrieve the file's small 
    /// icon. Also used to modify SHGFI_SYSICONINDEX, causing the function to 
    /// return the handle to the system image list that contains small icon 
    /// images. The SHGFI_ICON and/or SHGFI_SYSICONINDEX flag must also be set.
    /// </summary>
    internal const uint SHGFI_SMALLICON = 0x1;
    /// <summary>
    /// Indicates that the function should not attempt to access the file 
    /// specified by pszPath.
    /// </summary>
    const uint SHGFI_USEFILEATTRIBUTES = 0x10;

    /// <summary>
    /// Contains the native Win32 functions.
    /// </summary>
    private class NativeMethods
    {

        /// <summary>
        /// Retrieves information about an object in the file system, such as a file, folder, directory, or drive root.
        /// </summary>
        /// <param name="pszPath">A pointer to a null-terminated string of maximum length MAX_PATH that contains the path and file name. Both absolute and relative paths are valid.</param>
        /// <param name="dwFileAttributes">A combination of one or more file attribute flags (FILE_ATTRIBUTE_ values as defined in Winnt.h).</param>
        /// <param name="psfi">The address of a SHFILEINFO structure to receive the file information.</param>
        /// <param name="cbSizeFileInfo">The size, in bytes, of the SHFILEINFO structure pointed to by the psfi parameter.</param>
        /// <param name="uFlags">The flags that specify the file information to retrieve.</param>
        /// <returns>Nonzero if successful, or zero otherwise.</returns>
        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbSizeFileInfo,
            ShellIconSize uFlags
        );

        /// <summary>
        /// Destroys an icon and frees any memory the icon occupied.
        /// </summary>
        /// <param name="handle">A handle to the icon to be destroyed. The icon must not be in use.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static bool DestroyIcon(IntPtr handle);

        // https://stackoverflow.com/questions/49349374/extract-icon-from-dll-with-transparency
        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);
    }

    /// <summary>
    /// Contains information about a file object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    private struct SHFILEINFO
    {
        /// <summary>
        /// A handle to the icon that represents the file.
        /// </summary>
        public IntPtr hIcon;
        /// <summary>
        /// The index of the icon image within the system image list.
        /// </summary>
        public int iIcon;
        /// <summary>
        /// An array of values that indicates the attributes of the file object.
        /// </summary>
        public uint dwAttributes;
        /// <summary>
        /// A string that contains the name of the file as it appears in the Windows Shell, or the path and file name of the file that contains the icon representing the file.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        /// <summary>
        /// A string that describes the type of file.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };

    #endregion

    /// <summary>
    /// Returns an icon representation of the specified file.
    /// </summary>
    /// <param name="filename">The path to the file.</param>
    /// <param name="size">The desired size of the icon.</param>
    /// <returns>An icon that represents the file.</returns>
    public static Icon GetIconForFile(string filename, ShellIconSize size)
    {
        SHFILEINFO shinfo = new SHFILEINFO();

        //int flags = (uint)size;
        //flags |= 0x000001000;    // SHGFI_ICONLOCATION
        // SHGFI_SELECTED (0x000010000)
        //flags = flags | 0x000000400;    // SHGFI_TYPENAME  (works!!!)  See https://stackoverflow.com/questions/20152273/shgetfileinfo-description-for-a-files-extension-too-short
        //flags |= 0x000000400;    // SHGFI_TYPENAME  (works!!!)  See https://stackoverflow.com/questions/20152273/shgetfileinfo-description-for-a-files-extension-too-short
        //NativeMethods.SHGetFileInfo(filename, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), (ShellIconSize)flags);

        NativeMethods.SHGetFileInfo(filename, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), size);

        //NativeMethods.SHGetFileInfo(filename, 0x80, ref shinfo, (uint)Marshal.SizeOf(shinfo), (ShellIconSize)flags);

        // https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-shgetfileinfoa
        // https://stackoverflow.com/questions/20152273/shgetfileinfo-description-for-a-files-extension-too-short
        // https://social.msdn.microsoft.com/Forums/en-US/60610aff-2dfd-4d52-9c4d-638d514100d0/calling-shgetfileinfo-in-c-win-x64?forum=netfxbcl
        // https://stackoverflow.com/questions/42676256/i-cant-get-shgetfileinfo-to-return-an-icon-location

        Icon icon = null;

        if (shinfo.hIcon.ToInt32() != 0)
        {
            // create the icon from the native handle and make a managed copy of it
            icon = (Icon)Icon.FromHandle(shinfo.hIcon).Clone();

            // release the native handle
            NativeMethods.DestroyIcon(shinfo.hIcon);
        }

        return icon;
    }

    /// <summary>
    /// Returns an icon representation of the specified file.
    /// </summary>
    /// <param name="filename">The path to the file.</param>
    /// <param name="index">The index to the icon, in the file.</param>
    /// <param name="size">The desired size of the icon.</param>
    /// <returns>An icon that represents the file.</returns>
    public static Icon GetIcon(string filename, int index, ShellIconSize size)
    {
        IntPtr large;
        IntPtr small;
        NativeMethods.ExtractIconEx(filename, index, out large, out small, 1);

        IntPtr hIcon = 0;

        switch (size)
        {
            case ShellIconSize.LargeIcon:
                hIcon = large;
                break;
            case ShellIconSize.SmallIcon:
                hIcon = small;
                break;
        }

        Icon icon = null;

        if (hIcon.ToInt32() != 0)
        {
            // create the icon from the native handle and make a managed copy of it
            icon = (Icon)Icon.FromHandle(hIcon).Clone();

            // release the native handle
            NativeMethods.DestroyIcon(large);
            NativeMethods.DestroyIcon(small);
        }

        return icon;
    }

    /// <summary>
    /// Returns the default icon representation for files with the specified extension.
    /// </summary>
    /// <param name="extension">File extension (including the leading period).</param>
    /// <param name="size">The desired size of the icon.</param>
    /// <returns>The default icon for files with the specified extension.</returns>
    public static Icon GetIconForExtension(string extension, ShellIconSize size)
    {
        // repeat the process used for files, but instruct the API not to access the file
        size |= (ShellIconSize)SHGFI_USEFILEATTRIBUTES;
        return GetIconForFile(extension, size);
    }

    /// <summary>
    /// Returns an icon representation of the specified file.
    /// </summary>
    /// <param name="filename">The path to the file.</param>
    /// <param name="index">The index to the icon, in the file.</param>
    /// <param name="size">The desired size of the icon.</param>
    /// <returns>An icon that represents the file.</returns>
    public static Image GetIconForFileAsBitmap(string filename, ShellIconSize size)
    {
        return IconToAlphaBitmap(GetIconForFile(filename, size));
    }

    public static Image GetIconAsBitmap(string filename, int index, ShellIconSize size)
    {
        Icon ico = GetIcon(filename, index, size);

        return (ico == null) ? null : IconToAlphaBitmap(ico);
    }


    /// <summary>
    /// Returns the default icon representation for files with the specified extension.
    /// </summary>
    /// <param name="extension">File extension (including the leading period).</param>
    /// <param name="size">The desired size of the icon.</param>
    /// <returns>The default icon for files with the specified extension.</returns>
    public static Image GetIconForExtensionAsBitmap(string extension, ShellIconSize size)
    {
        // repeat the process used for files, but instruct the API not to access the file
        size |= (ShellIconSize)SHGFI_USEFILEATTRIBUTES;
        return IconToAlphaBitmap(GetIconForExtension(extension, size));
    }


    // https://dotnetrix.co.uk/misc.htm#tip2
    [DllImport("gdi32.dll", SetLastError = true)]
    static extern bool DeleteObject(IntPtr hObject);

    [DllImport("user32.dll")]
    static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO piconinfo);

    public struct ICONINFO
    {
        public bool fIcon;
        public int xHotspot;
        public int yHotspot;
        public IntPtr hbmMask;
        public IntPtr hbmColor;
    }

    public static Bitmap IconToAlphaBitmap(Icon ico)
    {
        ICONINFO ii = new ICONINFO();
        GetIconInfo(ico.Handle, out ii);
        Bitmap bmp = Bitmap.FromHbitmap(ii.hbmColor);
        DeleteObject(ii.hbmColor);
        DeleteObject(ii.hbmMask);

        if (Bitmap.GetPixelFormatSize(bmp.PixelFormat) < 32)
            return ico.ToBitmap();

        BitmapData bmData;
        Rectangle bmBounds = new Rectangle(0, 0, bmp.Width, bmp.Height);

        bmData = bmp.LockBits(bmBounds, ImageLockMode.ReadOnly, bmp.PixelFormat);

        Bitmap dstBitmap = new Bitmap(bmData.Width, bmData.Height, bmData.Stride, PixelFormat.Format32bppArgb, bmData.Scan0);

        bool IsAlphaBitmap = false;

        for (int y = 0; y <= bmData.Height - 1; y++)
        {
            for (int x = 0; x <= bmData.Width - 1; x++)
            {
                Color PixelColor = Color.FromArgb(Marshal.ReadInt32(bmData.Scan0, (bmData.Stride * y) + (4 * x)));
                if (PixelColor.A > 0 & PixelColor.A < 255)
                {
                    IsAlphaBitmap = true;
                    break;
                }
            }
            if (IsAlphaBitmap) break;
        }

        bmp.UnlockBits(bmData);

        if (IsAlphaBitmap == true)
            return new Bitmap(dstBitmap);
        else
            return new Bitmap(ico.ToBitmap());

    }

}

/// <summary>
/// Represents the different icon sizes that can be extracted using the 
/// <see cref="IconTools.ExtractAssociatedIcon"/> method.
/// </summary>
public enum ShellIconSize : uint
{

    /// <summary>
    /// Specifies a small (16x16) icon.
    /// </summary>
    SmallIcon = IconTools.SHGFI_ICON | IconTools.SHGFI_SMALLICON,
    /// <summary>
    /// Specifies a large (32x32) icon.
    /// </summary>
    LargeIcon = IconTools.SHGFI_ICON | IconTools.SHGFI_LARGEICON
}