using ProjectPharmacy.Bill;
using ProjectPharmacy.Customer;
using ProjectPharmacy.Medicine;
using ProjectPharmacy.Pharmacist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy
{
    public class PharmacyUI
    {
        PharmacistUI pharmacistUI = new PharmacistUI();
        CustomerUI customerUI = new CustomerUI();

        public void MainMenu()
        {
            string choice = "";

            while (true)
            {
                Console.Clear();

                Console.WriteLine("============================================");
                Console.WriteLine("       PHARMACY MANAGEMENT SYSTEM");
                Console.WriteLine("============================================");
                Console.WriteLine("1. Pharmacist");
                Console.WriteLine("2. Customer");
                Console.WriteLine("3. Exit");
                Console.Write("Choose option: ");

                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (pharmacistUI.Login())
                    {
                        pharmacistUI.ShowPharmacistMenu();
                    }
                }
                else if (choice == "2")
                {
                    customerUI.CustomerMenu();
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Thank you for using the pharmacy system.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
