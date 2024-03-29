﻿using BigSchool_2011060950_PhanNgocSon_20DTHB3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BigSchool_2011060950_PhanNgocSon_20DTHB3.ViewModels;

namespace BigSchool_2011060950_PhanNgocSon_20DTHB3.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcomingCourses = _dbContext.Courses
               .Include(c => c.Lecturer)
               .Include(c => c.Category)
               .Where(c => c.DateTime > DateTime.Now);
            var viewModel = new CoursesViewModel{
                UpcomingCourses = upcomingCourses,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}