using FilmCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FilmCollection.Models.ViewModels;

namespace FilmCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        //Add the repository
        private IFilmCollectionRepository _repository;

        public HomeController(ILogger<HomeController> logger, IFilmCollectionRepository repository)
        {
            _logger = logger;

        //Set the private repository equal to the repository passed in
        _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateMovie(newMovie);
                return View("Confirmation", newMovie);
            }
            else
            {
                return View();
            }
        }

        public IActionResult MyMovies()
        {
            //Pass the list of movies into the view
            return View(_repository.Movies);
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Update(int id)
        {
            //Pass the movie that needs updating into the view
            Movie movie = _repository.Movies.Where(x => x.MovieID == id).FirstOrDefault();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Update(Movie movie, int id)
        {
            //Update each attribute
            _repository.Movies.Where(x => x.MovieID == id).FirstOrDefault().Category = movie.Category;
            _repository.Movies.Where(x => x.MovieID == id).FirstOrDefault().Title = movie.Title;
            _repository.Movies.Where(x => x.MovieID == id).FirstOrDefault().Year = movie.Year;
            _repository.Movies.Where(x => x.MovieID == id).FirstOrDefault().Director = movie.Director;
            _repository.Movies.Where(x => x.MovieID == id).FirstOrDefault().Rating = movie.Rating;
            _repository.Movies.Where(x => x.MovieID == id).FirstOrDefault().Edited = movie.Edited;
            _repository.Movies.Where(x => x.MovieID == id).FirstOrDefault().LentTo = movie.LentTo;
            _repository.Movies.Where(x => x.MovieID == id).FirstOrDefault().Notes = movie.Notes;

            //Save the changes
            _repository.SaveMovie(movie);

            //Send back to my movies page
            return RedirectToAction("MyMovies");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Movie movie = _repository.Movies.Where(x => x.MovieID == id).FirstOrDefault();
            _repository.DeleteMovie(movie);
            return RedirectToAction("MyMovies");
        }
    }
}
