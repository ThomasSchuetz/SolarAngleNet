using System;

namespace SolarAngles.SunsetHourAngle
{
    public class SunsetHourAngleBasic : ISunsetHourAngle
    {
        /// <summary>
        /// Calculate Sunset Hour Angle as defined in Equation 1.6.10 (page 17)
        /// </summary>
        /// <param name="latitude">Latitude in radian</param>
        /// <param name="declination">Decliation angle in radian</param>
        public double GetSunsetHourAngle(double latitude, double declination)
        {
            var cosOmegaS = - Math.Tan(latitude) * Math.Tan(declination);
            return Math.Acos(cosOmegaS);
        }
    }
}
