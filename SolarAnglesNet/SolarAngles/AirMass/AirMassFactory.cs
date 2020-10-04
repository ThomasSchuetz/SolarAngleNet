using System;

namespace SolarAngles.AirMass
{
    public static class AirMassFactory
    {
        public static IAirMass GetAirMassModel(AirMassModels model)
        {
            switch (model)
            {
                case AirMassModels.SimpleModel:
                    return new AirMassSimpleModel();
                case AirMassModels.KarstenYoung1989:
                    return new AirMassKarstenYoung();
                default:
                    throw new ArgumentOutOfRangeException($"Unknown air mass model {model}");
            }
        }
    }
}
