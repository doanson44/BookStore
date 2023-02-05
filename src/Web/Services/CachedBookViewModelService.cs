using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.BookStore.Web.Extensions;
using Microsoft.BookStore.Web.Interfaces;
using Microsoft.BookStore.Web.ViewModels;
using Microsoft.Extensions.Caching.Memory;

namespace Microsoft.BookStore.Web.Services
{
    public class CachedBookViewModelService : IBookViewModelService
    {
        private readonly IMemoryCache _cache;
        private readonly BookViewModelService _bookViewModelService;

        public CachedBookViewModelService(IMemoryCache cache, BookViewModelService bookViewModelService)
        {
            _cache = cache;
            _bookViewModelService = bookViewModelService;
        }

        public async Task<BookIndexViewModel> GetBooks(int pageIndex, int itemsPage, long? categoryId)
        {
            var cacheKey = CacheHelpers.GenerateBookItemCacheKey(pageIndex, Constants.ITEMS_PER_PAGE, categoryId);

            return await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.SlidingExpiration = CacheHelpers.DefaultCacheDuration;
                return await _bookViewModelService.GetBooks(pageIndex, itemsPage, categoryId);
            });
        }

        public async Task<IEnumerable<SelectListItem>> GetCategories()
        {
            return await _cache.GetOrCreateAsync(CacheHelpers.GenerateTypesCacheKey(), async entry =>
            {
                entry.SlidingExpiration = CacheHelpers.DefaultCacheDuration;
                return await _bookViewModelService.GetCategories();
            });
        }
    }
}
