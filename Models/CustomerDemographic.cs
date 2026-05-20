using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNorthwind.Models
{
    [Table("customer_demographics")]
    public class CustomerDemographic
    {
        [Key]
        [Column("customer_type_id")]
        public string CustomerTypeId { get; set; } = null!;

        [Column("customer_desc")]
        public string? CustomerDesc { get; set; }
    }
}