using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMusic.Models;

namespace RazorPagesMusic.Data
{
    public class RazorPagesMusicContext : DbContext
    {
        public RazorPagesMusicContext (DbContextOptions<RazorPagesMusicContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMusic.Models.Music> AfroMusic { get; set; } = default!;
    }
}
