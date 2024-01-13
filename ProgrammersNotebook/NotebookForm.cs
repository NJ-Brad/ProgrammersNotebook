// split buttion, if necessary - https://wyday.com/splitbutton/

using System.Text.Json;

namespace ProgrammersNotebook
{
    public partial class NotebookForm : Form
    {
        //        internal Project? project { get; set; } = null;

        private List<Page> pages = new();
        private Page? selectedPage = null;

        public NotebookForm()
        {
            InitializeComponent();
        }

        bool binding = false;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            binding = true;

            //string folder = Folders.DefaultProjectFolder;

            // I don't want to go down the "files" rabbit hole
            //LoadFolder(folder);

            imageTree1.Font = Font;
            imageTree1.ShowRootLines = false;
            imageTree1.SelectImages(ShellIconSize.SmallIcon);

            // load an index file instead - it will transition better to other storage methods

            string fileName = Folders.GetConfigFileName("pages.index");
            if (File.Exists(fileName))
            {
                string content = File.ReadAllText(fileName);

                pages = JsonSerializer.Deserialize<List<Page>>(content);

                imageTree1.Nodes.Clear();
                AddToTree(imageTree1.Nodes, pages);
            }


            //actionItemWidgetControl1.SetTreeFont(Font);
            //notesWidgetControl1.SetTreeFont(Font);
            //peopleWidgetControl1.SetTreeFont(Font);

            //bindingSource.DataSource = selectedProjectDocument;

            //statuses.Add(new ComboBoxItem { Text = "Unknown", Value = "" });
            //statuses.Add(new ComboBoxItem { Text = "Good", Value = "GOOD" });
            //statuses.Add(new ComboBoxItem { Text = "Watch", Value = "WATCH" });
            //statuses.Add(new ComboBoxItem { Text = "Problem", Value = "PROBLEM" });
            //statuses.Add(new ComboBoxItem { Text = "Overdue", Value = "OVERDUE" });

            //comboBox2.DataSource = statuses;
            //comboBox2.DisplayMember = "Text";
            //comboBox2.ValueMember = "Value";

            //documentTypes.Add(new ComboBoxItem { Text = "Folder", Value = "Folder" });
            //documentTypes.Add(new ComboBoxItem { Text = "Unknown", Value = "" });
            //documentTypes.Add(new ComboBoxItem { Text = "File", Value = "File" });

            //comboBox1.DataSource = documentTypes;
            //comboBox1.DisplayMember = "Text";
            //comboBox1.ValueMember = "Value";

            //string fileName = Path.ChangeExtension(Folders.GetConfigFileName(FileName), "project");

            //if (!File.Exists(fileName))
            //{
            //    MessageBox.Show("File does not exist for this project");
            //    DialogResult = DialogResult.Cancel;
            //    Close();
            //    return;
            //}

            //string content = File.ReadAllText(fileName);

            //project = JsonSerializer.Deserialize<Project>(content);

            //AddToTree(imageTree1.Nodes, project.Documents);

            //textBox1.DataBindings.Add("Text", project, nameof(Project.Name), false, DataSourceUpdateMode.OnPropertyChanged);
            //textBox2.DataBindings.Add("Text", project, nameof(Project.Description), false, DataSourceUpdateMode.OnPropertyChanged);
            //textBox5.DataBindings.Add("Text", project, nameof(Project.Orgranization), false, DataSourceUpdateMode.OnPropertyChanged);
            //nullableDatePicker1.DataBindings.Add("Value", project, nameof(Project.InitiationDate), true, DataSourceUpdateMode.OnPropertyChanged);
            //nullableDatePicker2.DataBindings.Add("Value", project, nameof(Project.TargetedDeliveryDate), true, DataSourceUpdateMode.OnPropertyChanged);
            //comboBox2.DataBindings.Add("SelectedValue", project, nameof(Project.CurrentStatus), false, DataSourceUpdateMode.OnPropertyChanged);
            //nullableDatePicker3.DataBindings.Add("Value", project, nameof(Project.StatusDate), true, DataSourceUpdateMode.OnPropertyChanged);
            //textBox3.DataBindings.Add("Text", project, nameof(Project.StatusReason), false, DataSourceUpdateMode.OnPropertyChanged);
            //textBox4.DataBindings.Add("Text", project, nameof(Project.DefaultLocation), false, DataSourceUpdateMode.OnPropertyChanged);
            //textBox10.DataBindings.Add("Text", project, nameof(Project.LogoFile), false, DataSourceUpdateMode.OnPropertyChanged);


