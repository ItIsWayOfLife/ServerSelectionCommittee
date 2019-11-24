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
    public class TrainingDirectionSend
    {
        public int Id { get; set; }
        public string NameBudgetOrCharge { get; set; }
        public string NameFormStudy { get; set; }
        public string NameTrainingPeriod { get; set; }
        public string CodeSpecialty { get; set; }
        public string CodeSpecialization { get; set; }
        public string FullNameSpecialty { get; set; }
        public string ShortNameSpecialty { get; set; }
        public string FullNameFaculty { get; set; }
        public string ShortNameFaculty { get; set; }
        public string FullNameDepartment { get; set; }
        public string ShortNameDepartment { get; set; }
        public string FirstIdEntranceTests { get; set; }
        public string SecondEntranceTests { get; set; }
        public string ThirdEntranceTests { get; set; }
        public int AdmissionPlan { get; set; }

        public static List<TrainingDirectionSend> GetData()
        {
            List<TrainingDirectionSend> trainingDirectionSends = new List<TrainingDirectionSend>();

            using (DataContext db = new DataContext())
            {
                foreach (TrainingDirection t in db.TrainingDirections)
                {
                    trainingDirectionSends.Add(
                        new TrainingDirectionSend()
                        {
                            Id = t.IdDirectionTraining,
                            NameBudgetOrCharge=t.BudgetOrCharge.NameBudgetOrCharge,
                            NameFormStudy = t.FormStudy.NameFormStudy,
                            NameTrainingPeriod=t.TrainingPeriod.NameTrainingPeriod,
                            CodeSpecialty = t.Specialty.CodeSpecialty,
                            CodeSpecialization = t.Specialty.CodeSpecialization,
                            FullNameSpecialty = t.Specialty.FullNameSpecialty,
                            ShortNameSpecialty = t.Specialty.ShortNameSpecialty,
                            FullNameFaculty = t.Specialty.Faculty.FullNameFaculty,
                            ShortNameFaculty = t.Specialty.Faculty.ShortNameFaculty,
                            FullNameDepartment = t.Specialty.Department.FullNameDepartment,
                            ShortNameDepartment = t.Specialty.Department.ShortNameDepartment,
                            FirstIdEntranceTests = t.FirstIdEntranceTests,
                            SecondEntranceTests = t.SecondEntranceTests,
                            ThirdEntranceTests = t.ThirdEntranceTests,
                            AdmissionPlan = t.AdmissionPlan
                        }
                        );
                }
            }

            return trainingDirectionSends;
        }

        public static void DataSerializable()
        {
            List<TrainingDirectionSend> trainingDirectionSends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<TrainingDirectionSend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("SerializableFile/TrainingDirectionSend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, trainingDirectionSends);
            }
        }

        public static string ReadToXml()
        {
            string xmlData = null;

            using (StreamReader reader = new StreamReader("SerializableFile/TrainingDirectionSend.xml"))
            {
                xmlData = reader.ReadToEnd();
            }

            return xmlData;
        }
    }
}
