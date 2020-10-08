using SolarAngles.Extensions;
using System;

namespace SolarAngles
{
    public static class HourAngle
    {
        private const double anglesPerHour = 15;

        /// <summary>
        /// Hour angle (omega): The angular displacement of the sun east or west of the 
        /// local meridian due to rotation of the earth on its axis at 15 degrees per hour; 
        /// morning negative, afternoon positive
        /// Confirm page 13
        /// </summary>
        /// <param name="solarTime"></param>
        public static double GetHourAngle(DateTime solarTime)
        {
            var noon = new DateTime(solarTime.Year, solarTime.Month, solarTime.Day, 12, 0, 0);
            var timeDelta = solarTime - noon;

            var hourAngleDegrees = anglesPerHour * timeDelta.TotalHours;
            return hourAngleDegrees.FromDegreeToRadians();
        }

        /// <summary>Transforms an hour angle to a time span.</summary>
        /// <param name="hourAngle">Hour angle in radian</param>
        public static TimeSpan GetTimeSpanFromHourAngle(double hourAngle)
        {
            var hourAngleDegrees = hourAngle.FromRadiansToDegree();
            return TimeSpan.FromHours(hourAngleDegrees / anglesPerHour);
        }
    }
}
