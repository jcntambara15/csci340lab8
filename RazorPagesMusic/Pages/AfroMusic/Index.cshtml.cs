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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMusic.Data.RazorPagesMusicContext _context;

        public IndexModel(RazorPagesMusic.Data.RazorPagesMusicContext context)
        {
            _context = context;
        }

        public IList<Music> AfroMusic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AfroMusic != null)
            {
                AfroMusic = await _context.AfroMusic.ToListAsync();
            }
        }
    }
}
