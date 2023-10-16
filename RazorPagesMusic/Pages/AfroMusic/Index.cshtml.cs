using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMusic.Models;
using RazorPagesMusic.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Titles { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MusicTitle { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> titleQuery = from m in _context.AfroMusic
                                            orderby m.Artist
                                            select m.Artist;

            var musics = from m in _context.AfroMusic
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                musics = musics.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MusicTitle))
            {
                musics = musics.Where(x => x.Artist == MusicTitle);
            }
            Titles = new SelectList(await titleQuery.Distinct().ToListAsync());
            AfroMusic = await musics.ToListAsync();
        }
    }
}
