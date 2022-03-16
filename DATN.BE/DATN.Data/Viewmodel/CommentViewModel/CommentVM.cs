using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Data.Viewmodel.CommentViewModel
{
   public class CommentVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string CommentHeader { get; set; }
        public string CommnentText { get; set; }
        public DateTime CommnetTime { get; set; }
    }
}
