using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Pharmacist
{
    public class PharmacistModel
    {
        public string Username;
        public string Password;

        public PharmacistModel(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            return $"{Username},{Password}";
        }
    }
}
