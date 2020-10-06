﻿using System;

namespace SolarAngles
{
    public class BaseSolarCalculator
    {
        private readonly Configuration config;

        public BaseSolarCalculator()
        {
            config = Configuration.Config;
        }

        public double CalculateAngle(Func<DateTime, double> calculateAngle, DateTime originalDateTime)
        {
            var solarTime = config.DateTimeConverter.OriginalTimeToSolarTime(originalDateTime);
            return calculateAngle(solarTime);
        }

        public DateTime CalculateTime()
        {
            throw new NotImplementedException("Placeholder for future calculations, e.g. sunset time");
        }
    }
}
