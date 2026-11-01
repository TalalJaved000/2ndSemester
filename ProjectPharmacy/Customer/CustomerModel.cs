using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Customer
{
    public class CustomerModel
    {
        public string CustomerName;

        public CustomerModel(string customerName)
        {
            CustomerName = customerName;
        }

        public override string ToString()
        {
            return CustomerName;
        }
    }
}
