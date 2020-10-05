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

        public SolarAngles(Location location, TiltedSurface tiltedSurface)
        {
            config = Configuration.Config;

            Location = location;
            TiltedSurface = tiltedSurface;
        }

        public double GetHourAngle(DateTime solarTime)
            => HourAngle.GetHourAngle(solarTime);

        public double GetIncidenceAngle(DateTime solarTime) 
            => GetIncidenceAngle(solarTime, TiltedSurface);

        public double GetZenithAngle(DateTime solarTime)
            => GetIncidenceAngle(solarTime, TiltedSurface.GetFlatHorizontalSurface());

        private double GetIncidenceAngle(DateTime solarTime, TiltedSurface tiltedSurface)
        {
            var declinationAngle = config.DeclinationAngle.DeclinationAngle(solarTime.DayOfYear);
            var hourAngle = GetHourAngle(solarTime);

            Console.WriteLine($"Declination angle: {declinationAngle.FromRadiansToDegree()}");
            Console.WriteLine($"Hour angle: {hourAngle.FromRadiansToDegree()}");

            return IncidenceAngle.GetIncidenceAngle(tiltedSurface,
                Location.Latitude.FromDegreeToRadians(),
                declinationAngle,
                hourAngle);
        }
    }
}
