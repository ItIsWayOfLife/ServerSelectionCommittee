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
        public int IdSpecialty { get; set; }
        public int IdFormStudy { get; set; }
        public int IdTrainingPeriod { get; set; }
        public int IdBudgetOrCharge { get; set; }
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
                            IdSpecialty = t.IdSpecialty,
                            IdFormStudy = t.IdFormStudy,
                            IdTrainingPeriod = t.IdTrainingPeriod,
                            IdBudgetOrCharge = t.IdBudgetOrCharge,
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
