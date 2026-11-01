using ProjectPharmacy.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Pharmacist
{
    public class PharmacistUI
    {
        private readonly PharmacistService _service;
        private readonly MedicineUI _medicineUI;

        public PharmacistUI()
        {
            _service = new PharmacistService();
            _medicineUI = new MedicineUI();
        }

        public bool Login()
        {
            int attempt = 1;

            while (attempt <= 3)
            {
                Console.Clear();
                Console.WriteLine("===== PHARMACIST LOGIN =====");
                Console.WriteLine("Attempt " + attempt + " of 3");

                Console.Write("Username: ");
                string username = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                if (_service.Login(username, password))
                {
                    Console.WriteLine("Login successful!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true;
                }

                Console.WriteLine("Wrong username or password.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                attempt++;
            }

            Console.WriteLine("Too many failed attempts.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            return false;
        }

        public void ShowPharmacistMenu()
        {
            string choice = "";

            while (true)
            {
                Console.Clear();

                Console.WriteLine("===== PHARMACIST MENU =====");
                Console.WriteLine("1. Show all medicines");
                Console.WriteLine("2. Add medicine");
                Console.WriteLine("3. Search medicine");
                Console.WriteLine("4. Update medicine");
                Console.WriteLine("5. Delete medicine");
                Console.WriteLine("6. Logout");
                Console.Write("Choose option: ");

                choice = Console.ReadLine();

                if (choice == "1")
                {
                    _medicineUI.ShowAllMedicines();
                }
                else if (choice == "2")
                {
                    _medicineUI.AddMedicine();
                }
                else if (choice == "3")
                {
                    _medicineUI.SearchMedicine();
                }
                else if (choice == "4")
                {
                    _medicineUI.UpdateMedicine();
                }
                else if (choice == "5")
                {
                    _medicineUI.DeleteMedicine();
                }
                else if (choice == "6")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
