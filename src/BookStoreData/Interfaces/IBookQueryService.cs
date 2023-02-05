using BookStoreData.Models;
using System.Threading.Tasks;

namespace BookStoreData.Interfaces
{
    public interface IBookQueryService
    {
        Task<BookDetailsModel> GetBookDetailsAsync(long bookId);
    }
}
