using BookStoreData.Data;
using BookStoreData.Specifications;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.BookStore.ApplicationCore.Interfaces;
using Microsoft.BookStore.Web.Interfaces;
using Microsoft.BookStore.Web.ViewModels;
using ToDoData.Data;

namespace Microsoft.BookStore.Web.Services
{
    public class BookViewModelService : IBookViewModelService
    {
        private readonly ILogger<BookViewModelService> _logger;
        private readonly IRepository<Book, BookStoreContext> _bookRepository;
        private readonly IRepository<BookCategory, BookStoreContext> _categoryRepository;
        private readonly IRepository<TodoItem, TodoListDbContext> _todoItemRepository;

        public BookViewModelService(ILogger<BookViewModelService> logger, IRepository<Book, BookStoreContext> bookRepository, IRepository<BookCategory, BookStoreContext> categoryRepository, IRepository<TodoItem, TodoListDbContext> todoItemRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _todoItemRepository = todoItemRepository;
        }

        public async Task<BookIndexViewModel> GetBooks(int pageIndex, int itemsPage, long? categoryId)
        {
            _logger.LogInformation("GetBooks called.");
            var todoItems = await _todoItemRepository.ListAsync();

            var filterSpecification = new BookFilterSpecification(categoryId);
            var filterPaginatedSpecification =
                new BookFilterPaginatedSpecification(itemsPage * pageIndex, itemsPage, categoryId);

            // the implementation below using ForEach and Count. We need a List.
            var itemsOnPage = await _bookRepository.ListAsync(filterPaginatedSpecification);
            var totalItems = await _bookRepository.CountAsync(filterSpecification);

            var vm = new BookIndexViewModel
            {
                BookItems = itemsOnPage.Select(i => new BookItemViewModel
                {
                    Id = i.Id,
                    Title = i.Title,
                    Description = i.ShortDescription
                }).ToList(),
                Categories = (await GetCategories()).ToList(),
                PaginationInfo = new PaginationInfoViewModel()
                {
                    ActualPage = pageIndex,
                    ItemsPerPage = itemsOnPage.Count,
                    TotalItems = totalItems,
                    TotalPages = int.Parse(Math.Ceiling(((decimal)totalItems / itemsPage)).ToString())
                }
            };

            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

            return vm;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategories()
        {
            _logger.LogInformation("GetCategories called.");
            var category = await _categoryRepository.ListAsync();

            var items = category
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(b => b.Text)
                .ToList();

            var allItem = new SelectListItem() { Value = null, Text = "All", Selected = true };
            items.Insert(0, allItem);

            return items;
        }
    }
}
