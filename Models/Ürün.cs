using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakkalWebSiteVt2.Models
{
    public class Ürün
    {
        public int urun_id { get; set; }
        public string u_adi { get; set; }
        public string u_barkodu { get; set; }
        public DateTime u_tuketim_tarihi { get; set; }
        public DateTime u_uretim_tarihi { get; set; }
        public float u_fiyat { get; set; }
        public float u_agirlik { get; set; }
        public string u_rengi { get; set; }
       
    }
}