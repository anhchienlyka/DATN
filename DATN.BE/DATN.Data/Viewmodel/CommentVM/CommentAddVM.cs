using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Data.Viewmodel.Comment
{
    public class CommentAddVM
    {
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int ProductId { get; set; }
        public string CommentHeader { get; set; }
        public string CommnentText { get; set; }
        public DateTime CommnetTime { get; set; }
    }
}
