using System.ComponentModel.DataAnnotations;

namespace Rcr.Core.Entity
{
    public class EntityBase : IEntity
    {
        public EntityBase()
        {
            Id = new Guid();
        }
        [Key]
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }

        private DateTime createdDate;
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return DateTime.Now; }
            set { createdDate = value; }
        }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }
    }
}
