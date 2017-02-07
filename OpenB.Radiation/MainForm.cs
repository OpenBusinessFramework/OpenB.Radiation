using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using OpenB.Radiation.Controls;
using OpenB.Radiation.Views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace OpenB.Radiation
{
    public partial class MainForm : Form
    {
        private ProjectView projectView;

        private TreeNode modelTreeNode; 

        public override void Refresh()
        {      
            RefreshTitle();

            if (projectView.Name != null)
            {
                TreeNode projectNode = treeView1.Nodes.Add("Project");
                projectNode.NodeFont = new Font(FontFamily.GenericSansSerif, 13, FontStyle.Bold);

                modelTreeNode = projectNode.Nodes.Add("Models");
                modelTreeNode.NodeFont = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold);
                modelTreeNode.ContextMenu = new ContextMenu();

                RefreshModelNodes();
                RefreshModels();

                MenuItem modelContextMenuCreateNewItem = new MenuItem("&Create");
                
                modelTreeNode.ContextMenu.MenuItems.Add(modelContextMenuCreateNewItem);

                TreeNode workflowTreeNode = projectNode.Nodes.Add("Workflow");
                workflowTreeNode.NodeFont = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold);
                
                TreeNode tasksTreeNode = projectNode.Nodes.Add("Tasks");
                tasksTreeNode.NodeFont = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold);

                treeView1.Refresh();
            }

            base.Refresh();
        }

        private void RefreshModels()
        {
            foreach(ModelDefinitionView modelDefinitionView in projectView.ModelDefinitions)
            {
                if (!string.IsNullOrEmpty(modelDefinitionView.Key))
                {
                    ModelDefinition modelDefinition = new ModelDefinition(modelDefinitionView);

                  

                    splitContainer.Panel2.Controls.Add(modelDefinition);
                    RefreshModelNodes();
                }
            }
           
        }

        private void RefreshModelNodes()
        {
           

            foreach (ModelDefinitionView modelDefinitionView in projectView.ModelDefinitions)
            {
                TreeNode modelDefinitionTreeNode = modelTreeNode.Nodes.Add(modelDefinitionView.Name);
                modelDefinitionTreeNode.Tag = modelDefinitionView;
            }
        }

        private void RefreshTitle()
        {
            var title = "Radiation | The Open Business Framework IDE";

            if (projectView.Name != null)
            {
                title = string.Concat(title, " - ", projectView.Name);
            }

            addModelDefinitionToolStripMenuItem.Enabled = projectView.AllowAddingModelDefinitions;
            saveProjectToolStripMenuItem.Enabled = !string.IsNullOrEmpty(projectView.Name);

            this.Text = title;
        }

        public MainForm()
        {
            projectView = new ProjectView();

            InitializeComponent();

            ModelDefinitionDiagram modelDefinitionDiagram = new ModelDefinitionDiagram(projectView);
            modelDefinitionDiagram.Anchor = AnchorStyles.Left;

            mainStatusStrip.Text = "No project loaded.";
            mainStatusStrip.Refresh();

            Controls.Add(modelDefinitionDiagram);

            DoubleBuffered = true;           

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
           

        }

        private void addModelDefinitionToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var modelDefinitionView = new ModelDefinitionView(); 
            ModelDefinitionForm modelDefinitionForm = new ModelDefinitionForm(modelDefinitionView);
            modelDefinitionForm.ShowDialog(this);

            if (!string.IsNullOrEmpty(modelDefinitionView.Key))
            {
                ModelDefinition modelDefinition = new ModelDefinition(modelDefinitionView);
              
                modelDefinition.Width = 200;
                modelDefinition.Height = 100;
                modelDefinition.BorderColor = System.Drawing.Color.Black;
                modelDefinition.BackColor = System.Drawing.Color.White;
                modelDefinition.AllowMove = true;

                splitContainer.Panel2.Controls.Add(modelDefinition);
                RefreshModelNodes();
            }

            this.projectView.ModelDefinitions.Add(modelDefinitionView);
           
        }

        private void newProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm(projectView);
            
            projectForm.StartPosition = FormStartPosition.CenterParent;

            DialogResult result = projectForm.ShowDialog(this);

            Refresh();
        }

        private void saveProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(projectView.FileName))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    Filter = "OpenB Projects|*.project.xml"
                };

                var result = saveFileDialog.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    projectView.FileName = saveFileDialog.FileName;
                }

                projectView.Save();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (!projectView.IsSaved && !string.IsNullOrEmpty(projectView.Name))
            {
               DialogResult exitResult = MessageBox.Show("Warning: Changes to project are not saved? Save Now?", "Warning", MessageBoxButtons.YesNoCancel);

                if (exitResult.HasFlag(DialogResult.Cancel))
                {
                    return;
                }

                if (exitResult.HasFlag(DialogResult.Yes))
                {
                    projectView.Save();
                }               
            }

            Application.Exit();

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "OpenB Projects|*.project.xml"
            };

            var result = openFileDialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                XmlSerializer serializer = new XmlSerializer(CultureInfo.InvariantCulture, openFileDialog.FileName);
                this.projectView = serializer.Deserialize<ProjectView>();

                Refresh();
            }
        }
    }
}
