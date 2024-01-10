using System;
using System.Drawing;
using TestAirports.Models;

namespace TestAirports.Calculator
{
    public class DistanceCalculator:IDistanceCalculator
    {
        public double CalcDistance(AirportCoodinate coord1, AirportCoodinate coord2)
        {
            double lon1_rad = coord1.Longitude * Math.PI / 180;
            double lon2_rad = coord2.Longitude * Math.PI / 180;
            double lat1_rad = coord1.Latitude * Math.PI / 180;
            double lat2_rad = coord2.Latitude * Math.PI / 180;
            double cos_lat1 = Math.Cos(lat1_rad);
            double cos_lat2=Math.Cos(lat2_rad);
            double d_lon = lon2_rad - lon1_rad;
            double d_lat = lat2_rad - lat1_rad;
            double sin_d_lat = Math.Sin(d_lat / 2);
            double sin_d_lon=Math.Sin(d_lon / 2);
            double a = Math.Pow(sin_d_lat, 2) + cos_lat1 * cos_lat2 * Math.Pow(sin_d_lon, 2);
            double b = 2 * Math.Asin(Math.Sqrt(a));
            return b * 6372.795 / 1.609344;
        }
    }
}
