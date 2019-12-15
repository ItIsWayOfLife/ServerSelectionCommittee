using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    class GetEnrollee
    {
        public static string GetData(string mess)
        {
            mess = mess.Replace("GetEnrollee", "");
            string[] array = mess.Split(' ');
            string login = array[0];

            try
            {
                // сериализация данных
                EnrolleeSend.DataSerializable();
                Console.WriteLine($"{DateTime.Now.ToString()}: Пользователь {login} получил данные абитуриентов.");

                // счит данных
                return EnrolleeSend.ReadToXml();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now.ToString()}: Ошибка "+ex.ToString());

                return "Ошибка " + ex;
            }
        }
    }
}
