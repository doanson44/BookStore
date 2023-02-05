using Microsoft.EntityFrameworkCore;

namespace ToDoData.Data;

public partial class TodoListDbContext : DbContext
{
    public TodoListDbContext()
    {
    }

    public TodoListDbContext(DbContextOptions<TodoListDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TodoItem__3214EC0797DAB1F2");

            entity.ToTable("TodoItem");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Item)
                .IsRequired()
                .HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
