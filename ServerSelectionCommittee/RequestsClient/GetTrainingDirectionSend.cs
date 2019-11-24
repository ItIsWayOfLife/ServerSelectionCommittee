using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    class GetTrainingDirectionSend
    {
        public static string GetTD()
        {
            try
            {
                // сериализация данных
                TrainingDirectionSend.DataSerializable();
                // счит данных
                return TrainingDirectionSend.ReadToXml();
            }
            catch (Exception ex)
            {
                return "Ошибка "+ex;
            }
        }
    }
}
