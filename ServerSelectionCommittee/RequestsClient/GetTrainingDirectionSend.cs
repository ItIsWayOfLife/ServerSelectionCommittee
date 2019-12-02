using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    class GetTrainingDirectionSend
    {
        public static string GetTD(string mess)
        {
            mess = mess.Replace("GetTD","");
            string[] array = mess.Split(' ');
            Console.WriteLine($"{DateTime.Now.ToString()}: Пользователь {array[0]} считал направления подготовки.");
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
