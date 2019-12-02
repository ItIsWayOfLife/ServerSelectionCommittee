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
    public class EnrolleeSend
    {
        public int Id { get; set; }
        public int IdDirectionTraining { get; set; }
        public string NameLevelEducation { get; set; }
        public string NameConcession { get; set; }
        public string DescriptionConcession { get; set; }
        public DateTime EnrolleeDateOfRegistration { get; set; }
        public string EnrolleeFirstname { get; set; }
        public string EnrolleeLastname { get; set; }
        public string EnrolleePatronymic { get; set; }
        public string EnrolleeSex { get; set; }
        public DateTime EnrolleeDateOfBirth { get; set; }
        public string EnrolleePassportSeries { get; set; }
        public string EnrolleePassportNumber { get; set; }
        public string EnrolleePassportPersonalNumber { get; set; }
        public string EnrolleePassportIssuedBy { get; set; }
        public DateTime EnrolleeDateOfIssue { get; set; }
        public DateTime EnrolleeDateExpiry { get; set; }
        public string EnrolleeAddress { get; set; }
        public string EnrolleePostcode { get; set; }
        public string EnrolleePhoneNumber { get; set; }
        public string EnrolleeEducation { get; set; }
        public string EnrolleeLastPlaceOfStudy { get; set; }
        public string EnrolleeAddressLastPlaceOfStudy { get; set; }
        public DateTime EnrolleeGraduationDate { get; set; }
        public string EnrolleeNumberCertificateOrDiploma { get; set; }
        public double? EnrolleeAverageGradeOfCertificateOrDiploma { get; set; }
        public double? EnrolleeScoreOfTheFirstEntranceTest { get; set; }
        public double? EnrolleeScoreOfTheSecondEntranceTest { get; set; }
        public double? EnrolleeScoreOfTheThirdEntranceTest { get; set; }
        public string EnrolleeEmail { get; set; }
        public string EnrolleeAdditionalInformation { get; set; }

        public static List<EnrolleeSend> GetData()
        {
            List<EnrolleeSend> enrolleeSends = new List<EnrolleeSend>();

            using (DataContext db = new DataContext())
            {
                foreach (Enrollee e in db.Enrollees)
                {
                    enrolleeSends.Add(
                        new EnrolleeSend()
                        {
                            Id = e.IdEnrollee,
                            IdDirectionTraining = e.IdDirectionTraining,
                            NameLevelEducation = e?.LevelEducation?.NameLevelEducation,
                            NameConcession =e?.Concession?.NameConcession,
                            DescriptionConcession = e.DescriptionConcession,
                            EnrolleeDateOfRegistration =e.EnrolleeDateOfRegistration,
                            EnrolleeFirstname = e.EnrolleeFirstname,
                            EnrolleeLastname = e.EnrolleeLastname,
                            EnrolleePatronymic = e.EnrolleePatronymic,
                            EnrolleeSex = e.EnrolleeSex,
                            EnrolleeDateOfBirth = e.EnrolleeDateOfBirth,
                            EnrolleePassportSeries = e.EnrolleePassportSeries,
                            EnrolleePassportNumber = e.EnrolleePassportNumber,
                            EnrolleePassportPersonalNumber = e.EnrolleePassportPersonalNumber,
                            EnrolleePassportIssuedBy = e.EnrolleePassportIssuedBy,
                            EnrolleeDateOfIssue = e.EnrolleeDateOfIssue,
                            EnrolleeDateExpiry = e.EnrolleeDateExpiry,
                            EnrolleeAddress = e.EnrolleeAddress,
                            EnrolleePostcode = e.EnrolleePostcode,
                            EnrolleePhoneNumber = e.EnrolleePhoneNumber,
                            EnrolleeEducation = e.EnrolleeEducation,
                            EnrolleeLastPlaceOfStudy = e.EnrolleeLastPlaceOfStudy,
                            EnrolleeAddressLastPlaceOfStudy = e.EnrolleeAddressLastPlaceOfStudy,
                            EnrolleeGraduationDate = e.EnrolleeGraduationDate,
                            EnrolleeNumberCertificateOrDiploma = e.EnrolleeNumberCertificateOrDiploma,
                            EnrolleeAverageGradeOfCertificateOrDiploma = e.EnrolleeAverageGradeOfCertificateOrDiploma,
                            EnrolleeScoreOfTheFirstEntranceTest = e.EnrolleeScoreOfTheFirstEntranceTest,
                            EnrolleeScoreOfTheSecondEntranceTest = e.EnrolleeScoreOfTheSecondEntranceTest,
                            EnrolleeScoreOfTheThirdEntranceTest = e.EnrolleeScoreOfTheThirdEntranceTest,
                            EnrolleeEmail = e.EnrolleeEmail,
                            EnrolleeAdditionalInformation = e.EnrolleeAdditionalInformation
                        }
                        );
                }
            }

            return enrolleeSends;
        }

        public static void DataSerializable()
        {
            List<EnrolleeSend> enrolleeSends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<EnrolleeSend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("SerializableFile/EnrolleeSend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, enrolleeSends);
            }
        }

        public static string ReadToXml()
        {
            string xmlData = null;

            using (StreamReader reader = new StreamReader("SerializableFile/EnrolleeSend.xml"))
            {
                xmlData = reader.ReadToEnd();
            }

            return xmlData;
        }

        public string AddDB(string login)
        {
            string mess = null;

            try
            {
                using (DataContext db = new DataContext())
                {
                    int? idCon = null;
                    if (NameConcession != "без льготы")
                        idCon = db.Concessions.Where(p => p.NameConcession == NameConcession).First().IdConcession;

                    Enrollee enrollee = new Enrollee();
                    enrollee.EnrolleeLastname = EnrolleeLastname;
                    enrollee.EnrolleeFirstname = EnrolleeFirstname;
                    enrollee.EnrolleePatronymic = EnrolleePatronymic;
                    enrollee.IdDirectionTraining = IdDirectionTraining;
                    enrollee.IdLevelEducation = db.LevelEducations.Where(p => p.NameLevelEducation == NameLevelEducation).First().IdLevelEducation;
                    enrollee.IdConcession = idCon;
                    enrollee.DescriptionConcession = DescriptionConcession;
                    enrollee.EnrolleeAdditionalInformation = EnrolleeAdditionalInformation;
                    enrollee.EnrolleeAddress = EnrolleeAddress;
                    enrollee.EnrolleeAddressLastPlaceOfStudy = EnrolleeAddressLastPlaceOfStudy;
                    enrollee.EnrolleeAverageGradeOfCertificateOrDiploma = EnrolleeAverageGradeOfCertificateOrDiploma;
                    enrollee.EnrolleeDateExpiry = (DateTime)EnrolleeDateExpiry;
                    enrollee.EnrolleeDateOfBirth = (DateTime)EnrolleeDateOfBirth;
                    enrollee.EnrolleeDateOfIssue = (DateTime)EnrolleeDateOfIssue;
                    enrollee.EnrolleeDateOfRegistration = DateTime.Now;
                    enrollee.EnrolleeEducation = EnrolleeEducation;
                    enrollee.EnrolleeEmail = EnrolleeEmail;
                    enrollee.EnrolleeGraduationDate = EnrolleeGraduationDate;
                    enrollee.EnrolleeLastPlaceOfStudy = EnrolleeLastPlaceOfStudy;
                    enrollee.EnrolleeNumberCertificateOrDiploma = EnrolleeNumberCertificateOrDiploma;
                    enrollee.EnrolleePassportIssuedBy = EnrolleePassportIssuedBy;
                    enrollee.EnrolleePassportNumber = EnrolleePassportNumber;
                    enrollee.EnrolleePassportPersonalNumber = EnrolleePassportPersonalNumber;
                    enrollee.EnrolleePassportSeries = EnrolleePassportSeries;
                    enrollee.EnrolleePhoneNumber = EnrolleePhoneNumber;
                    enrollee.EnrolleePostcode = EnrolleePostcode;
                    enrollee.EnrolleeScoreOfTheFirstEntranceTest = EnrolleeScoreOfTheFirstEntranceTest;
                    enrollee.EnrolleeScoreOfTheSecondEntranceTest = EnrolleeScoreOfTheSecondEntranceTest;
                    enrollee.EnrolleeScoreOfTheThirdEntranceTest = EnrolleeScoreOfTheThirdEntranceTest;
                    enrollee.EnrolleeSex = EnrolleeSex;

                    db.Enrollees.Add(enrollee);
                    db.SaveChanges();


                    mess = "Данные успешно добавленны";

                    Console.WriteLine($"{DateTime.Now.ToString()}: Пользователь {login} добавил абитуриента {enrollee.EnrolleeLastname} {enrollee.EnrolleeFirstname[0]}. {enrollee.EnrolleePatronymic[0]}.");
                }
            }
            catch (Exception ex)
            {
                mess = "Ошибка " + ex.ToString();

                Console.WriteLine(mess);
            }

            return mess;
        }


        public string UpdateDB(string login)
        {
            string mess = null;

            Console.WriteLine($"{DateTime.Now.ToString()}: Пользователь {login} изменил данные абитуриента {EnrolleeLastname} {EnrolleeFirstname[0]}. {EnrolleePatronymic[0]}.");

            //try
            //{
            using (DataContext db = new DataContext())
                {
                    int? idCon = null;
                        idCon = db.Concessions.Where(p => p.NameConcession == NameConcession).First().IdConcession;

                    Enrollee enrollee = db.Enrollees.Where(p => p.IdEnrollee == this.Id).First();

                db.Enrollees.Attach(enrollee);
                    enrollee.EnrolleeLastname = EnrolleeLastname;
                    enrollee.EnrolleeFirstname = EnrolleeFirstname;
                    enrollee.EnrolleePatronymic = EnrolleePatronymic;
                    enrollee.IdDirectionTraining = IdDirectionTraining;
                    enrollee.IdLevelEducation = db.LevelEducations.Where(p => p.NameLevelEducation == NameLevelEducation).First().IdLevelEducation;
                    enrollee.IdConcession = idCon;
                    enrollee.DescriptionConcession = DescriptionConcession;
                    enrollee.EnrolleeAdditionalInformation = EnrolleeAdditionalInformation;
                    enrollee.EnrolleeAddress = EnrolleeAddress;
                    enrollee.EnrolleeAddressLastPlaceOfStudy = EnrolleeAddressLastPlaceOfStudy;
                    enrollee.EnrolleeAverageGradeOfCertificateOrDiploma = EnrolleeAverageGradeOfCertificateOrDiploma;
                    enrollee.EnrolleeDateExpiry = (DateTime)EnrolleeDateExpiry;
                    enrollee.EnrolleeDateOfBirth = (DateTime)EnrolleeDateOfBirth;
                    enrollee.EnrolleeDateOfIssue = (DateTime)EnrolleeDateOfIssue;
                    enrollee.EnrolleeDateOfRegistration = DateTime.Now;
                    enrollee.EnrolleeEducation = EnrolleeEducation;
                    enrollee.EnrolleeEmail = EnrolleeEmail;
                    enrollee.EnrolleeGraduationDate = EnrolleeGraduationDate;
                    enrollee.EnrolleeLastPlaceOfStudy = EnrolleeLastPlaceOfStudy;
                    enrollee.EnrolleeNumberCertificateOrDiploma = EnrolleeNumberCertificateOrDiploma;
                    enrollee.EnrolleePassportIssuedBy = EnrolleePassportIssuedBy;
                    enrollee.EnrolleePassportNumber = EnrolleePassportNumber;
                    enrollee.EnrolleePassportPersonalNumber = EnrolleePassportPersonalNumber;
                    enrollee.EnrolleePassportSeries = EnrolleePassportSeries;
                    enrollee.EnrolleePhoneNumber = EnrolleePhoneNumber;
                    enrollee.EnrolleePostcode = EnrolleePostcode;
                    enrollee.EnrolleeScoreOfTheFirstEntranceTest = EnrolleeScoreOfTheFirstEntranceTest;
                    enrollee.EnrolleeScoreOfTheSecondEntranceTest = EnrolleeScoreOfTheSecondEntranceTest;
                    enrollee.EnrolleeScoreOfTheThirdEntranceTest = EnrolleeScoreOfTheThirdEntranceTest;
                    enrollee.EnrolleeSex = EnrolleeSex;


                db.SaveChanges();

                    mess = "Данные успешно изменены";

                }

            //}
            //catch (Exception ex)
            //{
            //    mess = "Ошибка " + ex.ToString();

            //    Console.WriteLine(mess);
            //}

            return mess;
        }
    }
}
