#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetCoreWebApp.Models;

namespace AspNetCoreWebApp
{
    public class CreateModel : PageModel
    {
        private readonly AspNetCoreWebApp.Models.m_db1Context _context;

        public CreateModel(AspNetCoreWebApp.Models.m_db1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MT1 MT1 { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //return Page();
            }

            _context.MT1s.Add(MT1);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
