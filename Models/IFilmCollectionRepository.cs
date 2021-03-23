using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public interface IFilmCollectionRepository
    {
        //Create a place for information to be queried from
        IQueryable<Movie> Movies { get; }

        //Methods for CRUD
        void SaveMovie(Movie m);
        void CreateMovie(Movie m);
        void DeleteMovie(Movie m);

    }
}
