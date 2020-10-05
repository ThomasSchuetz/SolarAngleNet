using static Converter.RadianDegreeConverter;

namespace SolarAngles
{
    public class TiltedSurface
    {
        /// <summary>
        /// Beta in ° 
        /// Slope angle between the plane of the surface in question and the horizontal. 
        /// 0 <= beta <= 180. If beta > 90, the surface faces downwards.
        /// </summary>
        public double Beta { get; }

        /// <summary>
        /// Gamma in °
        /// Surface azimuth angle. The deviation of the projection on a horizontal
        /// plane of the normal to the surface from the local meridian, with zero
        /// due south, east negative, and west positive.
        /// -180 <= gamma <= 180
        /// </summary>
        public double Gamma { get; }

        /// <summary>Tilted surface</summary>
        /// <param name="beta">Slope angle</param>
        /// <param name="gamma">Surface azimuth angle</param>
        public TiltedSurface(double beta, double gamma)
        {
            this.Beta = beta;
            this.Gamma = gamma;
        }

        /// <summary>
        /// Returns a flat horizontal surface (0° slope, 0° azimuth angles)
        /// </summary>
        public static TiltedSurface GetFlatHorizontalSurface() => new TiltedSurface(0, 0);

        public (double betaRadian, double gammaRadian) GetAnglesRadian() 
            => (Beta.FromDegreeToRadians(), Gamma.FromDegreeToRadians());
    }
}
