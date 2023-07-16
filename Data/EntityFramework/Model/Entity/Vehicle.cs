using Rcr.Core.Entity;

namespace Rcr.Data.Entity
{
    public class Vehicle : EntityBase
    {
        public string Name { get; set; }

        public bool Status { get; set; }

        #region [ Navigation Properties ]
        
        public VehicleRoute Route { get; set; }
        
        #endregion
    }
}
