using Microsoft.AspNetCore.Mvc;
using TestAirports.Models;
using System.Threading.Tasks;
using System;

namespace TestAirports.Controllers
{

    public class AirportController : Controller
    {
        IDAO _dao;
        IAirportFinder _airportFinder;
        IDistanceCalculator _distanceCalculator;
        IRussianEndings _russianEndings;
        public AirportController(IDAO dao, IAirportFinder airportFinder, IDistanceCalculator distanceCalculator, IRussianEndings russianEndings) 
        { 
            _dao= dao;
            _airportFinder= airportFinder;
            _distanceCalculator= distanceCalculator;
            _russianEndings= russianEndings;
        }
        [Route("airports/{iata:length(3)}")]
        [HttpGet]
        public async Task<Airport> GetAirport(string iata)
        {
            var airport= _dao.GetAirport(iata?.ToUpper());
            if (airport == null)
            {
                airport = await _airportFinder.FindAirportAsync(iata);
                if (airport != null)
                    _dao.AddAirport(airport);
            }
            if (airport==null)
            return new Airport() { Error = "Not founded" };
            else
                return airport; 
        }
        [Route("airports/{iata1:length(3)},{iata2:length(3)}")]
        [HttpGet]
        public string CalcDistance(string iata1, string iata2)
        {
            var airport1 = _dao.GetAirport(iata1.ToUpper());
            var airport2 = _dao.GetAirport(iata2.ToUpper());
            if (airport1 == null || airport2 == null)
                return "Один из аэропортов не существует";
            AirportCoodinate coord1 = new AirportCoodinate(airport1.Latitude, airport1.Longitude);
            AirportCoodinate coord2 = new AirportCoodinate(airport2.Latitude, airport2.Longitude);
            double distance = _distanceCalculator.CalcDistance(coord1, coord2);
            if (Double.IsNormal(distance))
            {
                int int_distance = (int)Math.Round(distance, 0);
                return $"Расстояние {int_distance} {_russianEndings.GetEndingMiles(int_distance)}";
            }
            else
                return "Ошибка расчёта";
        }
        [Route("airports/{id}")]
        [HttpGet]
        public string Error(string id)
        {
            return "Получен неверный запрос api. Для получения информации об аэропорте укажите его iata код (3 символа), для расчёта расстояния - iata коды двух аэропортов (по 3 символа) через запятую";
        }
    }
}
