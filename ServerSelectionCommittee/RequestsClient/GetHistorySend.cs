using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    class GetHistorySend
    {
        public static string GetData()
        {
            try
            {
                // сериализация данных
                HistorySend.DataSerializable();
                // счит данных
                return HistorySend.ReadToXml();
            }
            catch (Exception ex)
            {
                return "Ошибка " + ex;
            }
        }
    }
}
