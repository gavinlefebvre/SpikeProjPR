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
    public class DetailsModel : PageModel
    {
        private readonly SpikeProjPR.Data.ApplicationDbContext _context;

        public DetailsModel(SpikeProjPR.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Hive Hive { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hive = await _context.Hives
                .Include(h => h.Apiary).FirstOrDefaultAsync(m => m.HiveId == id);

            if (Hive == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
