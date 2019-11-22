using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    [Serializable]
    class LevelEducationSend
    {
        public int Id { get; set; }
        public string NameLevelEducation { get; set; }

        public static List<LevelEducationSend> GetData()
        {
            List<LevelEducationSend> levelEducationSends = new List<LevelEducationSend>();

            using (DataContext db = new DataContext())
            {
                foreach (LevelEducation l in db.LevelEducations)
                {
                    levelEducationSends.Add(
                        new LevelEducationSend()
                        {
                            Id = l.IdLevelEducation,
                            NameLevelEducation = l.NameLevelEducation
                        }
                        );
                }
            }

            return levelEducationSends;
        }
    }
}
