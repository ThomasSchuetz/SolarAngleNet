namespace SolarAngles.AirMass
{
    public interface IAirMass
    {
        double GetAirMass(double zenithAngle, double altitude = 0);
    }
}
