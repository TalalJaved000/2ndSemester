using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Pharmacist
{
    public class PharmacistRepository
    {
        private readonly string _filePath = "Pharmacist.txt";

        public bool FileExists()
        {
            return File.Exists(_filePath);
        }

        public List<PharmacistModel> LoadData()
        {
            List<PharmacistModel> pharmacists = new List<PharmacistModel>();
            if (File.Exists(_filePath))
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    string record = "";
                    while ((record = sr.ReadLine()) != null)
                    {
                        string[] data = record.Split(',');

                        if (data.Length != 2)
                        {
                            continue;
                        }

                        PharmacistModel pharmacist = new PharmacistModel(data[0], data[1]);
                        pharmacists.Add(pharmacist);
                    }
                }
            }
            return pharmacists;
        }

        public void SaveData(PharmacistModel pharmacist)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, true))
            {
                sw.WriteLine(pharmacist.ToString());
            }
        }
    }
}
