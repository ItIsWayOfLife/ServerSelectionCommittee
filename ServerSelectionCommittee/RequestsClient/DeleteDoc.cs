using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    class DeleteDoc
    {
        public static string DeleteByIdDoc(string message)
        {
            try
            {

                // удаляем заголовок ("DeleteDoc ")
                message = message.Remove(0, 10);

                // id удал док
                int id = Convert.ToInt32(message);

                using (DataContext data = new DataContext())
                {
                    Documents doc = data.Documents.Where(p => p.IdDocument == id).First();

                    if (doc != null)
                    {
                        data.Documents.Attach(doc);
                        data.Documents.Remove(doc);
                        data.SaveChanges();
                    }
                }

                return "Успешно удалено";
            }
            catch (Exception ex)
            {
                return "Ошибка: " + ex.ToString();
            }
        }

        public static string DeleteByIdEnr(int idEnr)
        {
            try
            {
                using (DataContext data = new DataContext())
                {
                    List<Documents> docs = data.Documents.Where(p => p.IdEnrollee == idEnr).ToList();

                    foreach (Documents d in docs)
                    {

                        if (d != null)
                        {
                            data.Documents.Attach(d);
                            data.Documents.Remove(d);
                            data.SaveChanges();
                        }
                    }
                }

                return "Успешно удалено";
            }
            catch (Exception ex)
            {
                return "Ошибка: " + ex.ToString();
            }
        }
    }
}
