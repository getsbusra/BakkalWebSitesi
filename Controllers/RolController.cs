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
    public class RolController : Controller
    {
        // GET: Rol

        RolDal rolDal;
        Rol rol;


        public RolController()
        {
            rolDal = new RolDal();
            rol = new Rol();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();

        }

        //Verileri Listelemek için  ilgili Dal (veri tabanı sınıfları ) sınıflarına gider.

        public ActionResult List()
        {

            DataSet dataSet = rolDal.List();
            ViewBag.table = dataSet.Tables[0];

            return View(dataSet);
        }


        // Yeni Kayıt Eklemek İçin formdan gelen verileri ilgili Dal (veri tabanı sınıfları ) sınıflarına gönderir.
        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            rol.r_adi = form["r_adi"];
            rolDal.Add(rol);
            return RedirectToAction("List", "Rol");

        }


        //İstenilen veriyi silmek için is değerini ilgili Dal (veri tabanı sınıfları ) sınıflarına gönderir.
        public ActionResult Delete(int id)
        {

            rolDal.Delete(id);
            return RedirectToAction("List", "Rol");


        }
    }
}