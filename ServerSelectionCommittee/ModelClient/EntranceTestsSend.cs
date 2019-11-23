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
    public class EntranceTestsSend
    {
        public int Id { get; set; }
        public string NameEntranceTests { get; set; }

        public static List<EntranceTestsSend> GetData()
        {
            List<EntranceTestsSend> entranceTestsSends = new List<EntranceTestsSend>();

            using (DataContext db = new DataContext())
            {
                foreach (EntranceTests e in db.EntranceTests)
                {
                    entranceTestsSends.Add(
                        new EntranceTestsSend()
                        {
                            Id = e.IdEntranceTests,
                            NameEntranceTests = e.NameEntranceTests
                        }
                        );
                }
            }

            return entranceTestsSends;
        }

        public static void DataSerializable()
        {
            List<EntranceTestsSend> entranceTestsSends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<EntranceTestsSend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("EntranceTestsSend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, entranceTestsSends);
            }
        }
    }
}
