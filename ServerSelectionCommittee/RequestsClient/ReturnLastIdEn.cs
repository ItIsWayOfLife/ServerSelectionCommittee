using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    class ReturnLastIdEn
    {
        public static string ReturnId()
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    List<Enrollee> en = db.Enrollees.ToList();

                    string id = en.OrderByDescending(p=>p.IdEnrollee).First().IdEnrollee.ToString();

                    return id;
                }
            }
            catch (Exception ex)
            {
                return "Ошибка: " + ex.ToString();
            }
        }
    }
}
