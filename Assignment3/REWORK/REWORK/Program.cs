using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
namespace REWORK
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            do
            {
                Int16 menuSelect = UI.mainUI();
                switch (menuSelect)
                {
                    case 1: UI.AddCustomer(); break;
                    case 2: UI.AddOrder(); break;
                    case 3: UI.RemoveOrder(); break;
                    case 4: UI.ShipOrder(); break;
                    case 5: UI.Print(); break;
                    case 6: UI.Restock(); break;
                    case 7: exit = true; break;
                }
            } while (exit == false);
            Console.WriteLine("Press ENTER to exit program...");
            Console.Read();
            Environment.Exit(0);
        }
    }
    public class UI
    {
        public static Int16 mainUI()
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
        
        /// <summary>
        /// Prompt user for multiple fields of data.
        /// Combine data into a single query.
        /// INSERT into Customers relation.
        /// 
        /// Verifies correct inputs.
        /// </summary>
        public static void AddCustomer()
        {
            Console.WriteLine(
                "ADD CUSTOMER\n" +
                "------------\n");
            Console.WriteLine("Customer ID:");
            String customerID = Console.ReadLine();
            customerID = InputOps.ValidateID(customerID);             // Call method that formats input and verifies it is correct.
            Console.WriteLine("Company Name:");
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

            String addCustomer = String.Format("INSERT INTO Customers (CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,postalCode,Country,Phone,Fax) " +
                   "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", customerID, customerCompanyName,customerContactName,customerContactTitle,
                   customerAddress,customerCity,customerRegion,customerPostalCode,customerCountry,customerPhone,customerFax);
            DB.NonQuery(addCustomer);
        }
        /// <summary>
        /// Same process as AddCustomer method.
        /// </summary>
        public static void AddOrder()
        {
            Console.WriteLine(
                "ADD ORDER\n" +
                "---------\n");
            // Generate ID for Orders OrderID field.
            String orderIDGen = "SELECT MAX(OrderID) FROM Orders WHERE OrderID REGEXP '^[0-9]+$';";
            string orderID = InputOps.GenerateID(orderIDGen);
            // Gather user input for remaining fields.
            Console.WriteLine("Customer ID:");
            string orderCustomerID = Console.ReadLine();
            Console.WriteLine("Employee ID:");
            string orderEmployeeID = Console.ReadLine();
            Console.WriteLine("Order Date:");
            string orderDate = Console.ReadLine();
            Console.WriteLine("Required Date:");
            string orderRequiredDate = Console.ReadLine();
            Console.WriteLine("Shipped Date:");
            string orderShippedDate = Console.ReadLine();
            Console.WriteLine("Shipped Via:");
            string orderShippedVia = Console.ReadLine();
            Console.WriteLine("Freight:");
            string orderFreight = Console.ReadLine();
            Console.WriteLine("Ship Name:");
            string orderShipName = Console.ReadLine();
            Console.WriteLine("Ship Address:");
            string orderShipAddress = Console.ReadLine();
            Console.WriteLine("Ship City:");
            string orderShipCity = Console.ReadLine();
            Console.WriteLine("Ship Region:");
            string orderShipRegion = Console.ReadLine();
            Console.WriteLine("Ship Postal Code:");
            string orderShipPostalCode = Console.ReadLine();
            Console.WriteLine("Ship Country:");
            string orderShipCountry = Console.ReadLine();

            // Info for Order_details relation
            Console.WriteLine(
                "ORDER DETAILS:\n" +
                "ORDER ID: " + orderID +
                "\n--------------");
            // Generate ID for Order_details' ID field
            String orderDetailsIDGen = "SELECT MAX(ID) FROM Order_details WHERE ID REGEXP '^[0-9]+$';";
            string orderDetailsID = InputOps.GenerateID(orderDetailsIDGen);
            // Gather info for other fields.
            Console.WriteLine("Product ID:");
            string orderDetailsProductID = Console.ReadLine();
            Console.WriteLine("Quantity:");
            string orderDetailsQuantity = Console.ReadLine();
            // If item has a discount, the order gets rejected.
            string discountQuery = String.Format("SELECT Discount FROM Order_details WHERE OrderID={0}", orderID);
            string discountYN = DB.Scalar(discountQuery);
            if ( discountYN == "y")
            {
                Console.WriteLine("!! ORDER REJECTED DUE TO DISCOUNT !!");
            }
            else // Otherwise, submit order.
            {
                string grabTimestamp = "SELECT Current_timestamp();";
                grabTimestamp = DB.Scalar(grabTimestamp);

                // Update number of units on order by adding 1
                string updateUnitsOnOrderAdd = String.Format("UPDATE Products SET UnitsOnOrder = UnitsOnOrder+1 WHERE ProductID = '{0}'", orderDetailsProductID);
                DB.NonQuery(updateUnitsOnOrderAdd);

                // Add new row to Orders
                string orderQuery = String.Format("INSERT INTO Orders (OrderID,CustomerID,EmployeeID,RequiredDate,ShippedDate"+
                ",ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry) VALUES" +
                "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
                orderID,orderCustomerID,orderEmployeeID,orderRequiredDate,orderShippedDate,orderShippedVia,orderFreight,orderShipName,
                orderShipAddress,orderShipCity,orderShipRegion,orderShipPostalCode,orderShipCountry);
                DB.NonQuery(orderQuery);
                
                // Add new row to Order_details
                string productUnitPriceQuery = String.Format("SELECT UnitPrice FROM Products WHERE ProductID = '{0}'", orderDetailsProductID);
                string orderDetailsQuery = String.Format("INSERT INTO Order_details (ID,OrderID,ProductID,UnitPrice,Quantity,Discount) VALUES" +
                    "('{0}','{1}','{2}','{3}','{4}','{5}')",orderDetailsID,orderID,orderDetailsProductID,orderDetailsQuantity);
                DB.NonQuery(orderDetailsQuery);
            }
        }
        public static void RemoveOrder()
        {
            Console.WriteLine("REMOVE ORDER\n" +
                              "------------\n" +
                              "Enter Order ID to Delete:");
            string removeOrderID = Console.ReadLine();

            // Run queries to delete row from Orders, Order_details, and remove unit on order from Products
            string removeOrderQuery = String.Format("DELETE FROM Orders WHERE OrderID='{0}'", removeOrderID);
            string removeOrderDetailsQuery = String.Format("DELETE FROM Order_details WHERE OrderID='{0}'", removeOrderID);
            string orderDetailsProductID = String.Format("SELECT ProductID FROM Order_details WHERE OrderID='{0}'",removeOrderID);
            orderDetailsProductID = DB.Scalar(orderDetailsProductID);
            string updateUnitsOnOrderRemove = String.Format("UPDATE Products SET UnitsOnOrder = UnitsOnOrder+1 WHERE ProductID = '{0}'", orderDetailsProductID);
            DB.NonQuery(updateUnitsOnOrderRemove);
            DB.NonQuery(removeOrderQuery);
            DB.NonQuery(removeOrderDetailsQuery);
        }
        /// <summary>
        /// Ask for user input for OrderID. Verify ID exists in Orders relation.
        /// After validation, update that ID with timestamp and echo the update.
        /// </summary>
        public static void ShipOrder()
        {
            Console.WriteLine("SHIP ORDERS\n" +
                              "-----------\n" +
                              "Enter OrderID to Ship:");
            string orderID = Console.ReadLine();
            string validateOrderIDQuery = String.Format("SELECT OrderID FROM Orders WHERE OrderID = '{0}'", orderID);
            while(DB.Scalar(validateOrderIDQuery) == "")
            {
                Console.WriteLine("Please enter a valid Order ID.");
            }
            string shipOrders = "UPDATE Orders SET ShippedDate = Current_timestamp();";
            DB.NonQuery(shipOrders);
            string echo = String.Format("SELECT * FROM Orders WHERE OrderID='{0}'", orderID);
            DB.QueryDB(echo);
            Console.WriteLine("Item Shipped. See above for full order information.");
        }

        /// <summary>
        /// Selects all items from the Orders relation with value 'NULL' in ShippedDate column
        /// and prints entire row.
        /// </summary>
        public static void Print()
        {
            string printOrdersQuery = "SELECT * FROM Orders WHERE ShippedDate IS NULL ORDER BY OrderDate;";
            DB.QueryDB(printOrdersQuery);
        }

        /// <summary>
        /// Restock method finds all items in the Products relation that have less than 10 units remaining in the
        /// UnitsInStock column and adds 10 to that remaining value.
        /// </summary>
        public static void Restock()
        {
            string restockQuery = "UPDATE Product SET UnitsInStock = UnitsInStock+10 WHERE UnitsInStock<10;";
            DB.NonQuery(restockQuery);
            Console.WriteLine("All products with < 10 remaining units have been restocked with 10 more units.");
        }
    }

    /// <summary>
    /// Methods here are called from the UI class.
    /// </summary>
    public class InputOps
    {
        public static string GenerateID(string input)
        {
            string newID = "";
            int tempID;
            try
            {
                tempID = DB.GetID(input);
                tempID++;
                newID = tempID.ToString();
                newID = newID.PadLeft(5, '0');
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return newID;
        }

        /// <summary>
        /// Method used to validate input for customerID.
        /// Entirely used to offload tasks from UI class since it really
        /// should only be dealing with user input and not the actual
        /// functions related to DB queries.
        /// </summary>
        /// <param name="input"></param>
        public static string ValidateID(string input)
        {
            string newID = "";
            int tempID;
            bool duplicate = true;
            String genID = "SELECT MAX(CustomerID) FROM Customers WHERE CustomerID REGEXP '^[0-9]+$';";
            String checkDup = "";
            try
            {
                // Remove all spaces from input string.
                input = input.Replace(" ", String.Empty).ToUpper();
                // If string is longer than 5 char, trim down to 5.
                if (input.Length >= 5) {input = input.Remove(5, input.Length - 5);}
                // Generate new ID
                tempID = DB.GetID(genID);
                while (duplicate == true)
                {
                    newID = tempID.ToString();
                    newID = (input + newID.PadLeft((5 - input.Length), '0')).Remove(0,1);
                    checkDup = String.Format("SELECT CustomerID FROM Customers WHERE CustomerID='{0}';", newID);
                    if (DB.Scalar(checkDup) == "NULL")
                    {
                        if (input.Length >= 5)
                        {
                            input = input.Remove(5, input.Length - 5);
                        }
                        else
                        {
                            input = newID;
                        }
                        duplicate = false;
                    }
                    else
                    {
                        tempID++;
                    }
                }
                Console.WriteLine(input);
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return input;
        }
    }
    public class DB
    {
        public static List<string> QueryDB(string input)
        {
            List<string> queryResult = new List<string>();
            // Connection info and establish connection to server.
            string connStr = "server=localhost;user=root;database=northwind;port=3306;password=toor;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                // Open connection
                conn.Open();
                // Set commands and begin reading query results.
                MySqlCommand cmd = new MySqlCommand(input, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    //queryResult.Add(rdr.GetString(rdr.GetOrdinal())); THIS ALSO WORKS BUT ISNT NEEDED ANYMORE
                    // Below used to output in an easily read format using -- as a delimiter between values
                    // and NULL is filled in for null values in the tables.
                    string filterNull = "";
                    for(int i = 0; i<rdr.FieldCount; i++)
                    {
                        if(!rdr.IsDBNull(i) && i != rdr.FieldCount -1)
                        {
                            filterNull += rdr[i] + " -- ";
                        }
                        else if (!rdr.IsDBNull(i) && i == (rdr.FieldCount-1))
                        {
                            filterNull += rdr[i];
                        }
                        else if (rdr.IsDBNull(i) && i != rdr.FieldCount -1)
                        {
                            filterNull += "NULL -- ";
                        }
                        else if (rdr.IsDBNull(i) && i == (rdr.FieldCount-1))
                        {
                            filterNull += "NULL";
                        }
                    }
                    // Add to List.
                    queryResult.Add(filterNull);
                    // Alternate input methods below.
                    //queryResult.Add(rdr.GetString(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2] + " -- " + rdr[3] + " -- " + rdr[4] + " -- " + rdr[5]));
                    //Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            for (int i = 0; i < queryResult.Count; i++ )
            {
                Console.WriteLine(queryResult[i]);
            }
            return queryResult;
        }
        /// <summary>
        /// This method is used to INPUT and UPDATE the database.
        /// Very similar build to the QueryDB method but uses ExecuteNonQuery function instead.
        /// No return values needed since this only write to DB.
        /// </summary>
        /// <param name="input"></param>
        public static void NonQuery(string input)
        {
            string connStr = "server=localhost;user=root;database=northwind;port=3306;password=toor;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(input, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            conn.Close();
        }
        /// <summary>
        /// Similar to previous two methods but this is used when only a single
        /// value will be returned by a query.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Scalar(string input)
        {
            string connStr = "server=localhost;user=root;database=northwind;port=3306;password=toor;";
            object result = null;
            string output = "";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(input, conn);
                result = cmd.ExecuteScalar();
                // When null value returned, set to actual string NULL to prevent parsing errors.
                // Otherwise just return the value given by query.
                if (result == null || DBNull.Value == result) { output = "NULL"; }
                else { output = result.ToString(); }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            conn.Close();
            return output;
        }
        /// <summary>
        /// Method used to return int value associated with the ID fields of each relation.
        /// Takes string query input.
        /// Mostly finds highest value ID.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Int32 GetID(string input)
        {
            object result = null;
            string connStr = "server=localhost;user=root;database=northwind;port=3306;password=toor;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(input, conn);
                result = cmd.ExecuteScalar();
                if ( result != null && DBNull.Value != result ) { result = Convert.ToInt32(result); }
                else if (result == null || DBNull.Value == result) { result = "NULL"; }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            conn.Close();
            return Convert.ToInt32(result);
        }
    }
}
