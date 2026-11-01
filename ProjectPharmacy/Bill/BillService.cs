using ProjectPharmacy.Customer;
using ProjectPharmacy.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Bill
{
    public class BillService
    {
        private readonly BillRepository _repository;
        private readonly MedicineService _medicineService;

        public BillService()
        {
            _repository = new BillRepository();
            _medicineService = new MedicineService();
        }

        public void ResetBill()
        {
            _repository.ClearData();
        }

        public List<BillModel> GetBillItems()
        {
            return _repository.LoadData();
        }

        public bool HasItems()
        {
            return _repository.LoadData().Count > 0;
        }

        public int CalculateTotal()
        {
            int total = 0;

            foreach (BillModel bill in _repository.LoadData())
            {
                total = total + bill.CalculateTotal();
            }

            return total;
        }

        public bool AddToBill(string medicineName, int quantity)
        {
            // Check whether the medicine exists
            MedicineModel medicine = _medicineService.SearchMedicine(medicineName);

            if (medicine == null)
            {
                return false;
            }

            // Check the quantity
            if (quantity <= 0 || quantity > medicine.Stock)
            {
                return false;
            }

            // Take the quantity out of stock
            if (!_medicineService.ReduceStock(medicine.MedicineName, quantity))
            {
                return false;
            }

            // Add the item to the bill
            BillModel bill = new BillModel(medicine.MedicineName, quantity, medicine.Price);
            _repository.SaveData(bill);
            return true;
        }
    }
}
