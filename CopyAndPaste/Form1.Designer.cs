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
        //private TreeView selectView;
        private ToolStripMenuItem folderMenuItem;
        private TextBox selectBox;
        private TextBox targetBox;
        private ToolTip toolTip2;
        private Label processinglabel;
        private ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker copybackgroundworker;
        private System.ComponentModel.BackgroundWorker loadingpercentage;
        private Button fileNumberButton;
        private TextBox fileNumberText;
        private TriStateTreeView triStateTreeView;
    }
}

