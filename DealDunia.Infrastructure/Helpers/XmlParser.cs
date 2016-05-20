using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;


namespace DealDunia.Infrastructure.Helpers
{
    public class XmlParser
    {
        public void MapXMLtoClass(System.IO.Stream xml, List<ItemResponse> responseList, string rootElement)
        {
            //XmlDocument doc = new XmlDocument();
            //doc.Load(xml);

            //XmlNodeList lstItems = doc.GetElementsByTagName("Item");

            //if (lstItems.Count > 0)
            //{
            //    foreach (XmlNode nItem in lstItems)
            //    {
            //        ItemResponse responseItem = new ItemResponse();

            //        foreach (XmlNode nChild in nItem.ChildNodes)
            //        {
            //            if (nChild.Name == "ASIN")
            //            {
            //                responseItem.ProductCode = nChild.InnerText;
            //            }
            //            else if (nChild.Name == "DetailPageURL")
            //            {
            //                responseItem.DetailPageURL = nChild.InnerText;
            //            }
            //            if (nChild.Name == "ItemAttributes")
            //            {
            //                foreach (XmlNode nIA in nChild.ChildNodes)
            //                {
            //                    if (nIA.Name == "Title")
            //                    {
            //                        responseItem.Title = nIA.InnerText;
            //                    }
            //                    if (nIA.Name == "Title")
            //                    {
            //                        responseItem.Title = nIA.InnerText;
            //                    }
            //                }
            //            }
            //        }
            //        obj.Add(responseItem);
            //    }
            //}

            XmlTextReader reader = new XmlTextReader(xml);
            bool IsMatched = false;
            bool IsItem = false;
            string Property = string.Empty;
            ItemResponse obj = null;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:          
                        if (reader.Name == rootElement)
                        {
                            obj = new ItemResponse();
                            IsItem = true;
                        }
                        if (IsItem == true)
                        {
                            foreach (var prop in obj.GetType().GetProperties())
                            {
                                if (prop.Name == reader.Name)
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
