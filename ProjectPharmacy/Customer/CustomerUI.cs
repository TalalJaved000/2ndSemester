using ProjectPharmacy.Bill;
using ProjectPharmacy.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPharmacy.Customer
{
    public class CustomerUI
    {
        CustomerService customerService = new CustomerService();
        MedicineUI medicineUI = new MedicineUI();
        BillUI billUI = new BillUI();

        public void CustomerMenu()
        {
            Console.Clear();
            Console.WriteLine("===== CUSTOMER SECTION =====");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            //if (name == "")
            //{
            //    name = "Walk-in Customer";
            //}

            customerService.AddCustomer(new CustomerModel(name));
            CustomerModel customer = customerService.GetCurrentCustomer();

            // Every customer starts with an empty bill
            billUI.StartNewBill();

            string choice = "";

            while (true)
            {
                Console.Clear();

                Console.WriteLine("===== CUSTOMER MENU =====");
                Console.WriteLine("Customer: " + customer.CustomerName);
                Console.WriteLine("1. View medicines");
                Console.WriteLine("2. Buy medicine");
                Console.WriteLine("3. View bill");
                Console.WriteLine("4. Exit customer section");
                Console.Write("Choose option: ");

                choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Clear();
                    medicineUI.ShowAvailableMedicines();
                }
                else if (choice == "2")
                {
                    billUI.BuyMedicine();
                }
                else if (choice == "3")
                {
                    billUI.ShowBill(customer.CustomerName);
                }
                else if (choice == "4")
                {
                    if (billUI.HasItems())
                    {
                        billUI.ShowBill(customer.CustomerName);
                        Console.WriteLine("Please keep your bill.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
