using NUnit.Framework;
using System;

namespace SolarAngles.Test
{
    [TestFixture]
    public class SolarRadiationTest
    {
        [Test]
        public void ExtraterrestrialRadiationHasMaximumOnJanuaryFirst()
        {
            var result = SolarRadiation.GetExtraterrestrialRadiation(new DateTime(2020, 1, 1));
            Assert.AreEqual(1415, result, 1);
        }

        [Test]
        public void ExtraterrestrialRadiationHasMinimumOnJulyFirst()
        {
            var result = SolarRadiation.GetExtraterrestrialRadiation(new DateTime(2020, 7, 1));
            Assert.AreEqual(1321, result, 1);
        }
    }
}
