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

            Console.WriteLine("Start");


            DocumentsSend documentsSend = new DocumentsSend();
            documentsSend.IdEnrollee = 30;
            documentsSend.NameDocument = "ssssssss";
            documentsSend.NumberDocument = "233";
            documentsSend.Description = "sssss";

           

            using (DataContext db = new DataContext())
            {
                Documents documents = new Documents()
                {
                    IdEnrollee = documentsSend.IdEnrollee,
                    NameDocument = documentsSend.NameDocument,
                    NumberDocument = documentsSend.NumberDocument,
                    Description = documentsSend.Description,
                };



                db.Documents.Add(documents);
                db.SaveChanges();
            }



                Console.WriteLine("End");

            Console.ReadKey();
        }
    }
}
