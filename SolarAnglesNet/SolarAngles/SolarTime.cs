using System;

namespace SolarAngles
{
    public static class SolarTime
    {

        /// <summary>
        /// Equation of time (in minutes) as defined in Equation 1.5.3 (page 11)
        /// </summary>
        /// <param name="B">Equivalent "day on circle"</param>
        public static double EquationOfTime(double B)
        {
            return 229.2 * (0.000075 + 0.001868 * Math.Cos(B) - 0.032077 * Math.Sin(B)
                - 0.014615 * Math.Cos(2 * B) - 0.04089 * Math.Sin(2 * B));
        }

        /// <summary>Footnote 5 on page 11.</summary>
        public static double GetLocalStandardMeridian(TimeSpan timeDelta) => 15 * timeDelta.TotalHours;

        /// <summary>
        /// Transform local to solar time.
        /// See Equation 1.5.2 on page 11.
        /// </summary>
        /// <param name="localTime">Local time</param>
        /// <param name="longitude">Longitude of location</param>
        /// <param name="timeDelta">Time difference to Greenwich Mean Time</param>
        public static DateTime GetSolarTime(DateTime localTime, double longitude, TimeSpan timeDelta)
        {
            double timeDeltaMinutes = SolarTimeDeltaMinutes(localTime.DayOfYear, longitude, timeDelta);

            return localTime + TimeSpan.FromMinutes(timeDeltaMinutes);
        }

        /// <summary>
        /// Transform solar to local time
        /// See Equation 1.5.2 on page 11.
        /// </summary>
        /// <param name="localTime">Local time</param>
        /// <param name="longitude">Longitude of location</param>
        /// <param name="timeDelta">Time difference to Greenwich Mean Time</param>
        public static DateTime GetLocalTime(DateTime solarTime, double longitude, TimeSpan timeDelta)
        {
            double timeDeltaMinutes = SolarTimeDeltaMinutes(solarTime.DayOfYear, longitude, timeDelta);

            return solarTime - TimeSpan.FromMinutes(timeDeltaMinutes);
        }

        private static double SolarTimeDeltaMinutes(int dayOfYear, double longitude, TimeSpan timeDelta)
        {
            double localStandardMeridian = GetLocalStandardMeridian(timeDelta);

            double B = CalculationAbbreviations.DayOnCircle(dayOfYear);
            double equationOfTime = EquationOfTime(B);

            double timeDeltaMinutes = 4 * (localStandardMeridian - longitude) + equationOfTime;
            return timeDeltaMinutes;
        }
    }
}
