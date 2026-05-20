using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNorthwind.Models
{
    [Table("shippers")]
    public class Shipper
    {
        [Key]
        [Column("shipper_id")]
        public short ShipperId { get; set; }

        [Column("company_name")]
        public string CompanyName { get; set; } = null!;

        [Column("phone")]
        public string? Phone { get; set; }
    }
}