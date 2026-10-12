using VeloraEssentials.Models;

namespace VeloraEssentials.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext db)
        {
            if (db.Products.Any()) return;

            db.Products.AddRange(
                new Product { Name = "Organic Cotton Pads (Regular)", Category = "Pads", Description = "Soft, breathable cotton pads for everyday comfort.", Price = 199, StockQuantity = 50 },
                new Product { Name = "Organic Cotton Pads (Night)", Category = "Pads", Description = "Extra-long pads for overnight protection.", Price = 249, StockQuantity = 40 },
                new Product { Name = "Menstrual Cup", Category = "Cups", Description = "Reusable medical-grade silicone cup.", Price = 399, StockQuantity = 25 },
                new Product { Name = "Panty Liners", Category = "Liners", Description = "Thin daily liners for light days.", Price = 99, StockQuantity = 80 },
                new Product { Name = "Heat Patch", Category = "Comfort", Description = "Adhesive warming patch for cramp relief.", Price = 149, StockQuantity = 30 }
            );
            db.SaveChanges();
        }
    }
}
