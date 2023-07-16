using Rcr.Core.Entity;

namespace Rcr.Data.Entity
{
    public class Vehicle : EntityBase
    {
        public string Name { get; set; }

        public string Direction { get; set; }

        public int RouteX { get; set; }

        public int RouteY { get; set; }

        public string Status { get; set; }

    }
}
