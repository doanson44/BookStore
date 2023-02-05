namespace BookStoreData.Data;

public partial class Review
{
    public long Id { get; set; }

    public string ReviewText { get; set; } = null!;

    public long BookId { get; set; }

    public virtual Book Book { get; set; } = null!;
}
