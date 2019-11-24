using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    class GetConcessionSend
    {
        public static string GetData()
        {
            try
            {
                // сериализация данных
                ConcessionSend.DataSerializable();
                // счит данных
                return ConcessionSend.ReadToXml();
            }
            catch (Exception ex)
            {
                return "Ошибка " + ex;
            }
        }
    }
}
