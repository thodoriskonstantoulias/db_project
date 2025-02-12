﻿using Db_Chart_Proj.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Db_Chart_Proj.Data
{
    public class SQLCommandRepository
    {
        private readonly List<Labor> laborList;
        private readonly List<MobLandUsage> usageList;
        private readonly List<SelectListItem> countries;
        private string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public SQLCommandRepository()
        {
            laborList = new List<Labor>();
            usageList = new List<MobLandUsage>();
            countries = new List<SelectListItem>();
        }

        public IEnumerable<Labor> GetUnemploymentRateForSelectedCountry(int id)
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
                        Value = float.Parse(reader[4].ToString())
                    });
                }
            }
            return laborList;
        }

        public IEnumerable<MobLandUsage> GetMobileVsLandlineUsageForSelectedCountry(int id)
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
                        MobileValue = float.Parse(reader[1].ToString()),
                        LandlineValue = float.Parse(reader[2].ToString())
                    });
                }
            }
            return usageList;
        }

        public IEnumerable<SelectListItem> GetAllCountries() 
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetAllCountries", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    countries.Add(new SelectListItem { Text = reader[1].ToString(), Value = reader[0].ToString() });
                }
            }
            return countries;
        }
    }
}