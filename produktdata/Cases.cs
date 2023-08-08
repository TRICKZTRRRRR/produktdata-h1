using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace produktdata
{
    internal class Cases
    {
        public static void CaseAdmin()
        {

            Console.Clear();

            string connectionString = @"Data Source=ZBC-S-jona993p;Initial Catalog=produktdata;User ID=admin1;Password=admin1;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    Console.WriteLine("Du har følgende muligheder");
                    Console.WriteLine("- 1. Opret Producent \n- 2. Rediger Producent \n- 3. Slet Producent \n- 4. Opret produkt \n- 5. Rediger Produkt \n- 6. Slet Produkt \n- 7. Vælg produkter \n- 8. Sorter produter \n- 9. Produkter af producent");
                    Console.Write("> ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            ProducentDatabase.CreateProducent();
                            break;

                        case "2":
                            ProducentDatabase.UpdateProducent();
                            break;





                        default:
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
    }
}
