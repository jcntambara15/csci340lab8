using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Models;
using RazorPagesMusic.Data;

namespace RazorPagesMusic.Pages.AfroMusic
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMusic.Data.RazorPagesMusicContext _context;

        public CreateModel(RazorPagesMusic.Data.RazorPagesMusicContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Music AfroMusic { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.AfroMusic == null || AfroMusic == null)
            {
                return Page();
            }

            _context.AfroMusic.Add(AfroMusic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
