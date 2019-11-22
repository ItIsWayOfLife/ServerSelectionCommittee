using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    class FacultySend
    {
        public int Id { get; set; }
        public string FullNameFaculty { get; set; }
        public string ShortNameFaculty { get; set; }

        public static List<FacultySend> GetData()
        {
            List<FacultySend> facultySends = new List<FacultySend>();

            using (DataContext db = new DataContext())
            {
                foreach (Faculty f in db.Faculties)
                {
                    facultySends.Add(
                        new FacultySend()
                        {
                            Id = f.IdFaculty,
                            FullNameFaculty = f.FullNameFaculty,
                            ShortNameFaculty = f.ShortNameFaculty
                        }
                        );
                }
            }

            return facultySends;
        }
    }
}
