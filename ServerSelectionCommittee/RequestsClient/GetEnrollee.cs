using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    class GetEnrollee
    {
        public static string GetData()
        {
            try
            {
                // сериализация данных
                EnrolleeSend.DataSerializable();
                // счит данных
                return EnrolleeSend.ReadToXml();
            }
            catch (Exception ex)
            {
                return "Ошибка " + ex;
            }
        }
    }
}
