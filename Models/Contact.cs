﻿using CustomerDb.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDb.Models
{
    [Table("contact")]
    public class Contact : IMasterEntity
    {
        public int id { get; set; }
        public int company_id { get; set; }
        public string name { get; set; } = string.Empty;
        public string phone_no { get; set; } = string.Empty;
        public string? email { get; set; }
        public string? job_title { get; set; }
        public int row_status { get; set; } = 1;
        public DateTime created_at { get; set; } = DateTime.Now;
        public string created_by { get; set; } = string.Empty;
        public DateTime? updated_at { get; set; }
        public string? updated_by { get; set; }

        // Navigation Properties
        public virtual Company? company { get; set; }
    }

    public class ContactRequest
    {
        [Required]
        public int company_id { get; set; }
        [Required]
        public string name { get; set; } = string.Empty;
        [Required]
        public string phone_no { get; set; } = string.Empty;
        public string? email { get; set; }
        public string? job_title { get; set; }
    }

    public class ContactResponse
    {
        public int id { get; set; }
        public int company_id { get; set; }
        public string name { get; set; } = string.Empty;
        public string phone_no { get; set; } = string.Empty;
        public string? email { get; set; }
        public string? job_title { get; set; }
        public string company_name { get; set; } = string.Empty;
        public string? company_website { get; set; }
        public string? company_email { get; set; }
        public string? company_phone_no { get; set; }
        public string? company_address { get; set; }
    }
}
