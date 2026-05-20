using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNorthwind.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("order_id")]
        public short OrderId { get; set; }

        [Column("customer_id")]
        public string? CustomerId { get; set; }

        [Column("employee_id")]
        public short? EmployeeId { get; set; }

        [Column("order_date")]
        public DateTime? OrderDate { get; set; }

        [Column("required_date")]
        public DateTime? RequiredDate { get; set; }

        [Column("shipped_date")]
        public DateTime? ShippedDate { get; set; }

        [Column("ship_via")]
        public short? ShipVia { get; set; }

        [Column("freight")]
        public float? Freight { get; set; }

        [Column("ship_name")]
        public string? ShipName { get; set; }

        [Column("ship_address")]
        public string? ShipAddress { get; set; }

        [Column("ship_city")]
        public string? ShipCity { get; set; }

        [Column("ship_region")]
        public string? ShipRegion { get; set; }

        [Column("ship_postal_code")]
        public string? ShipPostalCode { get; set; }

        [Column("ship_country")]
        public string? ShipCountry { get; set; }
    }
}