using System;
using System.Collections.Generic;
using System.Globalization;

namespace OpenB.Radiation.Views
{
    public class ProjectView
    {
        public string FileName { get; set; }

        public bool IsSaved { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<ModelDefinitionView> ModelDefinitions { get; private set; }

        public bool AllowAddingModelDefinitions { get; set; }

        public ProjectView()
        {
            ModelDefinitions = new List<ModelDefinitionView>();
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(CultureInfo.InvariantCulture, FileName);
            xmlSerializer.Serialize(this);
        }
    }

    public class ModelDefinitionView
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HorizontalPosition { get; set; }
        public int VerticalPosition { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class RequiredAttribute : Attribute
    {
    }
}
