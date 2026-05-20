using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNorthwind.Models
{
    [Table("customer_customer_demo")]
    public class CustomerCustomerDemo
    {
        [Column("customer_id")]
        public string CustomerId { get; set; } = null!;

        [Column("customer_type_id")]
        public string CustomerTypeId { get; set; } = null!;
    }
}