using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpikeProjPR.Data;
using SpikeProjPR.Models;

namespace SpikeProjPR.Pages.Beekeepers
{
    public class IndexModel : PageModel
    {
        private readonly SpikeProjPR.Data.ApplicationDbContext _context;

        public IndexModel(SpikeProjPR.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Beekeeper> Beekeeper { get;set; }

        public async Task OnGetAsync()
        {
            Beekeeper = await _context.Beekeepers.ToListAsync();
        }
    }
}
