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
    public class DetailsModel : PageModel
    {
        private readonly SpikeProjPR.Data.ApplicationDbContext _context;

        public DetailsModel(SpikeProjPR.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Beekeeper Beekeeper { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Beekeeper = await _context.Beekeepers.FirstOrDefaultAsync(m => m.BeekeeperId == id);

            if (Beekeeper == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
