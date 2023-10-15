using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using RazorPagesMusic.Data;

namespace RazorPagesMusic.Pages.AfroMusic
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMusic.Data.RazorPagesMusicContext _context;

        public DeleteModel(RazorPagesMusic.Data.RazorPagesMusicContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AfroMusic == null)
            {
                return NotFound();
            }
            var afromusic = await _context.AfroMusic.FindAsync(id);

            if (afromusic != null)
            {
                AfroMusic = afromusic;
                _context.AfroMusic.Remove(AfroMusic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
