using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakkalWebSiteVt2.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace Bakkal.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Login login)
        {
            String mainconn = ConfigurationManager.ConnectionStrings["BakkalDb"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            SqlCommand sqlcomm = new SqlCommand("[dbo].[UserLogin]");
            sqlconn.Open();
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.Parameters.AddWithValue("@k_eposta", login.k_eposta);
            sqlcomm.Parameters.AddWithValue("@k_parola", login.k_parola);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            if(sdr.Read())
            {
                FormsAuthentication.SetAuthCookie(login.k_eposta, true);
                Session["k_eposta"] = login.k_eposta.ToString();
                return RedirectToAction("Welcome");
            }
            else
            {
                ViewData["Message"] = "Giriş Başarısız";
            }
            sqlconn.Close();
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }


    }

}
