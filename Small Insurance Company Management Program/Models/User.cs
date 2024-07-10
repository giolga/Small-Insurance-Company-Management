using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Small_Insurance_Company_Management_Program.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserLastName { get; set; }
        public int InsuranceId { get; set; }
        public ICollection<InsuranceProduct> InsuranceProducts { get; set; }
    }
}
