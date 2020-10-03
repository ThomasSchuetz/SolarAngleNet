using System;

namespace SolarAngles
{
    public static class AirMass
    {
        /// <summary>
        /// Calculate Air Mass as defined in Equation 1.5.1 (page 10)
        /// </summary>
        /// <param name="zenithAngle">
        /// Zenith angle in radian. Value has to be between 0° and 90°.
        /// </param>
        public static double GetAirMass(double zenithAngle)
        {
            ArgumentChecks.CheckValue(zenithAngle, 0.0, 90.0, nameof(zenithAngle));

            return 1 / Math.Cos(zenithAngle);
        }
    }
}
