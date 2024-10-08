using NUnit.Framework;
using System;

namespace JetBrainCoverage.Tests
{
    public class FormatDateTests
    {
        [Test]
        public void ParseDate_ValidDateStringAndFormat_ReturnsDateTime()
        {
            // Arrange
            string dateString = "2022-01-01";
            string format = "yyyy-MM-dd";

            // Act
            DateTime result = FormatDate.ParseDate(dateString, format);

            // Assert
            Assert.AreEqual(new DateTime(2022, 01, 01), result);
        }

        [Test]
        public void ParseDate_InvalidDateStringAndFormat_ThrowsFormatException()
        {
            // Arrange
            string dateString = "2022-01-01";
            string format = "MM/dd/yyyy";

            // Act & Assert
            Assert.Throws<FormatException>(() => FormatDate.ParseDate(dateString, format));
        }

        [Test]
        public void getType_ValidTypeName_ReturnsType()
        {
            // Arrange
            string typeName = "System.String";

            // Act
            Type result = FormatDate.GetType(typeName);

            // Assert
            Assert.AreEqual(typeof(string), result);
        }

        [Test]
        public void getType_EmptyTypeName_ReturnsNull()
        {
            // Arrange
            string typeName = string.Empty;

            // Act
            Type result = FormatDate.GetType(typeName);

            // Assert
            Assert.IsNull(result);
        }
        [Test]
        public void getType_InvalidTypeName_ReturnsNull()
        {
            // Arrange
            string typeName = "InvalidType";

            // Act
            Type result = FormatDate.GetType(typeName);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void FormatDate2String_ValidDateAndFormat_ReturnsFormattedString()
        {
            // Arrange
            DateTime date = new DateTime(2022, 01, 01);
            string format = "yyyy-MM-dd";

            // Act
            string result = FormatDate.FormatDate2String(date, format);

            // Assert
            Assert.AreEqual("2022-01-01", result);
        }
    }
}
