using System.Windows.Forms;
using OpenB.Radiation.Controls;
using OpenB.Radiation.Views;

public class ModelDefinitionDiagram : Panel
{
    public ModelDefinitionDiagram(ProjectView projectView)
    {
        if (projectView == null)
            throw new System.ArgumentNullException(nameof(projectView));

        foreach(ModelDefinitionView modelDefinitionView in projectView.ModelDefinitions)
        {
            this.Controls.Clear();

            Controls.Add(new ModelDefinition(modelDefinitionView));
        }
    }


}