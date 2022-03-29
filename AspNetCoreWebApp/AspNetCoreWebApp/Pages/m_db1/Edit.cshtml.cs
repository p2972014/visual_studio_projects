#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApp.Models;

namespace AspNetCoreWebApp
{
    public class EditModel : PageModel
    {
        private readonly AspNetCoreWebApp.Models.m_db1Context _context;

        public EditModel(AspNetCoreWebApp.Models.m_db1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public MT1 MT1 { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MT1 = await _context.MT1s.FirstOrDefaultAsync(m => m.MId == id);

            if (MT1 == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //return Page();
            }

            _context.Attach(MT1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MT1Exists(MT1.MId))
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

        private bool MT1Exists(long id)
        {
            return _context.MT1s.Any(e => e.MId == id);
        }
    }
}
