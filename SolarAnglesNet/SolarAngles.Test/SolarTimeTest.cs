using NUnit.Framework;
using System;

namespace SolarAngles.Test
{
    /// <summary>
    /// Test cases as defined in Example 1.5.1 on page 11.
    /// Test location is Madison, Wisconsin (USA)
    /// </summary>
    [TestFixture]
    public class SolarTimeTest
    {
        private readonly double longitude = 89.4;
        private readonly TimeSpan timeDifferenceToGMT = TimeSpan.FromHours(6);
        private readonly DateTime localTime = new DateTime(2020, 2, 3, 10, 30, 0);
        
        [Test]
        public void EquationOfTimeOnFebruary3()
        {
            var B = CalculationAbbreviations.DayOnCircle(localTime.DayOfYear);
            var result = SolarTime.EquationOfTime(B);

            Assert.AreEqual(-13.5, result, 0.1);
        }

        [Test]
        public void LocalStandardMeridianForMadisonWisconsin()
        {
            var result = SolarTime.GetLocalStandardMeridian(timeDifferenceToGMT);
            Assert.AreEqual(90, result, 0.001);
        }

        [Test]
        public void LocalTimeCalculationOnFebruary3()
        {
            var result = SolarTime.GetSolarTime(localTime, longitude, timeDifferenceToGMT);

            Assert.AreEqual(localTime.Year, result.Year);
            Assert.AreEqual(localTime.Month, result.Month);
            Assert.AreEqual(localTime.Day, result.Day);
            Assert.AreEqual(10, result.Hour);
            var remainderMinutesAndSeconds = result.Minute + result.Second / 60.0;
            Assert.AreEqual(19, remainderMinutesAndSeconds, 0.5);
        }
    }
}
