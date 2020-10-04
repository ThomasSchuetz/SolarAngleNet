using System;

namespace SolarAngles.AirMass
{
    public class AirMassSimpleModel : IAirMass
    {
        /// <summary>
        /// Simple model based on Equation 1.5.1 (page 10)
        /// </summary>
        /// <param name="zenithAngle">
        /// Zenith angle in radian. Value has to be between 0 and pi/2 [90°].
        /// </param>
        public double GetAirMass(double zenithAngle, double altitude = 0)
        {
            return 1 / Math.Cos(zenithAngle);
        }
    }
}
