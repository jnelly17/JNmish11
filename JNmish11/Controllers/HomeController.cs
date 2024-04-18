using JNmish11.Models;
using JNmish11.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JNmish11.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;

        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum, string? bookCat)
        {
            int pageSize = 5;

            var info = new BooksListViewModel
            {
                Books = _repo.Books
                .Where(x => x.Category == bookCat || bookCat == null)
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = bookCat == null ? _repo.Books.Count() : _repo.Books.Where(x => x.Category == bookCat).Count()
                },

                CurrentBookCat = bookCat
            };

            return View(info);
        }

    }
}
