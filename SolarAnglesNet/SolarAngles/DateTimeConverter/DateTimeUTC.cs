using System;

namespace SolarAngles.DateTimeConverter
{
    public class DateTimeUtc : IDateTimeConverter
    {
        private readonly TimeZoneInfo timeZone;
        private readonly double longitudeDegrees;

        public DateTimeUtc(Location location)
        {
            this.timeZone = location.TimeZone;
            this.longitudeDegrees = location.Longitude;
        }

        public DateTime OriginalTimeToSolarTime(DateTime originalTime)
        {
            var localTime = originalTime + this.timeZone.BaseUtcOffset;
            return SolarTime.GetSolarTime(localTime,
                           this.longitudeDegrees,
                           this.timeZone.BaseUtcOffset);
        }

        public DateTime SolarTimeToOriginalTime(DateTime solarTime)
        {
            var localTime = SolarTime.GetLocalTime(solarTime,
                           this.longitudeDegrees,
                           this.timeZone.BaseUtcOffset);
            var utcTime = localTime - this.timeZone.BaseUtcOffset;
            return utcTime;
        }
    }
}
