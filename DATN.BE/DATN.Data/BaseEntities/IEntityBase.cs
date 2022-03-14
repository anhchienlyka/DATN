using System;

namespace DATN.Data.BaseEntities
{
    public interface IEntityBase
    {
        public bool IsDeleted { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}