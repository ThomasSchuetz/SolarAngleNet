using System;

namespace SolarAngles
{
    public static class IncidenceAngle
    {
        /// <summary>
        /// Angle of incidence: The angle between the beam radiation 
        /// on a surface and the normal to that surface.
        /// Equation 1.6.2, page 14
        /// </summary>
        /// <param name="tiltedSurface">
        /// Describes slope (beta) and azimuth (gamma) angles of tilted surfaces
        /// </param>
        /// <param name="latitude">Latitude in radian (phi)</param>
        /// <param name="declinationAngle">Declination angle in radian (delta)</param>
        /// <param name="hourAngle">Hour angle in radian (omega)</param>
        /// <returns></returns>
        public static double GetIncidenceAngle(TiltedSurface tiltedSurface, 
            double latitude,
            double declinationAngle,
            double hourAngle)
        {
            (double slopeAngle, double azimuthAngle) = tiltedSurface.GetAnglesRadian();

            // Abbreviations to improve readability
            var sinBeta = Math.Sin(slopeAngle);
            var cosBeta = Math.Cos(slopeAngle);
            var sinDelta = Math.Sin(declinationAngle);
            var cosDelta = Math.Cos(declinationAngle);
            var sinPhi = Math.Sin(latitude);
            var cosPhi = Math.Cos(latitude);
            var sinGamma = Math.Sin(azimuthAngle);
            var cosGamma = Math.Cos(azimuthAngle);
            var sinOmega = Math.Sin(hourAngle);
            var cosOmega = Math.Cos(hourAngle);

            var cosTheta = sinDelta * sinPhi * cosBeta
                - sinDelta * cosPhi * sinBeta * cosGamma
                + cosDelta * cosPhi * cosBeta * cosOmega
                + cosDelta * sinPhi * sinBeta * cosGamma * cosOmega
                + cosDelta * sinBeta * sinGamma * sinOmega;

            // Ensure that cos(ThetaZ) is positive, so that ThetaZ is between 0 and pi/2
            cosTheta = Math.Max(0, cosTheta);

            return Math.Acos(cosTheta);
        }
    }
}
