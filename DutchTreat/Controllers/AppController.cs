﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly INullMailService mailService;
        private readonly DutchContext context;

        public AppController(INullMailService mailService, DutchContext context)
        {
            this.mailService = mailService;
            this.context = context;
        }
        public IActionResult Index()
        {
            var results = context.Products.ToList();
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {           
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                mailService.SendMessage("xxx@gmail.com", model.Subject, model.Message);
                ViewBag.UserMessage = "Mail sent";
                ModelState.Clear();
            }
            else
            {

            }

            return View();
        }
        public IActionResult About()
        {          
            return View();
        }

        public IActionResult Shop()
        {
            var results = context.Products.OrderBy(p =>p.Category)
                .ToList();
            return View(results);
        }
    }
}