/* DBMS Assignment 3
 * Due: 2017-07-31
 * By: Bryan Greener
 */

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
namespace REWORK
{
	class Program
	{
		/// <summary>
		/// Main method that calls mainUI method.
		/// Input calls UI methods based on return from mainUI.
		/// </summary>
		/// <param name="args"></param>
		#region Main
		static void Main(string[] args)
		{
			// Prompt user to enter database connection info
			DBConnect();

			// Used to control following do while loop in order to close program.
			bool exit = false;
			do
			{
                // Call mainUI which returns value 1-7 for following switch statement.
				Int16 menuSelect = mainUI();
                // Switch statement calls methods from UI region.
				switch (menuSelect)
				{
					case 1: AddCustomer(); break;
					case 2: AddOrder(); break;
					case 3: RemoveOrder(); break;
					case 4: ShipOrder(); break;
					case 5: Print(); break;
					case 6: Restock(); break;
					case 7: exit = true; break;
				}
			} while (exit == false);

            // Close console.
			Console.WriteLine("Press ENTER to exit program...");
			Console.Read();
			Environment.Exit(0);
		}
		#endregion

		/// <summary>
		/// Region used to take user inputs. Uses helper methods and DB regions to process inputs.
		/// </summary>
		/// <returns></returns>
		#region UI
		public static Int16 mainUI()
		{
            // Clear console used to make view a bit cleaner. Used at beginning of all UI methods.
            //Console.Clear();
			
			// Variable used to break do while loop.
			bool validateInput = false;
			Int16 menuInput = 0;

			do
			{
				Console.WriteLine(
					"------------------------\n" +
					" CONNECTED TO DATABASE\n" +
					"------------------------\n" +
					"Please select an option:\n" +
					"1) Add Customer\n" +
					"2) Add Order\n" +
					"3) Remove Order\n" +
					"4) Ship Order\n" +
					"5) Print Pending\n" +
					"6) Restock Parts\n" +
					"7) Exit");
                // Test if input is an integer, otherwise ask for corrected user input.
				try { menuInput = Convert.ToInt16(Console.ReadLine()); }
				catch (FormatException e) { Console.WriteLine("Please enter a number 1-7"); }
				finally
				{
                    // Verify input is one of given values.
					if (menuInput < 1 || menuInput > 7)
					{
						Console.WriteLine("Please enter a number 1-7");
					}
					else { validateInput = true; }
				}
			}
			while (validateInput == false);

            // Return value back to main class to call appropriate followup methods.
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
            //Console.Clear();

            // Ask for user input to fill out fields. Each input is checked to make sure it is not empty.
			Console.WriteLine(
				"ADD CUSTOMER\n" +
				"------------\n");

			Console.WriteLine("Customer ID:");
			String id = Console.ReadLine();
            // Call method that formats input and verifies it is correct.
            id = ValidateID(id);             
			Console.WriteLine("Company Name:");
			String companyName = Console.ReadLine();
            companyName = ValidateInput(companyName);
			Console.WriteLine("Contact Name:");
			String contactName = Console.ReadLine();
            contactName = ValidateInput(contactName);
            Console.WriteLine("Contact Title:");
			String title = Console.ReadLine();
            title = ValidateInput(title);
            Console.WriteLine("Address:");
			String addr = Console.ReadLine();
            addr = ValidateInput(addr);
            Console.WriteLine("City:");
			String city = Console.ReadLine();
            city = ValidateInput(city);
            Console.WriteLine("Region:");
			String region = Console.ReadLine();
            region = ValidateInput(region);
            Console.WriteLine("Postal Code:");
			String postal = Console.ReadLine();
            postal = ValidateInput(postal);
            Console.WriteLine("Country:");
			String country = Console.ReadLine();
            country = ValidateInput(country);
            Console.WriteLine("Phone:");
			String phone = Console.ReadLine();
            phone = ValidateInput(phone);
            Console.WriteLine("Fax:");
			String fax = Console.ReadLine();
            fax = ValidateInput(fax);

            // Create query string. Send to NonQuery method.
            String addCustomer = $"START TRANSACTION; INSERT INTO Customers (CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,postalCode,Country,Phone,Fax) " +
				$"VALUES('{id}','{companyName}','{contactName}','{title}','{addr}','{city}','{region}','{postal}','{country}','{phone}','{fax}'); COMMIT;";
			NonQuery(addCustomer);

            // Prompt for enter key to return to mainUI.
            Console.WriteLine("----------------------------------");
            Console.WriteLine("PRESS ENTER TO RETURN TO MAIN MENU");
            Console.ReadLine();

            // Return line used to send user back to main menu. Used in every UI method.
            return;
        }

