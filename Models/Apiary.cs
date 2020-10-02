using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SpikeProjPR.Models
{
    public class Apiary
    {
        public int ApiaryId { get; set; }
        public string ApiaryName { get; set; }
        public List<Hive> Hives { get; } = new List<Hive>();

        public int BeekeeperId { get; set; }
        public Beekeeper Beekeeper { get; set; }
    }
}