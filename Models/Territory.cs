using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNorthwind.Models
{
    [Table("territories")]
    public class Territory
    {
        [Key]
        [Column("territory_id")]
        public string TerritoryId { get; set; } = null!;

        [Column("territory_description")]
        public string TerritoryDescription { get; set; } = null!;

        [Column("region_id")]
        public short RegionId { get; set; }
    }
}