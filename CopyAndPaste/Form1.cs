using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CopyAndPaste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.selectBox = new System.Windows.Forms.TextBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.selectPath = new System.Windows.Forms.Label();
            this.selectView = new System.Windows.Forms.TreeView();
            this.targetButton = new System.Windows.Forms.Button();
            this.targetBox = new System.Windows.Forms.TextBox();
            this.targetPath = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.submitButton = new System.Windows.Forms.Button();
            this.folderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog3 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog4 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // selectBox
            // 
            this.selectBox.Location = new System.Drawing.Point(134, 31);
            this.selectBox.Name = "selectBox";
            this.selectBox.Size = new System.Drawing.Size(556, 20);
            this.selectBox.TabIndex = 0;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(696, 31);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(28, 23);
            this.selectButton.TabIndex = 1;
            this.selectButton.Text = "...";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.select_Click);
            // 
            // selectPath
            // 
            this.selectPath.AutoSize = true;
            this.selectPath.Location = new System.Drawing.Point(12, 35);
            this.selectPath.Name = "selectPath";
            this.selectPath.Size = new System.Drawing.Size(82, 13);
            this.selectPath.TabIndex = 2;
            this.selectPath.Text = "Select Directory";
            // 
            // selectView
            // 
            this.selectView.Location = new System.Drawing.Point(12, 74);
            this.selectView.Name = "selectView";
            this.selectView.Size = new System.Drawing.Size(702, 260);
            this.selectView.TabIndex = 3;
            this.selectView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.selectView_AfterCheck);
            // 
            // targetButton
            // 
            this.targetButton.Location = new System.Drawing.Point(696, 340);
            this.targetButton.Name = "targetButton";
            this.targetButton.Size = new System.Drawing.Size(28, 23);
            this.targetButton.TabIndex = 4;
            this.targetButton.Text = "...";
            this.targetButton.UseVisualStyleBackColor = true;
            this.targetButton.Click += new System.EventHandler(this.target_Click);
            // 
            // targetBox
            // 
            this.targetBox.Location = new System.Drawing.Point(134, 340);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new System.Drawing.Size(556, 20);
            this.targetBox.TabIndex = 5;
            // 
            // targetPath
            // 
            this.targetPath.AutoSize = true;
            this.targetPath.Location = new System.Drawing.Point(10, 344);
            this.targetPath.Name = "targetPath";
            this.targetPath.Size = new System.Drawing.Size(105, 13);
            this.targetPath.TabIndex = 6;
            this.targetPath.Text = "Destination Directory";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 378);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(536, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(602, 378);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(122, 23);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "Copy Directories";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submit_Click);
            // 
            // folderBrowserDialog3
            // 
            this.folderBrowserDialog3.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            this.folderBrowserDialog3.ShowNewFolderButton = false;
            // 
            // folderBrowserDialog4
            // 
            this.folderBrowserDialog4.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            this.folderBrowserDialog4.ShowNewFolderButton = false;
            // 
            // folderMenuItem
            // 
            this.folderMenuItem.Name = "folderMenuItem";
            this.folderMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(732, 413);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.targetPath);
            this.Controls.Add(this.targetBox);
            this.Controls.Add(this.targetButton);
            this.Controls.Add(this.selectView);
            this.Controls.Add(this.selectPath);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.selectBox);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void select_Click(object sender, EventArgs e)
        {
            DialogResult drResult = folderBrowserDialog3.ShowDialog();
            if (drResult == DialogResult.OK)
            {
                this.selectBox.Text = folderBrowserDialog3.SelectedPath;
            }
            selectView.Nodes.Clear();
            toolTip2.ShowAlways = true;
            if (!String.IsNullOrEmpty(this.selectBox.Text) && Directory.Exists(this.selectBox.Text))
            {
                LoadDirectory(this.selectBox.Text);
            }
            else
            {
                MessageBox.Show("Select Directory");
            }
        }
        private void target_Click(object sender, EventArgs e)
        {
            DialogResult drResult = folderBrowserDialog4.ShowDialog();
            if (drResult == DialogResult.OK)
            {
                this.targetBox.Text = folderBrowserDialog4.SelectedPath;
            }

        }

        private void LoadDirectory(string list)
        {
            DirectoryInfo di = new DirectoryInfo(list);
            TreeNode tds = selectView.Nodes.Add(di.Name);
            tds.Checked = true;
            tds.Tag = di.FullName;
            tds.StateImageIndex = 0;

            //LoadFiles(list, tds);
            LoadSubDirectories(list, tds);
        }
        private void LoadSubDirectories(string dir, TreeNode td)
        {
            Dictionary<string, Tuple<string, TreeNode>> tmp = new Dictionary<string, Tuple<string, TreeNode>>();

            List<string> subdirectoryEntries = Directory.EnumerateDirectories(dir, "*", SearchOption.TopDirectoryOnly).ToList();
            if (subdirectoryEntries.Count > 0)
            {
              foreach (string subdirectory in subdirectoryEntries)
                {
                    DirectoryInfo di = new DirectoryInfo(subdirectory);
                    TreeNode tds = td.Nodes.Add(di.Name);
                    tds.StateImageIndex = 0;
                    tds.Tag = di.FullName;
                    if (td.Checked)
                    {
                        tds.Checked = true;
                    }
                    //LoadFiles(subdirectory, tds);
                }
            }
        }

        private void selectView_MouseMove(object sender, MouseEventArgs e)
        {

            // Get the node at the current mouse pointer location.  
            TreeNode theNode = this.selectView.GetNodeAt(e.X, e.Y);

            // Set a ToolTip only if the mouse pointer is actually paused on a node.  
            if (theNode != null && theNode.Tag != null)
            {
                // Change the ToolTip only if the pointer moved to a new node.  
                if (theNode.Tag.ToString() != this.toolTip2.GetToolTip(this.selectView))
                    this.toolTip2.SetToolTip(this.selectView, theNode.Tag.ToString());

            }
            else     // Pointer is not over a node so clear the ToolTip.  
            {
                this.toolTip2.SetToolTip(this.selectView, "");
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            List<string> clickedList = new List<string>();
            if (!String.IsNullOrEmpty(this.selectBox.Text) && !String.IsNullOrEmpty(this.targetBox.Text))
            {


                foreach (TreeNode node in this.selectView.Nodes[0].Nodes)
                {
                    if (node.Checked)
                    {
                        clickedList.Add($"{this.selectBox.Text}\\{node.Text}");
                    }
                }

                this.CopyDirectory(this.selectBox.Text, clickedList, this.targetBox.Text);
                MessageBox.Show("Finished");
            }
        }

        private void CopyDirectory(string selectPath, List<string> sourceList, string targetPath)
        {

            Parallel.ForEach(sourceList, new ParallelOptions() { MaxDegreeOfParallelism = 5 }, (folder) =>
            {
                Parallel.ForEach(Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories), new ParallelOptions() { MaxDegreeOfParallelism = 10 }, (file) =>
                {

                    string fileName = file.Split('\\').Last();
                    string filePathDir = file.Replace(fileName, "");
                    string targetDir = filePathDir.Replace(selectPath, targetPath);
                    if (!Directory.Exists(targetDir))
                    {
                        Directory.CreateDirectory(targetDir);
                    }

                    try
                    {
                        File.Copy(file, $"{targetDir}\\{fileName}", true);
                    }
                    catch (Exception ex)
                    {

                    }

                });
            });
        }

        private List<string> getDirectory(string path, string option)
        {
            if (option == "all")
            {
                return Directory.GetDirectories(path, "*", SearchOption.AllDirectories).ToList();
            }
            else if (option == "top")
            {
                return Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly).ToList();
            }
            else
            {
                return new List<string>();
            }

        }

        private void LoadFiles(string dir, TreeNode td)
        {
            List<string> Files = Directory.GetFiles(dir, "*.*").ToList();

            // Loop through them to see files  
            Parallel.ForEach(Files, new ParallelOptions() { MaxDegreeOfParallelism = 20 }, (file) =>
            {
                FileInfo fi = new FileInfo(file);
                TreeNode tds = td.Nodes.Add(fi.Name);
                tds.Tag = fi.FullName;
                tds.StateImageIndex = 1;
            });
        }

        private void selectView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode n in e.Node.Nodes)
            {
                n.Checked = e.Node.Checked;
            }
        }

    }
}
