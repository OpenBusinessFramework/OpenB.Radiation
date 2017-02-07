using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenB.Core;
using OpenB.Radiation.Views;

namespace OpenB.Radiation
{
    
    public partial class ProjectForm : Form
    {
        readonly ProjectView projectView;

        public ProjectForm(ProjectView projectView)
        {
            this.projectView = projectView;
            if (projectView == null)
                throw new ArgumentNullException(nameof(projectView));

            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            projectView.Name = textProjectName.Text;
            projectView.Description = textProjectDescription.Text;
            projectView.AllowAddingModelDefinitions = true;

            this.Close();     
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
