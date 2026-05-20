using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNorthwind.Models
{
    [Table("employee_territories")]
    public class EmployeeTerritory
    {
        [Column("employee_id")]
        public short EmployeeId { get; set; }

        [Column("territory_id")]
        public string TerritoryId { get; set; } = null!;
    }
}