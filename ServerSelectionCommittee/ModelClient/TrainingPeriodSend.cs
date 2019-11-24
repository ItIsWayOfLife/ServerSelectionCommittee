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
    public class TrainingPeriodSend
    {
        public int Id { get; set; }
        public string NameTrainingPeriod { get; set; }

        public static List<TrainingPeriodSend> GetData()
        {
            List<TrainingPeriodSend> trainingPeriodSends = new List<TrainingPeriodSend>();

            using (DataContext db = new DataContext())
            {
                foreach (TrainingPeriod t in db.TrainingPeriods)
                {
                    trainingPeriodSends.Add(
                        new TrainingPeriodSend()
                        {
                            Id = t.IdTrainingPeriod,
                            NameTrainingPeriod = t.NameTrainingPeriod
                        }
                        );
                }
            }

            return trainingPeriodSends;
        }

        public static void DataSerializable()
        {
            List<TrainingPeriodSend> trainingPeriodSends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<TrainingPeriodSend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("SerializableFile/TrainingPeriodSend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, trainingPeriodSends);
            }
        }

        public static string ReadToXml()
        {
            string xmlData = null;

            using (StreamReader reader = new StreamReader("SerializableFile/TrainingPeriodSend.xml"))
            {
                xmlData = reader.ReadToEnd();
            }

            return xmlData;
        }
    }
}
