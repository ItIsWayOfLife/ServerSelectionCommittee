﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    class DocumentsSend
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
    }
}
