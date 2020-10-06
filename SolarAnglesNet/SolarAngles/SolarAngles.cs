using System;
using static Converter.RadianDegreeConverter;

namespace SolarAngles
{
    /// <summary>
    /// This class presents a collection of functions explaind in the book
    ///     "Solar Engineering of Thermal Processes" (4th edition, 2013) 
    ///     by John A. Duffie and William A. Beckman
    /// </summary>
    public class SolarAngles
    {
        private readonly Configuration config;
        private readonly BaseSolarCalculator calculator;

        public Location Location { get; }
        public TiltedSurface TiltedSurface { get; }

        /// <summary>
        /// Constructor for only setting the location. 
        /// A flat horizontal surface will be assumed.
        /// </summary>
        /// <param name="location">Location defining latitude and longitude</param>
        public SolarAngles(Location location) 
            : this(location, TiltedSurface.GetFlatHorizontalSurface())
        { }

        /// <summary>
        /// Constructor for setting location and tilted surface of interest
        /// </summary>
        /// <param name="location">Location defining latitude and longitude</param>
        /// <param name="tiltedSurface">Tilted surface defining slope and azimuth angles</param>
        public SolarAngles(Location location, TiltedSurface tiltedSurface)
        {
            config = Configuration.Config;
            calculator = new BaseSolarCalculator();

            Location = location;
            TiltedSurface = tiltedSurface;
        }

        /// <summary>
        /// Returns the hour angle. 
        /// The given dateTime will be interpreted as defined in the configuration object.
        /// </summary>
        public double GetHourAngle(DateTime dateTime) 
            => calculator.CalculateAngle(dt => HourAngle.GetHourAngle(dt), dateTime);

        /// <summary>
        /// Returns the incidence angle on the stored tilted surface. 
        /// The given dateTime will be interpreted as defined in the configuration object.
        /// </summary>
        public double GetIncidenceAngle(DateTime dateTime)
            => calculator.CalculateAngle(dt => GetIncidenceAngle(dt, TiltedSurface), dateTime);

        /// <summary>
        /// Returns the zenith angle. 
        /// The given dateTime will be interpreted as defined in the configuration object.
        /// </summary>
        public double GetZenithAngle(DateTime dateTime)
            => calculator.CalculateAngle(
                dt => GetIncidenceAngle(dt, TiltedSurface.GetFlatHorizontalSurface()), 
                dateTime);

        /// <summary>
        /// Private method to calculate either incidence or zenith angles, 
        /// depending on passed tiltedSurface
        /// </summary>
        private double GetIncidenceAngle(DateTime solarTime, TiltedSurface tiltedSurface)
        {
            var declinationAngle = config.DeclinationAngle.DeclinationAngle(solarTime.DayOfYear);
            var hourAngle = HourAngle.GetHourAngle(solarTime);

            return IncidenceAngle.GetIncidenceAngle(tiltedSurface,
                Location.Latitude.FromDegreeToRadians(),
                declinationAngle,
                hourAngle);
        }
    }
}
