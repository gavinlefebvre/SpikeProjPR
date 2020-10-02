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
    public class DeleteModel : PageModel
    {
        private readonly SpikeProjPR.Data.ApplicationDbContext _context;

        public DeleteModel(SpikeProjPR.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hive = await _context.Hives.FindAsync(id);

            if (Hive != null)
            {
                _context.Hives.Remove(Hive);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
