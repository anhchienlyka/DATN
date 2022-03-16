using DATN.Data.BaseEntities;
using System;

namespace DATN.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string CommentHeader { get; set; }

        public string CommnentText { get; set; }

        public DateTime CommnetTime { get; set; }
    }
}