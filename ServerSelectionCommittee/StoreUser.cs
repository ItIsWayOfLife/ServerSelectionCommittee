using System.Collections.Generic;

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

    }
}
