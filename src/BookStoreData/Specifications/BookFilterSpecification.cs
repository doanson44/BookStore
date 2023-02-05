using Ardalis.Specification;
using BookStoreData.Data;

namespace BookStoreData.Specifications
{
    public class BookFilterSpecification : Specification<Book>
    {
        public BookFilterSpecification(long? categoryd)
        {
            Query.Where(i => (!categoryd.HasValue || i.CategoryId == categoryd));
        }
    }
}
