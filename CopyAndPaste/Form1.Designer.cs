using System.Windows.Forms;

namespace CopyAndPaste
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Button submitButton;
        private Button selectButton;
        private Label selectPath;
        private Button targetButton;
        private Label targetPath;
        private TreeView selectView;
        private ProgressBar progressBar1;
        private ToolStripMenuItem folderMenuItem;
        private TextBox selectBox;
        private TextBox targetBox;
        private FolderBrowserDialog folderBrowserDialog3;
        private FolderBrowserDialog folderBrowserDialog4;
        private ToolTip toolTip2;
    }
}

