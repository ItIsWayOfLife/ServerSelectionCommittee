using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    [Serializable]
    class DepartmentSend
    {
        public int Id { get; set; }
        public string FullNameDepartment { get; set; }
        public string ShortNameDepartment { get; set; }

        public static List<DepartmentSend> GetData()
        {
            List<DepartmentSend> departmentSends = new List<DepartmentSend>();

            using (DataContext db = new DataContext())
            {
                foreach (Department d in db.Departments)
                {
                    departmentSends.Add(
                        new DepartmentSend()
                        {
                            Id = d.IdDepartment,
                            FullNameDepartment = d.FullNameDepartment,
                            ShortNameDepartment = d.ShortNameDepartment
                        }
                        );
                }
            }

            return departmentSends;
        }
    }
}
