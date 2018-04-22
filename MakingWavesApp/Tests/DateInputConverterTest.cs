using System;
using NUnit.Framework;

namespace MakingWavesApp.Tests
{
    [TestFixture]
    public class DateInputConverterTest
    {
        [Test]
        public void ConvertsCorrectDateFormatString()
        {
            // Arrange
            var args = new[] { "15.04.2000", "25.05.2000" };
            var expectedDate1 = new DateTime(2000, 04, 15);
            var expectedDate2 = new DateTime(2000, 05, 25);
            // Act
            var converter = new Converters.DateInputConverter();
            converter.InitializeDates(args);
            
            // Assert
            Assert.IsTrue(converter.DateFrom < converter.DateTo);
            Assert.AreEqual(expectedDate1, converter.DateFrom);
            Assert.AreEqual(expectedDate2, converter.DateTo);
        }
        
        [Test]
        public void CannotConvertWrongFormatDate()
        {
            // Arrange
            var args = new[] { "01.01.90", "02.05.2000" };
            // Act
            var converter = new Converters.DateInputConverter();
            converter.InitializeDates(args);
            
            // Assert
            Assert.AreEqual(null, converter.DateFrom);
            Assert.AreEqual(null, converter.DateTo);
        }
        
        [Test]
        public void CannotConvertIfSecondDateIsEarlierThanFirst()
        {
            // Arrange
            var args = new[] { "05.01.1990", "04.01.1990" };
            // Act
            var converter = new Converters.DateInputConverter();
            converter.InitializeDates(args);
            
            // Assert
            Assert.AreEqual(null, converter.DateFrom);
            Assert.AreEqual(null, converter.DateTo);
        }
        
        [Test]
        public void CannotConvertForEmptyArguments()
        {
            // Arrange
            var args = new string[2];
            // Act
            var converter = new Converters.DateInputConverter();
            converter.InitializeDates(args);
            
            // Assert
            Assert.AreEqual(null, converter.DateFrom);
            Assert.AreEqual(null, converter.DateTo);
        }
        
        [Test]
        public void CannotConvertForLessOrMoreThan2Arguments()
        {
            // Arrange
            var args = new[] { "10.10.1000" , "11.10.1000", "12.10.1000" };
            // Act
            var converter = new Converters.DateInputConverter();
            converter.InitializeDates(args);
            
            // Assert
            Assert.AreEqual(null, converter.DateFrom);
            Assert.AreEqual(null, converter.DateTo);
        }
    }
}