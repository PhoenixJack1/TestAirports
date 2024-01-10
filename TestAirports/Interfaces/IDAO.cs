using System.Collections.Generic;
using TestAirports.Models;
namespace TestAirports
{
    public interface IDAO
    {
        IEnumerable<Country> GetCountriesList();
        Airport GetAirport(string iata);
        bool AddAirport (Airport airport);
    }
}
