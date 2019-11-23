using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    [Serializable]
    public class HistorySend
    {
        public int Id { get; set; }
        public int IdEnrollee { get; set; }
        public string Operation { get; set; }
        public DateTime CreateAt { get; set; }

        public static List<HistorySend> GetData()
        {
            List<HistorySend> historySends = new List<HistorySend>();

            using (DataContext db = new DataContext())
            {
                foreach (History h in db.Histories)
                {
                    historySends.Add(
                        new HistorySend()
                        {
                            Id = h.IdHistory,
                            IdEnrollee = h.IdEnrollee,
                            Operation = h.Operation,
                            CreateAt = h.CreateAt                          
                        }
                        );
                }
            }

            return historySends;
        }
    }
}
