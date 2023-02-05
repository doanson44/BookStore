using Ardalis.Specification;
using BookStoreData.Data;

namespace BookStoreData.Specifications
{
    public class BookFilterPaginatedSpecification : Specification<Book>
    {
        public BookFilterPaginatedSpecification(int skip, int take, long? categoryId)
            : base()
        {
            if (take == 0)
            {
                take = int.MaxValue;
            }

            Query
                .Where(i => !categoryId.HasValue || i.CategoryId == categoryId)
                .Skip(skip).Take(take);
        }
    }
}
