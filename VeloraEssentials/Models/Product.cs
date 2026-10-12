using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeloraEssentials.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Product Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required, StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [Range(0.01, 100000)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Range(0, 100000)]
        [Display(Name = "Stock Quantity")]
        public int StockQuantity { get; set; }

        [StringLength(300)]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;
    }
}