		/// <summary>
		/// Same process as AddCustomer method.
		/// </summary>
		public static void AddOrder()
		{
            //Console.Clear();

			Console.WriteLine(
				"ADD ORDER\n" +
				"---------\n");
			// Generate ID for Orders OrderID field.
			String orderIDGen = "SELECT MAX(OrderID) FROM Orders WHERE OrderID REGEXP '^[0-9]+$';";
			string orderID = GenerateID(orderIDGen);

			// Gather user input for remaining fields.
			Console.WriteLine("Customer ID:");
			string cid = Console.ReadLine();
            cid = ValidateInput(cid);
            Console.WriteLine("Employee ID:");
			string eid = Console.ReadLine();
            eid = ValidateInput(eid);
            //Console.WriteLine("Order Date:");
            string oDate;// = Console.ReadLine();
            //oDate = ValidateInput(oDate);
            Console.WriteLine("Required Date:");
			string rDate = Console.ReadLine();
            rDate = ValidateInput(rDate);
            Console.WriteLine("Shipped Date:");
			string sDate = Console.ReadLine();
            sDate = ValidateInput(sDate);
            Console.WriteLine("Shipped Via:");
			string sVia = Console.ReadLine();
            sVia = ValidateInput(sVia);
            Console.WriteLine("Freight:");
			string freight = Console.ReadLine();
            freight = ValidateInput(freight);
            Console.WriteLine("Ship Name:");
			string sName = Console.ReadLine();
            sName = ValidateInput(sName);
            Console.WriteLine("Ship Address:");
			string sAddr = Console.ReadLine();
            sAddr = ValidateInput(sAddr);
            Console.WriteLine("Ship City:");
			string sCity = Console.ReadLine();
            sCity = ValidateInput(sCity);
            Console.WriteLine("Ship Region:");
            string sRegion = Console.ReadLine();
            sRegion = ValidateInput(sRegion);
            Console.WriteLine("Ship Postal Code:");
			string sPostal = Console.ReadLine();
            sPostal = ValidateInput(sPostal);
            Console.WriteLine("Ship Country:");
			string sCountry = Console.ReadLine();
            sCountry = ValidateInput(sCountry);

            // Info for Order_details relation
            Console.WriteLine(
				"ORDER DETAILS:\n" +
				"ORDER ID: " + orderID +
				"\n--------------");
			
            // Generate ID for Order_details' ID field
			String orderDetailsIDGen = "SELECT MAX(ID) FROM Order_details WHERE ID REGEXP '^[0-9]+$';";
			string orderDetailsID = GenerateID(orderDetailsIDGen);
			
            // Gather info for other fields.
			Console.WriteLine("Product ID:");
			string detailID = Console.ReadLine();
            //detailID = ValidateInput(detailID);
            Console.WriteLine("Quantity:");
			string quantity = Console.ReadLine();
            quantity = ValidateInput(quantity);

            // If item has a discount, the order gets rejected.
            string discontQuery = $"SELECT Discontinued FROM Products WHERE ProductID={detailID}";
            string discontYN = Scalar(discontQuery);

			if (discontYN == "y")
			{
				Console.WriteLine("!! ORDER REJECTED DUE TO DISCOUNT !!");
			}
			else // Otherwise, submit order.
			{
				string grabTimestamp = "SELECT Current_timestamp();";
				grabTimestamp = Scalar(grabTimestamp);
                oDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//grabTimestamp;

				// Update number of units on order by adding 1
				string updateUnitsOnOrderAdd = $"START TRANSACTION; UPDATE Products SET UnitsOnOrder=UnitsOnOrder+{quantity} WHERE ProductID={detailID}; COMMIT;";
				NonQuery(updateUnitsOnOrderAdd);

				// Add new row to Orders
				string orderQuery = "START TRANSACTION; INSERT INTO Orders (OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate" +
				",ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry) VALUES" +
				$"('{orderID}','{cid}','{eid}','{oDate}','{rDate}','{sDate}','{sVia}','{freight}','{sName}','{sAddr}','{sCity}','{sRegion}','{sPostal}','{sCountry}'); COMMIT;";
				NonQuery(orderQuery);
                string zero = "0";
				// Add new row to Order_details
				string productUnitPriceQuery = $"START TRANSACTION; SELECT UnitPrice FROM Products WHERE ProductID={detailID}";
                string unitPrice = Scalar(productUnitPriceQuery);
                double price = Convert.ToDouble(unitPrice);
                price = Convert.ToDouble(unitPrice);
				string orderDetailsQuery = "INSERT INTO Order_details (ID,OrderID,ProductID,UnitPrice,Quantity,Discount) VALUES" +
					$"('{orderDetailsID}','{orderID}','{detailID}','{price}','{quantity}','{zero}'); COMMIT;";
				NonQuery(orderDetailsQuery);
			}

            // Prompt for enter key to return to mainUI.
            Console.WriteLine("----------------------------------");
            Console.WriteLine("PRESS ENTER TO RETURN TO MAIN MENU");
            Console.ReadLine();
            return;
        }

