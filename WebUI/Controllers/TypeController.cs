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
    public class TypeController : Controller
    {
        private ITypeRepository typeRepository;
        public TypeController(ITypeRepository _typeRepo)
        {
            typeRepository = _typeRepo;
        }
        public IActionResult List()
        {          
          return View(typeRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {         
          return View();
        }
        [HttpPost]
        public IActionResult Create(Entity.Type entity)
        {
            if (ModelState.IsValid)
            {
                typeRepository.SaveType(entity);
                return RedirectToAction("List");
            }
            return View(entity);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {         
          return View(typeRepository.GetById(id));
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int TypeId)
        {
          typeRepository.DeleteType(TypeId);
          return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
         
          return View(typeRepository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Entity.Type entity)
        {
          if (ModelState.IsValid)
          {
              typeRepository.SaveType(entity);
              return RedirectToAction("List");
          }
          return View(entity);
        }
        public IActionResult Details(int id)
        {
          
          return View(typeRepository.GetById(id));
        }
    }

}