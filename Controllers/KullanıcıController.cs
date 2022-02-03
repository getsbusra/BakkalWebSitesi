using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakkalWebSiteVt2.DataBase_Dal;
using BakkalWebSiteVt2.Models;

namespace BakkalWebSiteVt2.Controllers

{
    public class KullanıcıController : Controller
    {
        KullaniciDal kullaniciDal = new KullaniciDal();
        // GET: Kullanıcı
        public ActionResult List()
        {
            var data = kullaniciDal.GetUsers();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Kullanıcı kullanıcı )
        {
            if(kullaniciDal.InsertUser(kullanıcı))
            {
                TempData["InsertMsg"] = "Kullanıcı kaydedildi.";
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErrorMsg"] = "Kullanıcı kaydedilemedi";
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var data = kullaniciDal.GetUsers().Find(a => a.kullanici_id == id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Kullanıcı kullanıcı)
        {
            if (kullaniciDal.UpdateUser(kullanıcı))
            {
                TempData["UpdateMsg"] = "Kullanıcı guncellendi.";
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
            int r = kullaniciDal.DeleteUser(id);
            if (r > 0)
            {
                TempData["DeleteMsg"] = "Kullanıcı silindi.";
                return RedirectToAction("List");
            }
            else
            {
                TempData["DeleteErrorMsg"] = "Kullanıcı silinemedi";
            }
            return View();
        }
    }
}