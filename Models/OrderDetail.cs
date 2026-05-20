using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNorthwind.Models
{
    [Table("order_details")]
    public class OrderDetail
    {
        [Column("order_id")]
        public short OrderId { get; set; }

        [Column("product_id")]
        public short ProductId { get; set; }

        [Column("unit_price")]
        public float UnitPrice { get; set; }

        [Column("quantity")]
        public short Quantity { get; set; }

        [Column("discount")]
        public float Discount { get; set; }
    }
}