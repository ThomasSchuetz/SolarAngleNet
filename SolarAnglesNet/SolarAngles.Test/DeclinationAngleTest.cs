using NUnit.Framework;
using SolarAngles.DeclinationAngle;
using static Converter.RadianDegreeConverter;

namespace SolarAngles.Test
{
    [TestFixture]
    public class DeclinationAngleTest
    {
        [TestCase(-23.45, 354.75)]
        [TestCase(23.45, 172.25)]
        [TestCase(0, 81)]
        [TestCase(0, 263.5)]
        public void CooperModelTests(double expectedResult, double dayOfYear)
        {
            var model = new DeclinationAngleCooper();
            Assert.IsTrue(CheckDeclinationModel(model, expectedResult, dayOfYear));
        }

        [TestCase(-23.43, 356.5)]
        [TestCase(23.46, 173)]
        [TestCase(0, 80.1)]
        [TestCase(0, 266.7)]
        public void SpencerModelTests(double expectedResult, double dayOfYear)
        {
            var model = new DeclinationAngleSpencer();
            Assert.IsTrue(CheckDeclinationModel(model, expectedResult, dayOfYear));
        }

        private bool CheckDeclinationModel(IDeclinationAngle model, double expectedResult, double dayOfYear)
        {
            var result = model.DeclinationAngle(dayOfYear);

            var resultDegrees = result.FromRadiansToDegree();

            Assert.AreEqual(expectedResult, resultDegrees, 0.05);

            return true;
        }
    }    
}
