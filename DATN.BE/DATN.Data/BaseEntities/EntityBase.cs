using System;

namespace DATN.Data.BaseEntities
{
    public class EntityBase : IEntityBase
    {
        public bool IsDeleted { get; set; }

        public string Note { get; set; }

        public DateTime UpdatedOn { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}