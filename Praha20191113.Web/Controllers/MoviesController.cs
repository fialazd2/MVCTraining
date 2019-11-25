using Praha20191113.Web.Models;
using Praha20191113.Web.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Praha20191113.Web.Controllers
{
    public class MoviesController : BaseController
    {
        public MoviesController(ILogger logger, ApplicationDbContext context) : base(logger, context)
        {
        }

        public ActionResult Details(int id)
        {
            var dbMovieToShowDetail = Db.Movies.Find(id);
            if (dbMovieToShowDetail == null)
            {
                throw new Exception("Cannot find movie to edit");
            }

            var movieViewModelToShowDetail = new MoviesViewModel()
            {
                Id = dbMovieToShowDetail.Id,
                Title = dbMovieToShowDetail.Title,
                Genre = dbMovieToShowDetail.Genre,
                ReleasedDate = dbMovieToShowDetail.ReleasedDate,
            };

            return View(movieViewModelToShowDetail);
        }

        public ActionResult Index()
        {
            var movies = Db.Movies.ToList();

            var viewModels = movies.Select(movie => new MoviesViewModel()
            {
                Id = movie.Id,
                Genre = movie.Genre,
                ReleasedDate = movie.ReleasedDate,
                Title = movie.Title,
                Director = movie.Director,
                Language = movie?.Language?.Name
            });

            return View(viewModels.ToList());
        }

        public ActionResult Released(string year, string month)
        {
            var parsedDateTime = DateTime.Parse($"{year}/{month}");

            var filteredMovies = Db.Movies.Where(movie => movie.ReleasedDate >= parsedDateTime);

            var filteredMoviesViewModel = filteredMovies.Select(dbMovie => new MoviesViewModel()
            {
                Id = dbMovie.Id,
                Genre = dbMovie.Genre,
                ReleasedDate = dbMovie.ReleasedDate,
                Title = dbMovie.Title,
                Director = dbMovie.Director,
            });

            Db.SaveChanges();

            return View(filteredMoviesViewModel.ToList());
        }


        [Authorize]
        public ActionResult Create()
        {
            return View(new MoviesViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(MoviesViewModel movieToCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(movieToCreate);
            }

            Db.Movies.Add(new Movie()
            {
                Genre = movieToCreate.Genre,
                Title = movieToCreate.Title,
                ReleasedDate = movieToCreate.ReleasedDate,
                Director = movieToCreate.Director,
            });

            Db.SaveChanges();
            TempData["Message"] = "Movie was successfully created";
            return this.RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var dbMovieToEdit = Db.Movies.SingleOrDefault(movie => movie.Id == id);
            if (dbMovieToEdit == null)
            {
                throw new Exception("Cannot find movie to edit");
            }

            var movieViewModelToEdit = new MoviesViewModel()
            {
                Id = dbMovieToEdit.Id,
                Title = dbMovieToEdit.Title,
                Genre = dbMovieToEdit.Genre,
                ReleasedDate = dbMovieToEdit.ReleasedDate,
                Director = dbMovieToEdit.Director
            };

            return View(movieViewModelToEdit);
        }

        [HttpPost]
        public ActionResult Edit(MoviesViewModel movieViewModelToEdit)
        {
            if (!ModelState.IsValid)
            {
                return View(movieViewModelToEdit);
            }

            var dbMovieToEdit = Db.Movies.Find(movieViewModelToEdit.Id);
            if (dbMovieToEdit == null)
            {
                throw new Exception("Cannot find movie in database");
            }

            dbMovieToEdit.Genre = movieViewModelToEdit.Genre;
            dbMovieToEdit.ReleasedDate = movieViewModelToEdit.ReleasedDate;
            dbMovieToEdit.Title = movieViewModelToEdit.Title;
            dbMovieToEdit.Director = movieViewModelToEdit.Director;
            Db.SaveChanges();

            return View(movieViewModelToEdit);
        }

        public ActionResult Delete(int id)
        {
            var dbMovieToDelete = Db.Movies.Find(id);
            if (dbMovieToDelete == null)
            {
                throw new Exception("Cannot find movie to delete");
            }

            var movieViewModelToDelete = new MoviesViewModel()
            {
                Id = dbMovieToDelete.Id,
                Title = dbMovieToDelete.Title,
                Genre = dbMovieToDelete.Genre,
                ReleasedDate = dbMovieToDelete.ReleasedDate,
                Director = dbMovieToDelete.Director,
            };

            return View(movieViewModelToDelete);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(MoviesViewModel moviesViewModel)
        {
            var dbMovieToDelete = Db.Movies.Find(moviesViewModel.Id);

            Db.Movies.Remove(dbMovieToDelete);

            Db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}