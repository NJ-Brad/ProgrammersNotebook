namespace ProgrammersNotebook
{
    public class ImageTree : TreeView
    {
        public ImageTree()
        {
            LargeImages.ImageSize = new Size(32, 32);
            // this is a folder
            SmallImages.Images.Add(IconTools.GetIconAsBitmap(Environment.ExpandEnvironmentVariables("%SystemRoot%\\System32\\SHELL32.dll"), 4, ShellIconSize.SmallIcon));
            LargeImages.Images.Add(IconTools.GetIconAsBitmap(Environment.ExpandEnvironmentVariables("%SystemRoot%\\System32\\SHELL32.dll"), 4, ShellIconSize.LargeIcon));
        }

        // Disable tooltips that automatically show up, when a node's text is too long for the control client area
        // https://stackoverflow.com/questions/1199564/sub-classing-treeview-in-winforms-for-mouse-over-tool-tips
        //private const int TVS_NOTOOLTIPS = 0x80;

        //protected override System.Windows.Forms.CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams p = base.CreateParams;
        //        p.Style = p.Style | TVS_NOTOOLTIPS;
        //        return p;
        //    }
        //}


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //// https://stackoverflow.com/questions/559707/windows-forms-tooltip-will-not-re-appear-after-first-use
        //// https://ux.stackexchange.com/questions/3931/tooltips-with-infinite-timeout#2438612
        //// https://stackoverflow.com/questions/1201004/winforms-why-does-my-tooltip-never-come-back?rq=4
        //// https://stackoverflow.com/questions/19161786/winforms-treeview-node-tooltip-customization
        //// https://stackoverflow.com/questions/2655080/how-to-make-tooltip-move-with-mouse-winforms

        //static int CW = Cursors.Default.Size.Width / 2;
        //static int CH = Cursors.Default.Size.Height / 2;
        //ToolTip toolTip1 = new ToolTip();
        //string prevToolTipText = string.Empty;
        //bool toolTipShownOnce = false;

        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);

        //    TreeViewHitTestInfo hti = HitTest(e.X, e.Y);

        //    switch (hti.Location)
        //    {
        //        case TreeViewHitTestLocations.Label:
        //        case TreeViewHitTestLocations.Indent:
        //        case TreeViewHitTestLocations.Image:
        //        case TreeViewHitTestLocations.StateImage:
        //        case TreeViewHitTestLocations.PlusMinus:
        //        case TreeViewHitTestLocations.RightOfLabel:
        //            //vis.OverNode = true;
        //            //vis.NodeText = hti.Node.Text;
        //            //vis.ToolTipText = hti.Node.ToolTipText;
        //            string newText = GetInfoTip(hti.Node);
        //            //if ((newText != prevToolTipText) || !toolTipShownOnce)
        //            {
        //                toolTipShownOnce = true; ;
        //                prevToolTipText = newText;
        //                toolTip1.Show(newText, this, new Point(e.X + CW, e.Y + CH));
        //            }
        //            break;
        //        default:
        //            //vis.OverNode = false;
        //            //vis.NodeText = string.Empty;
        //            //vis.ToolTipText = string.Empty;
        //            toolTip1.Hide(this);
        //            prevToolTipText = string.Empty;
        //            break;
        //    }
        //}

        //protected string GetInfoTip(TreeNode node)
        //{
        //    string rtnVal = node.ToolTipText;

        //    if (InfoTipRequested != null)
        //    {
        //        InfoTipEventArgs args = new InfoTipEventArgs();
        //        args.Node = node;
        //        InfoTipRequested?.Invoke(this, args);

        //        rtnVal = args.ToolTipText;
        //    }

        //    return rtnVal;
        //}

        //public event EventHandler<InfoTipEventArgs> InfoTipRequested;

        //public class InfoTipEventArgs
        //{
        //    public TreeNode Node { get; set; }
        //    public string ToolTipText { get; set; }
        //}

        //protected override void OnMouseLeave(EventArgs e)
        //{
        //    base.OnMouseLeave(e);
        //    toolTip1.Hide(this);
        //    prevToolTipText = string.Empty;
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);

            ImageList = LargeImages;
        }

        ImageList SmallImages { get; set; } = new();
        ImageList LargeImages { get; set; } = new();

        public void SelectImages(ShellIconSize IconSize)
        {
            switch (IconSize)
            {
                case ShellIconSize.SmallIcon:
                    ImageList = SmallImages;
                    break;
                case ShellIconSize.LargeIcon:
                    ImageList = LargeImages;
                    break;
            }
        }

        public int AddImage(Image smallImage, Image largeImage)
        {
            SmallImages.Images.Add(smallImage);
            LargeImages.Images.Add(largeImage);

            return LargeImages.Images.Count - 1;
        }

        public int AddImage(string path, int index, string extension)
        {
            Image img = null;
            Image smallImg = null;

            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    img = IconTools.GetIconAsBitmap(path, index, ShellIconSize.LargeIcon);
                    smallImg = IconTools.GetIconAsBitmap(path, index, ShellIconSize.SmallIcon);
                }
                catch { }
            }
            if (img == null)
            {
                img = IconTools.GetIconForExtensionAsBitmap(extension, ShellIconSize.LargeIcon);
                smallImg = IconTools.GetIconForExtensionAsBitmap(extension, ShellIconSize.SmallIcon);
            }

            if (img == null)
            {
                // "last resort" default icon
                img = IconTools.GetIconAsBitmap(Environment.ExpandEnvironmentVariables("%SystemRoot%\\System32\\SHELL32.dll"), 0, ShellIconSize.LargeIcon);
                smallImg = IconTools.GetIconAsBitmap(Environment.ExpandEnvironmentVariables("%SystemRoot%\\System32\\SHELL32.dll"), 0, ShellIconSize.SmallIcon);
            }

            return AddImage(smallImg, img);
        }


        public string AddKeyedImage(string key, Image smallImage, Image largeImage)
        {
            if (!SmallImages.Images.ContainsKey(key))
            {
                SmallImages.Images.Add(key, smallImage);
                LargeImages.Images.Add(key, largeImage);
            }

            return key;
        }

        public string AddKeyedImage(string path, int index, string extension)
        {
            Image img = null;
            Image smallImg = null;
            string key = string.Empty;

            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    img = IconTools.GetIconAsBitmap(path, index, ShellIconSize.LargeIcon);
                    smallImg = IconTools.GetIconAsBitmap(path, index, ShellIconSize.SmallIcon);
                    key = $"{path}:{index}";
                }
                catch { }
            }
            if (img == null)
            {
                img = IconTools.GetIconForExtensionAsBitmap(extension, ShellIconSize.LargeIcon);
                smallImg = IconTools.GetIconForExtensionAsBitmap(extension, ShellIconSize.SmallIcon);
                key = $"{extension}";
            }

            if (img == null)
            {
                // "last resort" default icon
                img = IconTools.GetIconAsBitmap(Environment.ExpandEnvironmentVariables("%SystemRoot%\\System32\\SHELL32.dll"), 0, ShellIconSize.LargeIcon);
                smallImg = IconTools.GetIconAsBitmap(Environment.ExpandEnvironmentVariables("%SystemRoot%\\System32\\SHELL32.dll"), 0, ShellIconSize.SmallIcon);
                key = $"default";
            }

            return AddKeyedImage(key, smallImg, img);
        }


        // https://stackoverflow.com/questions/7578857/how-to-check-whether-a-string-is-a-valid-http-url
        public static bool IsValidUrl(string webSiteUrl)
        {
            if (string.IsNullOrEmpty(webSiteUrl))
                return false;

            if (webSiteUrl.StartsWith("www."))
            {
                webSiteUrl = "http://" + webSiteUrl;
            }

            return Uri.TryCreate(webSiteUrl, UriKind.Absolute, out Uri uriResult)
                     && (uriResult.Scheme == Uri.UriSchemeHttp
                      || uriResult.Scheme == Uri.UriSchemeHttps) && uriResult.Host.Replace("www.", "").Split('.').Count() > 1 && uriResult.HostNameType == UriHostNameType.Dns && uriResult.Host.Length > uriResult.Host.LastIndexOf(".") + 1 && 100 >= webSiteUrl.Length;
        }

        //public int ReplaceImage(int imageIndex, Image smallImage, Image largeImage)
        //{
        //    var v = SmallImages.Images[imageIndex] ;
        //    LargeImages.Images.RemoveAt(imageIndex);

        //    SmallImages.Images.Add(smallImage);
        //    LargeImages.Images.Add(largeImage);

        //    return LargeImages.Images.Count - 1;
        //}

        //public int ReplaceImage(int imageIndex, string path, int index, string extension)
        //{
        //    Image img = null;
        //    Image smallImg = null;

        //    if (!string.IsNullOrEmpty(path))
        //    {
        //        try
        //        {
        //            img = IconTools.GetIconAsBitmap(path, index, ShellIconSize.LargeIcon);
        //            smallImg = IconTools.GetIconAsBitmap(path, index, ShellIconSize.SmallIcon);
        //        }
        //        catch { }
        //    }
        //    if (img == null)
        //    {
        //        img = IconTools.GetIconForExtensionAsBitmap(extension, ShellIconSize.LargeIcon);
        //        smallImg = IconTools.GetIconForExtensionAsBitmap(extension, ShellIconSize.SmallIcon);

        //        if (img == null)
        //        {
        //            // "last resort" default icon
        //            img = IconTools.GetIconAsBitmap(Environment.ExpandEnvironmentVariables("%SystemRoot%\\System32\\SHELL32.dll"), 0, ShellIconSize.LargeIcon);
        //            smallImg = IconTools.GetIconAsBitmap(Environment.ExpandEnvironmentVariables("%SystemRoot%\\System32\\SHELL32.dll"), 0, ShellIconSize.SmallIcon);
        //        }
        //    }

        //    return ReplaceImage(imageIndex, smallImg, img);
        //}

        //System.Windows.Forms.Timer dirtyTimer = new();
        //TreeNode dirtyNode = null;

        //public void SetDirty(TreeNode node)
        //{
        //    dirtyNode = node;
        //    dirtyTimer = new System.Windows.Forms.Timer();
        //    dirtyTimer.Tick += DirtyTimer_Tick;
        //    dirtyTimer.Interval = 100;
        //    dirtyTimer.Start();
        //}

        //private void DirtyTimer_Tick(object? sender, EventArgs e)
        //{
        //    //            Refresh();
        //    dirtyTimer.Stop();
        //    dirtyTimer = null;
        //    //Invalidate();
        //    //Update();

        //    if (dirtyNode != null)
        //    {
        //        TreeNode current = this.SelectedNode;
        //        this.SelectedNode = dirtyNode;
        //        Application.DoEvents();
        //        Refresh();
        //        //this.SelectedNode = current;
        //    }
        //}
    }

    internal class IconSource
    {
        public string Path { get; set; } = "";
        public int Index { get; set; }
        public string Extension { get; set; } = "";

        public Image GetImage(bool large)
        {
            Image img = null;
            if (!string.IsNullOrEmpty(Path))
            {
                try
                {
                    img = IconTools.GetIconAsBitmap(Path, Index, ShellIconSize.LargeIcon);
                }
                catch { }
            }
            if (img == null)
            {
                img = IconTools.GetIconForExtensionAsBitmap(Extension, ShellIconSize.LargeIcon);
                //IntPtr hIcon = Icon.ExtractAssociatedIcon("C:\\Users\\Brad\\Downloads\\Lean In A Nutshell.pdf").Handle;

                // directories don't have associated icons
                //IntPtr hIcon = Icon.ExtractAssociatedIcon("C:\\Users\\Brad\\Downloads").Handle;

                //IconExtractor.IconToAlphaBitmap(Icon.FromHandle(large ? large : small));

                if (img == null)
                    // "last resort" default icon
                    img = IconTools.GetIconAsBitmap(Environment.ExpandEnvironmentVariables("%SystemRoot%\\System32\\SHELL32.dll"), 0, ShellIconSize.LargeIcon);
            }
            return img;
        }

        //IntPtr hIcon = Icon.ExtractAssociatedIcon("C:\\Users\\Brad\\Downloads\\Lean In A Nutshell.pdf").Handle;

        //// directories don't have associated icons
        ////IntPtr hIcon = Icon.ExtractAssociatedIcon("C:\\Users\\Brad\\Downloads").Handle;

        ////IconExtractor.IconToAlphaBitmap(Icon.FromHandle(largeIcon ? large : small));
        //pictureBox1.Image = IconExtractor.IconToAlphaBitmap(Icon.FromHandle(hIcon));

    }
}
