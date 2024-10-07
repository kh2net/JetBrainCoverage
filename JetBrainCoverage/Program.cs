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
        public List<List<string>> MergeCSVFiles(string filePath1, string filePath2)
        {
            List<List<string>> mergedData = new List<List<string>>();

            // Read data from first CSV file
            List<List<string>> data1 = ReadCSVFile(filePath1);

            // Read data from second CSV file
            List<List<string>> data2 = ReadCSVFile(filePath2);

            // Merge the data
            mergedData.AddRange(data1);
            mergedData.AddRange(data2);

            return mergedData;
        }

        public List<List<string>> ReadCSVFile(string filePath)
        {
            List<List<string>> data = new List<List<string>>();

            // Read all lines from the CSV file
            string[] lines = File.ReadAllLines(filePath);

            // Process each line
            foreach (string line in lines)
            {
                // Split the line into columns
                string[] columns = line.Split(',');

                // Create a list to store the column values
                List<string> rowData = new List<string>();

                // Add each column value to the list
                foreach (string column in columns)
                {
                    rowData.Add(column);
                }

                // Add the row data to the data list
                data.Add(rowData);
            }

            return data;
        }
    }

}
