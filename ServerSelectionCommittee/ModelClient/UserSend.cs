using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerSelectionCommittee
{
   [Serializable]
    public class UserSend
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Patronymic { get; set; }
        public string AdminRights { get; set; }

        // получение данных
        public static List<UserSend> GetData()
        {
            List<UserSend> userSends = new List<UserSend>();

            using (DataContext db = new DataContext())
            {
               foreach (User u in db.Users)
                {
                    userSends.Add(
                        new UserSend()
                        {
                            Id = u.Id,
                            Login = u.Login, 
                            Password = u.Password, 
                            Lastname = u.Lastname,
                            Firstname = u.Firstname,
                            Patronymic = u.Patronymic,
                            AdminRights = u.AdminRights
                        }
                        );
                }
            }

            return userSends;
        }
        // ????
        public static void DataSerializable()
        {
            List<UserSend> userSends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<UserSend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("SerializableFile/UserSend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, userSends);
            }
        }

        // запись xml
        public void WriteToXml()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(UserSend));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("SerializableFile/OneUserSend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, this);
            }
        }

        // считывание xml
        public string ReadToXml()
        {
            string xmlData = null;

            using (StreamReader reader = new StreamReader("SerializableFile/OneUserSend.xml"))
            {
                xmlData = reader.ReadToEnd();
            }

            return xmlData;
        }  
    }
}
