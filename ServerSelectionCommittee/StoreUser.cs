using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerSelectionCommittee
{
    public class StoreUser
    {
        // список авторизованных users
        private static List<int> idLoginUser = new List<int>();

        public static List<int> IdLoginUser
        {
            get
            {
                return idLoginUser;
            }
        }

        // пров не вошел ли уже пользователь
        public static bool AddUser(int id_)
        {
            bool bl=true;

            foreach (int id in idLoginUser)
            {
                if (id == id_)
                {
                    bl = false;
                }
            }

            if (bl)
            {
                idLoginUser.Add(id_);
            }

            return bl;
        }

        public static string OutUser(string mess)
        {
            // удаляем заголовок ("OutUser ")
            mess = mess.Remove(0, 8);

            int id = Convert.ToInt32(mess);

            idLoginUser.Remove(id);

            using (DataContext db = new DataContext())
            {
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{DateTime.Now.ToString()}: Пользователь {db.Users.Where(p=>p.Id==id).First().Login} вышел из системы.");
                Console.ResetColor();
            }
            return "Выход";
        }
    }
}
