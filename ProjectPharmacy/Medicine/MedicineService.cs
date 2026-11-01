using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Medicine
{
    public class MedicineService
    {
        private readonly MedicineRepository _repository;

        public MedicineService()
        {
            _repository = new MedicineRepository();

            // First run: create the file with the default medicines
            //if (!_repository.FileExists())
            //{
            //    LoadDefaultMedicines();
            //}
        }

        public List<MedicineModel> GetAllMedicines()
        {
            return _repository.LoadData();
        }

        public List<MedicineModel> GetAvailableMedicines()
        {
            List<MedicineModel> medicines = _repository.LoadData();
            List<MedicineModel> available = new List<MedicineModel>();

            foreach (MedicineModel medicine in medicines)
            {
                if (medicine.Stock > 0)
                {
                    available.Add(medicine);
                }
            }

            return available;
        }

        public bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            // A comma would break the file format
            if (name.Contains(","))
            {
                return false;
            }

            return true;
        }

        public MedicineModel SearchMedicine(string name)
        {
            List<MedicineModel> medicines = _repository.LoadData();

            foreach (MedicineModel medicine in medicines)
            {
                if (medicine.MedicineName == name)
                {
                    return medicine;
                }
            }

            return null;
        }

        public bool AddMedicine(MedicineModel medicine)
        {
            if (!IsValidName(medicine.MedicineName))
            {
                return false;
            }

            if (medicine.Price < 0 || medicine.Stock < 0)
            {
                return false;
            }

            if (SearchMedicine(medicine.MedicineName) != null)
            {
                return false;
            }

            _repository.SaveData(medicine);
            return true;
        }

        public bool UpdateMedicine(MedicineModel updatedMedicine)
        {
            if (updatedMedicine.Price < 0 || updatedMedicine.Stock < 0)
            {
                return false;
            }

            List<MedicineModel> medicines = _repository.LoadData();

            foreach (MedicineModel medicine in medicines)
            {
                if (medicine.MedicineName == updatedMedicine.MedicineName)
                {
                    medicine.Price = updatedMedicine.Price;
                    medicine.Stock = updatedMedicine.Stock;

                    _repository.SaveAllMedicines(medicines);
                    return true;
                }
            }

            return false;
        }

        public bool DeleteMedicine(string name)
        {
            List<MedicineModel> medicines = _repository.LoadData();

            for (int i = 0; i < medicines.Count; i++)
            {
                if (medicines[i].MedicineName == name)
                {
                    medicines.RemoveAt(i);
                    _repository.SaveAllMedicines(medicines);
                    return true;
                }
            }

            return false;
        }

        public bool ReduceStock(string name, int quantity)
        {
            if (quantity <= 0)
            {
                return false;
            }

            List<MedicineModel> medicines = _repository.LoadData();

            foreach (MedicineModel medicine in medicines)
            {
                if (medicine.MedicineName == name)
                {
                    if (medicine.Stock < quantity)
                    {
                        return false;
                    }

                    medicine.Stock = medicine.Stock - quantity;

                    _repository.SaveAllMedicines(medicines);
                    return true;
                }
            }

            return false;
        }

        //    private void LoadDefaultMedicines()
        //    {
        //        string[] names =
        //        {
        //            "Panadol", "Brufen", "Melatonin", "Fentanyl", "Morphine",
        //            "Vicodin", "Percocet", "Carfentanyl", "Imodium", "Dolophine"
        //        };

        //        int[] prices = { 50, 40, 400, 320, 670, 690, 960, 1500, 500, 240 };
        //        int[] stocks = { 50, 50, 20, 6, 7, 6, 9, 4, 8, 7 };

        //        List<MedicineModel> medicines = new List<MedicineModel>();

        //        for (int i = 0; i < names.Length; i++)
        //        {
        //            medicines.Add(new MedicineModel(names[i], prices[i], stocks[i]));
        //        }

        //        _repository.SaveAllMedicines(medicines);
        //    }
    }
}    