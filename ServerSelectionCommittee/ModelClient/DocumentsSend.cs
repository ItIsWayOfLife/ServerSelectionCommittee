﻿using System;
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

        public static void SaveData()
        {
            List<DocumentsSend> documentsSends = DataDeserialize();

            List<Documents> documents = new List<Documents>();

            foreach (DocumentsSend d in documentsSends)
            {
                documents.Add(new Documents() { NameDocument = d.NameDocument, Description = d.Description, NumberDocument = d.NumberDocument,
                    IdEnrollee = d.IdEnrollee});
            }

            using (DataContext db = new DataContext())
            {
                db.Documents.AddRange(documents);
                db.SaveChanges();
            }
        }
    }
}
