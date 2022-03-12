using DATN.Data.BaseEntities;

namespace DATN.Data.Entities
{
    public class SaleCode : EntityBase
    {
        public int Id { get; set; }

        public string CodeName { get; set; }
    }
}