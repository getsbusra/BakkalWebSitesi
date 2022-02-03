using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakkalWebSiteVt2.Models
{
    public class Kullanıcı
    {
        public int kullanici_id { get; set; }
        public string k_kullaniciadi { get; set; }
        public string k_parola { get; set; }
        public string k_adi { get; set; }
        public string k_soyadi { get; set; }
        public string k_eposta { get; set; }
        public string k_telefon { get; set; }

        public bool k_durum { get; set; }
        public int rol_id { get; set; }
    }
}