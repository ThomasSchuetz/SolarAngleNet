using System;

namespace SolarAngles.DateTimeConverter
{
    public class DateTimeSolarTime : IDateTimeConverter
    {
        public DateTime OriginalTimeToSolarTime(DateTime originalTime) 
            => DuplicateGivenDateTime(originalTime);

        public DateTime SolarTimeToOriginalTime(DateTime solarTime) 
            => DuplicateGivenDateTime(solarTime);

        private DateTime DuplicateGivenDateTime(DateTime dt) 
            => new DateTime(dt.Ticks);
    }
}
