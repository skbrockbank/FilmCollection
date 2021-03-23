using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class FilmCollectionDbContext : DbContext
    {
        //Context constructor
        public FilmCollectionDbContext(DbContextOptions<FilmCollectionDbContext> options) : base(options)
        {

        }

        //Set of movies
        public DbSet<Movie> Movies { get; set; }
    }
}
