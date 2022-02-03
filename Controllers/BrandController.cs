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
    public class BrandController : Controller
    {

        MarkaDal markaDal = new MarkaDal();
        // GET: Kullanıcı
        public ActionResult List()
        {
            var data = markaDal.GetMarka();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Marka marka)
        {
            if (markaDal.InsertMarka(marka))
            {
                TempData["InsertMsg"] = "Marka kaydedildi.";
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErrorMsg"] = "Marka kaydedilemedi";
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var data = markaDal.GetMarka().Find(a => a.marka_id == id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Marka marka)
        {
            if (markaDal.UpdateMarka(marka))
            {
                TempData["UpdateMsg"] = "Marka guncellendi.";
                return RedirectToAction("List");
            }
            else
            {
                TempData["UpdateErrorMsg"] = "Marka guncellenemedi";
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            int r = markaDal.DeleteMarka(id);
            if (r > 0)
            {
                TempData["DeleteMsg"] = "Marka silindi.";
                return RedirectToAction("List");
            }
            else
            {
                TempData["DeleteErrorMsg"] = "Marka silinemedi";
            }
            return View();
        }


    }
}