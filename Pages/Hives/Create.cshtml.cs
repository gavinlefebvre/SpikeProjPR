using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpikeProjPR.Data;
using SpikeProjPR.Models;

namespace SpikeProjPR.Pages.Hives
{
    public class CreateModel : PageModel
    {
        private readonly SpikeProjPR.Data.ApplicationDbContext _context;

        public CreateModel(SpikeProjPR.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ApiaryId"] = new SelectList(_context.Apiaries, "ApiaryId", "ApiaryId");
            return Page();
        }

        [BindProperty]
        public Hive Hive { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Hives.Add(Hive);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
