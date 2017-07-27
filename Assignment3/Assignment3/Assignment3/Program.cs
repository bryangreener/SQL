using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ASSIGNMENT3
{
    class Program
    {

        static void Main(string[] args)
        {
            string connStr = "server=localhost;user=root;database=northwind;port=3306;password=toor;";
            MySqlConnection conn = new MySqlConnection();
            conn.
        }
        private static Int16 UI()
        {
            bool validateInput = false;
            Int16 menuInput = 0;
            do
            {
                Console.WriteLine(
                    "------------------------\n" +
                    "Please select an option:\n" +
                    "1) Add Customer\n" +
                    "2) Add Order\n" +
                    "3) Remove Order\n" +
                    "4) Ship Order\n" +
                    "5) Print Pending\n" +
                    "6) Restock Parts\n" +
                    "7) Exit");
                try { menuInput = Convert.ToInt16(Console.ReadLine()); }
                catch (FormatException e) { Console.WriteLine("Please enter a number 1-7"); }
                finally
                {
                    if (menuInput < 1 || menuInput > 7)
                    {
                        Console.WriteLine("Please enter a number 1-7");
                    }
                    else { validateInput = true; }
                }
            }
            while (validateInput == false);
            return menuInput;
        }

        public static string QueryDB(String input)
        {
            string connStr = "server=localhost;user=root;database=northwind;port=3306;password=toor;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(input, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        public static void AddCustomer()
        {
            Console.WriteLine(
                "ADD CUSTOMER\n" +
                "------------\n" +
                "Company Name:");
            String customerCompanyName = Console.ReadLine();
            Console.WriteLine("Contact Name:");
            String customerContactName = Console.ReadLine();
            Console.WriteLine("Contact Title:");
            String customerContactTitle = Console.ReadLine();
            Console.WriteLine("Address:");
            String customerAddress = Console.ReadLine();
            Console.WriteLine("City:");
            String customerCity = Console.ReadLine();
            Console.WriteLine("Region:");
            String customerRegion = Console.ReadLine();
            Console.WriteLine("Postal Code:");
            String customerPostalCode = Console.ReadLine();
            Console.WriteLine("Country:");
            String customerCountry = Console.ReadLine();
            Console.WriteLine("Phone:");
            String customerPhone = Console.ReadLine();
            Console.WriteLine("Fax:");
            String customerFax = Console.ReadLine();

            String getID = "SELECT MAX(CustomerID) FROM Customers";
            QueryDB
        }
        public static void AddOrder()
        {

        }
        public static void Remove()
        {

        }
        public static void Ship()
        {

        }
        public static void Print()
        {

        }
        public static void Restock()
        {

        }
    }
}
