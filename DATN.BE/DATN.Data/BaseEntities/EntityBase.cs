using System;

namespace DATN.Data.BaseEntities
{
    public class EntityBase : IEntityBase
    {
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}