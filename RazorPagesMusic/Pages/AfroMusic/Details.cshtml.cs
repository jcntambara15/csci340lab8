using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMusic.Models;
using RazorPagesMusic.Data;

namespace RazorPagesMusic.Pages.AfroMusic
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMusic.Data.RazorPagesMusicContext _context;

        public DetailsModel(RazorPagesMusic.Data.RazorPagesMusicContext context)
        {
            _context = context;
        }

      public Music AfroMusic { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AfroMusic == null)
            {
                return NotFound();
            }

            var afromusic = await _context.AfroMusic.FirstOrDefaultAsync(m => m.Id == id);
            if (afromusic == null)
            {
                return NotFound();
            }
            else 
            {
                AfroMusic = afromusic;
            }
            return Page();
        }
    }
}
