using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using DealDunia.Infrastructure.Abstract;


namespace DealDunia.Infrastructure.Helpers
{
    public class XmlParser
    {
        static IItemResponse item = null;

        public void MapXMLtoClass(XmlDocument xml, List<IItemResponse> responseList, string rootElement, string type)
        {
            GetItem(xml, rootElement, responseList,  type);
        }

        static void GetItem(XmlNode node, string rootElement, List<IItemResponse> responseList, string type)
        {

            if (node.Name.Equals(rootElement))
            {

                string xmlContent = string.Concat("<", rootElement, ">", node.InnerXml, "</", rootElement, ">");
                item = ItemResponseFactory.CreateItemReponse(type);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlContent);
                GetItemElements(doc.DocumentElement, item);
                responseList.Add(item);
            }

            //Console.WriteLine("{0}{1}{2}", "-".PadLeft(level + 1), node.Name, node.InnerText);

            foreach (XmlNode child in node.ChildNodes)
            {
                GetItem(child, rootElement, responseList, type);
            }
        }

        static void GetItemElements(XmlNode node, IItemResponse seed)
        {
            if (node.Name == "FormattedPrice")
            {
                int i = 0;
            }
            foreach (var prop in seed.GetType().GetProperties())
            {
                var d = prop.GetCustomAttributes(typeof(DevAttribute), true).Cast<DevAttribute>().Single().DisplayName;
                var x = prop.GetCustomAttributes(typeof(DevAttribute), true).Cast<DevAttribute>().Single().XPath;
                string xPath = string.Concat(node.ParentNode.Name, "/", node.Name);
                if (x.Equals(xPath) && node.Name == d)
                {
                    if (!string.IsNullOrEmpty(prop.GetCustomAttributes(typeof(DevAttribute), true).Cast<DevAttribute>().Single().PreviousNode))
                    {
                        var prevNode = prop.GetCustomAttributes(typeof(DevAttribute), true).Cast<DevAttribute>().Single().PreviousNode;
                        var prevNodeValue = prop.GetCustomAttributes(typeof(DevAttribute), true).Cast<DevAttribute>().Single().PreviousNodeValue;
                        if (node.PreviousSibling.Name == prevNode && node.PreviousSibling.InnerText == prevNodeValue)
                            seed.GetType().GetProperty(prop.Name).SetValue(seed, node.InnerText);
                    }
                    else
                    {
                        seed.GetType().GetProperty(prop.Name).SetValue(seed, node.InnerText);
                    }

                }
            }
            foreach (XmlNode child in node.ChildNodes)
            {
                GetItemElements(child, seed);
            }
        }
    }
}
