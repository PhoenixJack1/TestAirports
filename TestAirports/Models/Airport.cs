using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAirports.Models
{
    public class Airport
    {
        [Key]
        public string iata { get; set; }
        public City City { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        [NotMapped]
        public string Error { get; set; }
    }
}
