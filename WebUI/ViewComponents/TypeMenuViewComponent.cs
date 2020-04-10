using kutuphane.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace kutuphane.WebUI.ViewComponents
{
    public class TypeMenuViewComponent : ViewComponent
    {
        private ITypeRepository _repository;
        public TypeMenuViewComponent(ITypeRepository repo)
        {
            _repository = repo;            
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["id"];
            return View(_repository.GetAll());
        }
    }
}