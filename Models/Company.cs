using CustomerDb.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDb.Models
{
    [Table("company")]
    public class Company : IMasterEntity
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string? website { get; set; }
        public string? email { get; set; }
        public string? phone_no { get; set; }
        public string? address { get; set; }
        public int row_status { get; set; } = 1;
        public DateTime created_at { get; set; } = DateTime.Now;
        public string created_by { get; set; } = string.Empty;
        public DateTime? updated_at { get; set; }
        public string? updated_by { get; set; }

        // Navigation Properties
        [ForeignKey("company_id")]
        public virtual ICollection<Contact>? contacts { get; set; }
    }

    public class CompanyRequest
    {
        [Required]
        public string name { get; set; } = string.Empty;
        public string? website { get; set; }
        public string? email { get; set; }
        public string? phone_no { get; set; }
        public string? address { get; set; }
    }

    public class CompanyResponse
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string? website { get; set; }
        public string? email { get; set; }
        public string? phone_no { get; set; }
        public string? address { get; set; }
    }
}
