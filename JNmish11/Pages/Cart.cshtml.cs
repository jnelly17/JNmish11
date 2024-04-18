using JNmish11.Infrastructure;
using JNmish11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JNmish11.Pages
{
    public class AddCartModel : PageModel
    {
        private IBookRepository _repo;
        public AddCartModel(IBookRepository temp)
        {
            _repo = temp;
        }

        public Cart? Cart { get; set; }
        public void OnGet()
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public void OnPost(int bookId)
        {
            Book book = _repo.Books
                .FirstOrDefault(x => x.BookId == bookId);

            if (book != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            }

            Cart.AddItem(book, 1);

            HttpContext.Session.SetJson("cart", Cart);
        }
    }
}
