﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie(){ Name = "Shrek2!" };
            
            return View(movie);B
            // return Json(new { name = "Shrek3!", Id=9999 }, JsonRequestBehavior.AllowGet);
        }
    }
}