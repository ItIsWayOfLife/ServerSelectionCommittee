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
    public class FacultySend
    {
        public int Id { get; set; }
        public string FullNameFaculty { get; set; }
        public string ShortNameFaculty { get; set; }

        public static List<FacultySend> GetData()
        {
            List<FacultySend> facultySends = new List<FacultySend>();

            using (DataContext db = new DataContext())
            {
                foreach (Faculty f in db.Faculties)
                {
                    facultySends.Add(
                        new FacultySend()
                        {
                            Id = f.IdFaculty,
                            FullNameFaculty = f.FullNameFaculty,
                            ShortNameFaculty = f.ShortNameFaculty
                        }
                        );
                }
            }

            return facultySends;
        }

        public static void DataSerializable()
        {
            List<FacultySend> facultySends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<FacultySend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("FacultySend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, facultySends);
            }
        }
    }
}
