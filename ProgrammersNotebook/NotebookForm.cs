// split buttion, if necessary - https://wyday.com/splitbutton/

using MarkDownHelper;
using System.Diagnostics;

namespace ProgrammersNotebook
{
    public partial class NotebookForm : Form
    {
        private List<Page> pages = new();
        private List<TreePage> treePages = new();
        private Page? selectedPage = null;

        public NotebookForm()
        {
            InitializeComponent();

            if (Replacements.ContainsKey("LOCATION"))
            {
                Replacements["LOCATION"] = "notebook://";
            }
            else
            {
                Replacements.Add("LOCATION", "notebook://");
            }
        }

        PNContext context = new PNContext();

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            imageTree1.Font = Font;
            imageTree1.ShowRootLines = false;
            imageTree1.SelectImages(ShellIconSize.SmallIcon);

            // this loads everything, including page content
            //pages = context.Pages.ToList();
            //imageTree1.Nodes.Clear();
            //AddToTree(imageTree1.Nodes, pages);

            // this leaves out the content - need to query that only if editing
            // https://www.brentozar.com/archive/2016/09/select-specific-columns-entity-framework-query/
            treePages = context.Pages
                .Select(p => new TreePage()
                {
                    Id = p.Id,
                    Name = p.Name,
                    DocumentType = p.DocumentType,
                    Pages = p.Pages
                })
                .ToList();

            imageTree1.Nodes.Clear();
            AddToTree(imageTree1.Nodes, treePages);

            // work with this.  remembering the format may become an issue
            markDownEditor1.ProtocolHandlers.Add(new CustomProtocolHandler { Prefix = "notebook://*", Handler = ResolveProtocolRequest });

            markDownEditor1.EmbeddedFragmentHandler = ResolveEmbeddedFragmentRequest;
            markDownEditor1.Replacements = Replacements;
        }

        Fragments frMgr = null;


        public void ResolveEmbeddedFragmentRequest(object sender, EmbeddedFragmentEventArgs e)
        {
            if (frMgr == null)
                frMgr = new Fragments(context);

            if (e.Operation == "GET")
            {
                PageFragment fragment = frMgr.GetFragment(e.Key);

                // e.Value = fragment.Content;
                e.Value = fragment;
            }
            if (e.Operation == "LIST_TEXT_BLOCKS")
            {
                e.Names = frMgr.GetFragmentList(false);
            }
            if (e.Operation == "LIST_IMAGE_BLOCKS")
            {
                e.Names = frMgr.GetFragmentList(true);
            }
            if (e.Operation == "SAVE")
            {
                frMgr.SaveFragment(e.Value);
            }
        }

        public void ResolveProtocolRequest(object sender, CustomProtocolEventArgs e)
        {
            PageFragment fragment = GetFragment(e.Requested);

            // https://stackoverflow.com/questions/31524343/how-to-convert-base64-value-from-a-database-to-a-stream-with-c-sharp
            string base64encodedstring = fragment.Content;
            try
            {
                var bytes = Convert.FromBase64String(base64encodedstring);

                if (!string.IsNullOrEmpty(exportFolder))
                {
                    string fileName = Path.Combine(exportFolder, fragment.Name);
                    if (fragment.FragmentType == "Text")
                    {
                        fileName = Path.ChangeExtension(fileName, "txt");
                    }
                    else
                    {
                        fileName = Path.ChangeExtension(fileName, "jpg");
                    }

                    if (!File.Exists(fileName))
                    {
                        // create new replacement here
                        System.Diagnostics.Debug.WriteLine(fileName);
                        File.WriteAllBytes(fileName, bytes);
                    }
                }

                e.ReturnData = new MemoryStream(bytes);
                e.Found = true;
                //e.Headers.Add("Content-Type: image/jpeg");
                e.Headers.Add($"Content-Type: {fragment.FragmentType}");
            }
            catch
            {
                e.Found = false;
                return;
            }

        }

