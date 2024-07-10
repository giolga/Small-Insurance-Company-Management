using System.ComponentModel.DataAnnotations;

namespace Small_Insurance_Company_Management_Program.Models
{
    public class Package
    {
        [Key]
        public int PackageId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
