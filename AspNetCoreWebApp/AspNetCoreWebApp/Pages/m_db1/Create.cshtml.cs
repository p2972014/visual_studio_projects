#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetCoreWebApp.Models.db1;
using AspNetCoreWebApp.Models.db1.Tables;

namespace AspNetCoreWebApp.Pages.m_db1
{
    public class CreateModel : PageModel
    {
        private readonly AspNetCoreWebApp.Models.db1.m_db1Context _context;

        public CreateModel(AspNetCoreWebApp.Models.db1.m_db1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public m_t1 m_t1 { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.m_t1s.Add(m_t1);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
