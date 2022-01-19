#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApp.Models;

namespace AspNetCoreWebApp
{
    public class DetailsModel : PageModel
    {
        private readonly AspNetCoreWebApp.Models.m_db1Context _context;

        public DetailsModel(AspNetCoreWebApp.Models.m_db1Context context)
        {
            _context = context;
        }

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
    }
}
