using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNorthwind.Models
{
    [Table("region")]
    public class Region
    {
        [Key]
        [Column("region_id")]
        public short RegionId { get; set; }

        [Column("region_description")]
        public string RegionDescription { get; set; } = null!;
    }
}