using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ServerSelectionCommittee
{
    class UpdateEnrollee
    {
        public static string UpdateData(string message)
        {
            // удаляем заголовок ("UpdateEnrollee ")
            message = message.Remove(0, 15);

            // запись сообщения в xml
            WriteToXml(message);

            // десериализация
            EnrolleeSend enrolleeSend = DeserializeFileXml();

            return enrolleeSend.UpdateDB();
        }

        // запись в xml
        public static void WriteToXml(string words)
        {
            File.Delete("DeserializeFile/UpdateEnrollee.xml");
            using (StreamWriter writer = new StreamWriter("DeserializeFile/UpdateEnrollee.xml"))
            {
                writer.Write(words);
            }
        }

        // дисериализаця
        public static EnrolleeSend DeserializeFileXml()
        {
            using (FileStream fs = new FileStream("DeserializeFile/UpdateEnrollee.xml", FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(EnrolleeSend));

                return (EnrolleeSend)formatter.Deserialize(fs);
            }
        }
    }
}
