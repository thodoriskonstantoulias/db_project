using Db_Chart_Proj.Data;
using System;
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
