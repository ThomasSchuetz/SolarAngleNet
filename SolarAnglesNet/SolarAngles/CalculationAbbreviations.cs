using SolarAngles.Extensions;

namespace SolarAngles
{
    public static class CalculationAbbreviations
    {
        /// <summary>
        /// Transform day of year into an equivalent point on a circle.
        /// Equation 1.4.2
        /// </summary>
        /// <param name="dayOfYear"></param>
        public static double DayOnCircle(double dayOfYear) 
            => ((dayOfYear - 1) * 360.0 / 365.0).FromDegreeToRadians();
    }
}
