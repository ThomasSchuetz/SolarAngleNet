using System;

namespace SolarAngles
{
    public static class SolarRadiation
    {
        /// <summary>
        /// Returns the extraterrestrial radiation incident on the plane normal to the radiation
        /// Calculation is based on equation 1.4.1b (page 9)
        /// </summary>
        /// <param name="dateTime">Date on which the extraterrestrial radiation shall be computed</param>
        public static double GetExtraterrestrialRadiation(DateTime dateTime)
        {
            int dayOfYear = dateTime.DayOfYear;

            double B = (dayOfYear - 1) * 360.0 / 365.0; // Equation 1.4.2

            return NaturalConstants.SolarConstant_W_per_m2 * (
                1.000110 + 0.034221 * Math.Cos(B) + 0.001280 * Math.Sin(B)
                + 0.000719 * Math.Cos(2 * B) + 0.000077 * Math.Sin(2 * B)
                );
        }
    }
}
