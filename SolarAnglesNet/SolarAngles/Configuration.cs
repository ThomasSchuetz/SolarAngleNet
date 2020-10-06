using SolarAngles.AirMass;
using SolarAngles.DateTimeConverter;
using SolarAngles.DeclinationAngle;

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
        public IDateTimeConverter DateTimeConverter { get; private set; }

        private Configuration()
        {
            DeclinationAngle = new DeclinationAngleCooper();
            AirMass = new AirMassSimpleModel();
            DateTimeConverter = new DateTimeSolarTime();
        }

        public void SetDeclinationAngleModel(DeclinationAngleModels model)
            => DeclinationAngle = DeclinationAngleFactory.GetDeclinationAngleModel(model);

        public void SetAirMassModel(AirMassModels model)
            => AirMass = AirMassFactory.GetAirMassModel(model);

        public void SetDateTimeConverter(DateTimeModels model, Location location)
            => DateTimeConverter =  DateTimeFactory.GetDateTimeConverter(model, location);
    }
}
