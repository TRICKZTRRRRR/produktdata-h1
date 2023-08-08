using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace produktdata
{
    internal class DatabaseReader
    {
        private readonly string _connectionString;

        public DatabaseReader(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ReadDataFromTables()
        {
            List<string[]> producentData = new List<string[]>();
            List<string[]> vareData = new List<string[]>();
            List<string[]> kategoriData = new List<string[]>();
            List<string[]> materialeData = new List<string[]>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                try
                {
                    ReadProducentData(connection, producentData);
                    ReadVareData(connection, vareData);
                    ReadKategoriData(connection, kategoriData);
                    ReadMaterialeData(connection, materialeData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fejl ved læsning af data: " + ex.Message);
                }
            }

            Console.Clear();
            Console.Title = "Producentdata - Producent, Vare & Kategori";
            for (int i = 0; i < producentData.Count; i++)
            {
                string[] producent = producentData[i];
                string[] vare = vareData[i];
                string[] kategori = kategoriData[i];
                string[] materiale = materialeData[i];

                Console.WriteLine($"PID: {producent[0]} \nProducent Navn: {producent[1]} \nProducent Adresse: {producent[2]} \nVare Nummer: {vare[0]} \nVare Tekst: {vare[1]} \nKategori: {kategori[0]} \nMateriale: {materiale[0]} \nLager: {vare[2]} \n");
            }
        }

        private void ReadProducentData(SqlConnection connection, List<string[]> producentData)
        {
            string query = "SELECT PID, ProducentNavn, ProducentAdresse FROM producent";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] producent = new string[3];
                        producent[0] = reader["PID"].ToString();
                        producent[1] = reader["ProducentNavn"].ToString();
                        producent[2] = reader["ProducentAdresse"].ToString();
                        producentData.Add(producent);
                    }
                }
            }
        }

        private void ReadVareData(SqlConnection connection, List<string[]> vareData)
        {
            string query = "SELECT VareNummer, VareTekst, Lagerbeholdning FROM Vare";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] vare = new string[3];
                        vare[0] = reader["VareNummer"].ToString();
                        vare[1] = reader["VareTekst"].ToString();
                        vare[2] = reader["Lagerbeholdning"].ToString();
                        vareData.Add(vare);
                    }
                }
            }
        }

        private void ReadKategoriData(SqlConnection connection, List<string[]> kategoriData)
        {
            string query = "SELECT KategoriTekst FROM Kategori";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] kategori = new string[1];
                        kategori[0] = reader["KategoriTekst"].ToString();
                        kategoriData.Add(kategori);
                    }
                }
            }
        }

        private void ReadMaterialeData(SqlConnection connection, List<string[]> materialeData)
        {
            string query = "SELECT MaterialeTekst FROM Materialer";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] materiale = new string[1];
                        materiale[0] = reader["MaterialeTekst"].ToString();
                        materialeData.Add(materiale);
                    }
                }
            }
        }
    }
}
