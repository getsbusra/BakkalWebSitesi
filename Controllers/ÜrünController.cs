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
    public class ÜrünController : Controller
    {
        ÜrünDal ürünDal = new ÜrünDal();
        // GET: Kullanıcı
        public ActionResult List()
        {
            var data = ürünDal.GetÜrün();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Ürün ürün)
        {
            if (ürünDal.InsertÜrün(ürün))
            {
                TempData["InsertMsg"] = "Ürün kaydedildi.";
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErrorMsg"] = "Ürün kaydedilemedi";
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var data = ürünDal.GetÜrün().Find(a => a.urun_id == id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Ürün ürün)
        {
            if (ürünDal.UpdateÜrün(ürün))
            {
                TempData["UpdateMsg"] = "Ürün guncellendi.";
                return RedirectToAction("List");
            }
            else
            {
                TempData["UpdateErrorMsg"] = "Kullanıcı guncellenemedi";
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            int r = ürünDal.DeleteÜrün(id);
            if (r > 0)
            {
                TempData["DeleteMsg"] = "Ürün silindi.";
                return RedirectToAction("List");
            }
            else
            {
                TempData["DeleteErrorMsg"] = "Ürün silinemedi";
            }
            return View();
        }
    }
}