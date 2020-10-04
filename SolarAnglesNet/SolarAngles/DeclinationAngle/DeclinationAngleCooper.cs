using System;
using static Converter.RadianDegreeConverter;

namespace SolarAngles.DeclinationAngle
{
    public class DeclinationAngleCooper : IDeclinationAngle
    {
        /// <summary>
        /// Cooper 1969 model, as defined in Equation 1.6.1a on page 13
        /// </summary>
        public double DeclinationAngle(double dayOfYear)
        {
            var argumentDegrees = 360 * (284 + dayOfYear) / 365;
            var argumentRadians = argumentDegrees.FromDegreeToRadians();
            var decliationAngle = 23.45 * Math.Sin(argumentRadians);
            return decliationAngle.FromDegreeToRadians();
        }
    }
}
