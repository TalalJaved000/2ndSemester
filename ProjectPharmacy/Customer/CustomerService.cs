using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Customer
{
    public class CustomerService
    {
        private readonly CustomerRepository _repository;

        public CustomerService()
        {
            _repository = new CustomerRepository();
        }

        public void AddCustomer(CustomerModel customer)
        {
            _repository.SaveData(customer);
        }

        public CustomerModel GetCurrentCustomer()
        {
            List<CustomerModel> customers = _repository.LoadData();

            if (customers.Count == 0)
            {
                return null;
            }

            return customers[customers.Count - 1];
        }
    }
}
