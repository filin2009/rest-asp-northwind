using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNorthwind.Models
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public short EmployeeId { get; set; }

        [Column("last_name")]
        public string LastName { get; set; } = null!;

        [Column("first_name")]
        public string FirstName { get; set; } = null!;

        [Column("title")]
        public string? Title { get; set; }

        [Column("title_of_courtesy")]
        public string? TitleOfCourtesy { get; set; }

        [Column("birth_date")]
        public DateTime? BirthDate { get; set; }

        [Column("hire_date")]
        public DateTime? HireDate { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("city")]
        public string? City { get; set; }

        [Column("region")]
        public string? Region { get; set; }

        [Column("postal_code")]
        public string? PostalCode { get; set; }

        [Column("country")]
        public string? Country { get; set; }

        [Column("home_phone")]
        public string? HomePhone { get; set; }

        [Column("extension")]
        public string? Extension { get; set; }

        [Column("photo")]
        public byte[]? Photo { get; set; }

        [Column("notes")]
        public string? Notes { get; set; }

        [Column("reports_to")]
        public short? ReportsTo { get; set; }

        [Column("photo_path")]
        public string? PhotoPath { get; set; }
    }
}