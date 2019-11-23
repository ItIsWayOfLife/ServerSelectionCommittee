using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    [Serializable]
    class BudgetOrChargeSend
    {
        public int Id { get; set; }
        public string NameBudgetOrCharge { get; set; }

        public static List<BudgetOrChargeSend> GetData()
        {
            List<BudgetOrChargeSend> budgetOrChargeSends = new List<BudgetOrChargeSend>();

            using (DataContext db = new DataContext())
            {
                foreach (BudgetOrCharge b in db.BudgetOrCharges)
                {
                    budgetOrChargeSends.Add(
                        new BudgetOrChargeSend()
                        {
                            Id =b.IdBudgetOrCharge,
                            NameBudgetOrCharge = b.NameBudgetOrCharge
                        }
                        );
                }
            }

            return budgetOrChargeSends;
        }
    }
}
