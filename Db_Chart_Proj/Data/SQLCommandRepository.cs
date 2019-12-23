using Db_Chart_Proj.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Db_Chart_Proj.Data
{
    public class SQLCommandRepository
    {
        private readonly List<Labor> laborList;
        private readonly List<MobLandUsage> usageList;
        private string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public SQLCommandRepository()
        {
            laborList = new List<Labor>();
            usageList = new List<MobLandUsage>();
        }

        public List<Labor> GetUnemploymentRateForSelectedCountry(int id)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetUnemplRate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CountryId", id));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    laborList.Add(new Labor
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Oid = reader[1].ToString(),
                        Year = Convert.ToInt32(reader[2]),
                        Description = reader[3].ToString(),
                        Value = float.Parse(reader[4].ToString(), CultureInfo.InvariantCulture.NumberFormat)
                    });
                }
            }
            return laborList;
        }

        public List<MobLandUsage> GetMobileVsLandlineUsageForSelectedCountry(int id)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetMobileAndLandlineUsage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CountryId", id));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usageList.Add(new MobLandUsage
                    {
                        Year = Convert.ToInt32(reader[0]),
                        MobileValue = float.Parse(reader[1].ToString(), CultureInfo.InvariantCulture.NumberFormat),
                        LandlineValue = float.Parse(reader[2].ToString(), CultureInfo.InvariantCulture.NumberFormat)
                    });
                }
            }
            return usageList;
        }
    }
}