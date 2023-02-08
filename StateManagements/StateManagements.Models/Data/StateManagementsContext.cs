using Microsoft.EntityFrameworkCore;
using StateManagements.Models.Models;

namespace StateManagements.Models.Data;
public class StateManagementsContext : DbContext
{
    public StateManagementsContext(DbContextOptions options) : base(options) { }

    public virtual DbSet<Category> Categories { get; set; } = null!;
    public virtual DbSet<Product> Products { get; set; } = null!;
    public virtual DbSet<Food> Foods { get; set; } = null!;
}

