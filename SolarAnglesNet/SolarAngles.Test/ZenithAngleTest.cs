using NUnit.Framework;
using SolarAngles.Extensions;

namespace SolarAngles.Test
{
    [TestFixture]
    public class ZenithAngleTest
    {
        /// <summary>
        /// Test cases based on Example 1.6.2 from page 16
        /// </summary>
        [TestCase(43, -14, -37.5, 66.5)]
        [TestCase(43, 23.1, 97.5, 79.6)]
        public void ZenithAngleCalculationTests(double latitudeDegree, 
            double declinationAngleDegree,
            double hourAngleDegree,
            double expectedResultDegree)
        {
            var latitudeRadian = latitudeDegree.FromDegreeToRadians();
            var declinationAngleRadian = declinationAngleDegree.FromDegreeToRadians();
            var hourAngleRadian = hourAngleDegree.FromDegreeToRadians();

            var resultRadian = ZenithAngle.GetZenithAngle(latitudeRadian, 
                declinationAngleRadian, 
                hourAngleRadian);

            Assert.AreEqual(expectedResultDegree, resultRadian.FromRadiansToDegree(), 0.05);
        }
    }
}
