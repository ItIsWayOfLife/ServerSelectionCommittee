using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    class GetLevelEducationSend
    {
        public static string GetData()
        {
            try
            {
                // сериализация данных
                LevelEducationSend.DataSerializable();
                // счит данных
                return LevelEducationSend.ReadToXml();
            }
            catch (Exception ex)
            {
                return "Ошибка " + ex;
            }
        }
    }
}
