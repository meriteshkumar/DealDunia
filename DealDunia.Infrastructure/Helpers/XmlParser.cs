using System.Xml;
using System.Xml.Linq;
using System.Linq;


namespace DealDunia.Infrastructure.Helpers
{
    public class XmlParser
    {
        public object MapXMLtoClass(System.IO.Stream xml, ItemResponse obj)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);

            XmlNodeList lstItems = doc.GetElementsByTagName("Item");

            if (lstItems.Count > 0)
            {
                XmlNode nItem = lstItems[0];

                foreach (XmlNode nChild in nItem.ChildNodes)
                {
                    if (nChild.Name == "ItemAttributes")
                    {
                        foreach (XmlNode nIA in nChild.ChildNodes)
                        {

                            if (nIA.Name == "ASIN")
                            {
                                string strTitle = nIA.InnerXml;
                            }
                        }
                    }
                }                
            }
            return null;
        }
    }
}
