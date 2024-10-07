using System;
using System.Collections.Generic;
using System.IO;
using JetBrainCoverage;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class ProgramTests
    {
        // ...

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
    }
}