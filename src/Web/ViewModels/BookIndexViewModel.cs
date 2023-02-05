using Microsoft.AspNetCore.Mvc.Rendering;

namespace Microsoft.BookStore.Web.ViewModels
{
    public class BookIndexViewModel
    {
        public List<BookItemViewModel>? BookItems { get; set; }

        public List<SelectListItem>? Categories { get; set; }

        public long? CategoryFilterApplied { get; set; }

        public PaginationInfoViewModel? PaginationInfo { get; set; }
    }
}
