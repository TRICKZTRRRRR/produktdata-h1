using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace produktdata
{
    internal class Program
    {

        static void Main(string[] args)
        {
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("New, Read or old database?");
                Console.Write("> ");
                string answer = Console.ReadLine();

                if (answer == "old")
                {
                    Database.ExistingDatabase();

                    Console.WriteLine("\nWhat do you want to do?");
                    Console.WriteLine("You have the following options:");
                    Console.WriteLine("See the tables: see");
                    Console.WriteLine("Admin panel: Admin");
                    Console.Write("> ");
                    string answerOld = Console.ReadLine();

                    if (answerOld == "see")
                    {
                        string connectionString = @"Data Source=ZBC-S-jona993p;Initial Catalog=produktdata;User ID=admin1;Password=admin1;Integrated Security=True";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            // Open the connection to the database
                            connection.Open();

                            DatabaseReader databaseReader = new DatabaseReader(connectionString);
                            databaseReader.ReadDataFromTables();

                            Console.ReadLine();
                        }
                    }
                    else if (answerOld == "admin")
                    {
                        Cases.CaseAdmin();
                    }
                }
                else if (answer == "read")
                {
                    ReadCSV.ReadCSVFile();
                }
                else
                {
                    Database.NewDatabase();
                }

            }
        }
    }
}
