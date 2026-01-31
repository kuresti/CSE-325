using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UrestiMovieMvc.Data;
using System.Linq;

namespace UrestiMovieMvc.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new UrestiMovieMvcContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<UrestiMovieMvcContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return; // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Rating = "PG",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Rating = "PG",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = "NR",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Musci and Lyrics",
                    ReleaseDate = DateTime.Parse("2007-02-14"),
                    Genre = "Romantic Comedy",
                    Rating = "PG-13",
                    Price = 10.99M
                },
                new Movie
                {
                    Title = "Music and Lyrics",
                    ReleaseDate = DateTime.Parse("2007-02-14"),
                    Genre = "Romantic Comedy",
                    Rating = "PG-13",
                    Price = 10.99M
                },
                new Movie
                {
                    Title = "Wicked",
                    ReleaseDate = DateTime.Parse("2024-12-20"),
                    Genre = "Musical",
                    Rating = "PG",
                    Price = 15.99M
                },
                new Movie
                {
                    Title = "Wicked For Good",
                    ReleaseDate = DateTime.Parse("2025-12-20"),
                    Genre = "Musical",
                    Rating = "PG",
                    Price = 16.99M
                },
                new Movie
                {
                    Title = "Song Sung Blue",
                    ReleaseDate = DateTime.Parse("2025-12-25"),
                    Genre = "Musical Drama",
                    Rating = "PG-13",
                    Price = 14.99M
                }

              

            );
            context.SaveChanges();       
        }
    }
}