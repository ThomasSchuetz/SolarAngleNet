using NUnit.Framework;
using static Converter.RadianDegreeConverter;

namespace SolarAngles.Test
{
    [TestFixture]
    public class IncidenceAngleTest
    {
        // Test taken from Example 1.6.1, page 15
        [Test]
        public void TestIncidenceAngleForTiltedSurface()
        {
            var tiltedSurface = new TiltedSurface(45, 15);
            var latitudeRadian = (43.0).FromDegreeToRadians();
            var declinationAngleRadian = (-14.0).FromDegreeToRadians();
            var hourAngleRadian = (-22.5).FromDegreeToRadians();

            var resultRadian = IncidenceAngle.GetIncidenceAngle(tiltedSurface, 
                latitudeRadian,
                declinationAngleRadian,
                hourAngleRadian);

            var resultDegree = resultRadian.FromRadiansToDegree();
            Assert.AreEqual(35, resultDegree, 0.5);
        }
    }
}
