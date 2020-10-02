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

namespace SpikeProjPR.Pages.Apiaries
{
    public class EditModel : PageModel
    {
        private readonly SpikeProjPR.Data.ApplicationDbContext _context;

        public EditModel(SpikeProjPR.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["BeekeeperId"] = new SelectList(_context.Beekeepers, "BeekeeperId", "BeekeeperId");
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

            _context.Attach(Apiary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApiaryExists(Apiary.ApiaryId))
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

        private bool ApiaryExists(int id)
        {
            return _context.Apiaries.Any(e => e.ApiaryId == id);
        }
    }
}
