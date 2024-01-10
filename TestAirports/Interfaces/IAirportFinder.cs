using TestAirports.Models;
using System.Threading.Tasks;

namespace TestAirports
{
    public interface IAirportFinder
    {
        Task<Airport> FindAirportAsync(string iata);
    }
}
