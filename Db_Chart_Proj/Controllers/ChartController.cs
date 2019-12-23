using Db_Chart_Proj.Data;
using Db_Chart_Proj.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Db_Chart_Proj.Controllers
{
    public class ChartController : ApiController
    {
        private readonly SQLCommandRepository repo;
        public ChartController()
        {
            repo = new SQLCommandRepository();
        }
        public IHttpActionResult GetUnemploymentRate(int id)
        {
            try
            {
                var result = repo.GetUnemploymentRateForSelectedCountry(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