        /// <summary>
        /// Asks user for OrderID to delete.
        /// </summary>
		public static void RemoveOrder()
		{
            //Console.Clear();

			Console.WriteLine("REMOVE ORDER\n" +
							  "------------\n" +
							  "Enter Order ID to Delete:");
			string rid = Console.ReadLine();

            // Check if item with OrderID = rid exists in DB.
            string findOrder = $"SELECT OrderID FROM Orders WHERE OrderID='{rid}'";
            // If it does exist...
            if (Scalar(findOrder) != "NULL")
            {
                // Run queries to delete row from Orders, Order_details, and remove unit on order from Products
                string removeOrderQuery = $"START TRANSACTION; DELETE FROM Orders WHERE OrderID='{rid}'; COMMIT;";
                string removeOrderDetailsQuery = $"START TRANSACTION; DELETE FROM Order_details WHERE OrderID='{rid}'; COMMIT;";
                string pid = $"SELECT ProductID FROM Order_details WHERE OrderID='{rid}'";
                pid = Scalar(pid);
                string uoo = $"SELECT Quantity FROM Order_details WHERE OrderID='{rid}'";
                uoo = Scalar(uoo);
                string updateUnitsOnOrderRemove = $"START TRANSACTION; UPDATE Products SET UnitsOnOrder = UnitsOnOrder-'{uoo}' WHERE ProductID = '{pid}'; COMMIT;";
                NonQuery(updateUnitsOnOrderRemove);
                //NonQuery(removeOrderQuery);
                NonQuery(removeOrderDetailsQuery);
            } // Otherwise...
            else { Console.WriteLine($"NO ORDER WITH ID '{rid}' FOUND."); }
			
            // Prompt for enter key to return to mainUI.
            Console.WriteLine("----------------------------------");
            Console.WriteLine("PRESS ENTER TO RETURN TO MAIN MENU");
            Console.ReadLine();
            return;
        }

