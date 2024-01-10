using System.ComponentModel.DataAnnotations;

namespace TestAirports.Models
{
    public class City
    {
        public string Name { get; set; }
        [Key]
        public string City_iata { get; set; }
        public Country Country { get; set; }
    }
}
