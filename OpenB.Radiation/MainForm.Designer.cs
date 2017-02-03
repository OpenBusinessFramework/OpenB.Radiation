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
            this.modelDesignPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addModelDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelDefinition1 = new OpenB.Radiation.Controls.ModelDefinition();
            this.modelDefinition2 = new OpenB.Radiation.Controls.ModelDefinition();
            this.modelDesignPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // modelDesignPanel
            // 
            this.modelDesignPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modelDesignPanel.Controls.Add(this.modelDefinition1);
            this.modelDesignPanel.Controls.Add(this.modelDefinition2);
            this.modelDesignPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelDesignPanel.Location = new System.Drawing.Point(0, 24);
            this.modelDesignPanel.Name = "modelDesignPanel";
            this.modelDesignPanel.Size = new System.Drawing.Size(1173, 442);
            this.modelDesignPanel.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.designToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1173, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.newProjectToolStripMenuItem.Text = "&New project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
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
            this.addModelDefinitionToolStripMenuItem.Name = "addModelDefinitionToolStripMenuItem";
            this.addModelDefinitionToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.addModelDefinitionToolStripMenuItem.Text = "&Add Model Definition";
            this.addModelDefinitionToolStripMenuItem.Click += new System.EventHandler(this.addModelDefinitionToolStripMenuItem_Click);
            // 
            // modelDefinition1
            // 
            this.modelDefinition1.AllowMove = true;
            this.modelDefinition1.BackColor = System.Drawing.Color.White;
            this.modelDefinition1.BorderColor = System.Drawing.Color.Black;
            this.modelDefinition1.DefinitionName = "Test";
            this.modelDefinition1.Location = new System.Drawing.Point(13, 12);
            this.modelDefinition1.Name = "modelDefinition1";
            this.modelDefinition1.Size = new System.Drawing.Size(217, 201);
            this.modelDefinition1.TabIndex = 0;
            this.modelDefinition1.Text = "modelDefinition1";
            // 
            // modelDefinition2
            // 
            this.modelDefinition2.AllowMove = true;
            this.modelDefinition2.BackColor = System.Drawing.Color.White;
            this.modelDefinition2.BorderColor = System.Drawing.Color.Black;
            this.modelDefinition2.DefinitionName = "Another test";
            this.modelDefinition2.Location = new System.Drawing.Point(13, 219);
            this.modelDefinition2.Name = "modelDefinition2";
            this.modelDefinition2.Size = new System.Drawing.Size(164, 198);
            this.modelDefinition2.TabIndex = 1;
            this.modelDefinition2.Text = "modelDefinition2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1173, 466);
            this.Controls.Add(this.modelDesignPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.modelDesignPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ModelDefinition modelDefinition1;
        private Controls.ModelDefinition modelDefinition2;
        private System.Windows.Forms.Panel modelDesignPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem designToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addModelDefinitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
    }
}

