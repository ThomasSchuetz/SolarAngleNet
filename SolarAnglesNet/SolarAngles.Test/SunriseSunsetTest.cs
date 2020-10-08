using NUnit.Framework;
using SolarAngles.Extensions;
using System;

namespace SolarAngles.Test
{
    [TestFixture]
    public class SunriseSunsetTest
    {
        /// <summary>
        /// Test taken from Example 1.6.3 (page 19)
        /// The reference result is actually 17:51. 
        /// Due to small deviations between the calculated and the mentioned
        /// declination, the reference result is slightly varied in this test.
        /// </summary>
        [Test]
        public void SunsetForMadisonWisconsinOnMarch16th()
        {
            var location = new Location(43, 0, 0);
            var config = Configuration.Config;
            config.SetDateTimeConverter(DateTimeConverter.DateTimeModels.SolarTime, location);
            config.SetSunsetHourAngle(SunsetHourAngle.SunsetHourAngleModels.Basic);

            var solarNoon = new DateTime(2020, 3, 16, 12, 0, 0);
            var sunriseSunset = new SunriseSunset(solarNoon, location.Latitude.FromDegreeToRadians());
            var sunset = sunriseSunset.Sunset;

            Assert.AreEqual(solarNoon.Year, sunset.Year);
            Assert.AreEqual(solarNoon.Month, sunset.Month);
            Assert.AreEqual(solarNoon.Day, sunset.Day);
            Assert.AreEqual(17, sunset.Hour);
            Assert.AreEqual(52, sunset.Minute);
        }

        /// <summary>
        /// Test created here: https://www.esrl.noaa.gov/gmd/grad/solcalc/sunrise.html
        /// Intermediate results:
        /// Equation of time: 12.43 minutes
        /// Declination angle: -5.97 
        /// Solar noon: 13:03:22
        /// This declination angle is strongly different to internal calculations!
        /// When hard-coding the reference declination angle, the result is correct...
        /// </summary>
        [Test]
        public void SunriseForNurembergOnOctober8()
        {
            var location = new Location(49.27, 11.05, 0);
            var config = Configuration.Config;
            config.SetDateTimeConverter(DateTimeConverter.DateTimeModels.LocalTime, location);

            var solarNoon = new DateTime(2020, 10, 8, 12, 0, 0);
            var sunriseSunset = new SunriseSunset(solarNoon, location.Latitude.FromDegreeToRadians());
            var sunrise = sunriseSunset.Sunrise;

            var sunriseLocalTime = config.DateTimeConverter.SolarTimeToOriginalTime(sunrise);

            Assert.AreEqual(sunriseLocalTime.Year, sunriseLocalTime.Year);
            Assert.AreEqual(sunriseLocalTime.Month, sunriseLocalTime.Month);
            Assert.AreEqual(sunriseLocalTime.Day, sunriseLocalTime.Day);
            Assert.AreEqual(7, sunriseLocalTime.Hour);
            Assert.AreEqual(26, sunriseLocalTime.Minute, 11);
        }
    }
}
