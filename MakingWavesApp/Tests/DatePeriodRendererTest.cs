using System;
using NUnit.Framework;

namespace MakingWavesApp.Tests
{
    [TestFixture]
    public class DatePeriodRendererTest
    {
        [Test]
        public void RendersCorrectDate()
        {
            // Arrange
            var date1 = new DateTime(2000, 05, 25);
            var date2 = new DateTime(2000, 06, 15);
            var expectedOutput = "25.05 - 15.06.2000"; 
            // Act
            var renderer = new Renderers.DatePeriodRenderer();
            var actualOutput = renderer.RenderPeriod(date1, date2);
            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        
        [Test]
        public void RendersCorrectOldDate()
        {
            // Arrange
            var date1 = new DateTime(1950, 05, 25);
            var date2 = new DateTime(2000, 06, 15);
            var expectedOutput = "25.05 - 15.06.2000"; 
            // Act
            var renderer = new Renderers.DatePeriodRenderer();
            var actualOutput = renderer.RenderPeriod(date1, date2);
            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        
        [Test]
        public void RendersCorrectNegativeDate()
        {
            // Arrange
            var date1 = new DateTime(-1000, 05, 25);
            var date2 = new DateTime(2000, 06, 15);
            var expectedOutput = "25.05 - 15.06.2000"; 
            // Act
            var renderer = new Renderers.DatePeriodRenderer();
            var actualOutput = renderer.RenderPeriod(date1, date2);
            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}