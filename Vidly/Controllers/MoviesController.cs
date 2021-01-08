using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
  public class MoviesController : Controller
  {
    private ApplicationDbContext _context;

	public MoviesController()
	{
      _context = new ApplicationDbContext();
	}

	protected override void Dispose(bool disposing)
	{
      _context.Dispose();
	}

	// GET: Movies
	public ActionResult Random()
    {
      Movie movie = new Movie()
      {
        Name = "Shrek"
      };
      List<Customer> customers = new List<Customer>
      {
        new Customer { Name = "Customer 1" },
        new Customer { Name = "Customer 2" }
      };

      var viewModel = new RandomMovieViewModel
      {
        Movie = movie,
        Customers = customers
      };

	  return View(viewModel);
	  //return Content("Hello World!");
	  //return HttpNotFound();
	  //return new EmptyResult();
	  //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
	  //ViewData["Movie"] = movie;
	  //ViewBag.Movie = movie;
	  //return View();
	}

    //public ActionResult Edit(int id)
    //{
    //  return Content("id=" + id);
    //}

    /* public ActionResult Index(int? pageIndex, string sortBy)
     {
       if (!pageIndex.HasValue)
       {
         pageIndex = 1;
       }

       if (String.IsNullOrWhiteSpace(sortBy))
       {
         sortBy = "Name";
       }

       return Content(String.Format("pageIndex = {0} & sortBy = {1}", pageIndex, sortBy));
     }*/

    public ActionResult Index()
    {
      //var movies = GetMovies();
      var movies = _context.Movies.Include(m => m.Genre).ToList();
      return View(movies);
    }

	public ActionResult Details(int id) {
      var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
      if (movie == null)
      {
        return HttpNotFound();
      }
      return View(movie);
    }

    public ActionResult New()
    {
      var genres = _context.Genres.ToList();
      var viewModel = new MovieFormViewModel
      {
        Genres = genres
      };
      return View("MovieForm", viewModel);
    }

    public ActionResult Edit(int id) 
    {
      var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
      if (movie == null)
      {
        HttpNotFound();
      }

      var viewModel = new MovieFormViewModel
      {
        Movie = movie,
        Genres = _context.Genres.ToList()
      };

      return View("MovieForm", viewModel);
    }

	private IEnumerable<Movie> GetMovies() {
      return new List<Movie>
      {
        new Movie { Id = 1, Name = "Shrek"},
        new Movie { Id = 2, Name = "Wall-E"}
      };
    }

    [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
    public ActionResult ByReleaseDate(int year, byte month)
    {

      return Content("year="+year+"&month="+month);
    }
  }
}