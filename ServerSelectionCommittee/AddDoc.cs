using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerSelectionCommittee
{
    class AddDoc
    {
        public static string AddData(string message)
        {
            // удаляем заголовок ("AddDoc ")
            message = message.Remove(0, 7);

            // запись сообщения в xml
            WriteToXml(message);

            // десериализация
            List<DocumentsSend> documents = DeserializeFileXml();

            return DocumentsSend.AddDB(documents);

        }

        // запись в xml
        public static void WriteToXml(string words)
        {
            File.Delete("DeserializeFile/AddDocs.xml");
            using (StreamWriter writer = new StreamWriter("DeserializeFile/AddDocs.xml"))
            {
                writer.Write(words);
            }
        }

        // дисериализаця
        public static List<DocumentsSend> DeserializeFileXml()
        {
            using (FileStream fs = new FileStream("DeserializeFile/AddDocs.xml", FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<DocumentsSend>));

                return (List<DocumentsSend>)formatter.Deserialize(fs);
            }
        }
    }
}

