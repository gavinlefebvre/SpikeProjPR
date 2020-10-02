using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SpikeProjPR.Models
{
    public class Hive
    {
        public int HiveId { get; set; }
        public string HiveName { get; set; }
        public string InspectionResults { get; set; }
        public string Health { get; set; }
        public string HoneyStores { get; set; }
        public string QueenProduction { get; set; }
        public string Equipment { get; set; }
        public string Inventory { get; set; }
        public string Losses { get; set; }
        public string Gains { get; set; }

        public int ApiaryId { get; set; }
        public Apiary Apiary { get; set; }

    }
}