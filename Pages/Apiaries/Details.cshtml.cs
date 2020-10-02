using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpikeProjPR.Data;
using SpikeProjPR.Models;

namespace SpikeProjPR.Pages.Apiaries
{
    public class DetailsModel : PageModel
    {
        private readonly SpikeProjPR.Data.ApplicationDbContext _context;

        public DetailsModel(SpikeProjPR.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Apiary Apiary { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Apiary = await _context.Apiaries
                .Include(a => a.Beekeeper).FirstOrDefaultAsync(m => m.ApiaryId == id);

            if (Apiary == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
