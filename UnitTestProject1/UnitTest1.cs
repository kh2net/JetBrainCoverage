using JetBrainCoverage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            List<List<object>> data = new List<List<object>>
            {
                new List<object> { "Spalte1", "Spalte2", "Spalte3" },
                new List<object> { 1, 2.5, DateTime.Now },
                new List<object> { "Daten4", true, 3.14 }
            };
            string filePath = Path.Combine(Path.GetTempPath(), "test.csv");

            var program = new Program();
            // Act
            program.SaveListToCSV(data, filePath);

            // Assert
            Assert.IsTrue(File.Exists(filePath));
            string[] lines = File.ReadAllLines(filePath);
            Assert.AreEqual(3, lines.Length);
            Assert.AreEqual("Spalte1,Spalte2,Spalte3", lines[0]);
            Assert.AreEqual("1,2.5," + DateTime.Now.ToString(), lines[1]);
            Assert.AreEqual("Daten4,True,3.14", lines[2]);
        }
    }
}
