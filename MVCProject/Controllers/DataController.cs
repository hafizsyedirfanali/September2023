﻿using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class DataController : Controller
    {
        /// <summary>
        /// ViewData or ViewBag adds an item in a data dictionary, whose scope encloses the view.
        /// this dictionary item is available within the action and its view only.
        /// 
        /// TempData is a storage to store data temporarily (volatile) in sessions on server.
        /// Once data is red from the variable/key, it is marked for deletion, which is then deleted by GC.
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewDataAction()
        {
            ViewData["WelcomeText"] = "Hello from Irfan Sir. Its cold today";

            return View();
        }
        public IActionResult ViewBagAction()
        {
            ViewBag.WelcomeText = "Hello from Irfan Sir. Its cold today";
            return View();
        }
        public IActionResult ViewBagViewData()
        {
            ViewBag.Name = "Irfan";
            var date = new DateTime(2011, 11, 10, 23, 10, 22);
            var currentDate = DateTime.Now;
            var currentDateM1Yr = DateTime.Now.AddYears(-1);
            ViewData["Date"] = currentDate;
            Teacher teacher = new()
            {
                Id = 1,
                Name = "Irfan"
            };
            ViewBag.Teacher = teacher;
            return View();
        }

        public IActionResult TempDataAction()
        {
            TempData["MyName"] = "Irfan Sir";
            return View();
        }
        public IActionResult TempDataAction1()
        {
            if (TempData.ContainsKey("MyName"))
            {

            }
            return View();
        }
    }
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
