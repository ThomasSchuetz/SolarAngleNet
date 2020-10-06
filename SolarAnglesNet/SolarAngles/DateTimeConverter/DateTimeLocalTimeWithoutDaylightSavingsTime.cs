using System;

namespace SolarAngles.DateTimeConverter
{
    public class DateTimeLocalTimeWithoutDaylightSavingsTime : IDateTimeConverter
    {
        private readonly TimeZoneInfo timeZone;
        private readonly double longitudeDegrees;

        public DateTimeLocalTimeWithoutDaylightSavingsTime(Location location)
        {
            this.timeZone = location.TimeZone;
            this.longitudeDegrees = location.Longitude;
        }

        public DateTime OriginalTimeToSolarTime(DateTime originalTime) 
            => SolarTime.GetSolarTime(originalTime,
                this.longitudeDegrees,
                this.timeZone.BaseUtcOffset);

        public DateTime SolarTimeToOriginalTime(DateTime solarTime) 
            => SolarTime.GetLocalTime(solarTime,
                this.longitudeDegrees,
                this.timeZone.BaseUtcOffset);
    }
}
