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
    public class StatisticsController : Controller
    {
        private IUserRepository userRepository;
        private IBookRepository bookRepository;
        private ITypeRepository typeRepository;
        public StatisticsController(IUserRepository _userRepo,IBookRepository _bookRepo,ITypeRepository _typeRepo)
        {
            userRepository = _userRepo;
            bookRepository = _bookRepo;
            typeRepository = _typeRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
           var books = bookRepository.GetAll();
          ViewBag.SumPage = books.Sum(x => x.Page);;
          ViewBag.ReadBook = books.Where(x => x.isReaded == true).Count();
          ViewBag.FavBook = books.Where(x => x.isFavorite == true).Count();
          ViewBag.UnReadBook = books.Where(x => x.isReaded == false).Count();
          ViewBag.SpentMoney = books.Where(a => a.isReaded == true).Sum(x => x.Price);
          return View();
        }
       
        public IActionResult PieChart()
        {
           var books = bookRepository.GetAll();
         //PASTA GRAFİĞİ TÜRÜNE GÖRE
          var allCategory = typeRepository.GetAll();
        	List<DataPoint> dataPoints = new List<DataPoint>();

          var readedBook = books.Where(i => i.isReaded==true).Count();

          for (int i = 1; i <= allCategory.Count(); i++)
          { 
            var category = typeRepository.GetById(i);
            int book = books.Where(a => a.isReaded==true).Where(a => a.TypeId == i).Count();
            int rate = 100*book/readedBook;
               dataPoints.Add(new DataPoint(category.Name, rate));
          }  
		    	ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
          //PASTA GRAFİĞİ TÜRÜNE GÖRE SON
          return View();
        }
        public IActionResult MonthChart()
        {
         List<DataPoint> dataPoints = new List<DataPoint>();
          string[] months = new string[] {"January","February","March","April","May","June","July","August","September","October","November","December"};
          DateTime[] date = new DateTime[]
          {
            new DateTime(2020,1,1),
            new DateTime(2020,2,1),
            new DateTime(2020,3,1),
            new DateTime(2020,4,1),
            new DateTime(2020,5,1),
            new DateTime(2020,6,1),
            new DateTime(2020,7,1),
            new DateTime(2020,8,1),
            new DateTime(2020,9,1),
            new DateTime(2020,10,1),
            new DateTime(2020,11,1),
            new DateTime(2020,12,1)
          };
          for (int i = 0; i < 12; i++)
          {
            int piece = bookRepository.GetAll()
              .Where(x => x.isReaded==true)
              .Where(y => y.EndDate.Month==i+1)
              .Count();
            dataPoints.Add(new DataPoint(months[i], piece));
          }       
 
		      ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
          return View();
        }
    }
}