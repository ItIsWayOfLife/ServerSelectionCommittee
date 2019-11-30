using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerSelectionCommittee
{
    [Serializable]
    public class DocumentsSend
    {
        public int Id { get; set; }
        public int IdEnrollee { get; set; }
        public string NameDocument { get; set; }
        public string NumberDocument { get; set; }
        public string Description { get; set; }

        public static List<DocumentsSend> GetData()
        {
            List<DocumentsSend> documentsSends = new List<DocumentsSend>();

            using (DataContext db = new DataContext())
            {
                foreach (Documents d in db.Documents)
                {
                    documentsSends.Add(
                        new DocumentsSend()
                        {
                            Id = d.IdDocument,
                            IdEnrollee = d.IdEnrollee,
                            NameDocument = d.NameDocument,
                            NumberDocument = d.NumberDocument,
                            Description = d.Description
                        }
                        );
                }
            }

            return documentsSends;
        }

        public static void DataSerializable()
        {
            List<DocumentsSend> documentsSends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<DocumentsSend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("SerializableFile/DocumentsSend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, documentsSends);
            }
        }

        public static List<DocumentsSend> DataDeserialize()
        {
            List<DocumentsSend> documentsSends = null;

            using (FileStream fs = new FileStream("DeserializeFile/DocumentsSend.xml", FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<DocumentsSend>));

                documentsSends = (List<DocumentsSend>)formatter.Deserialize(fs);
            }

            return documentsSends;
        }

        // запись в xml, возвращает xml запись 
        public static string ReadToXml()
        {
            string xmlData = null;

            using (StreamReader reader = new StreamReader("SerializableFile/DocumentsSend.xml"))
            {
                xmlData = reader.ReadToEnd();
            }

            return xmlData;
        }

        public static void SaveData()
        {
            List<DocumentsSend> documentsSends = DataDeserialize();

            List<Documents> documents = new List<Documents>();

            foreach (DocumentsSend d in documentsSends)
            {
                documents.Add(new Documents()
                {
                    NameDocument = d.NameDocument,
                    Description = d.Description,
                    NumberDocument = d.NumberDocument,
                    IdEnrollee = d.IdEnrollee
                });
            }

            using (DataContext db = new DataContext())
            {
                db.Documents.AddRange(documents);
                db.SaveChanges();
            }
        }


        public static string AddDB(List<DocumentsSend> documents)
        {
            Console.WriteLine("Start");

            string mess = null;

            Console.WriteLine("1");
            try
            {
                using (DataContext db = new DataContext())
                {
                    Documents doc = null;

                    Console.WriteLine(db.Enrollees.OrderByDescending(p => p.IdEnrollee).First().IdEnrollee.ToString());

                    foreach (DocumentsSend d in documents)
                    {
                        Console.WriteLine("2");
                         doc = new Documents()
                        {
                            IdEnrollee = Convert.ToInt32(db.Enrollees.OrderByDescending(p => p.IdEnrollee).First().IdEnrollee),
                            NameDocument = d.NameDocument,
                            Description = d.Description,
                            NumberDocument = d.NumberDocument
                        };
                    }

                    Console.WriteLine($"Doc info idEnr: {doc.IdEnrollee}; nameDoc: {doc.NameDocument}; des: {doc.Description}; number: {doc.NumberDocument}");

                    db.Documents.Add(doc);

                    Console.WriteLine("4");

                    Console.WriteLine("5");


              
                    db.SaveChanges();

                    Console.WriteLine("6");

                    mess = "Успешно сохранены";
                }
            }
            catch (Exception ex)
            {
                mess = "Ошибка: "+ex.ToString();
            }

            return mess;
        }
    }
}
