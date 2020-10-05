namespace SolarAngles
{
    public static class ZenithAngle
    {
        /// <summary>
        /// Zenith angle: The angle between the vertical and the line to the sun, 
        /// that is, the angle of incidence of beam radiation on a horizontal surface; 
        /// 0 <= thetaZ <= 90. If thetaZ > 90, the sun is below the horizon.
        /// All inputs are required in radian.
        /// </summary>
        /// <param name="latitude">Latitude in radian (phi)</param>
        /// <param name="declinationAngle">Declination angle in radian (delta)</param>
        /// <param name="hourAngle">Hour angle in radian (omega)</param>
        public static double GetZenithAngle(double latitude, 
            double declinationAngle,
            double hourAngle)
        {
            // Zenith angle is the incidence angle onto a horizontal surface.
            var horizontalSurface = new TiltedSurface(0, 0);
            return IncidenceAngle.GetIncidenceAngle(horizontalSurface, latitude, declinationAngle, hourAngle);
        }
    }
}