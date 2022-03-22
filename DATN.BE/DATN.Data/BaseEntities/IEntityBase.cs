using System;

namespace DATN.Data.BaseEntities
{
    public interface IEntityBase
    {
   
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}