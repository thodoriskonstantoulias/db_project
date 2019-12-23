using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Db_Chart_Proj.Models
{
    public class Labor
    {
        public int Id { get; set; }
        public string Oid { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }


    }
}