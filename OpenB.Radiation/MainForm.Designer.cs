namespace OpenB.Radiation
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addModelDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.loadProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.designToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1173, 24);
            this.menuMain.TabIndex = 3;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.loadProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.newProjectToolStripMenuItem.Text = "&New project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Enabled = false;
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.saveProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.saveProjectToolStripMenuItem.Text = "&Save project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // designToolStripMenuItem
            // 
            this.designToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addModelDefinitionToolStripMenuItem});
            this.designToolStripMenuItem.Name = "designToolStripMenuItem";
            this.designToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.designToolStripMenuItem.Text = "&Design";
            // 
            // addModelDefinitionToolStripMenuItem
            // 
            this.addModelDefinitionToolStripMenuItem.Enabled = false;
            this.addModelDefinitionToolStripMenuItem.Name = "addModelDefinitionToolStripMenuItem";
            this.addModelDefinitionToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.addModelDefinitionToolStripMenuItem.Text = "&Add Model Definition";
            this.addModelDefinitionToolStripMenuItem.Click += new System.EventHandler(this.addModelDefinitionToolStripMenuItem_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 444);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1173, 22);
            this.mainStatusStrip.TabIndex = 4;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 420);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(3, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer.Size = new System.Drawing.Size(1170, 420);
            this.splitContainer.SplitterDistance = 248;
            this.splitContainer.TabIndex = 6;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(248, 420);
            this.treeView1.TabIndex = 0;
            // 
            // loadProjectToolStripMenuItem
            // 
            this.loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
            this.loadProjectToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.loadProjectToolStripMenuItem.Text = "&Load project";
            this.loadProjectToolStripMenuItem.Click += new System.EventHandler(this.loadProjectToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1173, 466);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.Text = "Radiaton | The Open Business Framework IDE ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem designToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addModelDefinitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem loadProjectToolStripMenuItem;
    }
}

