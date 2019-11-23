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
    public class FormStudySend
    {
        public int Id { get; set; }
        public string NameFormStudy { get; set; }

        public static List<FormStudySend> GetData()
        {
            List<FormStudySend> formStudySends = new List<FormStudySend>();

            using (DataContext db = new DataContext())
            {
                foreach (FormStudy f in db.FormStudies)
                {
                    formStudySends.Add(
                        new FormStudySend()
                        {
                            Id = f.IdFormStudy,
                            NameFormStudy = f.NameFormStudy
                        }
                        );
                }
            }

            return formStudySends;
        }

        public static void DataSerializable()
        {
            List<FormStudySend> formStudySends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<FormStudySend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("FormStudySend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, formStudySends);
            }
        }
    }
}
