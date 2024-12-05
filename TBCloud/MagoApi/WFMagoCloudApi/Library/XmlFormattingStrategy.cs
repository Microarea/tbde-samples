using System.IO;
using System.Text;
using System.Xml;

namespace MagoCloudApi.Libraries
{
    //===================================================================================
    class XmlFormattingStrategy
    {
        private static readonly string littleTrickString = "LittleTrickUsedToFillEmptyNodeThenFormatRemainingXML";

        //--------------------------------------------------------------------------			
        public static string FormatStringInXml(string xml)
        {
            if (string.IsNullOrEmpty(xml) || !xml.StartsWith("<"))
                return string.Empty;

            XmlDocument xmlDocument = new XmlDocument();
            XmlDocument xDoc = xmlDocument;
            try
            {
                xDoc.LoadXml(xml);
            }
            catch { return xml; }

            FillAllEmptyNodesWithDummyValue(ref xDoc);

            StringBuilder stringBuilder = new StringBuilder();
            StringWriter stringWriter = new StringWriter(stringBuilder);
            using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
            {
                xmlTextWriter.Formatting = Formatting.Indented;
                xmlTextWriter.Indentation = 4;
                xDoc.WriteTo(xmlTextWriter);
            }

            return DeleteDummyValueFromString(stringBuilder.ToString());
        }

        //--------------------------------------------------------------------------			
        private static void FillAllEmptyNodesWithDummyValue(ref XmlDocument xDoc)
        {
            //riempe tutti i nodi dell'xDoc vuoti con il valore LittleTrickUsedToFillEmptyNodeThenFormatRemainingXML
            //poi formatta l'xml, i nodi vuoti verrebbero spezzati su due righe e al termine della procedura
            //rimuove tutte le istanze di LittleTrickUsedToFillEmptyNodeThenFormatRemainingXML
            XmlNodeList xList = xDoc.SelectNodes("//node()");
            foreach (XmlNode node in xList)
            {
                if (string.IsNullOrEmpty(node.InnerText) && !node.HasChildNodes)
                    node.InnerText = littleTrickString;
            }
        }

        //--------------------------------------------------------------------------			
        private static string DeleteDummyValueFromString(string xmlString)
        {
            xmlString = xmlString.Replace(">" + littleTrickString + "</", "></");
            return xmlString;
        }
    }
}