using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNorthwind.Models
{
    [Table("categories")]
    public class Category
    {
        [Key]
        [Column("category_id")]
        public short CategoryId { get; set; }

        [Column("category_name")]
        public string CategoryName { get; set; } = null!;

        [Column("description")]
        public string? Description { get; set; }

        [Column("picture")]
        public byte[]? Picture { get; set; }
    }
}