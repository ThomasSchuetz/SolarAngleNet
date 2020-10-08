using SolarAngles.Extensions;
using System;

namespace SolarAngles.SunsetHourAngle
{
    public class SunsetHourAngleAtmosphericRefraction : ISunsetHourAngle
    {
        /// <summary>
        /// https://www.esrl.noaa.gov/gmd/grad/solcalc/solareqns.PDF
        /// </summary>
        /// <param name="latitude">Latitude in radian</param>
        /// <param name="declination">Decliation angle in radian</param>
        public double GetSunsetHourAngle(double latitude, double declination)
        {
            var cosOmegaS = (Math.Cos((90.833).FromDegreeToRadians()) - Math.Sin(latitude) * Math.Sin(declination))
                / (Math.Cos(latitude) * Math.Cos(declination));
            return Math.Acos(cosOmegaS);
        }
    }
}
