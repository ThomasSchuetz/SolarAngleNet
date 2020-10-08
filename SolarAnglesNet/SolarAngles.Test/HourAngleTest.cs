using NUnit.Framework;
using SolarAngles.Extensions;
using System;

namespace SolarAngles.Test
{
    [TestFixture]
    public class HourAngleTest
    {
        [Test]
        public void HourAngleAtSolarNoonIsZero()
        {
            var result = HourAngle.GetHourAngle(new DateTime(2020, 1, 1, 12, 0, 0));
            Assert.AreEqual(0.0, result);
        }

        [Test]
        public void HourAngleInAfternoonIsPositive()
        {
            var resultRadians = HourAngle.GetHourAngle(new DateTime(2020, 1, 1, 18, 0, 0));
            var resultDegrees = resultRadians.FromRadiansToDegree();
            Assert.AreEqual(90.0, resultDegrees);
        }

        [Test]
        public void HourAngleInMorningIsNegative()
        {
            var resultRadians = HourAngle.GetHourAngle(new DateTime(2020, 1, 1, 6, 0, 0));
            var resultDegrees = resultRadians.FromRadiansToDegree();
            Assert.AreEqual(-90.0, resultDegrees);
        }
    }
}
