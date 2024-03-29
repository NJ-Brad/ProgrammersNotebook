﻿// split buttion, if necessary - https://wyday.com/splitbutton/

using MarkDownHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WinForms.JumpLists;
using static MarkDownHelper.MarkDownEditor;

namespace ProgrammersNotebook
{
    public partial class NotebookForm : Form
    {
        bool integratedEdit = false;

        private readonly ILogger _logger;
        private readonly IHost _host;
        private readonly IConfiguration _config;

        private List<Page> pages = new();
        private List<TreePage> treePages = new();
        private List<TreeFragment> treeFragments = new();
        private Page? selectedPage = null;
        private PageFragment? selectedFragment = null;
        //private PNContext? context = null;
        private readonly IDbContextFactory<PNContext> _contextFactory;

        string userName = "Unkown";
        string longUserName = "Unkown";

        static int JumpListMessage = JumpListHandler.MessageId;

        public string[] args { get; set; } = new string[] { };

        // https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
        public NotebookForm(ILogger<NotebookForm> logger, IConfiguration config, IHost host, IDbContextFactory<PNContext> contextFactory)
        {
            InitializeComponent();

            _logger = logger;
            _config = config;
            _host = host;
            //this.context = context;
            _contextFactory = contextFactory;

            // "<$LOCATION$>

            string val = _config["ServerURL"];

            userName = _config["UserName"];
            longUserName = _config["LongUserName"];

            if (string.IsNullOrEmpty(longUserName))
            {
                longUserName = userName;
            }

            Replacements.Set("USERNAME", userName);
            Replacements.Set("LONGUSERNAME", longUserName);

            Replacements.Set("LOCATION", "notebook://");

            //if (Replacements.ContainsKey("LOCATION"))
            //{
            //    Replacements["LOCATION"] = "notebook://";
            //}
            //else
            //{
            //    Replacements.Add("LOCATION", "notebook://");
            //}

            if (!integratedEdit)
            {
                imageTree1.LabelEdit = false;
                imageTree2.LabelEdit = false;
            }
        }

