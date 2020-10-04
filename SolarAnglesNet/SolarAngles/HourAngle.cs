using System;
using static Converter.RadianDegreeConverter;

namespace SolarAngles
{
    public static class HourAngle
    {
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

            var hourAngleDegrees = 15 * timeDelta.TotalHours;
            return hourAngleDegrees.FromDegreeToRadians();
        }
    }
}
