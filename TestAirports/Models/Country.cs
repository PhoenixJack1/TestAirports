using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestAirports.Models
{
    public class Country
    {
        public string Name { get; set; }
        [Key]
        public string Country_iata { get; set; }
    }
}