        protected override void WndProc(ref Message m)
        {
            //if the coming message has the same number as our registered message
            if (m.Msg == JumpListMessage)
            {
                string atomValue = JumpListHandler.GetAtomValue((uint)m.WParam);

                ProcessArg(atomValue);
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void ProcessArg(string arg)
        {
            // is it a Jump List argument?
            if (arg.StartsWith("JL"))
            {
                //MessageBox.Show(arg, "Arg Received");
                if (arg.StartsWith("JL:Create:"))
                {
                    tabControl1.SelectedIndex = 0;
                    Page pg = StampPage(new Page { DocumentType = "Page", Name = "New Page", PageContent = "New Page" });
                    AddDocument(pg);
                }

                if (arg.StartsWith("JL:Open:"))
                {
                    //                    OpenProject(arg.Substring(8));
                }
            }
            else // straight from the command line (not through the Jump List)
            {
                //                OpenProject(arg);
            }
        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            JumpLists.Init();

            JumpLists.AddAppkicationTask("Actions", "Create New Note", "Create New Note", "JL:Create:ASDF");

            VerifyDatabase();

            LoadData();

            if (args.Length > 0)
            {
                ProcessArg(args[0]);
            }
        }

        private void VerifyDatabase()
        {
            using (PNContext context = _contextFactory.CreateDbContext())
            {
                List<string> pending = context.Database.GetPendingMigrations().ToList<string>();

                //if (pending.Count == 0)
                //{
                //    MessageBox.Show("There are no pending updates");
                //    return;
                //}

                // do migrations
                context.Database.Migrate();
            }
        }

        private void LoadData()
        {
            imageTree1.Nodes.Clear();
            imageTree2.Nodes.Clear();

            imageTree1.Font = Font;
            imageTree1.ShowRootLines = false;
            imageTree1.SelectImages(ShellIconSize.SmallIcon);

            // this loads everything, including page content
            //pages = context.Pages.ToList();
            //imageTree1.Nodes.Clear();
            //AddToTree(imageTree1.Nodes, pages);

            // this leaves out the content - need to query that only if editing
            // https://www.brentozar.com/archive/2016/09/select-specific-columns-entity-framework-query/

            using (PNContext context = _contextFactory.CreateDbContext())
            {
                treePages = context.Pages
                .Select(p => new TreePage()
                {
                    Id = p.Id,
                    Name = p.Name,
                    DocumentType = p.DocumentType,
                    Pages = p.Pages
                })
                //.OrderBy(p => p.Name)

                .AsEnumerable()     // this makes local 
                .OrderBy(p => p.Name.ToLowerInvariant())

                .ToList();

                imageTree1.Nodes.Clear();
                AddToTree(imageTree1.Nodes, treePages);

                tabControl1.SelectedIndex = 1;
                // fragments
                imageTree2.Font = Font;
                imageTree2.ShowRootLines = false;
                imageTree2.SelectImages(ShellIconSize.SmallIcon);

                // this loads everything, including page content
                //pages = context.Pages.ToList();
                //imageTree1.Nodes.Clear();
                //AddToTree(imageTree1.Nodes, pages);

                // this leaves out the content - need to query that only if editing
                // https://www.brentozar.com/archive/2016/09/select-specific-columns-entity-framework-query/
                treeFragments = context.Fragments
                    .Where(p => p.FragmentType == "Text")
                    .Select(p => new TreeFragment()
                    {
                        Id = p.Id,
                        Name = p.Name
                    })
                    //.OrderBy(p => p.Name)
                    .AsEnumerable()     // this makes
                    .OrderBy(p => p.Name.ToLowerInvariant())
                    .ToList();

                imageTree2.Nodes.Clear();
                AddToTree(imageTree2.Nodes, treeFragments);
                tabControl1.SelectedIndex = 0;
            }

            // work with this.  remembering the format may become an issue
            markDownEditor1.ProtocolHandlers.Add(new CustomProtocolHandler { Prefix = "notebook://*", Handler = ResolveProtocolRequest });
            markDownEditor1.EmbeddedFragmentHandler = ResolveEmbeddedFragmentRequest;
            markDownEditor1.SetUpHandlers();
            markDownEditor1.ViewMode = integratedEdit ? MarkDownEditor.EditorMode.ViewEdit : MarkDownEditor.EditorMode.ViewOnly;

            markDownEditor1.Replacements = Replacements;

        }

        Fragments frMgr = null;


        public void ResolveEmbeddedFragmentRequest(object sender, EmbeddedFragmentEventArgs e)
        {
            using (PNContext context = _contextFactory.CreateDbContext())
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
            using (PNContext context = _contextFactory.CreateDbContext())
            {
                Fragments fragMgr = new Fragments(context);
                return fragMgr.GetFragment(key);
            }
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

        private async void AddToTree(TreeNodeCollection coll, List<TreeFragment> fragmentList)
        {
            foreach (TreeFragment frag in fragmentList)
            {
                TreeNode tn = coll.Add(frag.Name);
                tn.Tag = frag;
                tn.ImageKey = tn.SelectedImageKey = imageTree2.AddKeyedImage(string.Empty, 0, "md");
                tn.ToolTipText = null;
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

            // it's new here
            pd = StampPage(pd);
            using (PNContext context = _contextFactory.CreateDbContext())
            {
                context.Add(pd);
                context.SaveChanges();
            }
            selectedPage = pd;
            imageTree1.SelectedNode = tn;
            //            imageTree1.SelectedNode.BeginEdit();

            PageForm pf = _host.Services.GetRequiredService<PageForm>();
            pf.ViewMode = EditorMode.Edit;
            pf.IsPage = true;
            pf.PageFragmentId = pd.Id;
            pf.FormClosed += PageClosed;
            pf.Show();
        }

        private void PageClosed(object? sender, FormClosedEventArgs e)
        {
            PageForm pf = sender as PageForm;

            if (pf != null)
            {
                if (pf.IsPage)
                {
                    foreach (TreeNode node in imageTree1.Nodes)
                    {
                        TreePage tp = node.Tag as TreePage;
                        if (tp != null)
                        {
                            if (tp.Id == pf.PageFragmentId)
                            {
                                tp.Name = pf.Text;
                                node.Text = tp.Name;
                                imageTree1.Sort();
                                imageTree1.SelectedNode = node;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    foreach (TreeNode node in imageTree2.Nodes)
                    {
                        TreeFragment tp = node.Tag as TreeFragment;
                        if (tp != null)
                        {
                            if (tp.Id == pf.PageFragmentId)
                            {
                                tp.Name = pf.Text;
                                node.Text = tp.Name;
                                imageTree2.Sort();
                                imageTree2.SelectedNode = node;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private async void AddFragment(PageFragment frag)
        {
            TreeNodeCollection coll = imageTree2.Nodes;
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

            TreeNode tn = coll.Add(frag.Name);

            if (frag.FragmentType == "Folder")
            {
                tn.ImageIndex = 0;
            }
            else
            {
                tn.ImageKey = imageTree1.AddKeyedImage(string.Empty, 0, "md");
            }
            tn.SelectedImageKey = tn.ImageKey;

            tn.Tag = new TreeFragment()
            {
                Id = frag.Id,
                Name = frag.Name
            };

            // it's new here
            frag = StampFragment(frag);
            using (PNContext context = _contextFactory.CreateDbContext())
            {
                context.Add(frag);
                context.SaveChanges();
            }
            selectedFragment = frag;
            imageTree2.SelectedNode = tn;
            //            imageTree2.SelectedNode.BeginEdit();
            PageForm pf = _host.Services.GetRequiredService<PageForm>();
            pf.ViewMode = EditorMode.Edit;
            pf.IsPage = false;
            pf.PageFragmentId = frag.Id;
            pf.FormClosed += PageClosed;
            pf.Show();
        }

        public Dictionary<string, string> Replacements = new();

        private void imageTree1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreePage pd = e.Node.Tag as TreePage;

            markDownEditor1.Enabled = (pd != null);

            selectedPage = null;
            if ((pd != null) && (pd.DocumentType != "Folder"))
            {
                using (PNContext context = _contextFactory.CreateDbContext())
                {
                    selectedPage = context.Pages.Where(p => p.Id == pd.Id).FirstOrDefault();
                }
            }

            if (selectedPage == null)
            {
                selectedPage = new();
            }

            Replacements.Set("PAGE_TITLE", selectedPage.Name);
            Replacements.Set("AUTHOR", selectedPage.Author);
            Replacements.Set("CREATED", selectedPage.Created.ToString("g"));
            Replacements.Set("MODIFIED_BY", selectedPage.ModifiedBy);
            Replacements.Set("MODIFIED", selectedPage.Modified.ToString("g"));
            markDownEditor1.DocumentText = selectedPage.PageContent;
            markDownEditor1.DocumentTitle = selectedPage.Name;

            markDownEditor1.ViewMode = integratedEdit ? MarkDownEditor.EditorMode.ViewEdit : MarkDownEditor.EditorMode.ViewOnly;
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

            using (PNContext context = _contextFactory.CreateDbContext())
            {
                selectedPage = context.Pages.Where(p => p.Id == selectedPage.Id).FirstOrDefault();

                //Page pd = e.Node.Tag as Page;
                Page pd = selectedPage;
                if ((pd != null) && (!string.IsNullOrEmpty(e.Label)))
                {
                    pd.Name = e.Label;
                    e.Node.Text = pd.Name;
                    Replacements.Set("PAGE_TITLE", pd.Name);
                }

                context.SaveChanges();
            }
        }

        private Page StampPage(Page pg)
        {
            // this way the time cannot change between uses
            DateTime now = DateTime.Now;
            if (string.IsNullOrEmpty(pg.Author))
            {
                pg.Author = longUserName;
                pg.Created = now;
            }

            pg.ModifiedBy = longUserName;
            pg.Modified = now;

            return pg;
        }

        private PageFragment StampFragment(PageFragment pg)
        {
            // this way the time cannot change between uses
            DateTime now = DateTime.Now;
            if (string.IsNullOrEmpty(pg.Author))
            {
                pg.Author = longUserName;
                pg.Created = now;
            }

            pg.ModifiedBy = longUserName;
            pg.Modified = now;

            return pg;
        }

        //private void documentToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    Page pg = StampPage(new Page { DocumentType = "Page", Name = "New Page" });
        //    AddDocument(pg);
        //}

        //private async void folderToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Page pg = StampPage(new Page { DocumentType = "Folder", Name = "New Folder" });
        //    AddDocument(pg);
        //}

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
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

                if (ConfirmationForm.ConfirmRemoval(selectedPage.Name))
                {
                    using (PNContext context = _contextFactory.CreateDbContext())
                    {
                        context.Remove(selectedPage);
                        context.SaveChanges();
                    }
                    coll.RemoveAt(index);
                }
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                Page pg = StampPage(new Page { DocumentType = "Page", Name = "New Page", PageContent = "New Page" });
                AddDocument(pg);
            }
            else
            {
                PageFragment frag = StampFragment(new PageFragment { FragmentType = "Text", Name = "New Fragment", Content = "New Fragment" });
                AddFragment(frag);
            }
        }

        private void markDownEditor1_SaveClicked(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                using (PNContext context = _contextFactory.CreateDbContext())
                {
                    Page pg = context.Pages.Where(p => p.Id == selectedPage.Id).FirstOrDefault();
                    if (pg == null)
                    {
                        // it's new here
                        selectedPage = StampPage(selectedPage);
                        context.Add(selectedPage);
                        Replacements.Set("AUTHOR", pg.Author);
                        Replacements.Set("CREATED", pg.Created.ToString("g"));
                        Replacements.Set("MODIFIED_BY", pg.ModifiedBy);
                        Replacements.Set("MODIFIED", pg.Modified.ToString("g"));
                    }
                    else
                    {
                        if ((!pg.PageContent.Equals(markDownEditor1.DocumentText)) || (!pg.Name.Equals(markDownEditor1.DocumentTitle)))
                        {
                            pg = StampPage(pg);
                            Replacements.Set("AUTHOR", pg.Author);
                            Replacements.Set("CREATED", pg.Created.ToString("g"));
                            Replacements.Set("MODIFIED_BY", pg.ModifiedBy);
                            Replacements.Set("MODIFIED", pg.Modified.ToString("g"));
                        }
                        pg.PageContent = markDownEditor1.DocumentText;
                        pg.Name = markDownEditor1.DocumentTitle;
                    }
                    context.SaveChanges();
                }
            }
            else
            {
                using (PNContext context = _contextFactory.CreateDbContext())
                {

                    PageFragment frag = context.Fragments.Where(p => p.Id == selectedFragment.Id).FirstOrDefault();
                    if (frag == null)
                    {
                        // it's new here
                        selectedFragment = StampFragment(selectedFragment);
                        context.Add(selectedFragment);
                        Replacements.Set("AUTHOR", frag.Author);
                        Replacements.Set("CREATED", frag.Created.ToString("g"));
                        Replacements.Set("MODIFIED_BY", frag.ModifiedBy);
                        Replacements.Set("MODIFIED", frag.Modified.ToString("g"));
                    }
                    else
                    {
                        if ((!frag.Content.Equals(markDownEditor1.DocumentText)) || (!frag.Name.Equals(markDownEditor1.DocumentTitle)))
                        {
                            frag = StampFragment(frag);
                            Replacements.Set("AUTHOR", frag.Author);
                            Replacements.Set("CREATED", frag.Created.ToString("g"));
                            Replacements.Set("MODIFIED_BY", frag.ModifiedBy);
                            Replacements.Set("MODIFIED", frag.Modified.ToString("g"));
                        }
                        frag.Content = markDownEditor1.DocumentText;
                        frag.Name = markDownEditor1.DocumentTitle;
                    }
                    context.SaveChanges();
                }
            }
        }

        private string exportFolder = string.Empty;

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageTree1.SelectedNode == null)
                return;

            TreePage pd = imageTree1.SelectedNode.Tag as TreePage;

            markDownEditor1.Enabled = (pd != null);

            if ((pd != null) && (pd.DocumentType != "Folder"))
            {
                using (PNContext context = _contextFactory.CreateDbContext())
                {
                    selectedPage = context.Pages.Where(p => p.Id == pd.Id).FirstOrDefault();
                }
            }
            else
            {
                selectedPage = new();
            }

            string name = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            exportFolder = Path.Combine(Folders.DownloadsFolder, $"PNEXP_{name}");
            Directory.CreateDirectory(exportFolder);

            markDownEditor1.ViewMode = integratedEdit ? MarkDownEditor.EditorMode.ViewEdit : MarkDownEditor.EditorMode.ViewOnly;

            markDownEditor1.Enabled = true;
            markDownEditor1.DocumentText = selectedPage.PageContent;
            markDownEditor1.DocumentTitle = selectedPage.Name;
            Replacements.Set("PAGE_TITLE", selectedPage.Name);

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
            Point position = (tabControl1.SelectedIndex == 0) ? imageTree1.PointToClient(Control.MousePosition) : imageTree2.PointToClient(Control.MousePosition);

            TreeViewHitTestInfo hti = (tabControl1.SelectedIndex == 0) ? imageTree1.HitTest(position) : imageTree2.HitTest(position);
            if (hti.Node == null)
            {
                contextMenuStrip1.Items.Clear();
                CreateMenuItem(contextMenuStrip1.Items, "Add", "", t =>
                {
                    toolStripButtonAdd_Click(sender, EventArgs.Empty);
                    return "";
                });
                //                e.Cancel = true;
            }
            else
            {
                if (tabControl1.SelectedIndex == 0)
                    imageTree1.SelectedNode = hti.Node;
                else
                    imageTree2.SelectedNode = hti.Node;

                contextMenuStrip1.Items.Clear();
                CreateMenuItem(contextMenuStrip1.Items, "Open in new window", "", t =>
                {
                    PageForm pf = _host.Services.GetRequiredService<PageForm>();
                    pf.ViewMode = EditorMode.ViewEdit;
                    pf.IsPage = true;
                    pf.PageFragmentId = t;
                    pf.FormClosed += PageClosed;
                    pf.Show();
                    return "";
                });
                CreateMenuItem(contextMenuStrip1.Items, "Edit", "", t =>
                {
                    PageForm pf = _host.Services.GetRequiredService<PageForm>();
                    pf.ViewMode = EditorMode.Edit;
                    pf.IsPage = true;
                    pf.PageFragmentId = t;
                    pf.FormClosed += PageClosed;
                    pf.Show();
                    return "";
                });
                CreateMenuItem(contextMenuStrip1.Items, "Export", "", t =>
                {
                    exportToolStripMenuItem_Click(sender, EventArgs.Empty);
                    return "";
                });
                contextMenuStrip1.Items.Add(new ToolStripSeparator());
                CreateMenuItem(contextMenuStrip1.Items, "Add", "", t =>
                {
                    toolStripButtonAdd_Click(sender, EventArgs.Empty);
                    return "";
                });

                if (tabControl1.SelectedIndex == 0)
                {
                    CreateMenuItem(contextMenuStrip1.Items, "Remove", "", t =>
                    {
                        toolStripButtonRemove_Click(sender, EventArgs.Empty);
                        return "";
                    });
                }
            }
        }

        private ToolStripMenuItem CreateMenuItem(ToolStripItemCollection items, string label, string imageKey, OperationDelegate del)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(label);

            menuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            //            menuItem.Image = imageList1.Images[imageKey];

            menuItem.Click += (sender, args) =>
            {
                DoOperation
                (
                    del
                );
            };

            items.Add(menuItem);

            return menuItem;
        }

        private void DoOperation(OperationDelegate del)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    del((selectedPage == null) ? "" : selectedPage.Id);
                    break;
                case 1:
                    del((selectedFragment == null) ? "" : selectedFragment.Id);
                    break;
            }
        }


        private void imageTree2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeFragment pd = e.Node.Tag as TreeFragment;

            markDownEditor1.Enabled = (pd != null);

            selectedPage = null;
            if (pd != null)
            {
                using (PNContext context = _contextFactory.CreateDbContext())
                {
                    selectedFragment = context.Fragments.Where(p => p.Id == pd.Id).FirstOrDefault();
                }
            }

            if (selectedFragment == null)
            {
                selectedFragment = new();
            }

            Replacements.Set("PAGE_TITLE", selectedFragment.Name);
            Replacements.Set("AUTHOR", selectedFragment.Author);
            Replacements.Set("CREATED", selectedFragment.Created.ToString("g"));
            Replacements.Set("MODIFIED_BY", selectedFragment.ModifiedBy);
            Replacements.Set("MODIFIED", selectedFragment.Modified.ToString("g"));
            markDownEditor1.DocumentText = selectedFragment.Content;
            markDownEditor1.DocumentTitle = selectedFragment.Name;

            markDownEditor1.ViewMode = integratedEdit ? MarkDownEditor.EditorMode.ViewEdit : MarkDownEditor.EditorMode.ViewOnly;
            markDownEditor1.Enabled = true;
        }

        private void imageTree2_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (selectedFragment == null)
                return;

            using (PNContext context = _contextFactory.CreateDbContext())
            {
                selectedFragment = context.Fragments.Where(p => p.Id == selectedFragment.Id).FirstOrDefault();

                PageFragment pd = selectedFragment;
                if ((pd != null) && (!string.IsNullOrEmpty(e.Label)))
                {
                    pd.Name = e.Label;
                    e.Node.Text = pd.Name;
                    Replacements.Set("PAGE_TITLE", pd.Name);
                }
                context.SaveChanges();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPage = null;
            selectedFragment = null;

            imageTree1.SelectedNode = null;
            imageTree2.SelectedNode = null;

            markDownEditor1.DocumentText = string.Empty;
            markDownEditor1.DocumentTitle = string.Empty;

            Replacements.Set("PAGE_TITLE", string.Empty);

            markDownEditor1.ViewMode = integratedEdit ? MarkDownEditor.EditorMode.ViewEdit : MarkDownEditor.EditorMode.ViewOnly;
            markDownEditor1.Enabled = false;

        }

        private void toolStripButtonDataMaintenance_Click(object sender, EventArgs e)
        {
            DatabaseMaintenanceForm dmf = _host.Services.GetRequiredService<DatabaseMaintenanceForm>();
            dmf.ShowDialog();

            //Application.Restart();
            ////Application.Exit();

            //var v = System.Diagnostics.Process.Start(Application.ExecutablePath);

            //Application.ExitThread();
            ////Application.Exit();

            ////Refresh();

            ////LoadData();
        }
    }
}
