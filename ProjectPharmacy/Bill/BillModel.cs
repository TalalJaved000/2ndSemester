using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Bill
{
    public class BillModel
    {
        public string MedicineName;
        public int Quantity;
        public int UnitPrice;

        public BillModel(string medicineName, int quantity, int unitPrice)
        {
            MedicineName = medicineName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public int CalculateTotal()
        {
            return UnitPrice * Quantity;
        }

        public override string ToString()
        {
            return $"{MedicineName},{Quantity},{UnitPrice}";
        }
    }
}
