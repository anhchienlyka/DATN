using DATN.Data.BaseEntities;
using System;

namespace DATN.Data.Entities
{
    public class Comment : EntityBase
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string CommentHeader { get; set; }

        public string CommnentText { get; set; }

        public DateTime CommnetTime { get; set; }
    }
}