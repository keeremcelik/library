using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using kutuphane.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository bookRepository;
        
        public HomeController(IBookRepository _bookRepo)
        {
            bookRepository = _bookRepo;
        }
        public IActionResult Index()
        {
            HomeModel model = new HomeModel();
                model.HomeBook = bookRepository.GetAll().ToList();
                model.SliderBook = bookRepository.GetAll().ToList();
            return View(model);
        }

        

    }
}
