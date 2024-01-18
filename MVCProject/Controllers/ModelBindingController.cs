﻿global using MVCProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    /// <summary>
    /// Model binding refers to binding a class object or list of object to the view
    /// to achieve this 
    /// 1. create an instance of object (class object / list) and pass it as a parameter/argument to View(object)
    /// 2. write a directive specifying the same model type (type of same object) eg. @model objectType
    /// if StudentClass is passed to View then on view we write @model StudentClass
    /// if List<StudentClass> is passed to the View then on view we write @model List<StudentClass>
    /// Now to get data from the model on view we get from Model (Note it is upper camel case)
    /// </summary>
    public class ModelBindingController : Controller
    {
        /// <summary>
        /// HTML has actions like get, post, put, patch, delete.
        /// for each action we must have Action in Controller
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IActionResult StudentList()
        {
            //on a page/view only one model can be binded. therefore the name model is sufficient
            var model = new List<Student>()
            {
                new Student() { Id = 1, Name = "abcd", Email = "a@a.com", Phone = "111" },
                new Student() { Id = 2, Name = "qqq", Email = "q@a.com", Phone = "222" },
                new Student() { Id = 3, Name = "www", Email = "w@a.com", Phone = "333" },
                new Student() { Id = 4, Name = "eee", Email = "e@a.com", Phone = "444" }
            };
            return View(model);
        }
        
    }    
}