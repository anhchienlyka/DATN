using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanMayAnh.Models
{
    public class Advertisement
    {
        [Key]
        public int AdvertisementID { get; set; }
        public string SubTitle { get; set; }
        public string Title { get; set; }
        public string ImageBG { get; set; }
        public string ImageProduct { get; set; }
        public string UrlLink { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
 
    }
}
