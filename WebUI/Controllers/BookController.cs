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
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository bookRepository;
        private ITypeRepository typeRepository;
        private IAuthorRepository authorRepository;
        private IPublisherRepository publisherRepository;
        private ILanguageRepository languageRepository;
        public BookController(ILanguageRepository _languageRepo,IPublisherRepository _publisherRepo, IBookRepository _bookRepo,ITypeRepository _typeRepo,IAuthorRepository _authRepo)
        {
            bookRepository = _bookRepo;
            typeRepository = _typeRepo;
            authorRepository= _authRepo;
            publisherRepository = _publisherRepo;
            languageRepository = _languageRepo;
        }
        public IActionResult AddFavorite(int id)
        {
          var book = bookRepository.GetById(id);
          bookRepository.AddFav(book);
          TempData["successmessage"] = $" \"{book.Name}\" added favorite list.";
          return RedirectToAction("Details", new {@id=id});
        }
        public IActionResult RemoveFavorite(int id)
        {
           var book = bookRepository.GetById(id);
          bookRepository.RemoveFav(book);
          TempData["failmessage"] = $"\"{book.Name}\" removed favorite list.";
          return RedirectToAction("Details", new {@id=id});
        }
       
        public IActionResult List()
        {
             BookModel model = new BookModel();
                model.BookList = bookRepository.GetAll().ToList();         
                model.AuthorList = authorRepository.GetAll().ToList();
                model.TypeList = typeRepository.GetAll().ToList();
          return View(model);
        }
        public IActionResult Index(int? id,string q)
        {
            var query = bookRepository.GetAll()
                .Where(i => i.isApproved);
            if (id != null)
            {
                query = query.Where(i => i.TypeId==id);
             
                
            } 
            if (!string.IsNullOrEmpty(q))
            {
              var aid=0;
             var aut = authorRepository.GetAll().Where(i => EF.Functions.Like(i.Name,"%"+q+"%") || EF.Functions.Like(i.Surname,"%"+q+"%")).ToList();
             foreach (var item in aut)
             {
                 aid = item.Id;
             }
              
                query = query.Where( i =>
                  EF.Functions.Like(i.Name,"%"+q+"%") ||
                  i.AuthorId == aid
                );
            } 
             
          return View(query);
        }

        public void pullSelect()
        {
             var author = authorRepository.GetAll()
                .Where(x => x.isApproved)
                .Select(x => new
                {
                    selectname =x.Id,
                    fullname = x.Name+" "+x.Surname
                });
            ViewBag.Types = new SelectList(typeRepository.GetAll(),"TypeId","Name");
            ViewBag.Authors = new SelectList(author,"selectname", "fullname");
            ViewBag.Publisher = new SelectList(publisherRepository.GetAll(),"PublisherId","Name");
            ViewBag.Language = new SelectList(languageRepository.GetAll(),"LanguageId","Name");
        }
      
        [HttpGet]
        public IActionResult Create()
        {
           pullSelect();
          return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book entity,IFormFile file)
        {
          
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\img",file.FileName);
                    using (var stream = new FileStream(path,FileMode.Create))
                    {
                      await file.CopyToAsync(stream);			
                      entity.Image=file.FileName;
                    }
                }
                bookRepository.SaveBook(entity);
                return RedirectToAction("List");
            }
            pullSelect();
          return View(entity);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {         
          return View(bookRepository.GetById(id));
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int BookId)
        {
        bookRepository.DeleteBook(BookId);
          return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
          pullSelect();
          return View(bookRepository.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Book entity,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {					
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\img",file.FileName);

                    using (var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);			
                        entity.Image=file.FileName;
                    }
                }
                bookRepository.SaveBook(entity);
                return RedirectToAction("List");
            }
            pullSelect();
            return View(entity);
        }
        public IActionResult Details(int id)
        {
          dynamic model = new ExpandoObject();
                model.BookList = bookRepository.GetById(id);         
                model.AuthorList = authorRepository.GetById(model.BookList.AuthorId);
                model.TypeList = typeRepository.GetById(model.BookList.TypeId);
                model.PublisherList = publisherRepository.GetById(model.BookList.PublisherId);
                model.LanguageList = languageRepository.GetById(model.BookList.LanguageId);
          return View(model);
        }

        public IActionResult MarkRead(int id)
        {
          var book = bookRepository.GetById(id);
          bookRepository.MarkRead(book);
          TempData["successmessage"] = $" \"{book.Name}\" marked as read.";
          return RedirectToAction("Details", new {@id=id});
        }
        public IActionResult MarkUnread(int id)
        {
           var book = bookRepository.GetById(id);
          bookRepository.MarkUnread(book);
          TempData["failmessage"] = $"\"{book.Name}\" marked unread.";
            return RedirectToAction("Details", new {@id=id});
        }
       
    }

}