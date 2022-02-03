using BakkalWebSiteVt2.DataBase_Dal;
using BakkalWebSiteVt2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bakkal.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis

        SatisDal satisDal;
        Satis satis;


        public SatisController()
        {

            satisDal = new SatisDal();
            satis = new Satis();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();

        }


        // Yeni Kayıt Eklemek İçin formdan gelen verileri ilgili Dal (veri tabanı sınıfları ) sınıflarına gönderir.
        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            satis.Kullanici_id = Convert.ToInt32(form["k_id"]);
            satis.Miktar = Convert.ToUInt16(form["miktar"]);
            satis.Stais_Tarihi = Convert.ToDateTime(form["s_tarih"]);
            satis.Durum = form["durum"].Trim();
            satis.Fiyat = Convert.ToUInt16(form["fiyat"]);
            satis.İskonto = Convert.ToUInt16(form["iskonto"]);
            satis.Satis_Id = Convert.ToInt32(form["satis_id"]);
            satis.Urun_Id = Convert.ToInt32(form["urun_id"]);



            satisDal.Add(satis);
            return RedirectToAction("List", "Satis");

        }

        //Verileri Listelemek için  ilgili Dal (veri tabanı sınıfları ) sınıflarına gider.

        public ActionResult List()
        {

            DataSet dataSet = satisDal.List();
            ViewBag.table = dataSet.Tables[0];

            return View(dataSet);
        }


        //İstenilen veriyi silmek için is değerini ilgili Dal (veri tabanı sınıfları ) sınıflarına gönderir.

        public ActionResult Delete(int id)
        {

            satisDal.Delete(id);
            return RedirectToAction("List", "Satis");


        }
    }
}