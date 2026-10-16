namespace SRMSS.Models
{
    public class RouteListViewModel
    {
        public int RouteId { get; set; }

        public string RouteCode { get; set; } = string.Empty;

        public string StartPoint { get; set; } = string.Empty;

        public string EndPoint { get; set; } = string.Empty;

        public string? IntermediateStops { get; set; }

        public decimal? DistanceKm { get; set; }

        public string ServiceType { get; set; } = string.Empty;

        public string? AssignedBus { get; set; }

        public string? AssignedDriver { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
