using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrestiMovieMvc.Models;

namespace UrestiMovieMvc.Data
{
    public class UrestiMovieMvcContext : DbContext
    {
        public UrestiMovieMvcContext (DbContextOptions<UrestiMovieMvcContext> options)
            : base(options)
        {
        }

        public DbSet<UrestiMovieMvc.Models.Movie> Movie { get; set; } = default!;
    }
}
