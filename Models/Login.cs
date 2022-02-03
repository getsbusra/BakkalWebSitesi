using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BakkalWebSiteVt2.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        [Display(Name = "Kullanıcı Adı:")]
        public String k_eposta { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        [Display(Name = "Şifre:")]
        [DataType(DataType.Password)]

        public String k_parola { get; set; }


    }
}