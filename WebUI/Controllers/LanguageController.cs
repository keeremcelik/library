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
    public class LanguageController : Controller
    {
        private ILanguageRepository languageRepository;
        public LanguageController(ILanguageRepository _languageRepo)
        {
            languageRepository = _languageRepo;
        }
        public IActionResult List()
        {          
          return View(languageRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {         
          return View();
        }
        [HttpPost]
        public IActionResult Create(Entity.Language entity)
        {
            if (ModelState.IsValid)
            {
                languageRepository.SaveLanguage(entity);
                return RedirectToAction("List");
            }
            return View(entity);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {         
          return View(languageRepository.GetById(id));
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int LanguageId)
        {
          languageRepository.DeleteLanguage(LanguageId);
          return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
         
          return View(languageRepository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Entity.Language entity)
        {
          if (ModelState.IsValid)
          {
              languageRepository.SaveLanguage(entity);
              return RedirectToAction("List");
          }
          return View(entity);
        }
        public IActionResult Details(int id)
        {
          
          return View(languageRepository.GetById(id));
        }
    }

}