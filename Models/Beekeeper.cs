using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SpikeProjPR.Models
{
    public class Beekeeper
    {
        public int BeekeeperId { get; set; }
        public string BeekeeperName { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public string ApiaryAddress { get; set; }
        public string ContactInfo { get; set; }

        public List<Apiary> Apiaries { get; } = new List<Apiary>();
    }
}