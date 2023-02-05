using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.BookStore.Web.ViewModels;

namespace Microsoft.BookStore.Web.Interfaces
{
    public interface IBookViewModelService
    {
        Task<BookIndexViewModel> GetBooks(int pageIndex, int itemsPage, long? categoryId);

        Task<IEnumerable<SelectListItem>> GetCategories();
    }
}
