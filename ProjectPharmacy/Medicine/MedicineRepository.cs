using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Medicine
{
    public class MedicineRepository
    {
        private readonly string _filePath = "Medicine.txt";

        public bool FileExists()
        {
            return File.Exists(_filePath);
        }

        public List<MedicineModel> LoadData()
        {
            List<MedicineModel> medicines = new List<MedicineModel>();
            if (File.Exists(_filePath))
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    string record = "";
                    while ((record = sr.ReadLine()) != null)
                    {
                        string[] data = record.Split(',');

                        if (data.Length != 3)
                        {
                            continue;
                        }

                        int price;
                        int stock;

                        if (int.TryParse(data[1], out price) && int.TryParse(data[2], out stock))
                        {
                            MedicineModel medicine = new MedicineModel(data[0], price, stock);
                            medicines.Add(medicine);
                        }
                    }
                }
            }
            return medicines;
        }

        public void SaveData(MedicineModel medicine)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, true))
            {
                sw.WriteLine(medicine.ToString());
            }
        }

        public void SaveAllMedicines(List<MedicineModel> medicines)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, false))
            {
                foreach (MedicineModel medicine in medicines)
                {
                    sw.WriteLine(medicine.ToString());
                }
            }
        }
    }
}
