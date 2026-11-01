using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Bill
{
    public class BillRepository
    {
        private readonly List<BillModel> _bills;

        public BillRepository()
        {
            _bills = new List<BillModel>();
        }

        public List<BillModel> LoadData()
        {
            return _bills;
        }

        public void SaveData(BillModel bill)
        {
            _bills.Add(bill);
        }

        public void ClearData()
        {
            _bills.Clear();
        }
    }
}
