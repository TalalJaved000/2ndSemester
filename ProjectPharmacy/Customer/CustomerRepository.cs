using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Customer
{
    public class CustomerRepository
    {
        private readonly List<CustomerModel> _customers;

        public CustomerRepository()
        {
            _customers = new List<CustomerModel>();
        }

        public List<CustomerModel> LoadData()
        {
            return _customers;
        }

        public void SaveData(CustomerModel customer)
        {
            _customers.Add(customer);
        }
    }
}
