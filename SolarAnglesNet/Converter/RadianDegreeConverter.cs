﻿using System;

namespace Converter
{
    public static class RadianDegreeConverter
    {
        public static double FromDegreeToRadians(this double valueDegree)
        {
            return valueDegree * Math.PI / 180;
        }

        public static double FromRadiansToDegree(this double valueRadians)
        {
            return valueRadians / Math.PI * 180;
        }
    }
}
