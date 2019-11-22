using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
   [Serializable]
    public class UserSend
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Patronymic { get; set; }
        public string AdminRights { get; set; }

        public static List<UserSend> GetData()
        {
            List<UserSend> userSends = new List<UserSend>();

            using (DataContext db = new DataContext())
            {
               foreach (User u in db.Users)
                {
                    userSends.Add(
                        new UserSend()
                        {
                            Id = u.Id,
                            Login = u.Login, 
                            Password = u.Password, 
                            Lastname = u.Lastname,
                            Firstname = u.Firstname,
                            Patronymic = u.Patronymic,
                            AdminRights = u.AdminRights
                        }
                        );
                }
            }

            return userSends;
        }
    }
}