        private PageFragment GetFragment(string key)
        {
            Fragments fragMgr = new Fragments(context);
            return fragMgr.GetFragment(key);
        }

        private async void SaveChanges()
        {
            context.SaveChanges();
        }

        private async void AddToTree(TreeNodeCollection coll, List<Page> pageList)
        {
            foreach (Page pg in pageList)
            {
                TreeNode tn = coll.Add(pg.Name);
                tn.Tag = pg;
                if (pg.DocumentType != "Folder")
                {
                    tn.ImageKey = tn.SelectedImageKey = imageTree1.AddKeyedImage(string.Empty, 0, "md");
                    tn.ToolTipText = null;
                }
                if (pg.DocumentType == "Folder")
                {
                    tn.ImageIndex = 0;
                    tn.SelectedImageIndex = tn.ImageIndex;
                    AddToTree(tn.Nodes, pg.Pages);
                }
            }
        }

        private async void AddToTree(TreeNodeCollection coll, List<TreePage> pageList)
        {
            foreach (TreePage pg in pageList)
            {
                TreeNode tn = coll.Add(pg.Name);
                tn.Tag = pg;
                if (pg.DocumentType != "Folder")
                {
                    tn.ImageKey = tn.SelectedImageKey = imageTree1.AddKeyedImage(string.Empty, 0, "md");
                    tn.ToolTipText = null;
                }
                if (pg.DocumentType == "Folder")
                {
                    tn.ImageIndex = 0;
                    tn.SelectedImageIndex = tn.ImageIndex;
                    AddToTree(tn.Nodes, pg.Pages);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void AddDocument(Page pd)
        {
            TreeNodeCollection coll = imageTree1.Nodes;
            //List<Page> pageList = pages;

            //if (imageTree1.SelectedNode != null)
            //{
            //    if ((imageTree1.SelectedNode.Tag as Page).DocumentType != "Folder")
            //    {
            //        if ((imageTree1.SelectedNode.Parent != null))
            //        {
            //            coll = imageTree1.SelectedNode.Parent.Nodes;
            //            pageList = (imageTree1.SelectedNode.Parent.Tag as Page).Pages;
            //        }
            //    }
            //    else
            //    {
            //        // as child - under selected folder
            //        coll = imageTree1.SelectedNode.Nodes;
            //        pageList = (imageTree1.SelectedNode.Tag as Page).Pages;
            //    }
            //}

            //int index = coll.IndexOf(imageTree1.SelectedNode);

            //TreeNode tn = coll.Insert(index + 1, pd.Name);

            //if (pd.DocumentType == "Folder")
            //{
            //    tn.ImageIndex = 0;
            //}
            //else
            //{
            //    tn.ImageKey = imageTree1.AddKeyedImage(string.Empty, 0, "md");
            //}
            //tn.SelectedImageKey = tn.ImageKey;

            //tn.Tag = pd;
            //pageList.Insert(index + 1, pd);

            TreeNode tn = coll.Add(pd.Name);

            if (pd.DocumentType == "Folder")
            {
                tn.ImageIndex = 0;
            }
            else
            {
                tn.ImageKey = imageTree1.AddKeyedImage(string.Empty, 0, "md");
            }
            tn.SelectedImageKey = tn.ImageKey;

            tn.Tag = new TreePage()
            {
                Id = pd.Id,
                Name = pd.Name,
                DocumentType = pd.DocumentType,
                Pages = pd.Pages
            };

            context.Add(pd);
            SaveChanges();
            selectedPage = pd;
            imageTree1.SelectedNode = tn;
        }

        public Dictionary<string, string> Replacements = new();

        private void imageTree1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreePage pd = e.Node.Tag as TreePage;

            markDownEditor1.Enabled = (pd != null);

            selectedPage = null;
            if ((pd != null) && (pd.DocumentType != "Folder"))
            {
                selectedPage = context.Pages.Where(p => p.Id == pd.Id).FirstOrDefault();
            }

            if (selectedPage == null)
            {
                selectedPage = new();
            }

            markDownEditor1.DocumentText = selectedPage.PageContent;

            markDownEditor1.ViewMode = true;
            markDownEditor1.Enabled = true;
        }

        private void imageTree1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeViewHitTestInfo hti = imageTree1.HitTest(e.X, e.Y);
                imageTree1.SelectedNode = hti.Node;
            }
        }

