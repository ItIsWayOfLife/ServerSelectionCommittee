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
    public class ContractEnSend
    {
        public int Id { get; set; }
        public int IdEnrollee { get; set; }
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
                            IdEnrollee = c.IdEnrollee,
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

        public static void DataSerializable()
        {
            List<ContractEnSend> contractEnSends = GetData();

            XmlSerializer formatter = new XmlSerializer(typeof(List<ContractEnSend>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("SerializableFile/ContractEnSend.xml", FileMode.Create))
            {
                formatter.Serialize(fs, contractEnSends);
            }
        }
    }
}
