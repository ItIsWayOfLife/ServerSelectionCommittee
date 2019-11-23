using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    [Serializable]
    public class EntranceTestsSend
    {
        public int Id { get; set; }
        public string NameEntranceTests { get; set; }

        public static List<EntranceTestsSend> GetData()
        {
            List<EntranceTestsSend> entranceTestsSends = new List<EntranceTestsSend>();

            using (DataContext db = new DataContext())
            {
                foreach (EntranceTests e in db.EntranceTests)
                {
                    entranceTestsSends.Add(
                        new EntranceTestsSend()
                        {
                            Id = e.IdEntranceTests,
                            NameEntranceTests = e.NameEntranceTests
                        }
                        );
                }
            }

            return entranceTestsSends;
        }
    }
}
