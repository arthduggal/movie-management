using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieManagementAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagementAPI.DBContext
{
    public class MovieDBContext : IdentityDbContext<IdentityUser>
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
