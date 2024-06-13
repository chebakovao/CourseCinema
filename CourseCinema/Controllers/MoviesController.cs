using Microsoft.AspNetCore.Mvc;
using CourseCinema.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CourseCinema.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Reviews).ToList();
            foreach (var movie in movies)
            {
                movie.Rating = movie.Reviews.Count > 0 ? movie.Reviews.Average(r => r.Rating) : 0;
            }
            return View(movies);
        }


        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _context.Movies
                .Include(m => m.Reviews)
                .FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddReview(int movieId, Review review)
        {
            if (ModelState.IsValid)
            {
                var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
                if (movie == null)
                {
                    return NotFound();
                }

                movie.Reviews.Add(review);
                _context.SaveChanges();
                return RedirectToAction(nameof(Details), new { id = movieId });
            }
            return View(review);
        }

    }
}
