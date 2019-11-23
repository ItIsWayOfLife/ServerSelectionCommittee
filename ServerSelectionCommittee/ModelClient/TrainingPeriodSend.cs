using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
