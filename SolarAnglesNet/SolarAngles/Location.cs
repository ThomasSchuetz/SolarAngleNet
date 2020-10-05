using System;

namespace SolarAngles
{
    public class Location
    {
        /// <summary>Latitude in °</summary>
        public double Latitude { get; }
        /// <summary>Longitude in °</summary>
        public double Longitude { get; }
        /// <summary>Time zone</summary>
        public TimeZoneInfo TimeZone { get; private set; }
        /// <summary>Altitude in meters above sea-level</summary>
        public double Altitude { get; }


        /// <summary>Geographic location.</summary>
        /// <param name="latitude">
        /// Latitude in °. Values should be between -90 (South) and +90 (North)
        /// </param>
        /// <param name="longitude">
        /// Longitude in °. Values should be between -180 (West) and +180 (East)
        /// </param>
        /// <param name="altitude">
        /// Altitude in meters above sea-level. Values should be between -10000 and +10000. Defaults to 0.
        /// </param>
        public Location(double latitude, double longitude, double altitude = 0)
        {
            CheckInputs(latitude, longitude, altitude);

            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Altitude = altitude;

            SetTimeZone();
        }

        /// <summary>
        /// Set time zone based on stored latitude and longitude
        /// </summary>
        private void SetTimeZone()
        {
            var ianaTimeZone = GeoTimeZone.TimeZoneLookup.GetTimeZone(Latitude, Longitude).Result;
            TimeZone = TimeZoneConverter.TZConvert.GetTimeZoneInfo(ianaTimeZone);
        }

        /// <summary>
        /// If values are out of bounds, ArgumentOutOfRangeExceptions are thrown.
        /// </summary>
        private static void CheckInputs(double latitude, double longitude, double altitude)
        {
            ArgumentChecks.CheckValue(latitude, -90.0, 90.0, nameof(latitude));
            ArgumentChecks.CheckValue(longitude, -180.0, 180.0, nameof(longitude));
            ArgumentChecks.CheckValue(altitude, -10000.0, 10000.0, nameof(altitude));
        }
    }
}
