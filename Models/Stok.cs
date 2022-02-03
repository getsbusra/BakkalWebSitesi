using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakkalWebSiteVt2.Models
{
    public class Stok
    {
        public int stok_id { get; set; }
        public int s_adedi { get; set; }

        public DateTime s_giris_tarihi { get; set; }
        public DateTime s_bitis_tarihi { get; set; }
    }
}