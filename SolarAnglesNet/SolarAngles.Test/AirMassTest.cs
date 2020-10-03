using NUnit.Framework;
using static Converter.RadianDegreeConverter;

namespace SolarAngles.Test
{
    [TestFixture]
    public class AirMassTest
    {
        [TestCase(0, 1)]
        [TestCase(60, 2)]
        public void TestAirMassAtDifferentZenithAngles(double zenithAngle, double expectedResult)
        {
            var result = AirMass.GetAirMass(zenithAngle.FromDegreeToRadians());
            Assert.AreEqual(expectedResult, result, 0.001);
        }
    }
}
