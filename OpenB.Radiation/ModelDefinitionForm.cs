using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenB.Radiation.Views;

namespace OpenB.Radiation
{
    public partial class ModelDefinitionForm : Form
    {
        readonly ModelDefinitionView modelDefinitionView;

        public ModelDefinitionForm(ModelDefinitionView modelDefinitionView)
        {
            this.modelDefinitionView = modelDefinitionView;
            if (modelDefinitionView == null)
                throw new ArgumentNullException(nameof(modelDefinitionView));

            InitializeComponent();

            if (string.IsNullOrEmpty(modelDefinitionView.Key))
            {
                Text = "Create new model definition";
            }
            else
            {
                Text = $"Edit model definition ({modelDefinitionView.Name})";
            }
        }

        private void ModelDefinitionForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            modelDefinitionView.Key = textKey.Text;
            modelDefinitionView.Name = textName.Text;
            modelDefinitionView.Description = textDescription.Text;

            Close();
        }
    }
}
