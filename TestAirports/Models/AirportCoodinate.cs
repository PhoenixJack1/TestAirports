namespace TestAirports.Models
{
    public struct AirportCoodinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public AirportCoodinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
