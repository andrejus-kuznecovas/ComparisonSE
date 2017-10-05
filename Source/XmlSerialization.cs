using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CSE.Source
{
    class XmlSerialization
    {

        public static void SaveReceipt(Receipt receipt)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Receipt>));

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
            XmlSerializer serializer = new XmlSerializer(typeof(List<Receipt>));
            StreamReader input = new StreamReader(@"../../Source/Data/receipts.xml", Encoding.UTF8, true);
            //try
            //{
                List<Receipt> receipts;
                receipts = (List<Receipt>)serializer.Deserialize(input);
                input.Close();
                return receipts;
            //}
            //catch (Exception e)
            //{
            //    input.Close();
            //    return new List<Receipt>();
            //}

        }
    }
}
