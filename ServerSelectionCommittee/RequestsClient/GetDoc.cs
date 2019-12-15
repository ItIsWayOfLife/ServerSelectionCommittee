using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    class GetDoc
    {
        public static string GetData(string message)
        {
            
            // удаляем заголовок ("GetDoc ")
            message = message.Remove(0, 7);

            int id = Convert.ToInt32(message);

            List<DocumentsSend> documents = null;

                documents = DocumentsSend.GetData().Where(p => p.IdEnrollee == id).ToList();

            DocumentsSend.DataSerializable(documents);

            return DocumentsSend.ReadToXml();


        }
    }
}
