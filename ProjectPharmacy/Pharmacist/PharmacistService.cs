using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Pharmacist
{
    public class PharmacistService
    {
        private readonly PharmacistRepository _repository;

        public PharmacistService()
        {
            _repository = new PharmacistRepository();

            //// First run: create the default pharmacist account (Pharmacist / 1234)
            //if (!_repository.FileExists())
            //{
            //    _repository.SaveData(new PharmacistModel("Pharmacist", "1234"));
            //}
        }

        public PharmacistModel SearchPharmacist(string username)
        {
            List<PharmacistModel> pharmacists = _repository.LoadData();

            foreach (PharmacistModel pharmacist in pharmacists)
            {
                if (pharmacist.Username == username)
                {
                    return pharmacist;
                }
            }

            return null;
        }

        public bool Login(string username, string password)
        {
            PharmacistModel pharmacist = SearchPharmacist(username);

            if (pharmacist == null)
            {
                return false;
            }

            return pharmacist.Password == password;
        }
    }
}
