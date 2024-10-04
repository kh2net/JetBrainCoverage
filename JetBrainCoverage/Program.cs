using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace JetBrainCoverage
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public bool Test(string filePath)
        {
            List<List<string>> data = new List<List<string>>
            {
                new List<string> { "Spalte1", "Spalte2", "Spalte3" },
                new List<string> { "Daten1", "Daten2", "Daten3" },
                new List<string> { "Daten4", "Daten5", "Daten6" }
            };
            if (filePath.Contains("\\")) return false;
            SaveListToCSV(data, filePath);
            return true;
        }

        public void test2()
        {
            List<List<object>> data = new List<List<object>>
            {
                new List<object> { "Spalte1", "Spalte2", "Spalte3" },
                new List<object> { 1, 2.5, DateTime.Now },
                new List<object> { "Daten4", true, 3.14 }
            };

            string filePath = @"C:\Pfad\zur\Datei.csv";
            SaveListToCSV(data, filePath);
        }

        public void SaveListToCSV(List<List<string>> data, string filePath)
        {
            StringBuilder csvContent = new StringBuilder();

            // Zeilen hinzufügen
            foreach (var row in data)
            {
                csvContent.AppendLine(string.Join(",", row));
            }

            // CSV-Datei speichern
            File.WriteAllText(filePath, csvContent.ToString());
        }
        public void SaveListToCSV<T>(List<List<T>> data, string filePath)
        {
            StringBuilder csvContent = new StringBuilder();

            // Zeilen hinzufügen
            foreach (var row in data)
            {
                List<string> stringRow = new List<string>();
                foreach (var item in row)
                {
                    stringRow.Add(item.ToString());
                }
                csvContent.AppendLine(string.Join(",", stringRow));
            }

            // CSV-Datei speichern
            File.WriteAllText(filePath, csvContent.ToString());
        }
    }

}
