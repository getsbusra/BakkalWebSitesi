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
    public class StokController : Controller
    {
        StokDal stokDal = new StokDal();
        // GET: Kullanıcı
        public ActionResult List()
        {
            var data = stokDal.GetStok();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Stok stok)
        {
            if (stokDal.InsertStok(stok))
            {
                TempData["InsertMsg"] = "Stok kaydedildi.";
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErrorMsg"] = "Stok kaydedilemedi";
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var data = stokDal.GetStok().Find(a => a.stok_id == id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Stok stok)
        {
            if (stokDal.UpdateStok(stok))
            {
                TempData["UpdateMsg"] = "Stok guncellendi.";
                return RedirectToAction("List");
            }
            else
            {
                TempData["UpdateErrorMsg"] = "Stok guncellenemedi";
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            int r = stokDal.DeleteStok(id);
            if (r > 0)
            {
                TempData["DeleteMsg"] = "Stok silindi.";
                return RedirectToAction("List");
            }
            else
            {
                TempData["DeleteErrorMsg"] = "Stok silinemedi";
            }
            return View();
        }
    }
}