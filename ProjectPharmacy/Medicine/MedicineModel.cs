using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Medicine
{
    public class MedicineModel
    {
        public string MedicineName;
        public int Price;
        public int Stock;

        public MedicineModel(string medicineName, int price, int stock)
        {
            MedicineName = medicineName;
            Price = price;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"{MedicineName},{Price},{Stock}";
        }
    }
}
