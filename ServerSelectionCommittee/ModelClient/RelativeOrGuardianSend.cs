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
    public class RelativeOrGuardianSend
    {
        public int Id { get; set; }
        public int IdEnrollee { get; set; }
        public string RelationDegree { get; set; }
        public string RelativeFirstname { get; set; }
        public string RelativeLastname { get; set; }
        public string RelativePatronymic { get; set; }
        public string RelativeSex { get; set; }
        public DateTime? RelativeDateOfBirth { get; set; }
        public string RelativePassportSeries { get; set; }
        public string RelativePassportNumber { get; set; }
        public string RelativePassportPersonalNumber { get; set; }
        public string RelativePassportIssuedBy { get; set; }
        public DateTime? RelativePassportDateOfIssue { get; set; }
        public DateTime? RelativePassportDateExpiry { get; set; }
        public string RelativeAddress { get; set; }
        public string RelativePhoneNumber { get; set; }
        public string RelativePlaceOfWork { get; set; }
        public string RelativePost { get; set; }

        public static List<RelativeOrGuardianSend> GetData()
        {
            List<RelativeOrGuardianSend> relativeOrGuardianSends = new List<RelativeOrGuardianSend>();

            using (DataContext db = new DataContext())
            {
                foreach (RelativeOrGuardian r in db.RelativeOrGuardians)
                {
                    relativeOrGuardianSends.Add(
                        new RelativeOrGuardianSend()
                        {
                            Id =r.IdRelative,
                            IdEnrollee = r.IdEnrollee,
                            RelationDegree=r.RelationDegree,
                            RelativeFirstname = r.RelativeFirstname,
                            RelativeLastname = r.RelativeLastname,
                            RelativePatronymic = r.RelativePatronymic,
                            RelativeSex = r.RelativeSex,
                            RelativeDateOfBirth = r.RelativeDateOfBirth,
                            RelativePassportSeries = r.RelativePassportSeries,
                            RelativePassportNumber = r.RelativePassportNumber,
                            RelativePassportPersonalNumber = r.RelativePassportPersonalNumber,
                            RelativePassportIssuedBy = r.RelativePassportIssuedBy,
                            RelativePassportDateOfIssue = r.RelativePassportDateOfIssue,
                            RelativePassportDateExpiry = r.RelativePassportDateExpiry,
                            RelativeAddress = r.RelativeAddress,
                            RelativePhoneNumber = r.RelativePhoneNumber,
                            RelativePlaceOfWork = r.RelativePlaceOfWork,
                            RelativePost = r.RelativePost
                            }
                        );
                }
            }
            return relativeOrGuardianSends;
        }

        public static void DataSerializable()
        {
            List<RelativeOrGuardianSend> relativeOrGuardianSends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<RelativeOrGuardianSend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("SerializableFile/RelativeOrGuardianSend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, relativeOrGuardianSends);
            }
        }
    }
}