		/// <summary>
		/// Ask for user input for OrderID. Verify ID exists in Orders relation.
		/// After validation, update that ID with timestamp and echo the update.
		/// </summary>
		public static void ShipOrder()
		{
            //Console.Clear();

            string id = "";
            string validateOrderIDQuery = "";
            string checkIfShipped = "";
            Console.WriteLine("SHIP ORDERS");
            Console.WriteLine("-----------");
            // Loop used to ask for appropriate input and verify that all data is entered correctly.
            do
            {
                Console.WriteLine("Enter Valid OrderID to Ship:");
                id = Console.ReadLine();
                validateOrderIDQuery = $"SELECT OrderID FROM Orders WHERE OrderID = '{id}'";
                
                // While entered ID exists in relation
                while (Scalar(validateOrderIDQuery) == "NULL")
                {
                    Console.WriteLine("Please enter a valid Order ID:");
                    id = Console.ReadLine();
                    validateOrderIDQuery = $"SELECT OrderID FROM Orders WHERE OrderID = '{id}'";
                }
                // Check to see if the order has already been shipped.
                checkIfShipped = $"SELECT ShippedDate FROM Orders WHERE OrderID = '{id}'";
                checkIfShipped = Scalar(checkIfShipped);
                // If already shipped, return error and continue loop until user enters valid ID
                if (checkIfShipped != "NULL") { Console.WriteLine("UNABLE TO SHIP. Order has already been shipped."); }
            } while (checkIfShipped != "NULL");

            // After input has been verified to exist in relation, update Shipped Date field in relation with current timestamp.
			string shipOrders = $"START TRANSACTION; UPDATE Orders SET ShippedDate = Current_timestamp() WHERE OrderID = '{id}'; COMMIT;";
            NonQuery(shipOrders);
            // Print order info for newly shipped order.
			string echo = $"SELECT * FROM Orders WHERE OrderID='{id}'";
			QueryDB(echo);
			Console.WriteLine("^^ Order Shipped. See above for full order information. ^^");

            // Prompt for enter key to return to mainUI.
            Console.WriteLine("----------------------------------");
            Console.WriteLine("PRESS ENTER TO RETURN TO MAIN MENU");
            Console.ReadLine();
            return;
        }

		/// <summary>
		/// Selects all items from the Orders relation with value 'NULL' in ShippedDate column
		/// and prints entire row.
		/// </summary>
		public static void Print()
		{
            //Console.Clear();

            // Header formatting. space string used to simplify formatting.
            string space = "";
            Console.WriteLine($"ID{space.PadRight(7, ' ')}CID{space.PadRight(6, ' ')}EID{space.PadRight(2, ' ')}Order Date{space.PadRight(14, ' ')}Required Date{space.PadRight(9, ' ')}" +
                $"ShipDate{space.PadRight(2, ' ')}Via{space.PadRight(2, ' ')}Freight{space.PadRight(2, ' ')}Ship Name{space.PadRight(10, ' ')}Ship Address{space.PadRight(5, ' ')}Ship City{space.PadRight(5, ' ')}" +
                $"Ship Region{space.PadRight(3, ' ')}Ship Postal{space.PadRight(2, ' ')}Ship Country");

            // Query DB to return list of rows where ShippedDate is null.
            string printOrdersQuery = "SELECT * FROM Orders WHERE ShippedDate IS NULL ORDER BY OrderDate;";
			QueryDB(printOrdersQuery);

            // Prompt for enter key to return to mainUI.
            Console.WriteLine("----------------------------------");
            Console.WriteLine("PRESS ENTER TO RETURN TO MAIN MENU");
            Console.ReadLine();
            return;
        }

		/// <summary>
		/// Restock method finds all items in the Products relation that have less than 10 units remaining in the
		/// UnitsInStock column and adds 10 to that remaining value.
		/// </summary>
		public static void Restock()
		{
            //Console.Clear();

            // Update DB. See writeline for explanation.
			string restockQuery = "START TRANSACTION; UPDATE Products SET UnitsInStock = UnitsInStock+50 WHERE UnitsInStock<10; COMMIT;";
			NonQuery(restockQuery);
			Console.WriteLine("All products with < 10 remaining units have been restocked with 50 more units.");

            // Prompt for enter key to return to mainUI.
            Console.WriteLine("----------------------------------");
            Console.WriteLine("PRESS ENTER TO RETURN TO MAIN MENU");
            Console.ReadLine();
            return;
        }
		#endregion

