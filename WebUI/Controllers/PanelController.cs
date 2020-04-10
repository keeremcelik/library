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
    public class PanelController : Controller
    {
        private IBookRepository bookRepository;
        
        public PanelController(IBookRepository _bookRepo)
        {
            bookRepository = _bookRepo;
        }
        public IActionResult Index()
        {           
            return View();
        }
       
        

    }
}
