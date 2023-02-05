using System.Collections.Generic;

namespace BookStoreData.Data;

public partial class BookCategory
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; } = new List<Book>();
}
