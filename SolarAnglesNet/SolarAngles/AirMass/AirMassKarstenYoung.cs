using SolarAngles.Extensions;
using System;

namespace SolarAngles.AirMass
{
    public class AirMassKarstenYoung : IAirMass
    {
        /// <summary>
        /// Calculate Air Mass according to Kasten and Young (1989) [footnote 3 on page 10]
        /// </summary>
        /// <param name="zenithAngle">
        /// Zenith angle in radian. Value has to be between 0 and pi/2 [90°].
        /// </param>
        /// <param name="altitude">Altitude in meters above sea level.</param>
        public double GetAirMass(double zenithAngle, double altitude = 0)
        {
            ArgumentChecks.CheckValue(zenithAngle, 0.0, Math.PI / 2, nameof(zenithAngle));
            ArgumentChecks.CheckAltitude(altitude);

            return Math.Exp(-0.0001184 * altitude) /
                (Math.Cos(zenithAngle) + 0.5057 * Math.Pow(96.080 - zenithAngle.FromRadiansToDegree(), -1.634));
        }
    }
}
