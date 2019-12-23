using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Db_Chart_Proj.Controllers
{
    public class HomeController : Controller
    {
        List<SelectListItem> countries = new List<SelectListItem>();
        public ActionResult Index()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetAllCountries",con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    countries.Add(new SelectListItem { Text = reader[1].ToString(), Value = reader[0].ToString() });
                }
            }
            return View(countries);
        }

        public ActionResult About()
        {
           return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}