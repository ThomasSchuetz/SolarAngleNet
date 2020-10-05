using System;

namespace SolarAngles.DateTimeConverter
{
    public static class DateTimeFactory
    {
        public static IDateTimeConverter GetDateTimeConverter(DateTimeModels model, Location location)
        {
            switch (model)
            {
                case DateTimeModels.UTC:
                    return new DateTimeUtc(location);
                case DateTimeModels.LocalTime:
                    return new DateTimeLocalTime(location);
                case DateTimeModels.LocalTimeWithoutDaylightSavingsTime:
                    return new DateTimeLocalTimeWithoutDaylightSavingsTime(location);
                case DateTimeModels.SolarTime:
                    return new DateTimeSolarTime();
                default:
                    throw new ArgumentOutOfRangeException($"Unknown date time converter {model}");
            }
        }
    }
}
