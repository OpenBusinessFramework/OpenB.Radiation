using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml;
using OpenB.Radiation.Views.Converters;

namespace OpenB.Radiation.Views
{

    public class XmlSerializer
    {
        private CultureInfo culture;

        private string xmlFilePath;

        private IDictionary<Type, Type> interfacesToConcreteTypes = new Dictionary<Type, Type>() { { typeof(IList<>), typeof(List<>) } };

        public XmlSerializer(CultureInfo culture, string xmlFilePath)
        {

            if (xmlFilePath == null)
                throw new ArgumentNullException(nameof(xmlFilePath));
            if (culture == null)
                throw new ArgumentNullException(nameof(culture));

            this.culture = culture;
            this.xmlFilePath = xmlFilePath;

            OnPropertySerialization += SerializeProperty;
            OnXmlDocumentCreation += CreatXmlDocument;
        }

        private XmlDocument CreatXmlDocument(object sender, ObjectSerializationEventArgs e)
        {
            XmlDocument resultDocument = new XmlDocument();
            XmlDeclaration declaration = resultDocument.CreateXmlDeclaration("1.0", "utf-8", "yes");
            XmlElement rootNode = resultDocument.CreateElement(sender.GetType().Name);
            resultDocument.InsertBefore(declaration, resultDocument.DocumentElement);
            resultDocument.AppendChild(rootNode);

            return resultDocument;
        }

        private void SerializeProperty(object sender, PropertySerializationEventArgs e)
        {
            XmlDocument xmlDocument = e.ParentNode as XmlDocument;
            if (xmlDocument == null)
            {
                xmlDocument = e.ParentNode.OwnerDocument;
            }

            XmlNode propertyNode = xmlDocument.CreateNode(XmlNodeType.Element, e.PropertyName, "");

            // Todo: to strategies and overloading enabled.

            Type genericInterface = typeof(IXmlConverter<>).MakeGenericType(new[] { sender.GetType() });

            var relevantConverter = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => genericInterface.IsAssignableFrom(t) && !t.IsInterface);           

            if (relevantConverter != null)
            {
                object converterInstance = Activator.CreateInstance(relevantConverter);

                MethodInfo serializationMethod = relevantConverter.GetMethod("Serialize");
                
                if (serializationMethod != null)
                {
                    propertyNode.InnerText = (string) serializationMethod.Invoke(converterInstance, new[] { sender });
                    e.ParentNode.AppendChild(propertyNode);
                    return;
                }
            }
            
            // ICollection
            if (sender is ICollection)
            {
                ICollection collection = sender as ICollection;

                foreach (var item in collection)
                {
                    SerializeProperty(item, new PropertySerializationEventArgs(item.GetType().Name, propertyNode));
                    e.ParentNode.AppendChild(propertyNode);

                }
                return;
            }

            // Object conversion, create childnode

            var subProperties = sender.GetType().GetProperties();

            foreach (var subProperty in subProperties)
            {
                var subObject = subProperty.GetValue(sender, null);
                OnPropertySerialization(subObject, new PropertySerializationEventArgs(subProperty.Name, propertyNode));

                e.ParentNode.AppendChild(propertyNode);
            }
        }

