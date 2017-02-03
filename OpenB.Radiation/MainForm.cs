using System.Windows.Forms;
using OpenB.Radiation.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace OpenB.Radiation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            DoubleBuffered = true;

            var member1 = this.modelDefinition1.AddMember("Name", "String");
            var member2 = this.modelDefinition1.AddMember("DateOfBirth", "Date");

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            
        }

        private void addModelDefinitionToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ModelDefinition modelDefinition = new ModelDefinition();
            modelDefinition.DefinitionName = "NewDefinition";
            modelDefinition.Width = 150;
            modelDefinition.Height = 400;
            modelDefinition.BorderColor = System.Drawing.Color.Black;
            modelDefinition.AllowMove = true;

            this.modelDesignPanel.Controls.Add(modelDefinition);
            modelDesignPanel.Refresh();
        }

        private void newProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm();
            
            projectForm.StartPosition = FormStartPosition.CenterParent;

            projectForm.ShowDialog(this);
        }
    }
}
