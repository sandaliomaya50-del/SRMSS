namespace SRMSS.Models
{
    public class Route
    {
        public int RouteId { get; set; }

        public string RouteName { get; set; } = string.Empty;

        public string StartLocation { get; set; } = string.Empty;

        public string EndLocation { get; set; } = string.Empty;

        public decimal? DistanceKm { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}