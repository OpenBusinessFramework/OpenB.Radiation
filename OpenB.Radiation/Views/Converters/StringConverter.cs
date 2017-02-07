using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenB.Radiation.Views.Converters
{
    class StringConverter : IXmlConverter<string>
    {
        public string Serialize(string value)
        {
            return WebUtility.HtmlEncode(value);
        }

        public string Deserialize(string value)
        {
            return WebUtility.HtmlDecode(value);
        }

    }

    class IntegerConverter : IXmlConverter<int>
    {
        

        public string Serialize(int value)
        {
            return Convert.ToString(value);
        }

        public int Deserialize(string value)
        {
            return Convert.ToInt32(value);
        }
    }

    class BooleanConverter : IXmlConverter<bool>
    {


        public string Serialize(bool value)
        {
            return Convert.ToString(value);
        }

        public bool Deserialize(string value)
        {
            return Convert.ToBoolean(value);
        }
    }
}
