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
                //_repository.Movies.Add(newMovie);
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
    }
}
