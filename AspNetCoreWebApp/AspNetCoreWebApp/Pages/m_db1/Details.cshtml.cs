#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApp.Models.db1;
using AspNetCoreWebApp.Models.db1.Tables;

namespace AspNetCoreWebApp.Pages.m_db1
{
    public class DetailsModel : PageModel
    {
        private readonly AspNetCoreWebApp.Models.db1.m_db1Context _context;

        public DetailsModel(AspNetCoreWebApp.Models.db1.m_db1Context context)
        {
            _context = context;
        }

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
    }
}
