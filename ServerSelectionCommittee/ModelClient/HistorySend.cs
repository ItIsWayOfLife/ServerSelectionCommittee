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
    public class HistorySend
    {
        public int Id { get; set; }
        public int IdEnrollee { get; set; }
        public string Operation { get; set; }
        public DateTime CreateAt { get; set; }

        public static List<HistorySend> GetData()
        {
            List<HistorySend> historySends = new List<HistorySend>();

            using (DataContext db = new DataContext())
            {
                foreach (History h in db.Histories)
                {
                    historySends.Add(
                        new HistorySend()
                        {
                            Id = h.IdHistory,
                            IdEnrollee = h.IdEnrollee,
                            Operation = h.Operation,
                            CreateAt = h.CreateAt                          
                        }
                        );
                }
            }

            return historySends;
        }

        public static void DataSerializable()
        {
            List<HistorySend> historySends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<HistorySend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("SerializableFile/HistorySend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, historySends);
            }
        }

        public static string ReadToXml()
        {
            string xmlData = null;

            using (StreamReader reader = new StreamReader("SerializableFile/HistorySend.xml"))
            {
                xmlData = reader.ReadToEnd();
            }

            return xmlData;
        }

    }
}
