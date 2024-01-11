using Microsoft.EntityFrameworkCore;
using PizzaCalculator.Domain;

namespace PizzaCalculator.Infrastructure.Persistence
{
    public class PizzaDbContext : DbContext
    {
        public DbSet<PizzaOrder> PizzaOrders { get; set; }
        public DbSet<PizzaSize> PizzaSizes { get; set; }
        public DbSet<PizzaOrderTopping> PizzaOrderToppings { get; set; }
        public DbSet<Topping> Toppings { get; set; }

        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaOrderTopping>()
               .HasKey(pt => pt.PizzaOrderToppingID);

            modelBuilder.Entity<PizzaOrderTopping>()
                .HasOne(pt => pt.PizzaOrder)
                .WithMany(p => p.PizzaOrderToppings)
                .HasForeignKey(pt => pt.PizzaOrderId);

            modelBuilder.Entity<PizzaOrderTopping>()
                .HasOne(pt => pt.Topping)
                .WithMany(t => t.PizzaOrderToppings)
                .HasForeignKey(pt => pt.ToppingId);

            modelBuilder.Entity<PizzaOrder>()
                .HasOne(p => p.PizzaSize)
                .WithMany()
                .HasForeignKey(p => p.PizzaSizeId);

            modelBuilder.Entity<PizzaSize>()
                .Property(p => p.Cost)
                .HasColumnType("decimal(18, 2)"); // Встановлюємо тип стовпця decimal із точністю 18 і 2 знаками після коми

            modelBuilder.Entity<PizzaOrder>()
                .Property(p => p.TotalCost)
                .HasColumnType("decimal(18, 2)"); // Встановлюємо тип стовпця decimal із точністю 18 і 2 знаками після коми

            modelBuilder.Entity<Topping>()
                .Property(t => t.Cost)
                .HasColumnType("decimal(18, 2)"); // Встановлюємо тип стовпця decimal із точністю 18 і 2 знаками після коми

            // Додайте логіку початкового наповнення бази даних, наприклад, додавання розмірів піци
            modelBuilder.Entity<PizzaSize>().HasData(
                new PizzaSize { Id = 1, SizeName = "Small", Cost = 8 },
                new PizzaSize { Id = 2, SizeName = "Medium", Cost = 10 },
                new PizzaSize { Id = 3, SizeName = "Large", Cost = 12 }
            );
        }
    }
}
