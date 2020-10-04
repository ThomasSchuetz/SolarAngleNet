using NUnit.Framework;
using static Converter.RadianDegreeConverter;
using SolarAngles.DeclinationAngle;
using System.Collections.Generic;

namespace SolarAngles.Test
{
    [TestFixture]
    public class DeclinationAngleTest
    {
        [Test]
        public void CooperModelTests() 
            => Assert.DoesNotThrow(() => DeclinationAngleTests(new DeclinationAngleCooper()));

        [Test]
        public void SpencerModelTests()
            => Assert.DoesNotThrow(() => DeclinationAngleTests(new DeclinationAngleSpencer()));

        public void DeclinationAngleTests(IDeclinationAngle declinationAngleModel)
        {
            var expectedResultForGivenDay = new Dictionary<double, double>()
            {
                { 355, -23.45 },
                { 172, 23.45 },
                { 81, 0 },
                { 263.5, 0 },
            };

            foreach (var item in expectedResultForGivenDay)
            {
                var expectedResult = item.Value;
                var dayOfYear = item.Key;

                var result = declinationAngleModel.DeclinationAngle(dayOfYear);

                var resultDegrees = result.FromRadiansToDegree();

                // Note: Very large tolerance to comply with all models.
                Assert.AreEqual(expectedResult, resultDegrees, 1.5);
                System.Console.WriteLine($"Passed test for day {dayOfYear}");
            }
        }
    }    
}
