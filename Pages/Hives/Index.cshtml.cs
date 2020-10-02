using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpikeProjPR.Data;
using SpikeProjPR.Models;

namespace SpikeProjPR.Pages.Hives
{
    public class IndexModel : PageModel
    {
        private readonly SpikeProjPR.Data.ApplicationDbContext _context;

        public IndexModel(SpikeProjPR.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Hive> Hive { get;set; }

        public async Task OnGetAsync()
        {
            Hive = await _context.Hives
                .Include(h => h.Apiary).ToListAsync();
        }
    }
}
