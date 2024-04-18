using JNmish11.Models;
using Microsoft.AspNetCore.Mvc;

namespace JNmish11.Components
{
    public class ProjectTypesViewComponent : ViewComponent
    {
        private IBookRepository _bookRepo;
        public ProjectTypesViewComponent(IBookRepository temp)
        {
            _bookRepo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCat"];

            var BookCategory = _bookRepo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(BookCategory);
        }
    }
}
