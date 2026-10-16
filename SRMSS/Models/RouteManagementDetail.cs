using System;

namespace SRMSS.Models
{
    public class RouteManagementDetail
    {
        public int RouteManagementDetailId { get; set; }

        public int RouteId { get; set; }

        public string? IntermediateStops { get; set; }

        public string ServiceType { get; set; } = string.Empty;

        public string? AssignedBus { get; set; }

        public string? AssignedDriver { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

        public Route? Route { get; set; }
    }
}
