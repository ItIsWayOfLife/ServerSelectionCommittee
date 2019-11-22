using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    [Serializable]
    class ContractEnSend
    {
        public int Id { get; set; }
        public int IdEnrolle { get; set; }
        public string NumberContract { get; set; }
        public DateTime ImprisonmentDateContract { get; set; }
        public DateTime ValidityContract { get; set; }
        public string DescriptionContract { get; set; }

        public static List<ContractEnSend> GetData()
        {
            List<ContractEnSend> contractEnSends = new List<ContractEnSend>();

            using (DataContext db = new DataContext())
            {
                foreach (ContractEn c in db.ContractEns)
                {
                    contractEnSends.Add(
                        new ContractEnSend()
                        {
                            Id = c.IdContract,
                            IdEnrolle = c.IdEnrolle,
                            NumberContract = c.NumberContract,
                            ImprisonmentDateContract = c.ImprisonmentDateContract,
                            ValidityContract = c.ValidityContract,
                            DescriptionContract = c.DescriptionContract
                        }
                        );
                }
            }

            return contractEnSends;
        }
    }
}
