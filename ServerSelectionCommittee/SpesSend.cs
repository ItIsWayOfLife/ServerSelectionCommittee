using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    [Serializable]
    public class SpesSend
    {
        public int Id { get; set; }
        public int IdFaculty { get; set; }
        public int IdDepartment {get; set;}
        public string CodeSpecialty { get; set; }
        public string CodeSpecialization { get; set; }
        public string FullNameSpecialty { get; set; }
        public string ShortNameSpecialty { get; set; }



        public static List<SpesSend> GetData()
        {
            List<SpesSend> spesSends = new List<SpesSend>();

            using (DataContext db = new DataContext())
            {
              

                foreach (Specialty sp in db.Specialties)
                {
                    spesSends.Add(
                        new SpesSend() {
                            Id = sp.IdSpecialty,
                            IdFaculty= sp.IdFaculty,
                            IdDepartment = sp.IdDepartment,
                            CodeSpecialization = sp.CodeSpecialization,
                            FullNameSpecialty = sp.FullNameSpecialty,
                            ShortNameSpecialty = sp.ShortNameSpecialty
                        }
                        );
                }
            }

            return spesSends;




        }



    }
}
