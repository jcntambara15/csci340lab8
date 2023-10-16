using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMusic.Models;
using RazorPagesMusic.Data;

namespace RazorPagesMusic.Pages.AfroMusic
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMusic.Data.RazorPagesMusicContext _context;

        public EditModel(RazorPagesMusic.Data.RazorPagesMusicContext context)
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

            var afromusic =  await _context.AfroMusic.FirstOrDefaultAsync(m => m.Id == id);
            if (afromusic == null)
            {
                return NotFound();
            }
            AfroMusic = afromusic;
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

            _context.Attach(AfroMusic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AfroMusicExists(AfroMusic.Id))
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

        private bool AfroMusicExists(int id)
        {
          return (_context.AfroMusic?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
