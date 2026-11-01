using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Medicine
{
    public class MedicineUI
    {
        private readonly MedicineService _service;

        public MedicineUI()
        {
            _service = new MedicineService();
        }

        private void ShowHeader()
        {
            Console.WriteLine("" + "Medicine".PadRight(16) + "Price (PKR)".PadRight(16) + "Stock");
            Console.WriteLine("--------------------------------------------");
        }

        private void ShowRow(MedicineModel medicine)
        {
            Console.WriteLine(medicine.MedicineName.PadRight(16) + medicine.Price.ToString().PadRight(16) + medicine.Stock);
        }

        public void ShowAllMedicines()
        {
            Console.Clear();
            Console.WriteLine("===== ALL MEDICINES =====");
            ShowHeader();

            List<MedicineModel> medicines = _service.GetAllMedicines();

            if (medicines.Count == 0)
            {
                Console.WriteLine("No medicines in the database.");
                return;
            }

            foreach (MedicineModel medicine in medicines)
            {
                ShowRow(medicine);
            }
        }

        public void ShowAvailableMedicines()
        {
            Console.WriteLine("===== AVAILABLE MEDICINES =====");
            ShowHeader();

            List<MedicineModel> medicines = _service.GetAvailableMedicines();

            if (medicines.Count == 0)
            {
                Console.WriteLine("No medicines currently available.");
                return;
            }

            foreach (MedicineModel medicine in medicines)
            {
                ShowRow(medicine);
            }
        }

        public void AddMedicine()
        {
            Console.Clear();
            Console.WriteLine("===== ADD MEDICINE =====");

            Console.Write("Enter medicine name: ");
            string name = Console.ReadLine();

            if (!_service.IsValidName(name))
            {
                Console.WriteLine("Invalid name. It cannot be empty or contain a comma.");
                return;
            }

            if (_service.SearchMedicine(name) != null)
            {
                Console.WriteLine("Medicine already exists. Update it instead.");
                return;
            }

            Console.Write("Enter price: ");
            int price = int.Parse(Console.ReadLine());

            Console.Write("Enter stock: ");
            int stock = int.Parse(Console.ReadLine());

            if (price < 0 || stock < 0)
            {
                Console.WriteLine("Price and stock cannot be negative.");
                return;
            }

            MedicineModel medicine = new MedicineModel(name, price, stock);

            if (_service.AddMedicine(medicine))
            {
                Console.WriteLine("Medicine added successfully.");
            }
            else
            {
                Console.WriteLine("Medicine could not be added.");
            }
        }

        public void SearchMedicine()
        {
            Console.Clear();
            Console.WriteLine("===== SEARCH MEDICINE =====");

            Console.Write("Enter medicine name: ");
            string name = Console.ReadLine();

            MedicineModel medicine = _service.SearchMedicine(name);

            if (medicine == null)
            {
                Console.WriteLine("Medicine not found.");
            }
            else
            {
                Console.WriteLine("Name: " + medicine.MedicineName);
                Console.WriteLine("Price: " + medicine.Price + " PKR");
                Console.WriteLine("Stock: " + medicine.Stock);
            }
        }

        public void UpdateMedicine()
        {
            Console.Clear();
            Console.WriteLine("===== UPDATE MEDICINE =====");

            Console.Write("Enter medicine name: ");
            string name = Console.ReadLine();

            MedicineModel existingMedicine = _service.SearchMedicine(name);

            if (existingMedicine == null)
            {
                Console.WriteLine("Medicine not found.");
                return;
            }

            
            Console.WriteLine("Current price: " + existingMedicine.Price);
            Console.Write("Enter new price: ");
            int price = int.Parse(Console.ReadLine());

            Console.WriteLine("Current stock: " + existingMedicine.Stock);
            Console.Write("Enter new stock: ");
            int stock = int.Parse(Console.ReadLine());

            if (price < 0 || stock < 0)
            {
                Console.WriteLine("Price and stock cannot be negative.");
                return;
            }

            MedicineModel updatedMedicine = new MedicineModel(name, price, stock);

            if (_service.UpdateMedicine(updatedMedicine))
            {
                Console.WriteLine("Medicine updated successfully.");
            }
            else
            {
                Console.WriteLine("Medicine could not be updated.");
            }
        }

        public void DeleteMedicine()
        {
            Console.Clear();
            Console.WriteLine("===== DELETE MEDICINE =====");

            Console.Write("Enter medicine name: ");
            string name = Console.ReadLine();

            if (_service.DeleteMedicine(name))
            {
                Console.WriteLine("Medicine deleted successfully.");
            }
            else
            {
                Console.WriteLine("Medicine not found.");
            }
        }
    }
}
