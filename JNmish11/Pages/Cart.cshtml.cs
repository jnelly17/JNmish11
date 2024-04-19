using JNmish11.Infrastructure;
using JNmish11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JNmish11.Pages
{
    public class AddCartModel : PageModel
    {
        private IBookRepository _repo;
        public Cart? Cart { get; set; }
        public AddCartModel(IBookRepository temp, Cart cartService)
        {
            _repo = temp;
            Cart = cartService;
        }


        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book book = _repo.Books
                .FirstOrDefault(x => x.BookId == bookId);

            if (book != null)
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(book, 1);
                //HttpContext.Session.SetJson("cart", Cart);
            }

            return RedirectToPage (new {returnUrl = ReturnUrl});
            
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage (new {returnUrl = returnUrl});
        }
    }
}
