using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerSelectionCommittee
{
    class UpdateDoc
    {
        public static string UpdateData(string message)
        {
            // удаляем заголовок ("UpdateDoc ")
            message = message.Remove(0, 10);

            // запись сообщения в xml
            WriteToXml(message);

            // десериализация
            DocumentsSend doc = DeserializeFileXml();

            return doc.UpdateDB();
        }

        // запись в xml
        public static void WriteToXml(string words)
        {
            File.Delete("DeserializeFile/UpdateDoc.xml");
            using (StreamWriter writer = new StreamWriter("DeserializeFile/UpdateDoc.xml"))
            {
                writer.Write(words);
            }
        }

        // дисериализаця
        public static DocumentsSend DeserializeFileXml()
        {
            using (FileStream fs = new FileStream("DeserializeFile/UpdateDoc.xml", FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(DocumentsSend));

                return (DocumentsSend)formatter.Deserialize(fs);
            }
        }
    }
}
