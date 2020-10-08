using System;

namespace SolarAngles.SunsetHourAngle
{
    public static class SunsetHourAngleFactory
    {
        public static ISunsetHourAngle GetSunsetHourAngleModel(SunsetHourAngleModels model)
        {
            switch (model)
            {
                case SunsetHourAngleModels.Basic:
                    return new SunsetHourAngleBasic();
                case SunsetHourAngleModels.WithAtmosphericRefraction:
                    return new SunsetHourAngleAtmosphericRefraction();
                default:
                    throw new ArgumentOutOfRangeException($"Unknown sunset hour angle model {model}");
            }
        }
    }
}
