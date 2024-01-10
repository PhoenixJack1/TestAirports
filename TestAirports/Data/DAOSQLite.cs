using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using TestAirports.Models;

namespace TestAirports
{
    public class DAOSQLite:IDAO
    {
        SQLiteContext _context;
        public DAOSQLite(SQLiteContext context)
        {
            _context = context;
        }
        public IEnumerable<Country> GetCountriesList() => _context.Countries.ToList();
        public Airport GetAirport(string iata)
        {
            return _context.Airports.Include(t=>t.City).ThenInclude(t=>t.Country).FirstOrDefault(t=>t.iata == iata);
        }
        public bool AddAirport(Airport airport)
        {
            if (airport.City== null)
                return false;
            if (airport.City.Country == null)
                return false;   
            if (_context.Countries.FirstOrDefault(t=>t.Country_iata==airport.City.Country.Country_iata)==null)
                _context.Countries.Add(airport.City.Country);
            if (_context.Cities.FirstOrDefault(t => t.City_iata == airport.City.City_iata) == null)
                _context.Cities.Add(airport.City);
            if (_context.Airports.FirstOrDefault(t => t.iata == airport.iata) == null)
                _context.Airports.Add(airport);
            else
                return true;
            _context.SaveChanges();
            return true;
        }
    }
}
