using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    class DeleteEnrollee
    {
        public static string DeleteEn(string message)
        {
            try
            {

                // удаляем заголовок ("DeleteEnrollee ")
                message = message.Remove(0, 15);

                // id удал абит
                int id = Convert.ToInt32(message);

                DeleteDoc.DeleteByIdEnr(id);

                using (DataContext data = new DataContext())
                {
                    Enrollee enrolleeDel = data.Enrollees.Where(p => p.IdEnrollee == id).First();

                    if (enrolleeDel != null)
                    {
                        data.Enrollees.Attach(enrolleeDel);
                        data.Enrollees.Remove(enrolleeDel);
                        data.SaveChanges();
                    }
                }

                return "Успешно удалено";
            }
            catch (Exception ex)
            {
                return "Ошибка: "+ex.ToString();
            }
        }
    }
}
