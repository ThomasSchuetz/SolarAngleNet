using System;

namespace SolarAngles
{
    public class SunriseSunset
    {
        public DateTime Sunrise { get; private set; }
        public DateTime Sunset { get; private set; }

        public SunriseSunset(DateTime solarNoon, double latitudeRadian)
        {
            var config = Configuration.Config;
            var declination = config.DeclinationAngle.DeclinationAngle(solarNoon.DayOfYear);

            var sunsetHourAngle = config.SunsetHourAngle.GetSunsetHourAngle(latitudeRadian, declination);
            var timeDelta = HourAngle.GetTimeSpanFromHourAngle(sunsetHourAngle);

            Sunrise = solarNoon - timeDelta;
            Sunset = solarNoon + timeDelta;
        }
    }
}
