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
            // ответ сервера
            string response = null;

            // удаляем заголовок ("LogInTo ")
            message = message.Remove(0, 12);

            // запись сообщения в xml
            WriteToXml(message);

            // десериализация
            EnrolleeSend enrolleeSend = DeserializeFileXml();

            Console.WriteLine($"enr lastname: {enrolleeSend.EnrolleeLastname}");

            return enrolleeSend.AddDB();

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
