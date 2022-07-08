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
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.Concurrent;
//using Microsoft.WindowsAPICodePack.Dialogs;


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
            this.submitButton = new System.Windows.Forms.Button();
            this.folderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.processinglabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.copybackgroundworker = new System.ComponentModel.BackgroundWorker();
            this.loadingpercentage = new System.ComponentModel.BackgroundWorker();
            this.fileNumberButton = new System.Windows.Forms.Button();
            this.fileNumberText = new System.Windows.Forms.TextBox();
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
            this.selectView.CheckBoxes = true;
            this.selectView.Location = new System.Drawing.Point(12, 74);
            this.selectView.Name = "selectView";
            this.selectView.Size = new System.Drawing.Size(709, 260);
            this.selectView.TabIndex = 3;
            this.selectView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.selectView_AfterCheck);
            this.selectView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.selectView_AfterExpand);
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
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(602, 373);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(122, 23);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "Copy Directories";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submit_Click);
            // 
            // folderMenuItem
            // 
            this.folderMenuItem.Name = "folderMenuItem";
            this.folderMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // processinglabel
            // 
            this.processinglabel.AutoSize = true;
            this.processinglabel.Location = new System.Drawing.Point(30, 373);
            this.processinglabel.Name = "processinglabel";
            this.processinglabel.Size = new System.Drawing.Size(0, 13);
            this.processinglabel.TabIndex = 9;
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(72, 373);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(406, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Visible = false;
            // 
            // copybackgroundworker
            // 
            this.copybackgroundworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.copybackgroundworker_DoWork);
            this.copybackgroundworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.copybackgroundworker_RunWorkerCompleted);
            // 
            // loadingpercentage
            // 
            //this.loadingpercentage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loadingPercentage_DoWork);
            //this.loadingpercentage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.loadingPercentage_RunWorkerCompleted);
            // 
            // fileNumberButton
            // 
            this.fileNumberButton.Location = new System.Drawing.Point(259, 405);
            this.fileNumberButton.Name = "fileNumberButton";
            this.fileNumberButton.Size = new System.Drawing.Size(75, 23);
            this.fileNumberButton.TabIndex = 11;
            this.fileNumberButton.Text = "file number";
            this.fileNumberButton.UseVisualStyleBackColor = true;
            //this.fileNumberButton.Click += new System.EventHandler(this.number_Click);
            // 
            // fileNumberText
            // 
            this.fileNumberText.Location = new System.Drawing.Point(72, 408);
            this.fileNumberText.Name = "fileNumberText";
            this.fileNumberText.Size = new System.Drawing.Size(181, 20);
            this.fileNumberText.TabIndex = 12;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(733, 436);
            this.Controls.Add(this.fileNumberText);
            this.Controls.Add(this.fileNumberButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.processinglabel);
            this.Controls.Add(this.submitButton);
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
            CommonOpenFileDialog selectdialog = new CommonOpenFileDialog();
            selectdialog.Multiselect = true;
            selectdialog.InitialDirectory = "C:\\Users";
            selectdialog.IsFolderPicker = true;
            if (selectdialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                this.selectBox.Text = selectdialog.FileName;
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
            CommonOpenFileDialog targetdialog = new CommonOpenFileDialog();
            targetdialog.InitialDirectory = "C:\\Users";
            targetdialog.IsFolderPicker = true;
            if (targetdialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                this.targetBox.Text = targetdialog.FileName;
            }
        }

        private void LoadDirectory(string list)
        {
            DirectoryInfo di = new DirectoryInfo(list);
            TreeNode tds = selectView.Nodes.Add(di.Name);
            tds.Checked = true;
            tds.Tag = di.FullName;
            tds.StateImageIndex = 0;

            LoadFiles(list, tds);
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
                    tds.Nodes.Add("");
                }
            }
        }
        private void LoadFiles(string dir, TreeNode td)
        {
            List<string> Files = Directory.GetFiles(dir, "*.*").ToList();

            // Loop through them to see files  
            foreach (var file in Files)
            {
                FileInfo fi = new FileInfo(file);
                TreeNode tds = td.Nodes.Add(fi.Name);
                tds.Tag = fi.FullName;
                tds.StateImageIndex = 1;
                if (td.Checked)
                {
                    tds.Checked = true;
                }
            };
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
            progressBar1.Visible = true;
            progressBar1.Enabled = true;
            copybackgroundworker.RunWorkerAsync();
        }

        //private void number_Click(object sender, EventArgs e)
        //{
        //    List<string> clickedList = new List<string>();
        //    List<string> fileList = new List<string>();
        //    if (!String.IsNullOrEmpty(this.selectBox.Text))
        //    {
        //        if (this.selectView.Nodes[0].Nodes.Count != 0)
        //        {
        //            foreach (TreeNode node in this.selectView.Nodes[0].Nodes)
        //            {
        //                if (node.Checked)
        //                {
        //                    clickedList.Add($"{this.selectBox.Text}\\{node.Text}");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            clickedList.Add($"{this.selectBox.Text}");
        //        }
        //    }
        //    foreach (var file in clickedList)
        //    {
        //        var attr = File.GetAttributes(file);
        //        if (attr.HasFlag(FileAttributes.Directory))
        //        {
        //            List<string> list = Directory.GetFiles(file, "*", SearchOption.AllDirectories).ToList();
        //            fileList.AddRange(list);
        //        }
        //        else
        //        {
        //            fileList.Add(file);
        //        }
        //    }
        //    this.fileNumberText.Text = fileList.Count.ToString();
        //}

        private void copybackgroundworker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<TreeNode> clickedList = new List<TreeNode>();
            if (!String.IsNullOrEmpty(this.selectBox.Text) && !String.IsNullOrEmpty(this.targetBox.Text))
            {
                Console.WriteLine(this.selectView.Nodes[0].Nodes);
                var testResult = descendants(this.selectView.Nodes[0]).Where(x => x.Checked == true).ToList();
                foreach (TreeNode node in testResult)
                {
                    if(!String.IsNullOrEmpty(node.Text))
                    {
                        Console.WriteLine(node.FullPath);
                        clickedList.Add(node);
                    }
                }
                //if (this.selectView.Nodes[0].Nodes.Count != 0)
                //{
                //    foreach (TreeNode node in this.selectView.Nodes[0].Nodes)
                //    {
                //        if (node.Checked)
                //        {
                //            Console.WriteLine(node.Tag);
                //            Console.WriteLine($"{this.selectBox.Text}\\{node.Text}");
                //            clickedList.Add($"{this.selectBox.Text}\\{node.Text}");
                //        }
                //    }
                //}
                //else
                //{
                //    clickedList.Add($"{this.selectBox.Text}");
                //}

                this.CopyDirectory(this.selectBox.Text, clickedList, this.targetBox.Text);
            }
        }

        private List<TreeNode> descendants(TreeNode node)
        {
            var nodes = node.Nodes.Cast<TreeNode>().ToList();
            return nodes.SelectMany(x => descendants(x)).Concat(nodes).ToList();
        }

        private void copybackgroundworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = progressBar1.Enabled = false;
            MessageBox.Show("Finished");
        }

        //private void loadingPercentage_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    List<string> clickedList = new List<string>();
        //    List<string> fileList = new List<string>();
        //    if (!String.IsNullOrEmpty(this.selectBox.Text) && !String.IsNullOrEmpty(this.targetBox.Text))
        //    {
        //        if (this.selectView.Nodes[0].Nodes.Count != 0)
        //        {
        //            foreach (TreeNode node in this.selectView.Nodes[0].Nodes)
        //            {
        //                if (node.Checked)
        //                {
        //                    Console.WriteLine(node.Tag);
        //                    Console.WriteLine($"{this.selectBox.Text}\\{node.Text}");
        //                    clickedList.Add($"{this.selectBox.Text}\\{node.Text}");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            clickedList.Add($"{this.selectBox.Text}");
        //        }
        //    }
        //    foreach (var file in clickedList)
        //    {
        //        var attr = File.GetAttributes(file);
        //        if (attr.HasFlag(FileAttributes.Directory))
        //        {
        //            List<string> list = Directory.GetFiles(file, "*", SearchOption.AllDirectories).ToList();
        //        }
        //    }
        //}

        //private void loadingPercentage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{

        //}


        private void CopyDirectory(string selectPath, List<TreeNode> sourceList, string targetPath)
        {
            ConcurrentDictionary<string, object> lockDict = new ConcurrentDictionary<string, object>();
            Parallel.ForEach(sourceList, new ParallelOptions() { MaxDegreeOfParallelism = 5 }, (folder) =>
            {
                var attr = File.GetAttributes(folder.Tag.ToString());
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    Parallel.ForEach(Directory.EnumerateFiles(folder.Tag.ToString(), "*", SearchOption.AllDirectories), new ParallelOptions() { MaxDegreeOfParallelism = 20 }, (file) =>
                    {
                        string fileName = file.Split('\\').Last();
                        string filePathDir = file.Replace(fileName, "");
                        string targetDir = filePathDir.Replace(selectPath, targetPath);

                        var lockObj = new object();
                        var checking = lockDict.TryAdd($"{targetDir}\\{fileName}", lockObj);
                        if (checking)
                        {
                            //try
                            //{
                            if (!Directory.Exists(targetDir))
                            {
                                Directory.CreateDirectory(targetDir);
                            }
                            File.Copy(file, $"{targetDir}\\{fileName}", true);
                            //}
                            //catch (Exception ex)
                            //{
                            //    //log
                            //}
                        }
                    });
                }
                else
                {
                    var lockObj = new object();
                    string fileName = folder.Tag.ToString().Split('\\').Last();
                    string filePathDir = folder.Tag.ToString().Replace(fileName, "");
                    string targetDir = filePathDir.Replace(selectPath, targetPath);
                    var checking = lockDict.TryAdd($"{targetDir}\\{fileName}", lockObj);
                    if (checking)
                    {
                        if (!Directory.Exists(targetDir))
                        {
                            Directory.CreateDirectory(targetDir);
                        }
                        File.Copy(folder.Tag.ToString(), $"{targetDir}\\{fileName}", true);
                    }
                }
            });
        }

        private void selectView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode n in e.Node.Nodes)
            {
                n.Checked = e.Node.Checked;
            }
        }

        private void selectView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            string path = e.Node.Tag as string;
            e.Node.Nodes.Clear();
            LoadSubDirectories(path, e.Node);
            LoadFiles(path, e.Node);
        }

    }
}
