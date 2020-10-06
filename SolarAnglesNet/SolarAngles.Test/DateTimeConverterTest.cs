using NUnit.Framework;
using SolarAngles.DateTimeConverter;
using System;

namespace SolarAngles.Test
{
    [TestFixture]
    public class DateTimeConverterTest
    {
        private readonly Location madisonWisconsin = new Location(43.0, -89.4);

        [Test]
        public void DateTimeLocalTimeWithoutDaylightSavingsTime_LocalTime()
        {
            var dateTimeConverter = new DateTimeLocalTimeWithoutDaylightSavingsTime(madisonWisconsin);
            var originalTime = new DateTime(2020, 2, 3, 10, 30, 0);

            var result = dateTimeConverter.OriginalTimeToSolarTime(originalTime);

            Assert.AreEqual(originalTime.Date, result.Date);
            Assert.AreEqual(10, result.Hour);
            var remainderMinutesAndSeconds = result.Minute + result.Second / 60.0;
            Assert.AreEqual(19, remainderMinutesAndSeconds, 0.5);
        }

        [Test]
        public void DateTimeLocalTimeWithoutDaylightSavingsTime_OriginalTime()
        {
            var dateTimeConverter = new DateTimeLocalTimeWithoutDaylightSavingsTime(madisonWisconsin);
            var solarTime = new DateTime(2020, 2, 3, 10, 18, 54);

            var result = dateTimeConverter.SolarTimeToOriginalTime(solarTime);

            Assert.AreEqual(solarTime.Date, result.Date);
            Assert.AreEqual(10, result.Hour);
            var remainderMinutesAndSeconds = result.Minute + result.Second / 60.0;
            Assert.AreEqual(30, remainderMinutesAndSeconds, 0.5);
        }

        [Test]
        public void DateTimeUtc_LocalTime()
        {
            var dateTimeConverter = new DateTimeUtc(madisonWisconsin);
            var originalTime = new DateTime(2020, 2, 3, 16, 30, 0);

            var result = dateTimeConverter.OriginalTimeToSolarTime(originalTime);

            Assert.AreEqual(originalTime.Date, result.Date);
            Assert.AreEqual(10, result.Hour);
            var remainderMinutesAndSeconds = result.Minute + result.Second / 60.0;
            Assert.AreEqual(19, remainderMinutesAndSeconds, 0.5);
        }

        [Test]
        public void DateTimeUtc_OriginalTime()
        {
            var dateTimeConverter = new DateTimeUtc(madisonWisconsin);
            var solarTime = new DateTime(2020, 2, 3, 10, 18, 54);

            var result = dateTimeConverter.SolarTimeToOriginalTime(solarTime);

            Assert.AreEqual(solarTime.Date, result.Date);
            Assert.AreEqual(16, result.Hour);
            var remainderMinutesAndSeconds = result.Minute + result.Second / 60.0;
            Assert.AreEqual(30, remainderMinutesAndSeconds, 0.5);
        }

        [Test]
        public void DateTimeLocalTime_OutsideDaylightSavingsTime_LocalTime()
        {
            var dateTimeConverter = new DateTimeLocalTime(madisonWisconsin);
            var originalTime = new DateTime(2020, 2, 3, 10, 30, 0);

            var result = dateTimeConverter.OriginalTimeToSolarTime(originalTime);

            Assert.AreEqual(originalTime.Date, result.Date);
            Assert.AreEqual(10, result.Hour);
            var remainderMinutesAndSeconds = result.Minute + result.Second / 60.0;
            Assert.AreEqual(19, remainderMinutesAndSeconds, 0.5);
        }

        [Test]
        public void DateTimeLocalTime_OutsideDaylightSavingsTime_OriginalTime()
        {
            var dateTimeConverter = new DateTimeLocalTime(madisonWisconsin);
            var solarTime = new DateTime(2020, 2, 3, 10, 18, 54);

            var result = dateTimeConverter.SolarTimeToOriginalTime(solarTime);

            Assert.AreEqual(solarTime.Date, result.Date);
            Assert.AreEqual(10, result.Hour);
            var remainderMinutesAndSeconds = result.Minute + result.Second / 60.0;
            Assert.AreEqual(30, remainderMinutesAndSeconds, 0.5);
        }
    }
}
