using System;

namespace SolarAngles.DateTimeConverter
{
    public class DateTimeLocalTime : IDateTimeConverter
    {
        private readonly TimeZoneInfo timeZone;
        private readonly double longitudeDegrees;

        public DateTimeLocalTime(Location location)
        {
            this.timeZone = location.TimeZone;
            this.longitudeDegrees = location.Longitude;
        }

        public DateTime OriginalTimeToSolarTime(DateTime originalTime)
        {
            if (timeZone.IsDaylightSavingTime(originalTime))
            {
                originalTime -= TimeSpan.FromHours(1);
            }
            return SolarTime.GetSolarTime(originalTime,
                           this.longitudeDegrees,
                           this.timeZone.BaseUtcOffset);
        }

        public DateTime SolarTimeToOriginalTime(DateTime solarTime)
        {
            var localTime = SolarTime.GetLocalTime(solarTime,
                           this.longitudeDegrees,
                           this.timeZone.BaseUtcOffset);
            if (timeZone.IsDaylightSavingTime(localTime))
            {
                localTime += TimeSpan.FromHours(1);
            }
            return localTime;
        }
    }
}
