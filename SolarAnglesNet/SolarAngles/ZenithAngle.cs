using System;

namespace SolarAngles
{
    public static class ZenithAngle
    {
        /// <summary>
        /// Zenith angle: The angle between the vertical and the line to the sun, 
        /// that is, the angle of incidence of beam radiation on a horizontal surface; 
        /// 0 <= thetaZ <= 90. If thetaZ > 90, the sun is below the horizon.
        /// All inputs are required in radian.
        /// Equation 1.6.5 on page 15
        /// </summary>
        /// <param name="latitude">Latitude in radian (phi)</param>
        /// <param name="declinationAngle">Declination angle in radian (delta)</param>
        /// <param name="hourAngle">Hour angle in radian (omega)</param>
        public static double GetZenithAngle(double latitude, 
            double declinationAngle,
            double hourAngle)
        {
            // Abbreviations
            var cosPhi = Math.Cos(latitude);
            var sinPhi = Math.Sin(latitude);
            var cosDelta = Math.Cos(declinationAngle);
            var sinDelta = Math.Sin(declinationAngle);
            var cosOmega = Math.Cos(hourAngle);

            var cosThetaZ = cosPhi * cosDelta * cosOmega + sinPhi * sinDelta;

            // Ensure that cos(ThetaZ) is positive, so that ThetaZ is between 0 and pi/2
            cosThetaZ = Math.Max(0, cosThetaZ);

            return Math.Acos(cosThetaZ);
        }
    }
}