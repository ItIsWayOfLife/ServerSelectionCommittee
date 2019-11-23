using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    class DataSerializable
    {
        public List<BudgetOrChargeSend> BudgetOrChargeSends { get; set; }
        public List<ConcessionSend> ConcessionSends { get; set; }
        public List<ContractEnSend> ContractEnSends { get; set; }
        public List<DepartmentSend> DepartmentSends { get; set; }
        public List<DocumentsSend> DocumentsSends { get; set; }
        public List<EnrolleeSend> EnrolleeSends { get; set; }
        public List<FacultySend> FacultySends { get; set; }
        public List<FormStudySend> FormStudySends { get; set; }
        public List<HistorySend> HistorySends { get; set; }
        public List<LevelEducationSend>  EducationSends { get; set; }
        public List<RelativeOrGuardianSend>  RelativeOrGuardianSends { get; set; }
        public List<SpecialtySend>  SpecialtySends { get; set; }
        public List<TrainingDirectionSend> TrainingDirectionSends { get; set; }
        public List<TrainingPeriodSend> TrainingPeriodSends { get; set; }
        public List<UserSend> UserSends { get; set; }


        public DataSerializable()
        {
            BudgetOrChargeSends = BudgetOrChargeSend.GetData();
            ConcessionSends = ConcessionSend.GetData();
            ContractEnSends = ContractEnSend.GetData();
            DepartmentSends = DepartmentSend.GetData();
            DocumentsSends = DocumentsSend.GetData();
            EnrolleeSends = EnrolleeSend.GetData();

            FacultySends = FacultySend.GetData();
            FormStudySends = FormStudySend.GetData();
            HistorySends = HistorySend.GetData();

            RelativeOrGuardianSends = RelativeOrGuardianSend.GetData();
            SpecialtySends = SpecialtySend.GetData();
            TrainingDirectionSends = TrainingDirectionSend.GetData();
            TrainingPeriodSends = TrainingPeriodSend.GetData();
            UserSends = UserSend.GetData();
        }
    }
}
