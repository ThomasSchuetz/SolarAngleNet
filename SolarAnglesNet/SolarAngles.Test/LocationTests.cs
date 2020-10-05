using NUnit.Framework;

namespace SolarAngles.Test
{
    public class LocationTests
    {
        [TestCase(1, 53.5582, 9.6476)] // Hamburg, Germany
        [TestCase(-5, 40.6971, -74.2599)] // New York City, USA
        public void LatitudeAndLongitudeLeadToCorrectTimeZone(double expectedUtcBaseOffsetHours, 
            double latitude, 
            double longitude)
        {
            var location = new Location(latitude, longitude);
            Assert.AreEqual(expectedUtcBaseOffsetHours, location.TimeZone.BaseUtcOffset.TotalHours);
        }
    }
}