using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNorthwind.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public short ProductId { get; set; }

        [Column("product_name")]
        public string ProductName { get; set; } = null!;

        [Column("supplier_id")]
        public short? SupplierId { get; set; }

        [Column("category_id")]
        public short? CategoryId { get; set; }

        [Column("quantity_per_unit")]
        public string? QuantityPerUnit { get; set; }

        [Column("unit_price")]
        public float? UnitPrice { get; set; }

        [Column("units_in_stock")]
        public short? UnitsInStock { get; set; }

        [Column("units_on_order")]
        public short? UnitsOnOrder { get; set; }

        [Column("reorder_level")]
        public short? ReorderLevel { get; set; }

        [Column("discontinued")]
        public int Discontinued { get; set; }
    }
}