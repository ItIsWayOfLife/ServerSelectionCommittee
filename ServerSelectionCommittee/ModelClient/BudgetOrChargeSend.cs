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
    public class BudgetOrChargeSend
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

        public static void DataSerializable()
        {
            List<BudgetOrChargeSend> budgetOrChargeSends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<BudgetOrChargeSend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("SerializableFile/BudgetOrChargeSend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, budgetOrChargeSends);
            }
        }
    }
}
