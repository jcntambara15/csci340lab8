using Microsoft.EntityFrameworkCore;
using RazorPagesMusic.Data;

namespace RazorPagesMusic.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesMusicContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesMusicContext>>()))
        {
            if (context == null || context.AfroMusic == null)
            {
                throw new ArgumentNullException("Null RazorPagesMusicContext");
            }

            // Look for anysMusics.
            if (context.AfroMusic.Any())
            {
                return;   // DB has been seeded
            }

            context.AfroMusic.AddRange(
                new Music
                {
                    Title = "Calm Down",
                    Artist = "Rema",
                    Genre = "Afro Beat",
                    Country = "Nigeria",
                    ReleaseDate = DateTime.Parse("2022-2-10")
                },

                new Music
                {
                    Title = "Rush",
                    Artist = "Ayra Starr",
                    Genre = "Afro Beat",
                    Country = "Nigeria",
                    ReleaseDate = DateTime.Parse("2022-09-26")
                },

                new Music
                {
                    Title = "Unavailable",
                    Artist = "Davido ft. Musa Keys",
                    Genre = "Afro Beat",
                    Country = "Nigeria",
                    ReleaseDate = DateTime.Parse("2023-03-30")
                },

                new Music
                {
                    Title = "Calm Down",
                    Artist = "Rema",
                    Genre = "Afro Beat",
                    Country = "Nigeria",
                    ReleaseDate = DateTime.Parse("2022-2-10")
                },

                 new Music
                {
                    Title = "love nwantiti",
                    Artist = "CKay",
                    Genre = "Afro Beat",
                    Country = "Nigeria",
                    ReleaseDate = DateTime.Parse("2020-2-14")
                }
            );
            context.SaveChanges();
        }
    }
}