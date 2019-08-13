using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek2!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer1"},
                new Customer { Name = "Customer2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);
            // return Json(new { name = "Shrek3!", Id=9999 }, JsonRequestBehavior.AllowGet);
    }

        [Route("movies/output/{year:regex(\\d{4})}")]
        public ActionResult Output(int year)
        {
            return Content("This would be the output if it worked.. Maybe in year "+ year.ToString());
        }
    }
}