using static Converter.RadianDegreeConverter;
using System;

namespace SolarAngles.DeclinationAngle
{
    public class DeclinationAngleSpencer : IDeclinationAngle
    {
        /// <summary>
        /// Spencer 1971 model, as defined in Equation 1.6.1b on page 14
        /// </summary>
        public double DeclinationAngle(double dayOfYear)
        {
            var B = CalculationAbbreviations.DayOnCircle(dayOfYear);
            
            return 0.006918 
                - 0.399912 * Math.Cos(B) + 0.070257 * Math.Sin(B) 
                - 0.006758 * Math.Cos(2 * B) + 0.000907 * Math.Sin(2 * B)
                - 0.002697 * Math.Cos(3 * B) + 0.00148 * Math.Sin(3 * B);
        }
    }
}
