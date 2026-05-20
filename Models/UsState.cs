using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNorthwind.Models
{
    [Table("us_states")]
    public class UsState
    {
        [Key]
        [Column("state_id")]
        public short StateId { get; set; }

        [Column("state_name")]
        public string? StateName { get; set; }

        [Column("state_abbr")]
        public string? StateAbbr { get; set; }

        [Column("state_region")]
        public string? StateRegion { get; set; }
    }
}