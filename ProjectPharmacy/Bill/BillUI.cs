using ProjectPharmacy.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Bill
{
    public class BillUI
    {
        private readonly BillService _service;
        private readonly MedicineService _medicineService;
        private readonly MedicineUI _medicineUI;

        public BillUI()
        {
            _service = new BillService();
            _medicineService = new MedicineService();
            _medicineUI = new MedicineUI();
        }

        public void StartNewBill()
        {
            _service.ResetBill();
        }

        public bool HasItems()
        {
            return _service.HasItems();
        }

        public void BuyMedicine()
        {
            Console.Clear();
            Console.WriteLine("===== BUY MEDICINE =====");

            _medicineUI.ShowAvailableMedicines();

            Console.Write("Enter medicine name: ");
            string name = Console.ReadLine().Trim();

            MedicineModel medicine = _medicineService.SearchMedicine(name);

            if (medicine == null)
            {
                Console.WriteLine("Medicine not found.");
                return;
            }

            if (medicine.Stock <= 0)
            {
                Console.WriteLine("This medicine is out of stock.");
                return;
            }

            Console.WriteLine("Price per item: " + medicine.Price);
            Console.WriteLine("Available stock: " + medicine.Stock);
            Console.Write("Enter quantity: ");

            int quantity;
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            if (quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than zero.");
                return;
            }

            if (quantity > medicine.Stock)
            {
                Console.WriteLine("Not enough stock available.");
                return;
            }

            if (_service.AddToBill(medicine.MedicineName, quantity))
            {
                Console.WriteLine("Medicine added to bill.");
                Console.WriteLine("Total for this item: " + (medicine.Price * quantity) + " PKR");
            }
            else
            {
                Console.WriteLine("Could not add medicine to bill.");
            }
        }

        public void ShowBill(string customerName)
        {
            Console.Clear();
            Console.WriteLine("===== YOUR BILL =====");
            Console.WriteLine("Customer: " + customerName);
            Console.WriteLine("Medicine".PadRight(16) + "Quantity".PadRight(16) + "Price (PKR)");
            Console.WriteLine("--------------------------------------------");

            List<BillModel> bills = _service.GetBillItems();

            if (bills.Count == 0)
            {
                Console.WriteLine("No items in the bill.");
                return;
            }

            foreach (BillModel bill in bills)
            {
                Console.WriteLine(bill.MedicineName.PadRight(16) + bill.Quantity.ToString().PadRight(16) + bill.CalculateTotal());
            }

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Total bill: " + _service.CalculateTotal() + " PKR");
        }
    }
}