        public void Serialize(object source)
        {
            var publicProperties = source.GetType().GetProperties();


            XmlDocument resultDocument = OnXmlDocumentCreation(source, new ObjectSerializationEventArgs());
            XmlNode rootNode = resultDocument.DocumentElement;


            foreach (var property in publicProperties)
            {
                PropertySerializationEventArgs eventArgs = new PropertySerializationEventArgs(property.Name, rootNode);

                OnPropertySerialization(property.GetValue(source, null), eventArgs);
            }

            resultDocument.Save(this.xmlFilePath);

        }
        public T Deserialize<T>()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlFilePath);

            var objectTypeName = xmlDocument.DocumentElement.LocalName;

            Type resultObjectType = typeof(T);

            object resultObject = Activator.CreateInstance(resultObjectType);

            foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
            {
                PropertyInfo selectedProperty = resultObjectType.GetProperty(childNode.LocalName);

                selectedProperty.SetValue(resultObject, DeserializeXmlNode(resultObject, childNode));
            }

            return (T)resultObject;
        }

        private object DeserializeObjectFromNode(XmlNode xmlNode, Type objectType)
        {
            object destinationObject = Activator.CreateInstance(objectType);

            foreach(XmlNode childNode in xmlNode.ChildNodes)
            {
                object value = DeserializeXmlNode(destinationObject, childNode);
                objectType.GetProperty(childNode.LocalName).SetValue(destinationObject, value);
            }

            return destinationObject;
        }

        private object DeserializeXmlNode(object resultObject, XmlNode childNode)
        {
            if (childNode == null)
                throw new ArgumentNullException(nameof(childNode));
            if (resultObject == null)
                throw new ArgumentNullException(nameof(resultObject));

            var selectedProperty = resultObject.GetType().GetProperty(childNode.LocalName);

            if (selectedProperty == null)
            {
                return null;
            }
                       

            if (selectedProperty.PropertyType.IsInterface)
            {
                // TODO: Non generic interfaces.

                // For generics 
                // Todo: Option to require setting the default value for a list in the constructor of an class.
                if (selectedProperty.PropertyType.IsGenericType)
                {
                    Type genericTypeDef = selectedProperty.PropertyType.GetGenericTypeDefinition();

                    if (interfacesToConcreteTypes.ContainsKey(genericTypeDef))
                    {
                        Type concreteTypeDef = interfacesToConcreteTypes[genericTypeDef];

                        Type genericConcreteTypeDef = concreteTypeDef.MakeGenericType(selectedProperty.PropertyType.GetGenericArguments());

                        ICollection collection = Activator.CreateInstance(genericConcreteTypeDef) as ICollection;

                        foreach(XmlNode itemnode in childNode.ChildNodes)
                        {
                            Type argumentType = selectedProperty.PropertyType.GetGenericArguments().Single();
                           

                            object item = DeserializeObjectFromNode(itemnode, argumentType);

                            // TODO: Or just assign...
                            MethodInfo addMethod = collection.GetType().GetMethod("Add");
                          
                            addMethod.Invoke(collection, new[] { item });
                        }

                        return collection;
                    }
                }
                else
                {
                    if (!interfacesToConcreteTypes.ContainsKey(selectedProperty.PropertyType))
                    {
                        throw new NotSupportedException($"Cannot automaticly convert interface {selectedProperty.PropertyType.Name}.");
                    }
                }
            }



            // TODO: Converter strategies.
            if (selectedProperty.PropertyType == typeof(string))
            {
                return childNode.InnerText;
            }

            if (selectedProperty.PropertyType == typeof(bool))
            {
                return Boolean.Parse(childNode.InnerText);

            }

            if (selectedProperty.PropertyType == typeof(int))
            {
                return int.Parse(childNode.InnerText);
            }

            if (typeof(IEnumerable).IsAssignableFrom(selectedProperty.PropertyType))
            {
                Type objectType = selectedProperty.PropertyType;

                if (selectedProperty.PropertyType.IsGenericType)
                {
                    objectType = selectedProperty.PropertyType.GetGenericArguments().Single();
                }

                foreach (XmlNode subChildNode in childNode.ChildNodes)
                {
                    object item = Activator.CreateInstance(objectType);
                    item = DeserializeXmlNode(item, subChildNode);
                }                
            }

            // Then it is an object. 
            if (childNode.HasChildNodes)
            {
                object subProperty = Activator.CreateInstance(selectedProperty.PropertyType);
                

                foreach (XmlNode subChildNode in childNode.ChildNodes)
                {
                    PropertyInfo relevantProperty = selectedProperty.PropertyType.GetProperty(subChildNode.LocalName);
                    
                    relevantProperty.SetValue(subProperty, DeserializeXmlNode(subProperty, subChildNode));
                }
            }

            throw new NotSupportedException($"Cannot deserialize property {selectedProperty.Name}.");

        }

        public delegate void PropertySerializationEventHandler(object sender, PropertySerializationEventArgs e);
        public event PropertySerializationEventHandler OnPropertySerialization;

        public delegate XmlDocument XmlDocumentCreationEventHandler(object sender, ObjectSerializationEventArgs e);
        public event XmlDocumentCreationEventHandler OnXmlDocumentCreation;
    }

    public class ObjectSerializationEventArgs
    {

    }

    public class PropertySerializationEventArgs
    {
        public string PropertyName { get; private set; }
        public XmlNode ParentNode { get; private set; }

        public PropertySerializationEventArgs(string propertyName, XmlNode parentNode)
        {
            if (parentNode == null)
                throw new ArgumentNullException(nameof(parentNode));

            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            this.PropertyName = propertyName;
            this.ParentNode = parentNode;
        }
    }


}