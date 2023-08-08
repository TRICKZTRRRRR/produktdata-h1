using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace produktdata
{
    internal class ReadCSV
    {

        public static void ReadCSVFile()
        {
            while (true)
            {
                Console.Clear();
                string file = @"C:\Users\zbc23jkst\source\repos\produktdata\produktdata\EXEL\ProduktData.csv";

                /*Console.WriteLine("Indtast stien til CSV-filen:");
                string filePath = Console.ReadLine();*/

                try
                {
                    // Læs indholdet af CSV-filen
                    string[] lines = File.ReadAllLines(file);

                    // Opret arrays til at gemme produktdata
                    int rowCount = lines.Length - 1; // Ekskluder headerlinjen
                    string[] producentNavn = new string[rowCount];
                    string[] producentAdresse = new string[rowCount];
                    string[] vareNummer = new string[rowCount];
                    string[] vareTekst = new string[rowCount];
                    string[] kategori = new string[rowCount];
                    string[] materiale = new string[rowCount];
                    int[] lagerBeholdning = new int[rowCount];

                    // Gem produktdata i arrays
                    for (int i = 1; i < lines.Length; i++) // Start ved index 1 for at ekskludere headerlinjen
                    {
                        string[] values = lines[i].Split(';');

                        producentNavn[i - 1] = GetArrayValue(values, 0);
                        producentAdresse[i - 1] = GetArrayValue(values, 1);
                        vareNummer[i - 1] = GetArrayValue(values, 2);
                        vareTekst[i - 1] = GetArrayValue(values, 3);
                        kategori[i - 1] = GetArrayValue(values, 4);
                        materiale[i - 1] = GetArrayValue(values, 5);
                        lagerBeholdning[i - 1] = GetArrayIntValue(values, 6);
                    }

                    // Vis produktdata
                    Console.WriteLine("Produktdata i CSV-filen:");
                    for (int i = 0; i < rowCount; i++)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine($"Producent Navn: {producentNavn[i]}");
                        Console.WriteLine($"Producent Adresse: {producentAdresse[i]}");
                        Console.WriteLine($"Vare Nummer: {vareNummer[i]}");
                        Console.WriteLine($"Vare Tekst: {vareTekst[i]}");
                        Console.WriteLine($"Kategori: {kategori[i]}");
                        Console.WriteLine($"Materiale: {materiale[i]}");
                        Console.WriteLine($"Lager Beholdning: {lagerBeholdning[i]}");
                    }
                    Console.WriteLine("\nFor at komme tilbage til main, tryk enter");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fejl ved læsning af CSV-filen: " + ex.Message);
                }

                Console.ReadLine();
            }
        }

        // Hjælpefunktion til at få værdien fra et array med den angivne indeksplacering
        static string GetArrayValue(string[] array, int index)
        {
            if (index >= 0 && index < array.Length)
            {
                return array[index];
            }

            return string.Empty;
        }

        // Hjælpefunktion til at få den numeriske værdi fra et array med den angivne indeksplacering
        static int GetArrayIntValue(string[] array, int index)
        {
            if (index >= 0 && index < array.Length)
            {
                int value;
                if (int.TryParse(array[index], out value))
                {
                    return value;
                }
            }

            return 0;
        }
    }
}
