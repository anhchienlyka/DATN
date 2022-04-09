using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Models
{
    public class Category
    {
        [Key]
         public int CatID { get; set; }
        public string CatName { get; set; }
        //public string Description { get; set; }
        //public int ParentID { get; set; }
        //public int Levels { get; set; }
        //public int Ordering { get; set; }
        //public bool Published { get; set; }
        //public string Thumb { get; set; }
        //public string Title { get; set; }
        //public string Alias { get; set; }
        //public string MetaDesc { get; set; }
        //public string MetaKey { get; set; }
        //public string Cover { get; set; }
        //public string SchemaMarkup { get; set; }
        //public IEnumerable<Post>  Posts { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
