using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string Title { get; set; }
        public string SContents { get; set; }
        public string Contents { get; set; }
        public string Thumb { get; set; }
        public bool Published { get; set; }
        public string Alias { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Author { get; set; }
        public int  AccountID { get; set; }
        public Account  Account { get; set; }
        public string Tags { get; set; }
        public int CatID { get; set; }
        public Category  Category { get; set; }
        public bool IsHot { get; set; }
        public bool IsNewfeed { get; set; }
        public bool MetaKey { get; set; }
        public bool MetaDesc { get; set; }
        public int Views { get; set; }

    }
}
