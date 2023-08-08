using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace produktdata
{
    internal class ProducentDatabase
    {

        public static void CreateProducent()
        {
            string connectionString = @"Data Source=ZBC-S-jona993p;Initial Catalog=produktdata;User ID=admin1;Password=admin1;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    Console.Title = "Opret Producent";
                    Console.Clear();



                    Console.Write("Indtast producentens navn: ");
                    string producentNavn = Console.ReadLine();

                    Console.Write("Indtast producentens adresse: ");
                    string producentAdresse = Console.ReadLine();

                    int producentId = GetNewProducentId(connectionString);
                    InsertProducent(connectionString, producentId, producentNavn, producentAdresse);

                    Console.WriteLine("Data blev indsat i databasen.");
                    Console.WriteLine($"ProducentID: {producentId}, ProducentNavn: {producentNavn}, ProducentAdresse: {producentAdresse}");

                    Console.ReadLine();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fejl ved læsning af data: " + ex.Message);
                }
                Console.ReadLine();
            }
        }

        static int GetNewProducentId(string connectionString)
        {
            int producentId = 1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MAX(PID) FROM Producent";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        producentId = Convert.ToInt32(result) + 1;
                    }
                }
            }

            return producentId;
        }

        static void InsertProducent(string connectionString, int producentId, string producentNavn, string producentAdresse)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Producent (PID, ProducentNavn, ProducentAdresse) VALUES (@pid, @navn, @adresse)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@pid", producentId);
                    command.Parameters.AddWithValue("@navn", producentNavn);
                    command.Parameters.AddWithValue("@adresse", producentAdresse);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Update Producent

        public static void UpdateProducent()
        {
            string connectionString = @"Data Source=ZBC-S-jona993p;Initial Catalog=produktdata;User ID=admin1;Password=admin1;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    Console.Title = "Rediger Producent";
                    Console.Clear();

                    Console.Write("Indtast ProducentID for producenten, du vil ændre: ");
                    int producentId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Vælg, hvad du vil ændre:");
                    Console.WriteLine("1. Producent Navn");
                    Console.WriteLine("2. Producent Adresse");
                    Console.WriteLine("0. Afslut");
                    Console.Write("\n> ");

                    int valg = int.Parse(Console.ReadLine());

                    switch (valg)
                    {
                        case 1:
                            Console.Write("\nIndtast nyt producentnavn: ");
                            string nytNavn = Console.ReadLine();
                            UpdateProducentNavn(connectionString, producentId, nytNavn);
                            Console.WriteLine("Producentnavnet er blevet ændret.");
                            break;
                        case 2:
                            Console.Write("Indtast ny producentadresse: ");
                            string nyAdresse = Console.ReadLine();
                            UpdateProducentAdresse(connectionString, producentId, nyAdresse);
                            Console.WriteLine("Producentadressen er blevet ændret.");
                            break;
                        case 0:
                            Console.WriteLine("Afslutter programmet.");
                            break;
                        default:
                            Console.WriteLine("Ugyldigt valg. Afslutter programmet.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fejl ved læsning af data: " + ex.Message);
                }
                Console.ReadLine();
            }
        }

        static void UpdateProducentNavn(string connectionString, int producentId, string nytNavn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Producent SET ProducentNavn = @nytNavn WHERE PID = @producentId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nytNavn", nytNavn);
                    command.Parameters.AddWithValue("@producentId", producentId);

                    command.ExecuteNonQuery();
                }
            }
        }

        static void UpdateProducentAdresse(string connectionString, int producentId, string nyAdresse)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Producent SET ProducentAdresse = @nyAdresse WHERE PID = @producentId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nyAdresse", nyAdresse);
                    command.Parameters.AddWithValue("@producentId", producentId);

                    command.ExecuteNonQuery();
                }
            }
        }

        /*
        // Slet Prodcucent
        static void DeleteProducent()
        {
            string connectionString = @"Data Source=ZBC-S-jona993p;Initial Catalog=produktdata;User ID=admin1;Password=admin1;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    Console.Title = "Slet Producent";
                    Console.Clear();

                    Console.Write("Indtast ProducentID for producenten, du vil slette: ");
                    int producentId = int.Parse(Console.ReadLine());

                    DeleteProducent(connectionString, producentId);

                    Console.WriteLine("Producenten er blevet slettet.");

                    Console.ReadLine();


                    string query = "DELETE FROM producent WHERE PID = @producentId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@producentId", producentId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fejl ved læsning af data: " + ex.Message);
                }
                Console.ReadLine();
            }
        }
        */
    }
}

