namespace OpenB.Radiation.Views.Converters
{
    public interface IXmlConverter
    {

    }
    public interface IXmlConverter<T> : IXmlConverter
    {
        string Serialize(T value);
        T Deserialize(string value);
    }
}