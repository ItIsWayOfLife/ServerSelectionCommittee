using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerSelectionCommittee
{
    class Program
    {
        static void Main(string[] args)
        {

            //using (DataContext db = new DataContext())
            //{
            //    foreach (Enrollee en in db.Enrollees)
            //    {
            //        Console.WriteLine($"id: {en.IdEnrollee} льгота: {en.Concession} email: {en.EnrolleeEmail}  ");
            //    }
            //}


            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("End");


            // запись в xml
            //List<User> users = null;

            //using (DataContext db = new DataContext())
            //{
            //    users = db.Users.ToList();
            //}

            //XmlSerializer formatter = new XmlSerializer(typeof(List<User>));

            //// получаем поток, куда будем записывать сериализованный объект
            //using (FileStream fs = new FileStream("User.xml", FileMode.Create))
            //{
            //    formatter.Serialize(fs, users);
            //}

            Console.WriteLine("End");

            Console.ReadKey();
        }
    }
}
