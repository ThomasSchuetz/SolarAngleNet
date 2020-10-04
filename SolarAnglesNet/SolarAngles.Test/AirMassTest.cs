using NUnit.Framework;
using SolarAngles.AirMass;
using static Converter.RadianDegreeConverter;

namespace SolarAngles.Test
{
    [TestFixture]
    public class AirMassTest
    {
        [TestCase(0, 1)]
        [TestCase(60, 2)]
        public void TestSimpleAirMassModel(double zenithAngleDegrees, double expectedResult)
        {
            var model = new AirMassSimpleModel();
            Assert.IsTrue(TestAirMassAtDifferentZenithAngles(model, zenithAngleDegrees, expectedResult));
        }

        [TestCase(0, 1)]
        [TestCase(60, 2)]
        public void TestKarstenYoungAirMassModel(double zenithAngleDegrees, double expectedResult)
        {
            var model = new AirMassKarstenYoung();
            Assert.IsTrue(TestAirMassAtDifferentZenithAngles(model, zenithAngleDegrees, expectedResult));
        }

        public bool TestAirMassAtDifferentZenithAngles(IAirMass model, 
            double zenithAngle, 
            double expectedResult, 
            double altitude = 0)
        {
            var result = model.GetAirMass(zenithAngle.FromDegreeToRadians(), altitude);
            Assert.AreEqual(expectedResult, result, 0.01);
            return true;
        }
    }
}
