
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BakkalWebSiteVt2.DataBase_Dal;
using BakkalWebSiteVt2.Models;

namespace Bakkal.Controllers
{
    public class CategoryController : Controller
    {

        CategoryDal categoryDal = new CategoryDal();
        // GET: Kullanıcı
        public ActionResult List()
        {
            var data = categoryDal.GetCategories();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (categoryDal.InsertCategory(category))
            {
                TempData["InsertMsg"] = "Kategori kaydedildi.";
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErrorMsg"] = "Kategori kaydedilemedi";
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var data = categoryDal.GetCategories().Find(a => a.kategori_id == id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (categoryDal.UpdateCategory(category))
            {
                TempData["UpdateMsg"] = "Kategori guncellendi.";
                return RedirectToAction("List");
            }
            else
            {
                TempData["UpdateErrorMsg"] = "Kategori guncellenemedi";
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            int r = categoryDal.DeleteUser(id);
            if (r > 0)
            {
                TempData["DeleteMsg"] = "Kategori silindi.";
                return RedirectToAction("List");
            }
            else
            {
                TempData["DeleteErrorMsg"] = "Kategori silinemedi";
            }
            return View();
        }


    }
}