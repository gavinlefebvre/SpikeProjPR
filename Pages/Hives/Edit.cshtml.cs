using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpikeProjPR.Data;
using SpikeProjPR.Models;

namespace SpikeProjPR.Pages.Hives
{
    public class EditModel : PageModel
    {
        private readonly SpikeProjPR.Data.ApplicationDbContext _context;

        public EditModel(SpikeProjPR.Data.ApplicationDbContext context)
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
           ViewData["ApiaryId"] = new SelectList(_context.Apiaries, "ApiaryId", "ApiaryId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Hive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiveExists(Hive.HiveId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HiveExists(int id)
        {
            return _context.Hives.Any(e => e.HiveId == id);
        }
    }
}
