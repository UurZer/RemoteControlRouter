using Rcr.Core.Entity;

namespace Rcr.Data.Entity
{
    public class Coordinate : IEntity
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Head { get; set; }
    }
}
