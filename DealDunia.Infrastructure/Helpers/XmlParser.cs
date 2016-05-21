using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using DealDunia.Infrastructure.Abstract;


namespace DealDunia.Infrastructure.Helpers
{
    public class XmlParser
    {
        public void MapXMLtoClass(System.IO.Stream xml, List<IItemResponse> responseList, string rootElement, IItemResponse seed)
        {
            XmlTextReader reader = new XmlTextReader(xml);
            bool IsMatched = false;
            bool IsItem = false;
            string Property = string.Empty;
            IItemResponse obj = null;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:          
                        if (reader.Name == rootElement)
                        {
                            obj = seed;
                            IsItem = true;
                        }
                        if (IsItem == true)
                        {
                            foreach (var prop in obj.GetType().GetProperties())
                            {
                                if (prop.GetCustomAttributes(typeof(System.ComponentModel.DisplayNameAttribute), true).Cast<System.ComponentModel.DisplayNameAttribute>().Single().DisplayName == reader.Name)
                                {
                                    IsMatched = true;
                                    Property = prop.Name;
                                }
                            }
                        }
                        break;
                    case XmlNodeType.Text: 
                        if (IsMatched == true)
                        {
                            obj.GetType().GetProperty(Property).SetValue(obj, reader.Value);
                            IsMatched = false;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (reader.Name == rootElement)
                        {
                            responseList.Add(obj);
                            IsItem = false;
                        }
                        break;
                }
            }
        }
    }
}
