using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    [Serializable]
    class EnrolleeSend
    {
        public int Id { get; set; }
        public int IdDirectionTraining { get; set; }
        public int IdLevelEducation { get; set; }
        public int? IdConcession { get; set; }
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
                            IdLevelEducation = e.IdLevelEducation,
                            IdConcession =e.IdConcession,
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

    }
}