        private void imageTree1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (selectedPage == null)
                return;

            //Page pd = e.Node.Tag as Page;
            Page pd = selectedPage;
            if ((pd != null) && (!string.IsNullOrEmpty(e.Label)))
            {
                pd.Name = e.Label;
                e.Node.Text = pd.Name;
            }
            SaveChanges();
        }

        private void documentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Page pg = new Page { DocumentType = "Page", Name = "New Page" };
            AddDocument(pg);
        }

        private async void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Page pg = new Page { DocumentType = "Folder", Name = "New Folder" };
            AddDocument(pg);
        }

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            Page pd = new();
            TreeNodeCollection coll = imageTree1.Nodes;
            List<Page> pageList = pages;

            if ((imageTree1.SelectedNode != null) && ((imageTree1.SelectedNode.Parent != null)))
            {
                coll = imageTree1.SelectedNode.Parent.Nodes;
                pageList = (imageTree1.SelectedNode.Parent.Tag as Page).Pages;
            }

            int index = coll.IndexOf(imageTree1.SelectedNode);

            context.Remove(selectedPage);
            context.SaveChanges();

            coll.RemoveAt(index);
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            Page pg = new Page { DocumentType = "Page", Name = "New Page", PageContent = "New Page" };
            AddDocument(pg);
        }

        private void markDownEditor1_SaveClicked(object sender, EventArgs e)
        {
            Page pg = context.Pages.Where(p => p.Id == selectedPage.Id).FirstOrDefault();
            if (pg == null)
            {
                context.Add(selectedPage);
            }
            else
            {
                pg.PageContent = markDownEditor1.DocumentText;
            }

            int numUpdated = context.SaveChanges();
        }

        private string exportFolder = string.Empty;

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageTree1.SelectedNode == null)
                return;

            Page pd = imageTree1.SelectedNode.Tag as Page;

            markDownEditor1.Enabled = (pd != null);

            if ((pd != null) && (pd.DocumentType != "Folder"))
            {
                selectedPage = pd;
            }
            else
            {
                selectedPage = new();
            }

            string name = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            exportFolder = Path.Combine(Folders.DownloadsFolder, $"PNEXP_{name}");
            Directory.CreateDirectory(exportFolder);

            markDownEditor1.ViewMode = true;
            markDownEditor1.Enabled = true;
            markDownEditor1.DocumentText = selectedPage.PageContent;

            Replacer rep = new Replacer();
            rep.Replacements = new();
            //rep.Replacements.Add("LOCATION", "file://");
            rep.Replacements.Add("LOCATION", "");

            string repText = rep.DoReplacements(selectedPage.PageContent);

            string indexFileName = Path.Combine(exportFolder, "Index.html");
            File.WriteAllText(indexFileName, markDownEditor1.ToHtml(repText));

            System.Timers.Timer t = new();
            t.Interval = 500; // In milliseconds
            //t.AutoReset = false; // Stops it from repeating
            // t.Elapsed => { } += new ElapsedEventHandler(TimerElapsed);
            t.Elapsed += (sender, e) =>
            {
                //System.Diagnostics.Debug.WriteLine(markDownEditor1.NavComplete);
                if (markDownEditor1.NavComplete)
                {
                    Process.Start(new ProcessStartInfo(indexFileName) { UseShellExecute = true });
                    //Cursor.Current = Cursors.Default;
                    t.Stop();
                }
            };
            t.Start();


        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Point position = imageTree1.PointToClient(Control.MousePosition);

            TreeViewHitTestInfo hti = imageTree1.HitTest(position);
            if (hti.Node == null)
                e.Cancel = true;
            else
                imageTree1.SelectedNode = hti.Node;
        }
    }
}
