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
            List<SpecialtySend> spec = SpecialtySend.GetData();
          

          

            XmlSerializer formatter = new XmlSerializer(typeof(List<SpecialtySend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("Spec.xml", FileMode.Create))
            {
                formatter.Serialize(fs, spec);
            }

           

            Console.WriteLine("End");

            Console.ReadKey();
        }
    }
}