            //textBox6.DataBindings.Add("Text", bindingSource, nameof(ProjectDocument.Name), false, DataSourceUpdateMode.OnPropertyChanged);
            //comboBox1.DataBindings.Add("SelectedValue", bindingSource, nameof(ProjectDocument.DocumentType), false, DataSourceUpdateMode.OnPropertyChanged);
            //textBox7.DataBindings.Add("Text", bindingSource, nameof(ProjectDocument.Location), false, DataSourceUpdateMode.OnPropertyChanged);
            //textBox8.DataBindings.Add("Text", bindingSource, nameof(ProjectDocument.LastViewed), false, DataSourceUpdateMode.OnPropertyChanged);
            //textBox9.DataBindings.Add("Text", bindingSource, nameof(ProjectDocument.Updated), false, DataSourceUpdateMode.OnPropertyChanged);

            //Text = project.Name;
            binding = false;

            //ActionItemList items = new();
            //items.Add(new ActionItem { Title = "Title", PersonName = "Brad", Status = "New" });
            ////BindingSource bx = new BindingSource();
            ////bx.DataSource = items;
            ////actionItemWidgetControl1.Data = bx;
            ////actionItemWidgetControl1.Data = items;
            //actionItemWidgetControl1.DataSource = items;

            //actionItemWidgetControl1.DataSource = project.ActionItems;
            //notesWidgetControl1.DataSource = project.Notes;

            //using var db = new PCDataContext();
            ////db.People

            //// Create
            //Console.WriteLine("Inserting a new blog");
            //db.Add(new PersonInfoModel { Name = "Brad Bruce", Role = "Developer", Email = "NJ_Brad@Verizon.net", TimeZone = "Eastern" });
            //db.SaveChanges();

            //// Read
            //Console.WriteLine("Querying for a blog");
            //var blog = db.People
            //    //.OrderBy(b => b.BlogId)
            //    .First();

            //peopleWidgetControl1.DataSource = project.People;
        }

