using Db_Chart_Proj.Data;
using System;
using System.Web.Http;

namespace Db_Chart_Proj.Controllers
{
    public class MobTelUsageController : ApiController
    {
        private readonly SQLCommandRepository repo;
        public MobTelUsageController()
        {
            repo = new SQLCommandRepository();
        }
        public IHttpActionResult GetMobileLandlineUsage(int id)
        {
            try
            {
                var result = repo.GetMobileVsLandlineUsageForSelectedCountry(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
