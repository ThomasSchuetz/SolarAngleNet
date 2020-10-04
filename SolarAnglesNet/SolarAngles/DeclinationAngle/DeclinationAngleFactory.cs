using System;

namespace SolarAngles.DeclinationAngle
{
    public static class DeclinationAngleFactory
    {
        public static IDeclinationAngle GetDeclinationAngleModel(DeclinationAngleModels model)
        {
            switch (model)
            {
                case DeclinationAngleModels.Cooper1969:
                    return new DeclinationAngleCooper();
                case DeclinationAngleModels.Spencer1971:
                    return new DeclinationAngleSpencer();
                default:
                    throw new ArgumentOutOfRangeException($"Unknown declination angle model {model}");
            }
        }
    }
}
