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
    public class ConcessionSend
    {
        public int Id { get; set; }
        public string NameConcession { get; set; }

        public static List<ConcessionSend> GetData()
        {
            List<ConcessionSend> concessionSends = new List<ConcessionSend>();

            using (DataContext db = new DataContext())
            {
                foreach (Concession c in db.Concessions)
                {
                    concessionSends.Add(
                        new ConcessionSend()
                        {
                            Id = c.IdConcession,
                            NameConcession = c.NameConcession
                        }
                        );
                }
            }

            return concessionSends;
        }

        public static void DataSerializable()
        {
            List<ConcessionSend> concessionSends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<ConcessionSend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("SerializableFile/ConcessionSend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, concessionSends);
            }
        }
    }
}
