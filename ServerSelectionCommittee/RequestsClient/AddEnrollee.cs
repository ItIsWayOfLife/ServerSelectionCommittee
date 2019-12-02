using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerSelectionCommittee
{
    class AddEnrollee
    {
        public static string AddData(string message)
        {
            // удаляем заголовок ("LogInTo")
            message = message.Remove(0, 12);

            string[] array = message.Split(' ');
            string login = array[0];
            message = message.Remove(0,login.Length+1);

            // запись сообщения в xml
            WriteToXml(message);

            // десериализация
            EnrolleeSend enrolleeSend = DeserializeFileXml();
            
            return enrolleeSend.AddDB(login);
        }

        // запись в xml
        public static void WriteToXml(string words)
        {
            File.Delete("DeserializeFile/AddEnrollee.xml");
            using (StreamWriter writer = new StreamWriter("DeserializeFile/AddEnrollee.xml"))
            {
                writer.Write(words);
            }
        }

        // дисериализаця
        public static EnrolleeSend DeserializeFileXml()
        {
            using (FileStream fs = new FileStream("DeserializeFile/AddEnrollee.xml", FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(EnrolleeSend));

                return (EnrolleeSend)formatter.Deserialize(fs);
            }
        }
    }
}
