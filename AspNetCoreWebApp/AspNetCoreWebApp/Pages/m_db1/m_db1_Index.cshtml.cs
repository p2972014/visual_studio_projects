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
    public class m_db1_Index_Model : PageModel
    {
        private readonly AspNetCoreWebApp.Models.m_db1Context _context;

        public m_db1_Index_Model(AspNetCoreWebApp.Models.m_db1Context context)
        {
            _context = context;
        }

        public IList<MT1> MT1 { get;set; }

        public async Task OnGetAsync()
        {
            MT1 = await _context.MT1s.ToListAsync();
        }
    }
}
