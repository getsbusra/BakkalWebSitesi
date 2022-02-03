using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakkalWebSiteVt2.Models
{
    public class Satis
    {
        public int Satis_Id { get; set; }
        public DateTime Stais_Tarihi { get; set; }
        public string Durum { get; set; }
        public int Kullanici_id { get; set; }
        public float Miktar { get; set; }
        public float Fiyat { get; set; }
        public float İskonto { get; set; }
        public int Urun_Id { get; set; }
    }
}