		/// <summary>
		/// Helper methods used to process input and validate correctness of user data.
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		#region HelperMethods
		public static string GenerateID(string input)
		{
			string newID = "";
			int tempID;
            // Test to make sure input is an integer and format the input using GetID method.
			try
			{
				tempID = Convert.ToInt32(GetID(input));
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
            string tempGen;
            // Finds max auto generated ID with only numbers in its ID.
			String genID = "SELECT MAX(CustomerID) FROM Customers WHERE CustomerID REGEXP '^[0-9]+$';";
			String checkDup = "";

            try
			{
				// Remove all spaces from input string.
				input = input.Replace(" ", String.Empty).ToUpper();
				// If string is longer than 5 char, trim down to 5.
				if (input.Length >= 5) { input = input.Remove(5, input.Length - 5); }
                // Generate new ID
                tempGen = GetID(genID);
                // When no auto gen IDs have been created yet, this prevents error with null return from query.
                if (tempGen == "NULL") { tempID = 0; }
                else { tempID = Convert.ToInt32(tempGen); }
                // Checks if input value exists in relation already.
                checkDup = $"SELECT CustomerID FROM Customers WHERE CustomerID='{input}';";
                if(Scalar(checkDup) =="NULL")
                {
                    duplicate = false;
                }
                // While the value already exists in relation...
                while (duplicate == true)
				{
                    // Format string to match other IDs
					newID = tempID.ToString();
                    newID = newID.PadLeft(5 - input.Length, '0');
                    // Heavy formatting to concatenate input with auto generated ID
                    if(input.Length + newID.Length > 5)
                    {
                        input = input.Remove(5 - newID.Length);
                    }
                    newID = input + newID;

                    // Verify this new ID doesn't exist in relation. Much of above processes repeated here.
                    checkDup = $"SELECT CustomerID FROM Customers WHERE CustomerID='{newID}';";
					if (Scalar(checkDup) == "NULL")
					{
						if (input.Length > 5)
						{
							input = input.Remove(5, input.Length - 5);
						}
						else
						{
							input = newID;
						}
						duplicate = false;
					}
					else // Otherwise, increment tempID and continue loop until unique ID is created.
					{
						tempID++;
					}
				}
				//Console.WriteLine(input); USED FOR TESTING.
			}
			catch (Exception ex) { Console.WriteLine(ex.ToString()); }

			return input;
		}

        /// <summary>
        /// Basic method used to check if input is null then prompts for user input until they correct the issue.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ValidateInput(string input)
        {
            while(input == "")
            {
                Console.WriteLine("Please enter a valid input:");
                input = Console.ReadLine();
            }
            return input;
        }
		#endregion

		/// <summary>
		/// DB methods used to send data and queries to database then return results to UI.
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		#region DB
		public static List<string> QueryDB(string input)
		{
			List<string> queryResult = new List<string>();
			List<string> customerLink = new List<string>();
			// Connection info and establish connection to server.
			// Defaults are server=localhost db=northwind port=3306 un=root pw=toor
			string user = ConfigurationManager.AppSettings["User"];
			string password = ConfigurationManager.AppSettings["Password"];
			string server = ConfigurationManager.AppSettings["Server"];
			string db = ConfigurationManager.AppSettings["DB"];
			string port = ConfigurationManager.AppSettings["Port"];
			string connStr = $"server={server};user={user};database={db};port={port};password={password};";
			MySqlConnection conn = new MySqlConnection(connStr);
			try
			{
				// Open connection
				conn.Open();
				// Set commands and begin reading query results.
				MySqlCommand cmd = new MySqlCommand(input, conn);
				MySqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					//queryResult.Add(rdr.GetString(rdr.GetOrdinal())); THIS ALSO WORKS BUT ISNT NEEDED ANYMORE

					// Below used to output in an easily read format using " -- " as a delimiter between values
					// "NULL" is filled in for null values in relation.
					string filterNull = "";
					for (int i = 0; i < rdr.FieldCount; i++)
					{
						customerLink.Add(rdr[1].ToString());
						if (!rdr.IsDBNull(i) && i != rdr.FieldCount - 1)
						{
							filterNull += rdr[i] + " -- ";
						}
						else if (!rdr.IsDBNull(i) && i == (rdr.FieldCount - 1))
						{
							filterNull += rdr[i];
						}
						else if (rdr.IsDBNull(i) && i != rdr.FieldCount - 1)
						{
							filterNull += "NULL -- ";
						}
						else if (rdr.IsDBNull(i) && i == (rdr.FieldCount - 1))
						{
							filterNull += "NULL";
						}
					}
					// Add to List.
					queryResult.Add(filterNull);
				}
				rdr.Close();
			}
			catch (Exception ex) { Console.WriteLine(ex.ToString()); }
			conn.Close();
            // For each item in queryresult list, print out.
			for (int i = 0; i < queryResult.Count; i++)
			{
				Console.WriteLine(queryResult[i]);
				string cInfo = $"SELECT * FROM Customers WHERE CustomerID='{customerLink[i]}';";
				customerQuery(cInfo);
			}
			return queryResult;
		}
        public static void customerQuery(string input)
        {
            string queryResult = "";
            // Connection info and establish connection to server.
            // Defaults are server=localhost db=northwind port=3306 un=root pw=toor
            string user = ConfigurationManager.AppSettings["User"];
            string password = ConfigurationManager.AppSettings["Password"];
            string server = ConfigurationManager.AppSettings["Server"];
            string db = ConfigurationManager.AppSettings["DB"];
            string port = ConfigurationManager.AppSettings["Port"];
            string connStr = $"server={server};user={user};database={db};port={port};password={password};";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                // Open connection
                conn.Open();
                // Set commands and begin reading query results.
                MySqlCommand cmd = new MySqlCommand(input, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //queryResult.Add(rdr.GetString(rdr.GetOrdinal())); THIS ALSO WORKS BUT ISNT NEEDED ANYMORE

                    // Below used to output in an easily read format using " -- " as a delimiter between values
                    // "NULL" is filled in for null values in relation.
                    string filterNull = "";
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        if (!rdr.IsDBNull(i) && i != rdr.FieldCount - 1)
                        {
                            filterNull += rdr[i] + " -- ";
                        }
                        else if (!rdr.IsDBNull(i) && i == (rdr.FieldCount - 1))
                        {
                            filterNull += rdr[i];
                        }
                        else if (rdr.IsDBNull(i) && i != rdr.FieldCount - 1)
                        {
                            filterNull += "NULL -- ";
                        }
                        else if (rdr.IsDBNull(i) && i == (rdr.FieldCount - 1))
                        {
                            filterNull += "NULL";
                        }
                    }
                    // Add to List.
                    Console.WriteLine(filterNull);
                    Console.WriteLine();
                }
                rdr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            conn.Close();

        }
		/// <summary>
		/// This method is used to INPUT and UPDATE the database.
		/// Very similar build to the QueryDB method but uses ExecuteNonQuery function instead.
		/// No return values needed since this only write to DB.
		/// </summary>
		/// <param name="input"></param>
		public static void NonQuery(string input)
		{
			// Connection info and establish connection to server.
			// Defaults are server=localhost db=northwind port=3306 un=root pw=toor
			string user = ConfigurationManager.AppSettings["User"];
			string password = ConfigurationManager.AppSettings["Password"];
			string server = ConfigurationManager.AppSettings["Server"];
			string db = ConfigurationManager.AppSettings["DB"];
			string port = ConfigurationManager.AppSettings["Port"];
			string connStr = $"server={server};user={user};database={db};port={port};password={password};";
			MySqlConnection conn = new MySqlConnection(connStr);
			try
			{
                // executes NonQuery used to update/input
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
			// Connection info and establish connection to server.
			// Defaults are server=localhost db=northwind port=3306 un=root pw=toor
			string user = ConfigurationManager.AppSettings["User"];
			string password = ConfigurationManager.AppSettings["Password"];
			string server = ConfigurationManager.AppSettings["Server"];
			string db = ConfigurationManager.AppSettings["DB"];
			string port = ConfigurationManager.AppSettings["Port"];
			string connStr = $"server={server};user={user};database={db};port={port};password={password};";
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
		public static string GetID(string input)
		{
			object result = null;
			// Connection info and establish connection to server.
			// Defaults are server=localhost db=northwind port=3306 un=root pw=toor
			string user = ConfigurationManager.AppSettings["User"];
			string password = ConfigurationManager.AppSettings["Password"];
			string server = ConfigurationManager.AppSettings["Server"];
			string db = ConfigurationManager.AppSettings["DB"];
			string port = ConfigurationManager.AppSettings["Port"];
			string connStr = $"server={server};user={user};database={db};port={port};password={password};";
			MySqlConnection conn = new MySqlConnection(connStr);
			try
			{
				conn.Open();
				MySqlCommand cmd = new MySqlCommand(input, conn);
				result = cmd.ExecuteScalar();
                // Make sure the result is not null. If it is, set result string to avoid conversion issues with return.
				if (result != null && DBNull.Value != result) { result = Convert.ToInt32(result); }
				else if (result == null || DBNull.Value == result) { result = "NULL"; }
			}
			catch (Exception ex) { Console.WriteLine(ex.ToString()); }
			conn.Close();
            return result.ToString();
		}
		public static void DBConnect()
		{
			bool correctPort = false;
			bool connection = false;
			string testPort = "";
			do
			{
				// Prompt for DB credentials and update app.config.
				System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				Console.WriteLine("DB Server:");
				config.AppSettings.Settings["Server"].Value = Console.ReadLine();
				Console.WriteLine("DB Port:");
				// Verify port input is a number. Otherwise the program crashes.
				do
				{
					try
					{
						testPort = Console.ReadLine();
						Convert.ToInt64(testPort);
						correctPort = true;
					}
					catch (Exception ex)
					{
						Console.WriteLine("Port must be numbers only.");
						Console.WriteLine("DB Port:");
					}
					
				} while (correctPort == false);
				// gather remaining info
				config.AppSettings.Settings["Port"].Value = testPort;
				Console.WriteLine("DB Name:");
				config.AppSettings.Settings["DB"].Value = Console.ReadLine();
				Console.WriteLine("DB User:");
				config.AppSettings.Settings["User"].Value = Console.ReadLine();
				Console.WriteLine("DB Password:");

				// Password masking below not used due to output adding special characters to appSettings file.
				/*ConsoleKeyInfo key;
				// Mask password entry
				string pass = "";
				do
				{
					key = Console.ReadKey(true);

					// Backspace Should Not Work
					if (key.Key != ConsoleKey.Backspace)
					{
						pass += key.KeyChar;
						Console.Write("*");
					}
					else
					{
						Console.Write("\b");
					}
				}
				// Stops Receving Keys Once Enter is Pressed
				while (key.Key != ConsoleKey.Enter);
				Console.WriteLine();*/
				//config.AppSettings.Settings["Password"].Value = pass;

				config.AppSettings.Settings["Password"].Value = Console.ReadLine();
				config.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection("appSettings");

				// Connection info and establish connection to server.
				// Defaults are server=localhost db=northwind port=3306 un=root pw=toor
				// Set variables for connStr string
				string user = ConfigurationManager.AppSettings["User"];
				string password = ConfigurationManager.AppSettings["Password"];
				string server = ConfigurationManager.AppSettings["Server"];
				string db = ConfigurationManager.AppSettings["DB"];
				string port = ConfigurationManager.AppSettings["Port"];

				string connStr = $"server={server};user={user};database={db};port={port};password={password};";
				MySqlConnection conn = new MySqlConnection(connStr);
				// Test connection. Restart connection prompts if connection fails.
				try
				{
					conn.Open();
					connection = true;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					Console.WriteLine("---------------------------------------");
					Console.WriteLine("       SERVER CONNECTION FAILED");
					Console.WriteLine("Invalid connection information entered.");
					Console.WriteLine("       SEE ABOVE FOR ERROR INFO");
					Console.WriteLine("---------------------------------------");
				}
				conn.Close();
			} while (connection == false);
			
			// Return to main.
			return;
		}
		#endregion
	}
}
