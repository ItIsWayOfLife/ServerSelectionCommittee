using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ServerSelectionCommittee
{
    [Serializable]
    public class SpecialtySend
    {
        public int Id { get; set; }
        public int IdFaculty { get; set; }
        public int IdDepartment {get; set;}
        public string CodeSpecialty { get; set; }
        public string CodeSpecialization { get; set; }
        public string FullNameSpecialty { get; set; }
        public string ShortNameSpecialty { get; set; }



        public static List<SpecialtySend> GetData()
        {
            List<SpecialtySend> spesSends = new List<SpecialtySend>();

            using (DataContext db = new DataContext())
            {             
                foreach (Specialty sp in db.Specialties)
                {
                    spesSends.Add(
                        new SpecialtySend() {
                            Id = sp.IdSpecialty,
                            IdFaculty= sp.IdFaculty,
                            IdDepartment = sp.IdDepartment,
                            CodeSpecialization = sp.CodeSpecialization,
                            FullNameSpecialty = sp.FullNameSpecialty,
                            ShortNameSpecialty = sp.ShortNameSpecialty
                        }
                        );
                }
            }

            return spesSends;
        }

        public static void DataSerializable()
        {
            List<SpecialtySend> specialtySends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<SpecialtySend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("SpecialtySend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, specialtySends);
            }
        }
    }
}
