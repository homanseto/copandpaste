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
            //UseWaitCursor = true;
            InitializeComponent();
            //    UseWaitCursor = false;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.selectBox = new System.Windows.Forms.TextBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.selectPath = new System.Windows.Forms.Label();
            this.targetButton = new System.Windows.Forms.Button();
            this.targetBox = new System.Windows.Forms.TextBox();
            this.targetPath = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.folderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.processinglabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.copybackgroundworker = new System.ComponentModel.BackgroundWorker();
            this.fileNumberButton = new System.Windows.Forms.Button();
            this.fileNumberText = new System.Windows.Forms.TextBox();
            this.progressbackgorundworker = new System.ComponentModel.BackgroundWorker();
            this.triStateTreeView = new CopyAndPaste.TriStateTreeView();
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
            // fileNumberButton
            // 
            this.fileNumberButton.Location = new System.Drawing.Point(259, 405);
            this.fileNumberButton.Name = "fileNumberButton";
            this.fileNumberButton.Size = new System.Drawing.Size(75, 23);
            this.fileNumberButton.TabIndex = 11;
            this.fileNumberButton.Text = "file number";
            this.fileNumberButton.UseVisualStyleBackColor = true;
            this.fileNumberButton.Click += new System.EventHandler(this.file_Click);
            // 
            // fileNumberText
            // 
            this.fileNumberText.Location = new System.Drawing.Point(72, 408);
            this.fileNumberText.Name = "fileNumberText";
            this.fileNumberText.Size = new System.Drawing.Size(181, 20);
            this.fileNumberText.TabIndex = 12;
            // 
            // progressbackgorundworker
            // 
            this.progressbackgorundworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.pogressbackgroundworker_DoWork);
            this.progressbackgorundworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.pogressbackgroundworker_RunWorkerCompleted);
            // 
            // triStateTreeView
            // 
            this.triStateTreeView.Location = new System.Drawing.Point(12, 74);
            this.triStateTreeView.Name = "triStateTreeView";
            this.triStateTreeView.Size = new System.Drawing.Size(709, 260);
            this.triStateTreeView.TabIndex = 3;
            this.triStateTreeView.TriStateStyleProperty = CopyAndPaste.TriStateTreeView.TriStateStyles.Standard;
            this.triStateTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.triStateTreeView1_BeforeExpand);
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
            this.Controls.Add(this.triStateTreeView);
            this.Controls.Add(this.selectPath);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.selectBox);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        List<TreeNode> checkedList = new List<TreeNode>();
        private int downloadedNum
        {
            get { return this.downloadedNum; }
            set
            {
                this.downloadedNum = value;
            }
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
            this.triStateTreeView.Nodes.Clear();
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
            TreeNode tds = triStateTreeView.Nodes.Add(di.Name);
            tds.Tag = di.FullName;
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
                    tds.Tag = di.FullName;
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
            };
        }
        private void triStateTreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // A node in the tree has been selected
            TreeView tv = sender as TreeView;
            tv.UseWaitCursor = true;

            //if ((e.Node.Nodes.Count == 1) && (e.Node.Nodes[0].Text == ""))
            //{
            string path = e.Node.Tag as string;
            e.Node.Nodes.Clear();
            LoadSubDirectories(path, e.Node);
            LoadFiles(path, e.Node);
            //}

            tv.UseWaitCursor = false;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.selectBox.Text) && !String.IsNullOrEmpty(this.targetBox.Text))
            {
                this.submitButton.Enabled = false;
                this.submitButton.ForeColor = Color.Gray;
                this.selectButton.Enabled = false;
                this.targetButton.Enabled = false;
                this.progressBar1.Visible = true;
                this.progressBar1.Enabled = true;
                copybackgroundworker.RunWorkerAsync();
                progressbackgorundworker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Select both directories");
            }
        }

        private void UpdataPeogress()
        {
            this.progressBar1.Value = downloadedNum;
            if (this.progressBar1.Value < this.progressBar1.Maximum)
            {
                int percent = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);
                progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                Application.DoEvents();
            }

        }
        private void pogressbackgroundworker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.progressBar1.Maximum = FileNoumber();
          
        }

        private void pogressbackgroundworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void copybackgroundworker_DoWork(object sender, DoWorkEventArgs e)
        {
            checkedList.Clear();
            loadCheckedList(this.triStateTreeView.Nodes[0]);
            this.CopyDirectory(this.selectBox.Text, checkedList, this.targetBox.Text);
        }
        private void loadCheckedList(TreeNode parent)
        {
            if (!parent.Checked)
            {
                foreach (TreeNode node in parent.Nodes)
                {
                    if (node.StateImageIndex == -1 || node.StateImageIndex == 0)
                    {
                        continue;
                    }
                    else if (node.StateImageIndex == 2)
                    {
                        loadCheckedList(node);
                    }
                    else if (node.StateImageIndex == 1)
                    {
                        checkedList.Add(node);
                    }
                }
            }
            else
            {
                checkedList.Add(parent);
            }
        }

        private void CopyDirectory(string selectPath, List<TreeNode> sourceList, string targetPath)
        {
            ConcurrentDictionary<string, object> lockDict = new ConcurrentDictionary<string, object>();
            downloadedNum = 0;
            Parallel.ForEach(sourceList, new ParallelOptions() { MaxDegreeOfParallelism = 5 }, (i) =>
            {
                var attr = File.GetAttributes(i.Tag.ToString());
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    Parallel.ForEach(Directory.EnumerateFiles(i.Tag.ToString(), "*", SearchOption.AllDirectories), new ParallelOptions() { MaxDegreeOfParallelism = 20 }, (j) =>
                    {
                        try
                        {
                            string fileName = j.Split('\\').Last();
                            string filePathDir = j.Replace(fileName, "");
                            string targetDir = filePathDir.Replace(selectPath, targetPath);

                            var lockObj = new object();
                            var checking = lockDict.TryAdd($"{targetDir}\\{fileName}", lockObj);
                            if (checking)
                            {
                                if (!Directory.Exists(targetDir))
                                {
                                    Directory.CreateDirectory(targetDir);
                                }
                                File.Copy(j, $"{targetDir}\\{fileName}", true);
                                downloadedNum++;

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    });
                }
                else
                {
                    var lockObj = new object();
                    string fileName = i.Tag.ToString().Split('\\').Last();
                    string filePathDir = i.Tag.ToString().Replace(fileName, "");
                    string targetDir = filePathDir.Replace(selectPath, targetPath);
                    var checking = lockDict.TryAdd($"{targetDir}\\{fileName}", lockObj);
                    if (checking)
                    {
                        if (!Directory.Exists(targetDir))
                        {
                            Directory.CreateDirectory(targetDir);
                        }
                        File.Copy(i.Tag.ToString(), $"{targetDir}\\{fileName}", true);
                        downloadedNum++;

                    }
                }
            });
        }
        private void copybackgroundworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = progressBar1.Enabled = false;
            MessageBox.Show("Finished");
            this.submitButton.Enabled = true;
            this.selectButton.Enabled = true;
            this.targetButton.Enabled = true;
            this.submitButton.ForeColor = Color.Black;
        }
        private void file_Click(object sender, EventArgs e)
        {
            this.fileNumberText.Text = FileNoumber().ToString();
            this.fileNumberButton.Enabled = true;
            this.fileNumberButton.ForeColor = Color.Black;
        }
        private int FileNoumber()
        {
            checkedList.Clear();
            this.fileNumberButton.Enabled = false;
            this.fileNumberButton.ForeColor = Color.Gray;
            loadCheckedList(this.triStateTreeView.Nodes[0]);
            int total = 0;
            foreach (var i in checkedList)
            {
                var attr = File.GetAttributes(i.Tag.ToString());
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    var files = Directory.GetFiles(i.Tag.ToString(), "*", SearchOption.AllDirectories);
                    foreach (var f in files)
                    {
                        total++;
                    }
                }
                else
                {
                    total++;
                }
            }
            return total;
        }

    }
}
