using BookStoreData.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Microsoft.BookStore.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookQueryService _bookQueryService;

        public BooksController(IBookQueryService bookQueryService)
        {
            _bookQueryService = bookQueryService;
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookQueryService.GetBookDetailsAsync(id.Value);

            return View(book);
        }
    }
}
