using System.ComponentModel.DataAnnotations;

namespace Small_Insurance_Company_Management_Program.Models
{
    public class AuthorizedUser
    {
        [Key]
        public int AuthorizedId { get; set; }
        [Required]
        public string AuthorizedName { get; set; }
        public ICollection<InsuranceProduct> InsuranceProducts { get; set; }
    }
}
