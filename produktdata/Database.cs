using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace produktdata
{
    internal class Database
    {
        public static void NewDatabase()
        {
            Console.Clear();
            Console.WriteLine("Name of the database");
            Console.Write("> ");
            string database = Console.ReadLine();

            // Indsæt forbindelsesstrengen til din database
            string connectionString = "Data Source=localhost;Initial Catalog=master;Integrated Security=True";

            // Navnet på den nye database, som du vil oprette
            string databaseName = database;

            // SQL-forespørgsler for at oprette databasen og de 6 tabeller
            string[] createQueries = new string[]
            {
            // Opret database
            $"CREATE DATABASE {databaseName}",

            // Opret tabeller
            $@"
            USE {databaseName}
            CREATE TABLE producent (
            PID INT PRIMARY KEY, 
            ProducentNavn NVARCHAR(255),
            ProducentAdresse NVARCHAR(255),
            PostID NVARCHAR(255),
            LandID NVARCHAR(255)
            )",

            $@"
            USE {databaseName}
            CREATE TABLE PostNr (
            PostNr NVARCHAR(255),
            PostID INT PRIMARY KEY, 
            ByNavn NVARCHAR(255)
            )",

            $@"
            USE {databaseName}
            CREATE TABLE vare_tekst (
            Id INT PRIMARY KEY, 
            VareTekst NVARCHAR(255)
            )",

            $@"
            USE {databaseName}
            CREATE TABLE Lande (
            LandID INT PRIMARY KEY, 
            LandeNavne NVARCHAR(255)
            )",

            $@"
            USE {databaseName}
            CREATE TABLE Kategori (
            KategoriID INT PRIMARY KEY, 
            KategoriTekst NVARCHAR(255)
            )",

            $@"
            USE {databaseName}
            CREATE TABLE Materialer (
            MaterialeID INT PRIMARY KEY, 
            MaterialeTekst NVARCHAR(255)
            )",

            $@"
            USE {databaseName}
            CREATE TABLE Vare (
            ProducentID INT PRIMARY KEY, 
            VareID INT,
            KategoriID INT,
            Lagerbeholdning INT,
            VareTekst NVARCHAR(255),
            VareNummer NVARCHAR(255)
            )"
            };

            // Opret forbindelsen til master-databasen for at oprette den nye database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Opret database og tabeller ved hjælp af SQL-forespørgslerne
                    foreach (string query in createQueries)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    Console.WriteLine("\nDatabase og tabeller er oprettet.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nFejl ved oprettelse af database: " + ex.Message);
                }
            }

            Console.ReadLine();
        }

        public static void ExistingDatabase()
        {
            Console.Clear();

            // Opret forbindelsesstrengen
            string connectionString = @"Data Source=ZBC-S-jona993p;Initial Catalog=produktdata;User ID=admin1;Password=admin1;Integrated Security=True";

            // Opret en SqlConnection-objekt med forbindelsesstrengen
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Åbn forbindelsen til databasen
                    connection.Open();

                    // Forbindelsen er åben, og du kan udføre dine databaseoperationer her

                    Console.WriteLine("\nForbindelse til databasen er oprettet.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fejl ved forbindelse til database: " + ex.Message);
                }
            }

            //Console.ReadLine();
        }

        public static void CreateProducent()
        {
            Console.Clear();

            string connectionString = @"Data Source=ZBC-S-jona993p;Initial Catalog=produktdata;User ID=admin1;Password=admin1;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    Cases.CaseAdmin();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fejl ved læsning af data: " + ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
