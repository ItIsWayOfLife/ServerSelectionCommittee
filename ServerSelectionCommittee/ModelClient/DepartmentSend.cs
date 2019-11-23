using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerSelectionCommittee
{
    [Serializable]
    public class DepartmentSend
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

        public static void DataSerializable()
        {
            List<DepartmentSend> departmentSends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<DepartmentSend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("DepartmentSend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, departmentSends);
            }
        }
    }
}
