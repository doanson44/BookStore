using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.BookStore.Web.Interfaces;
using Microsoft.BookStore.Web.ViewModels;

namespace Microsoft.BookStore.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IBookViewModelService _bookViewModelService;

    public IndexModel(IBookViewModelService bookViewModelService)
    {
        _bookViewModelService = bookViewModelService;
    }

    public BookIndexViewModel BookModel { get; set; } = new BookIndexViewModel();

    public async Task OnGet(BookIndexViewModel bookModel, int? pageId)
    {
        BookModel = await _bookViewModelService.GetBooks(pageId ?? 0, Constants.ITEMS_PER_PAGE, bookModel.CategoryFilterApplied);
    }
}
