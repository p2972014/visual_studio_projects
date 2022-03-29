#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApp.Models.db1;
using AspNetCoreWebApp.Models.db1.Tables;

namespace AspNetCoreWebApp.Pages.m_db1
{
    public class EditModel : PageModel
    {
        private readonly AspNetCoreWebApp.Models.db1.m_db1Context _context;

        public EditModel(AspNetCoreWebApp.Models.db1.m_db1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public m_t1 m_t1 { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            m_t1 = await _context.m_t1s.FirstOrDefaultAsync(m => m.m_id == id);

            if (m_t1 == null)
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
                return Page();
            }

            _context.Attach(m_t1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!m_t1Exists(m_t1.m_id))
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

        private bool m_t1Exists(long id)
        {
            return _context.m_t1s.Any(e => e.m_id == id);
        }
    }
}
