using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerSelectionCommittee
{
    [Serializable]
    public class LogIn
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public static string LogInTo(string message) // принимаем сообщение
        {
            // удаляем заголовок ("LogInTo ")
            message = message.Remove(0, 8);
            // пользователь
            UserSend userSend = null;
            // запись сообщения в xml
            WriteToXml(message);
            // десериализация
            LogIn logIn = DeserializeFileXml();
          
            // поиск нужного объекта
            foreach (UserSend u in UserSend.GetData())
            {
                if (logIn.Login == u.Login && logIn.Password == u.Password)
                {
                    userSend = u;
                }
            }

            if (userSend != null)
            {

                userSend?.WriteToXml();
                return userSend?.ReadToXml();
            }
            else
            {
                return "error";
            }
        }

        // запись в xml
        public static void WriteToXml(string words)
        {
            File.Delete("SerializableFile/LogIn.xml");
            using (StreamWriter writer = new StreamWriter("SerializableFile/LogIn.xml"))
            {
                writer.Write(words);
            }
        }
        // дисериализаця
        public static LogIn DeserializeFileXml()
        {
            using (FileStream fs = new FileStream("SerializableFile/LogIn.xml", FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(LogIn));

                return (LogIn)formatter.Deserialize(fs);
            }
        }

    }
}
