using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using TestAirports.Models;
using System.Threading.Tasks;

namespace TestAirports
{
    public class Places_dev : IAirportFinder
    {
        public async Task<Airport> FindAirportAsync(string iata)
        {
            HttpClient httpClient = new HttpClient();
            var url = @"https://places-dev.cteleport.com/airports/" + iata.ToUpper();
            try
            {
                var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    HttpContent content = response.Content;
                    string text = await content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<JToken>(text);
                    var airport = new Airport()
                    {
                        Name = result["name"].ToString(),
                        iata = result["iata"].ToString(),
                        Longitude = double.Parse(result["location"]["lon"].ToString()),
                        Latitude = double.Parse(result["location"]["lat"].ToString()),
                        City = new City()
                        {
                            City_iata = result["city_iata"].ToString(),
                            Name = result["city"].ToString(),
                            Country = new Country()
                            {
                                Country_iata = result["country_iata"].ToString(),
                                Name = result["country"].ToString()

                            }
                        }

                    };
                    return airport;
                }
            }
            catch
            {

            }
            return null;

        }
    }
}
