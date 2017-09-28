using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CSE.Source
{
    class XmlSerialization
    {
        private static XmlSerializer serializer = new XmlSerializer(typeof(List<Receipt>));

        public static void SaveReceipt(Receipt receipt)
        {
            
            List<Receipt> receipts = GetReceipts();
            receipts.Add(receipt);

            using (var output = new FileStream("../../Source/Data/receipts.xml",FileMode.Open))
            {
                using (XmlWriter writer = XmlWriter.Create(output))
                {
                    serializer.Serialize(writer, receipts);
                }
            }
            
        }

        public static List<Receipt> GetReceipts()
        {
            FileStream input = new FileStream("../../Source/Data/receipts.xml", FileMode.Open);
            XmlReader reader = XmlReader.Create(input);
            try
            {
                List<Receipt> receipts;
                receipts = (List<Receipt>)serializer.Deserialize(input);
                input.Close();
                return receipts;
            }
            catch (Exception e)
            {
                input.Close();
                return new List<Receipt>();
            }

        }
    }
}