        private async void SaveChanges()
        {
            string output = JsonSerializer.Serialize<List<Page>>(pages, new JsonSerializerOptions { WriteIndented = true });

            string fileName = Folders.GetConfigFileName("pages.index");
            File.WriteAllText(fileName, output);
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

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string output = JsonSerializer.Serialize<Project>(project, new JsonSerializerOptions { WriteIndented = true });

        //    File.WriteAllText(Path.ChangeExtension(Folders.GetConfigFileName(FileName), "project"), output);
        //    DialogResult = DialogResult.OK;
        //    Close();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    if (!binding)
        //    {
        //        project.StatusDate = DateTime.Today.ToString();
        //    }
        //}

        //ProjectDocument? selectedProjectDocument = new();
        //BindingSource bindingSource = new BindingSource();

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    selectedProjectDocument.LastViewed = DateTime.Now.ToString();
        //    bindingSource.DataSource = new ProjectDocument();
        //    bindingSource.DataSource = selectedProjectDocument;
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    OpenDocument();
        //}
        //private void OpenDocument()
        //{
        //    if (imageTree1.SelectedNode != null)
        //    {
        //        selectedProjectDocument = imageTree1.SelectedNode.Tag as ProjectDocument;
        //        try
        //        {
        //            // https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.processstartinfo?view=net-7.0
        //            //Process.Start(new ProcessStartInfo(selectedProjectDocument.Location) { UseShellExecute = true });

        //            ProcessStartInfo psi = new ProcessStartInfo();

        //            string startedHere = Application.ExecutablePath;

        //            if (!string.IsNullOrEmpty(selectedProjectDocument.OpenWith))
        //            {
        //                psi.FileName = selectedProjectDocument.OpenWith;
        //                if (!string.IsNullOrEmpty(selectedProjectDocument.Arguments))
        //                {
        //                    psi.Arguments = selectedProjectDocument.Arguments.Replace("%1", $"\"{selectedProjectDocument.Location}\"");
        //                }
        //                else
        //                {
        //                    psi.Arguments = $"\"{selectedProjectDocument.Location}\"";
        //                }
        //            }
        //            else
        //            {
        //                psi.FileName = selectedProjectDocument.Location;    // use the default application for this type of file
        //            }

        //            ProcessWindowStyle parsed;
        //            bool valid = Enum.TryParse<ProcessWindowStyle>(selectedProjectDocument.Visibility, out parsed);
        //            psi.WindowStyle = valid ? parsed : ProcessWindowStyle.Normal;

        //            if (!string.IsNullOrEmpty(selectedProjectDocument.WorkingDirectory))
        //            {
        //                psi.WorkingDirectory = $"\"{selectedProjectDocument.WorkingDirectory}\"";
        //            }

        //            psi.UseShellExecute = true;

        //            Process.Start(psi);

        //            // https://www.howtogeek.com/366399/how-and-why-to-start-microsoft-word-from-the-command-prompt/

        //            selectedProjectDocument.LastViewed = DateTime.Now.ToString();
        //        }
        //        catch { }

        //        bindingSource.ResetBindings(false);
        //        //bindingSource.DataSource = new ProjectDocument();
        //        //bindingSource.DataSource = selectedProjectDocument;
        //    }
        //}

        private async void AddDocument(Page pd)
        {
            TreeNodeCollection coll = imageTree1.Nodes;
            List<Page> pageList = pages;

            if (imageTree1.SelectedNode != null)
            {
                if ((imageTree1.SelectedNode.Tag as Page).DocumentType != "Folder")
                {
                    if ((imageTree1.SelectedNode.Parent != null))
                    {
                        coll = imageTree1.SelectedNode.Parent.Nodes;
                        pageList = (imageTree1.SelectedNode.Parent.Tag as Page).Pages;
                    }
                }
                else
                {
                    // as child - under selected folder
                    coll = imageTree1.SelectedNode.Nodes;
                    pageList = (imageTree1.SelectedNode.Tag as Page).Pages;
                }
            }

            int index = coll.IndexOf(imageTree1.SelectedNode);

            //TreeNode tn = coll.Insert(index + 1, "New document");
            TreeNode tn = coll.Insert(index + 1, pd.Name);

            if (pd.DocumentType == "Folder")
            {
                tn.ImageIndex = 0;
            }
            else
            {
                tn.ImageKey = imageTree1.AddKeyedImage(string.Empty, 0, "md");
            }
            tn.SelectedImageKey = tn.ImageKey;

            tn.Tag = pd;
            pageList.Insert(index + 1, pd);
            imageTree1.SelectedNode = tn;
            SaveChanges();
        }


        //private void AddDirectory(string dirPath)
        //{
        //    Page pd2 = new ();
        //    pd2.Name = Path.GetFileName(dirPath);
        //    //pd2.Location = str;
        //    pd2.DocumentType = "Folder";
        //    AddDocument(pd2);
        //    foreach (string str in Directory.GetFiles(dirPath))
        //    {
        //        Page pd = new ();
        //        pd.Name = Path.GetFileName(str);
        //        pd.Location = str;
        //        AddDocument(pd);
        //    }

        //    foreach (string str in Directory.GetDirectories(dirPath))
        //    {
        //        AddDirectory(str);
        //    }
        //}

        //private void buttonAdvanced_Click(object sender, EventArgs e)
        //{
        //    if (imageTree1.SelectedNode != null)
        //    {
        //        DocumentDetails dd = new();
        //        selectedProjectDocument = imageTree1.SelectedNode.Tag as ProjectDocument;

        //        dd.Document = selectedProjectDocument;
        //        if (dd.ShowDialog() == DialogResult.OK)
        //        {
        //            selectedProjectDocument = dd.Document;
        //            bindingSource.ResetBindings(false);
        //            FixNode(imageTree1.SelectedNode);
        //        }
        //    }
        //}

        //private async void FixNode(TreeNode node)
        //{
        //    if (node == null)
        //    {
        //        return;
        //    }

        //    ProjectDocument pd = node.Tag as ProjectDocument;

        //    if (pd != null)
        //    {
        //        node.Text = pd.Name;
        //        if (pd.DocumentType != "Folder")
        //        {
        //            if (pd.WebIcon && (!string.IsNullOrEmpty(pd.IconPath)) && (ImageTree.IsValidUrl(pd.IconPath)))
        //            {
        //                Image img = await WebIcon.Retrieve(pd.IconPath, 32, 32);
        //                node.ImageIndex = imageTree1.AddImage(img, img);
        //                node.SelectedImageIndex = node.ImageIndex;
        //            }
        //            else
        //            {
        //                // some day I may find a way to replace the image.  For now, an extra few images shouldn't hurt
        //                node.ImageIndex = imageTree1.AddImage(pd.IconPath, pd.IconIndex, $"*.{Path.GetExtension(pd.Location)}");
        //                node.SelectedImageIndex = node.ImageIndex;
        //            }
        //        }
        //        else //  pd.DocumentType == "Folder"
        //        {
        //            node.ImageIndex = 0;
        //            node.SelectedImageIndex = node.ImageIndex;
        //        }
        //    }

        //}

        //private void textBox6_Leave(object sender, EventArgs e)
        //{
        //    FixNode(imageTree1.SelectedNode);
        //}

        //private void toolStripButtonAddDocument_Click(object sender, EventArgs e)
        //{
        //    //AddDocumentForm ad = new AddDocumentForm();
        //    //ad.DefaultLocation = project.DefaultLocation;
        //    //if (ad.ShowDialog() == DialogResult.OK)
        //    //{
        //    //TreeNodeCollection coll = imageTree1.Nodes;
        //    //List<ProjectDocument> docList = project.Documents;

        //    //foreach (ProjectDocument pd in ad.NewDocuments)
        //    //{
        //    Page pg = new Page { DocumentType = "Page", Name = "New Page" };
        //            AddDocument(pg);
        //        //}
        //    //}
        //}

        //private void toolStripButtonRemove_Click(object sender, EventArgs e)
        //{
        //    bool deleteFile = false;
        //    switch (MessageBox.Show("Delete underlying file as well?", "Verification", MessageBoxButtons.YesNoCancel))
        //    {
        //        case DialogResult.Cancel:
        //            return;
        //        case DialogResult.Yes:
        //            deleteFile = true;
        //            break;
        //        default:
        //            deleteFile = false;
        //            break;
        //    }

        //    ProjectDocument pd = new();
        //    TreeNodeCollection coll = imageTree1.Nodes;
        //    List<ProjectDocument> docList = project.Documents;

        //    if ((imageTree1.SelectedNode != null) && ((imageTree1.SelectedNode.Parent != null)))
        //    {
        //        coll = imageTree1.SelectedNode.Parent.Nodes;
        //        docList = (imageTree1.SelectedNode.Parent.Tag as ProjectDocument).Documents;
        //    }

        //    int index = coll.IndexOf(imageTree1.SelectedNode);

        //    string fileName = (imageTree1.SelectedNode.Tag as ProjectDocument).Location;

        //    try
        //    {
        //        File.Delete(fileName);
        //    }
        //    catch { }

        //    coll.RemoveAt(index);
        //    docList.RemoveAt(index);
        //}

        //private void toolStripButtonAddFolder_Click(object sender, EventArgs e)
        //{
        //    // add child - putting node at end is fine
        //    ProjectDocument pd = new();
        //    pd.DocumentType = "Folder";
        //    pd.Name = "New Folder";

        //    AddDocument(pd);
        //}

        //private void toolStripButtonImport_Click(object sender, EventArgs e)
        //{
        //    BulkImportForm bif = new BulkImportForm();

        //    bif.Folder = project.DefaultLocation;

        //    if (bif.ShowDialog() == DialogResult.OK)
        //    {
        //        List<ProjectDocument> addTarget = project.Documents;

        //        TreeNode selNode = imageTree1.SelectedNode;
        //        if (selNode != null)
        //        {
        //            addTarget = (selNode.Tag as ProjectDocument).Documents;
        //        }

        //        foreach (ProjectDocument pd in bif.NewDocumentList)
        //        {
        //            //project.Documents.Add(pd);
        //            addTarget.Add(pd);
        //        }

        //        imageTree1.Nodes.Clear();
        //        AddToTree(imageTree1.Nodes, project.Documents);
        //    }
        //}

        private void imageTree1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Page pd = e.Node.Tag as Page;

            //markDownDisplay1.Enabled = (pd != null);
            markDownEditor1.Enabled = (pd != null);

            if ((pd != null) && (pd.DocumentType != "Folder"))
            {
                selectedPage = pd;
                try
                {
                    //FileInfo fi = new FileInfo(pd.Location);
                    //pd.Updated = fi.LastWriteTime.ToString();
                }
                catch { }
            }
            else
            {
                selectedPage = new();
            }

            //bindingSource.DataSource = selectedProjectDocument;

            string fileName = Path.ChangeExtension(Folders.GetConfigFileName(pd.Id), "md");

            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, pd.Name);
            }

            //markDownDisplay1.FileName = fileName;
            //markDownDisplay1.ReadOnly = false;

            //markDownEditor1.FileName = fileName;
            markDownEditor1.DocumentText = File.ReadAllText(fileName);
            markDownEditor1.ViewMode = true;
            markDownEditor1.Enabled = true;

            //// https://stackoverflow.com/questions/14941537/better-way-to-update-bound-controls-when-changing-the-datasource
            //foreach (Control c in tabPageDocuments.Controls)
            //    foreach (Binding b in c.DataBindings)
            //        b.ReadValue();

        }

        private void imageTree1_DragDrop(object sender, DragEventArgs e)
        {
            //// what if it is a folder?????
            //string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            //if (filePaths.Length > 0)
            //{
            //    // Convert to client coordinates
            //    Point clientPoint = imageTree1.PointToClient(new Point(e.X, e.Y));

            //    //TreeViewHitTestInfo info = treeView1.HitTest(e.X, e.Y);
            //    TreeViewHitTestInfo info = imageTree1.HitTest(clientPoint.X, clientPoint.Y);
            //    TreeNode hitNode;
            //    if (info.Node != null)
            //    {
            //        hitNode = info.Node;
            //        //MessageBox.Show(hitNode.Level.ToString());

            //        foreach (string str in filePaths)
            //        {
            //            imageTree1.SelectedNode = hitNode;
            //            ProjectDocument pd = new ProjectDocument();
            //            pd.Name = Path.GetFileName(str);
            //            pd.Location = str;
            //            if (Directory.Exists(str))   // it's a directory
            //            {
            //                AddDirectory(str);
            //            }
            //            else
            //            {
            //                AddDocument(pd);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        foreach (string str in filePaths)
            //        {
            //            imageTree1.SelectedNode = null;
            //            ProjectDocument pd = new ProjectDocument();
            //            pd.Name = Path.GetFileName(str);
            //            pd.Location = str;
            //            if (Directory.Exists(str))   // it's a directory
            //            {
            //                AddDirectory(str);
            //            }
            //            else
            //            {
            //                AddDocument(pd);
            //            }
            //        }
            //    }
            //}
        }

        private void imageTree1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string value = (string)e.Data.GetData(DataFormats.Text);
                try
                {
                    UriBuilder builder = new UriBuilder(value);
                    if ((builder.Scheme == "http") || (builder.Scheme == "https"))
                    {
                        e.Effect = DragDropEffects.Link;
                    }
                }
                catch
                {
                    e.Effect = DragDropEffects.None;
                }
            }

            // https://stackoverflow.com/questions/4364437/get-the-path-of-a-file-dragged-into-a-windows-forms-form
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //e.Effect = DragDropEffects.Copy;
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void imageTree1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //            OpenDocument();
        }

        private void toolStripButtonAddUrl_Click(object sender, EventArgs e)
        {
            //UrlForm uf = new();
            //if (uf.ShowDialog() == DialogResult.OK)
            //{
            //    AddDocument(uf.Document);
            //}
        }

        public string FileName { get; set; }


        //private async void dataGridView1_DragDrop(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.StringFormat))
        //    {
        //        string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

        //        if (dataString.StartsWith("http", StringComparison.OrdinalIgnoreCase))
        //        {

        //        }
        //        else
        //        {
        //            // because Chrome removes this part, by default
        //            // If you drag the lock icon, instead of the text it will include the full https://
        //            dataString = "https://" + dataString;
        //        }

        //        await SaveEdits();

        //        ChainLink newLink = new ChainLink();
        //        newLink.Chain = string.Empty;
        //        newLink.Url = dataString;
        //        newLink.DisplayText = await GetDescription(dataString);

        //        links.Add(newLink);
        //        await dataService.CreateChainLink(newLink);

        //        //Item = newJob;
        //        //bs.DataSource = Item;

        //        dataGridView1.CurrentCell = dataGridView1.Rows[idxNewRow].Cells[0];
        //        dataGridView1.CurrentRow.Selected = true;

        //        dataGridView1_SelectionChanged(sender, EventArgs.Empty);
        //    }
        //}

        //private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.Text))
        //        e.Effect = DragDropEffects.Copy;
        //    else
        //        e.Effect = DragDropEffects.None;
        //}

        private async Task<string> GetDescription(string url)
        {
            string rtnVal = "";

            //using HttpClient client = new()
            //{
            //    BaseAddress = new Uri(url),
            //};

            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", "web api client");

            //using HttpResponseMessage response = await client.GetAsync("");

            //var stringResponse = await response.Content.ReadAsStringAsync();

            //int titleStart = stringResponse.IndexOf("<title>", StringComparison.OrdinalIgnoreCase);
            //if (titleStart != -1)
            //{
            //    titleStart += 7;
            //    int titleEnd = stringResponse.IndexOf("</title>", titleStart, StringComparison.OrdinalIgnoreCase);

            //    rtnVal = stringResponse.Substring(titleStart, (titleEnd - titleStart));
            //    textBox6.DataBindings[0].ReadValue();
            //}

            return rtnVal;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //Text = textBox1.Text;
        }

        private void imageTree1_MouseHover(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenDocument();
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (imageTree1.SelectedNode != null)
            //{
            //    DocumentDetails dd = new();
            //    selectedProjectDocument = imageTree1.SelectedNode.Tag as ProjectDocument;

            //    dd.Document = selectedProjectDocument;
            //    if (dd.ShowDialog() == DialogResult.OK)
            //    {
            //        selectedProjectDocument = dd.Document;
            //        bindingSource.ResetBindings(false);
            //        FixNode(imageTree1.SelectedNode);
            //    }
            //}
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
            if (e.Node.Tag == null)
                return;

            Page pd = e.Node.Tag as Page;
            if (pd != null)
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

            //string folder = Folders.DefaultProjectFolder;

            //Directory.CreateDirectory(folder);

            //string name = Guid.NewGuid().ToString();
            //string fileName = Path.ChangeExtension(Path.Combine(folder, name), "md");

            //File.WriteAllText(fileName, "Hello");
        }

        private async void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Page pg = new Page { DocumentType = "Folder", Name = "New Folder" };
            AddDocument(pg);
        }

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            bool deleteFile = false;
            switch (MessageBox.Show("Delete underlying file as well?", "Verification", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Cancel:
                    return;
                case DialogResult.Yes:
                    deleteFile = true;
                    break;
                default:
                    deleteFile = false;
                    break;
            }

            Page pd = new();
            TreeNodeCollection coll = imageTree1.Nodes;
            List<Page> pageList = pages;

            if ((imageTree1.SelectedNode != null) && ((imageTree1.SelectedNode.Parent != null)))
            {
                coll = imageTree1.SelectedNode.Parent.Nodes;
                pageList = (imageTree1.SelectedNode.Parent.Tag as Page).Pages;
            }

            int index = coll.IndexOf(imageTree1.SelectedNode);

            //string fileName = (imageTree1.SelectedNode.Tag as Page).Location;

            //try
            //{
            //    File.Delete(fileName);
            //}
            //catch { }

            coll.RemoveAt(index);
            pageList.RemoveAt(index);
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            Page pg = new Page { DocumentType = "Page", Name = "New Page" };
            AddDocument(pg);
        }

        private void markDownEditor1_SaveClicked(object sender, EventArgs e)
        {
            string fileName = Path.ChangeExtension(Folders.GetConfigFileName(selectedPage.Id), "md");

            File.WriteAllText(fileName, markDownEditor1.DocumentText);
        }

        //private void imageTree1_InfoTipRequested(object sender, ProjectCrossroads.ImageTree.InfoTipEventArgs e)
        //{
        //    ProjectDocument pd = e.Node.Tag as ProjectDocument;
        //    if ((pd != null) && (pd.DocumentType != "Folder"))
        //    {
        //        e.ToolTipText = $"Filename: {Path.GetFileName(pd.Location)}\r\nUpdated: {pd.Updated}\r\nLast Viewed: {pd.LastViewed}";
        //    }
        //    else
        //    {
        //        e.ToolTipText = e.Node.ToolTipText;
        //    }
        //}
    }
}
