using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int? IdFirstIdEntranceTests { get; set; }
        public int? IdSecondEntranceTests { get; set; }
        public int? IdThirdEntranceTests { get; set; }
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
                            IdFirstIdEntranceTests = t.IdFirstIdEntranceTests,
                            IdSecondEntranceTests = t.IdSecondEntranceTests,
                            IdThirdEntranceTests = t.IdThirdEntranceTests,
                            AdmissionPlan = t.AdmissionPlan
                        }
                        );
                }
            }
            return trainingDirectionSends;
        }
    }
}
