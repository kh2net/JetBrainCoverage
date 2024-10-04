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
        private Program program;

        [SetUp]
        public void Setup()
        {
            program = new Program();
        }

        [Test]
        public void Test_SaveListToCSV_WithListOfStrings_ShouldSaveCSVFile()
        {
            // Arrange
            List<List<string>> data = new List<List<string>>
            {
                new List<string> { "Spalte1", "Spalte2", "Spalte3" },
                new List<string> { "Daten1", "Daten2", "Daten3" },
                new List<string> { "Daten4", "Daten5", "Daten6" }
            };
            string filePath = Path.Combine(Path.GetTempPath(), "test.csv");

            // Act
            program.SaveListToCSV(data, filePath);

            // Assert
            Assert.IsTrue(File.Exists(filePath));
            string[] lines = File.ReadAllLines(filePath);
            Assert.AreEqual(3, lines.Length);
            Assert.AreEqual("Spalte1,Spalte2,Spalte3", lines[0]);
            Assert.AreEqual("Daten1,Daten2,Daten3", lines[1]);
            Assert.AreEqual("Daten4,Daten5,Daten6", lines[2]);
        }

        //[Test]
        //public void Test_SaveListToCSV_WithListOfObjects_ShouldSaveCSVFile()
        //{
        //    // Arrange
        //    var s = DateTime.Now.ToString();
        //    List<List<object>> data = new List<List<object>>
        //    {
        //        new List<object> { "Spalte1", "Spalte2", "Spalte3" },
        //        new List<object> { 1, 2.5, s },
        //        new List<object> { "Daten4", true, 3.14 }
        //    };
        //    string filePath = Path.Combine(Path.GetTempPath(), "test.csv");

        //    // Act
        //    program.SaveListToCSV(data, filePath);

        //    // Assert
        //    Assert.IsTrue(File.Exists(filePath));
        //    string[] lines = File.ReadAllLines(filePath);
        //    Assert.AreEqual(3, lines.Length);
        //    Assert.AreEqual("Spalte1,Spalte2,Spalte3", lines[0]);
        //    Assert.AreEqual("1,2.5," + s, lines[1]);
        //    Assert.AreEqual("Daten4,True,3.14", lines[2]);
        //}

        //[Test]
        //public void Test_SaveListToCSV_WithEmptyList_ShouldSaveEmptyCSVFile()
        //{
        //    // Arrange
        //    List<List<string>> data = new List<List<string>>();

        //    string filePath = Path.Combine(Path.GetTempPath(), "test.csv");

        //    // Act
        //    program.SaveListToCSV(data, filePath);

        //    // Assert
        //    Assert.IsTrue(File.Exists(filePath));
        //    string[] lines = File.ReadAllLines(filePath);
        //    Assert.AreEqual(0, lines.Length);
        //}

        //[Test]
        //public void Test_Test_WithFilePath_ShouldSaveCSVFile()
        //{
        //    // Arrange
        //    string filePath = Path.Combine(Path.GetTempPath(), "test.csv");

        //    // Act
        //    bool result = program.Test(filePath);

        //    // Assert
        //    Assert.IsTrue(result);
        //    Assert.IsTrue(File.Exists(filePath));
        //    string[] lines = File.ReadAllLines(filePath);
        //    Assert.AreEqual(3, lines.Length);
        //    Assert.AreEqual("Spalte1,Spalte2,Spalte3", lines[0]);
        //    Assert.AreEqual("Daten1,Daten2,Daten3", lines[1]);
        //    Assert.AreEqual("Daten4,Daten5,Daten6", lines[2]);
        //}
    }
}