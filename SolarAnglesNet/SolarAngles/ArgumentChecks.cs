using System;

namespace SolarAngles
{
    public static class ArgumentChecks
    {
        public static void CheckValue(double value, double lowerBound, double upperBound, string typeOfValue)
        {
            if (value < lowerBound)
            {
                string msg = $"{typeOfValue} should be greater than {lowerBound}, current value: {value}";
                throw new ArgumentOutOfRangeException(msg);
            }

            if (value > upperBound)
            {
                string msg = $"{typeOfValue} should be less than {upperBound}, current value: {value}";
                throw new ArgumentOutOfRangeException(msg);
            }
        }
    }
}
