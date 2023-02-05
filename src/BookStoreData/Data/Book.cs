using System.Collections.Generic;

namespace BookStoreData.Data;

public partial class Book
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public long CategoryId { get; set; }

    public long PublisherId { get; set; }

    public string ShortDescription { get; set; } = null!;

    public string Description { get; set; }

    public virtual BookCategory Category { get; set; } = null!;

    public virtual Publisher Publisher { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();

    public virtual ICollection<Author> Authors { get; } = new List<Author>();
}
