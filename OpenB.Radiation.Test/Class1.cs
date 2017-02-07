using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenB.Radiation.Views;

namespace OpenB.Radiation.Test
{
    [TestFixture]
    public class XmlSerializerTest
    {
        [Test]
        public void SerializeProjectView()
        {
            ProjectView projectView = new ProjectView()
            {
                Name = "SerializableProjectView",
                Description = "My first serializable projectview",
                AllowAddingModelDefinitions = false,
                FileName = "test.xml",

            };

            projectView.ModelDefinitions.Add(new ModelDefinitionView
            {
                Height = 43,
                Width = 100,
                Description = "My first model definition",
                Name = "My first model definition",
                Key = "MyFirstModelDefinition"

            });

            projectView.ModelDefinitions.Add(new ModelDefinitionView
            {
                Height = 43,
                Width = 100,
                Description = "My second model definition",
                Name = "My second model definition",
                Key = "MySecondModelDefinition"

            });

            XmlSerializer serializer = new XmlSerializer(CultureInfo.InvariantCulture, "test.xml");
            serializer.Serialize(projectView);
        }

        [Test]
        public void DeserializeProjectView()
        {
            XmlSerializer serializer = new XmlSerializer(CultureInfo.InvariantCulture, "test.xml");
            object projectView = serializer.Deserialize<ProjectView>();
        }
    }
}
