using SolarAngles.DeclinationAngle;
using SolarAngles.AirMass;

namespace SolarAngles
{
    /// <summary>
    /// This class is a singleton configuration in which 
    /// default models for calculations are stored.
    /// </summary>
    public sealed class Configuration
    {
        #region Singleton stuff
        private static Configuration instance = null;
        private static readonly object lockingObject = new object();

        public static Configuration Config
        {
            get
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new Configuration();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public IDeclinationAngle DeclinationAngle { get; private set; }
        public IAirMass AirMass { get; private set; }

        private Configuration()
        {
            DeclinationAngle = new DeclinationAngleCooper();
            AirMass = new AirMassSimpleModel();
        }

        public void SetDeclinationAngleModel(IDeclinationAngle declinationAngleModel)
            => DeclinationAngle = declinationAngleModel;
        public void SetDeclinationAngleModel(DeclinationAngleModels model)
            => SetDeclinationAngleModel(DeclinationAngleFactory.GetDeclinationAngleModel(model));

        public void SetAirMassModel(IAirMass airMassModel)
            => AirMass = airMassModel;
        public void SetAirMassModel(AirMassModels model)
            => SetAirMassModel(AirMassFactory.GetAirMassModel(model));
    }
}
