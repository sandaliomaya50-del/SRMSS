using System;

namespace SRMSS.Models
{
    public class RouteManagement
    {
        public int RouteManagementId { get; set; }

        public string RouteCode { get; set; } = string.Empty;

        public string StartPoint { get; set; } = string.Empty;

        public string EndPoint { get; set; } = string.Empty;

        public string? IntermediateStops { get; set; }

        public decimal TotalDistanceKm { get; set; }

        public string ServiceType { get; set; } = string.Empty;

        public string? AssignedBus { get; set; }

        public string? AssignedDriver { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}