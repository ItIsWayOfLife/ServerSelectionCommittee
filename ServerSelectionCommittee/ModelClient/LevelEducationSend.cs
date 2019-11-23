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
    public class LevelEducationSend
    {
        public int Id { get; set; }
        public string NameLevelEducation { get; set; }

        public static List<LevelEducationSend> GetData()
        {
            List<LevelEducationSend> levelEducationSends = new List<LevelEducationSend>();

            using (DataContext db = new DataContext())
            {
                foreach (LevelEducation l in db.LevelEducations)
                {
                    levelEducationSends.Add(
                        new LevelEducationSend()
                        {
                            Id = l.IdLevelEducation,
                            NameLevelEducation = l.NameLevelEducation
                        }
                        );
                }
            }

            return levelEducationSends;
        }

        public static void DataSerializable()
        {
            List<LevelEducationSend> levelEducationSends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<LevelEducationSend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("LevelEducationSend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, levelEducationSends);
            }
        }
    }
}
