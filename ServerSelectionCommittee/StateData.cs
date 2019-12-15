using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ServerSelectionCommittee
{
    [Serializable]
    public class StateData
    {
       public double CountEnrolee { get; set; }
        public double CountEnroleeBigjet { get; set; }
        public double CountEnroleePay { get; set; }
        public double PercentBrest { get; set; }
        public double PercentGomel { get; set; }
        public double PercentGrodno { get; set; }
        public double PercentVitebsk { get; set; }
        public double PercentMinsk { get; set; }
        public double PercentMogilevsk { get; set; }
        public double PercentMinskregion { get; set; }
        public double EmrolleeThisPoint { get; set; }


        public StateData()
        {
            CountEnrolee = 0;
            CountEnroleeBigjet = 0;
            CountEnroleePay = 0;
            PercentBrest = 0;
            PercentGomel = 0;
            PercentGrodno = 0;
            PercentVitebsk = 0;
            PercentMinsk = 0;
            PercentMogilevsk = 0;
            PercentMinskregion = 0;
            EmrolleeThisPoint = 0;
        }

        public static string GetData(string message)
        {
            string header = "GetStateData ";
            message = message.Remove(0, header.Length + 1);

            Console.WriteLine($"{DateTime.Now.ToString()}: Пользователь {message} получил статические данные");

            CountData();

            return ReadToXml();
  
        }

        public static void CountData()
        {
            StateData stateData = new StateData();
            List<Enrollee> enrollees = null;

            using (DataContext db = new DataContext())
            {
                enrollees = db.Enrollees.ToList();
            }

            stateData.CountEnrolee = enrollees.Count;

            foreach (Enrollee enrollee in enrollees)
            {
                if (enrollee?.EnrolleeAverageGradeOfCertificateOrDiploma + enrollee?.EnrolleeScoreOfTheFirstEntranceTest +
                    enrollee?.EnrolleeScoreOfTheSecondEntranceTest + enrollee?.EnrolleeScoreOfTheSecondEntranceTest >= 300)
                {
                    stateData.EmrolleeThisPoint++;
                }

                if (enrollee.EnrolleeAddress.ToLower().Contains("брест"))
                {
                    stateData.PercentBrest++;
                }

                if (enrollee.EnrolleeAddress.ToLower().Contains("минск "))
                {
                    stateData.PercentMinsk++;
                }

                if (enrollee.EnrolleeAddress.ToLower().Contains("минская"))
                {
                    stateData.PercentMinskregion++;
                }

                if (enrollee.EnrolleeAddress.ToLower().Contains("могил"))
                {
                    stateData.PercentMogilevsk++;
                }

                if (enrollee.EnrolleeAddress.ToLower().Contains("гоме"))
                {
                    stateData.PercentGomel++;
                }

                if (enrollee.EnrolleeAddress.ToLower().Contains("грод"))
                {
                    stateData.PercentGrodno++;
                }

                if (enrollee.EnrolleeAddress.ToLower().Contains("витеб"))
                {
                    stateData.PercentVitebsk++;
                }

                DataSerializable(stateData);
            }
        }

        public static void DataSerializable(StateData st)
        {    
            XmlSerializer formatter = new XmlSerializer(typeof(StateData));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("SerializableFile/StateData.xml", FileMode.Create))
            {
                formatter.Serialize(fs, st);
            }
        }

        // запись в xml, возвращает xml запись 
        public static string ReadToXml()
        {
            string xmlData = null;

            using (StreamReader reader = new StreamReader("SerializableFile/StateData.xml"))
            {
                xmlData = reader.ReadToEnd();
            }

            return xmlData;
        }
    }
}
