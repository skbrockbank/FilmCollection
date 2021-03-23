using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    //Inherit from IFilmCollectionRepository
    public class EFFilmCollectionRepository : IFilmCollectionRepository
    {
        //Create context object
        private FilmCollectionDbContext _context;

        //Constructor
        public EFFilmCollectionRepository(FilmCollectionDbContext context)
        {
            //Store the parameter context into the private context
            _context = context;
        }

        //Set the movies to the list of movies
        public IQueryable<Movie> Movies => _context.Movies;

        //Methods for CRUD
        public void CreateMovie(Movie m)
        {
            _context.Add(m);
            _context.SaveChanges();
        }
        public void DeleteMovie(Movie m)
        {
            _context.Remove(m);
            _context.SaveChanges();
        }
        public void SaveMovie(Movie m)
        {
            _context.SaveChanges();
        }
    }
}
