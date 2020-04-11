using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using kutuphane.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepository;
        private IBookRepository bookRepository;
        private ITypeRepository typeRepository;
        public UserController(IUserRepository _userRepo,IBookRepository _bookRepo,ITypeRepository _typeRepo)
        {
            userRepository = _userRepo;
            bookRepository = _bookRepo;
            typeRepository = _typeRepo;
        }
        public IActionResult Index()
        {
            return View(userRepository.GetAll());
        }

        public IActionResult Read()
        {
            
          return View(bookRepository.GetAll().Where(i => !i.isReaded));
        }

        public IActionResult Unread()
        {
          return View(bookRepository.GetAll().Where(i => i.isReaded));
        }
        public IActionResult Favorites()
        {
        
          return View(bookRepository.GetAll().Where(i => i.isFavorite));
        }

      
    }
}
