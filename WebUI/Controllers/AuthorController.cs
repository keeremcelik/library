using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using kutuphane.Data.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorRepository authorRepository;
        private IBookRepository bookRepository;
        private ITypeRepository typeRepository;
        public AuthorController(IAuthorRepository _authRepo,IBookRepository _bookRepo,ITypeRepository _typeRepo)
        {
            authorRepository = _authRepo;
            bookRepository = _bookRepo;
            typeRepository = _typeRepo;
        }
        public IActionResult List()
        {          
          return View(authorRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {         
          return View();
        }
        [HttpPost]
        public IActionResult Create(Author entity)
        {
            if (ModelState.IsValid)
            {
                authorRepository.SaveAuthor(entity);
                return RedirectToAction("List");
            }
            return View(entity);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {         
          return View(authorRepository.GetById(id));
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int AuthorId)
        {
          authorRepository.DeleteAuthor(AuthorId);
          return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
         
          return View(authorRepository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Author entity)
        {
          if (ModelState.IsValid)
          {
              authorRepository.SaveAuthor(entity);
              return RedirectToAction("List");
          }
          return View(entity);
        }
        
        public IActionResult Details(int id)
        {         
          return View(authorRepository.GetById(id));
       
        }
    }

}