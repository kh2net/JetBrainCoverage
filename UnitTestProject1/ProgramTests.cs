using System;
using System.Collections.Generic;
using System.IO;
using JetBrainCoverage;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture, Ignore]
    public class ProgramTests
    {
        // ...

        [Test]
        public void Test_SaveListToCSV_WithValidData_ShouldCreateCSVFile()
        {
            // Arrange
            string filePath = Path.Combine(Path.GetTempPath(), "test.csv");
            List<List<string>> data = new List<List<string>>
            {
                new List<string> { "Spalte1", "Spalte2", "Spalte3" },
                new List<string> { "Daten1", "Daten2", "Daten3" },
                new List<string> { "Daten4", "Daten5", "Daten6" }
            };

            Program program = new Program();

            // Act
            program.SaveListToCSV(data, filePath);

            // Assert
            Assert.IsTrue(File.Exists(filePath));
        }

        [Test]
        public void Test_SaveListToCSV_WithEmptyData_ShouldCreateEmptyCSVFile()
        {
            // Arrange
            string filePath = Path.Combine(Path.GetTempPath(), "empty.csv");
            List<List<string>> data = new List<List<string>>();

            Program program = new Program();

            // Act
            program.SaveListToCSV(data, filePath);

            // Assert
            Assert.IsTrue(File.Exists(filePath));
            Assert.AreEqual(0, new FileInfo(filePath).Length);
        }

        [Test]
        public void Test_ReadCSVFile_WithValidFilePath_ShouldReturnCorrectData()
        {
            // Arrange
            string filePath = Path.Combine(Path.GetTempPath(), "test.csv");
            List<List<string>> expectedData = new List<List<string>>
            {
                new List<string> { "Spalte1", "Spalte2", "Spalte3" },
                new List<string> { "Daten1", "Daten2", "Daten3" },
                new List<string> { "Daten4", "Daten5", "Daten6" }
            };

            Program program = new Program();
            // Create the CSV file
            program.SaveListToCSV(expectedData, filePath);

            // Act
            List<List<string>> actualData = program.ReadCSVFile(filePath);

            // Assert
            Assert.AreEqual(expectedData.Count, actualData.Count);
            for (int i = 0; i < expectedData.Count; i++)
            {
                CollectionAssert.AreEqual(expectedData[i], actualData[i]);
            }
        }

        [Test]
        public void Test_ReadCSVFile_WithEmptyFile_ShouldReturnEmptyData()
        {
            // Arrange
            string filePath = Path.Combine(Path.GetTempPath(), "empty.csv");
            File.WriteAllText(filePath, "");

            Program program = new Program();
            // Act
            List<List<string>> actualData = program.ReadCSVFile(filePath);

            // Assert
            Assert.AreEqual(0, actualData.Count);
        }

        [Test]
        public void Test_ReadCSVFile_WithInvalidFilePath_ShouldThrowFileNotFoundException()
        {
            // Arrange
            string filePath = @"C:\Invalid\Path\test.csv";

            Program program = new Program();
            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => program.ReadCSVFile(filePath));
        }

        [Test]
        public void Test_MergeCSVFiles_WithValidFilePaths_ShouldReturnMergedData()
        {
            // Arrange
            string filePath1 = Path.Combine(Path.GetTempPath(), "file1.csv");
            string filePath2 = Path.Combine(Path.GetTempPath(), "file2.csv");
            List<List<string>> data1 = new List<List<string>>
            {
                new List<string> { "Spalte1", "Spalte2", "Spalte3" },
                new List<string> { "Daten1", "Daten2", "Daten3" }
            };
            List<List<string>> data2 = new List<List<string>>
            {
                new List<string> { "Spalte4", "Spalte5", "Spalte6" },
                new List<string> { "Daten4", "Daten5", "Daten6" }
            };
            List<List<string>> expectedMergedData = new List<List<string>>
            {
                new List<string> { "Spalte1", "Spalte2", "Spalte3" },
                new List<string> { "Daten1", "Daten2", "Daten3" },
                new List<string> { "Spalte4", "Spalte5", "Spalte6" },
                new List<string> { "Daten4", "Daten5", "Daten6" }
            };

            Program program = new Program();
            // Create the CSV files
            program.SaveListToCSV(data1, filePath1);
            program.SaveListToCSV(data2, filePath2);

            // Act
            List<List<string>> actualMergedData = program.MergeCSVFiles(filePath1, filePath2);

            // Assert
            Assert.AreEqual(expectedMergedData.Count, actualMergedData.Count);
            for (int i = 0; i < expectedMergedData.Count; i++)
            {
                CollectionAssert.AreEqual(expectedMergedData[i], actualMergedData[i]);
            }
        }
    }
}