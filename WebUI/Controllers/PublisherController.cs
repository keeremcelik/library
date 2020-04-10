using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class PublisherController : Controller
    {
        private IPublisherRepository publisherRepository;
        public PublisherController(IPublisherRepository _publisherRepo)
        {
            publisherRepository = _publisherRepo;
        }
        public IActionResult List()
        {          
          return View(publisherRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {         
          return View();
        }
        [HttpPost]
        public IActionResult Create(Entity.Publisher entity)
        {
            if (ModelState.IsValid)
            {
                publisherRepository.SavePublisher(entity);
                return RedirectToAction("List");
            }
            return View(entity);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {         
          return View(publisherRepository.GetById(id));
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int PublisherId)
        {
          publisherRepository.DeletePublisher(PublisherId);
          return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
         
          return View(publisherRepository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Entity.Publisher entity)
        {
          if (ModelState.IsValid)
          {
              publisherRepository.SavePublisher(entity);
              return RedirectToAction("List");
          }
          return View(entity);
        }
        public IActionResult Details(int id)
        {
          
          return View(publisherRepository.GetById(id));
        }
    }

}