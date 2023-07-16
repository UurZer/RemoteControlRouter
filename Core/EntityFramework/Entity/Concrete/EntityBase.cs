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
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        private DateTime? createdDate;
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return createdDate ?? DateTime.Now; }
            set { createdDate = value; }
        }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }
    }
}
