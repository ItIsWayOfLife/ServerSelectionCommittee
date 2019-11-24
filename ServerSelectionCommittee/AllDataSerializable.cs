using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    public static class AllDataSerializable
    {
        public static void AllSerializable()
        {
           
            ConcessionSend.DataSerializable();
            ContractEnSend.DataSerializable();
            
            DocumentsSend.DataSerializable();
            EnrolleeSend.DataSerializable();
           
            HistorySend.DataSerializable();
            LevelEducationSend.DataSerializable();
            RelativeOrGuardianSend.DataSerializable();
         
            TrainingDirectionSend.DataSerializable();
           
            UserSend.DataSerializable();
        }


    }
}
