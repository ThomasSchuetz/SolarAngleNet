using NUnit.Framework;
using System;
using static Converter.RadianDegreeConverter;

namespace SolarAngles.Test
{
    [TestFixture]
    public class SolarAnglesTest
    {
        private SolarAngles MadisonWisconsinFlatSurface()
            => MadisonWisconsinTiltedSurface(0, 0);
        private SolarAngles MadisonWisconsinTiltedSurface(double beta, double gamma)
            => new SolarAngles(new Location(43, 0), new TiltedSurface(beta, gamma));

        [Test]
        public void SolarAnglesFacadeHourAngleAtSolarNoonIsZero()
        {
            var solarAngles = MadisonWisconsinFlatSurface();
            var result = solarAngles.GetHourAngle(new DateTime(2020, 1, 1, 12, 0, 0));
            Assert.AreEqual(0.0, result);
        }

        [Test]
        public void SolarAnglesFacadeHourAngleInAfternoonIsPositive()
        {
            var solarAngles = MadisonWisconsinFlatSurface();
            var resultRadians = solarAngles.GetHourAngle(new DateTime(2020, 1, 1, 18, 0, 0));
            var resultDegrees = resultRadians.FromRadiansToDegree();
            Assert.AreEqual(90.0, resultDegrees);
        }

        [Test]
        public void SolarAnglesFacadeHourAngleInMorningIsNegative()
        {
            var solarAngles = MadisonWisconsinFlatSurface();
            var resultRadians = solarAngles.GetHourAngle(new DateTime(2020, 1, 1, 6, 0, 0));
            var resultDegrees = resultRadians.FromRadiansToDegree();
            Assert.AreEqual(-90.0, resultDegrees);
        }

        [Test]
        public void SolarAnglesFacadeTestIncidenceAngleForTiltedSurface()
        {
            var solarAngles = MadisonWisconsinTiltedSurface(45, 15);
            var solarTime = new DateTime(2020, 2, 13, 10, 30, 0);

            var resultRadian = solarAngles.GetIncidenceAngle(solarTime);

            var resultDegree = resultRadian.FromRadiansToDegree();
            Assert.AreEqual(35, resultDegree, 0.5);
        }


        [Test]
        public void SolarAnglesFacadeTestZenithAngleFebruary13()
            => TestZenithAngle(new DateTime(2020, 2, 13, 9, 30, 0), 66.5);

        [Test]
        public void SolarAnglesFacadeTestZenithAngleJuly1()
            => TestZenithAngle(new DateTime(2020, 7, 1, 18, 30, 0), 79.6);

        private bool TestZenithAngle(DateTime solarTime, double expectedResultDegree)
        {
            var solarAngles = MadisonWisconsinFlatSurface();
            var resultRadian = solarAngles.GetZenithAngle(solarTime);

            Assert.AreEqual(expectedResultDegree, resultRadian.FromRadiansToDegree(), 0.1);
            return true;
        }

        [Test]
        public void SolarAnglesFacadeTestSunsetForMadisonWisconsinOnMarch16th()
        {
            var solarAngles = MadisonWisconsinFlatSurface();
            var config = Configuration.Config;
            config.SetDateTimeConverter(DateTimeConverter.DateTimeModels.SolarTime, solarAngles.Location);
            config.SetSunsetHourAngle(SunsetHourAngle.SunsetHourAngleModels.Basic);

            var date = new DateTime(2020, 3, 16);
            (_, var sunset) = solarAngles.GetSunriseSunset(date);

            Assert.AreEqual(date.Year, sunset.Year);
            Assert.AreEqual(date.Month, sunset.Month);
            Assert.AreEqual(date.Day, sunset.Day);
            Assert.AreEqual(17, sunset.Hour);
            Assert.AreEqual(52, sunset.Minute);
        }
    }
}
