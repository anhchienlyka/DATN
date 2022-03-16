using DATN.InfrastructureLayer.Enums;
using System;

namespace DATN.Data.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User  User { get; set; }
        public TypeRole TypeRole { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}