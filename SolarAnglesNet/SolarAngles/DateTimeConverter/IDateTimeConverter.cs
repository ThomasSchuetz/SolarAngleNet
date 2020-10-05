using System;

namespace SolarAngles.DateTimeConverter
{
    public interface IDateTimeConverter
    {
        DateTime OriginalTimeToSolarTime(DateTime originalTime);
        DateTime SolarTimeToOriginalTime(DateTime solarTime);
    }
}
