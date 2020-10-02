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

namespace SpikeProjPR.Pages.Beekeepers
{
    public class EditModel : PageModel
    {
        private readonly SpikeProjPR.Data.ApplicationDbContext _context;

        public EditModel(SpikeProjPR.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Beekeeper).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeekeeperExists(Beekeeper.BeekeeperId))
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

        private bool BeekeeperExists(int id)
        {
            return _context.Beekeepers.Any(e => e.BeekeeperId == id);
        }
    }
}
