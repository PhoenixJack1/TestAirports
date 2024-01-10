using System.Drawing;
using TestAirports.Models;

namespace TestAirports
{
    public interface IDistanceCalculator
    {
        double CalcDistance(AirportCoodinate coord1, AirportCoodinate AirportCoodinate);
    }
}
